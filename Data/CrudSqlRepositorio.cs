namespace Utilitarios.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.Data;
    using System.Linq.Expressions;
    using System.Text.Json;
    using Utilitarios.Contracts;
    using Utilitarios.Entities;

    /// <summary>
    /// Implementación genérica de operaciones CRUD con Entity Framework Core.
    /// Incluye soporte para consultas dinámicas y procedimientos almacenados.
    /// </summary>
    /// <typeparam name="T">Entidad que hereda de <see cref="EntidadBase"/>.</typeparam>
    public class CrudSqlRepositorio<T> : ICrudSqlRepositorio<T> where T : EntidadBase
    {
        #region Variables

        /// <summary>Representa el DbSet asociado a la entidad.</summary>
        protected readonly DbSet<T> _entidad;

        /// <summary>Contexto de base de datos de Entity Framework.</summary>
        protected readonly DbContext _contexto;

        #endregion

        #region Constructor

        /// <summary>Inicializa una nueva instancia del repositorio CRUD genérico.</summary>
        /// <param name="contexto">Contexto de base de datos inyectado.</param>
        public CrudSqlRepositorio(DbContext contexto)
        {
            _entidad = contexto.Set<T>();
            _contexto = contexto;
        }

        #endregion

        #region Consultas

        /// <inheritdoc />
        public async Task<T?> ConsultarPorIdAsync<TKey>(TKey id) where TKey : struct
        {
            return await _entidad.FindAsync(id);
        }

        /// <inheritdoc />
        public async Task<T?> ConsultarUnoAsync(Expression<Func<T, bool>> filtro)
        {
            return await _entidad.AsNoTracking().FirstOrDefaultAsync(filtro);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> ConsultarTodosAsync()
        {
            return await _entidad.AsNoTracking().ToListAsync();

        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> ConsultarListaAsync(Expression<Func<T, bool>> filtro)
        {
            return await _entidad.AsNoTracking().Where(filtro).ToListAsync();
        }

        /// <inheritdoc />
        public async Task<bool> ExisteAsync(Expression<Func<T, bool>> filtro)
        {
            return await _entidad.AnyAsync(filtro);
        }

        /// <inheritdoc />
        public async Task<int> ContarAsync(Expression<Func<T, bool>> filtro)
        {
            return await _entidad.CountAsync(filtro);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> ConsultarStoreProcedureAsync<T>(
            string procedure, object[] variables, object[] parameters)
        {
            var dataSetResultado = new DataSet();
            List<T> lista = new();

            var connection = _contexto.Database.GetDbConnection();
            try
            {
                await _contexto.Database.OpenConnectionAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedure;

                    if (variables != null)
                    {
                        for (int i = 0; i < variables.Length; i++)
                        {
                            var p = command.CreateParameter();
                            p.ParameterName = variables[i].ToString();
                            p.Value = parameters[i] ?? DBNull.Value;
                            command.Parameters.Add(p);
                        }
                    }

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        do
                        {
                            var table = new DataTable();
                            table.Load(reader);
                            dataSetResultado.Tables.Add(table);
                        } while (!reader.IsClosed);
                    }
                }
            }
            finally
            {
                _contexto.Database.CloseConnection();
            }

            foreach (DataTable dt in dataSetResultado.Tables)
            {
                var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();
                var properties = typeof(T).GetProperties();

                var resultado = dt.AsEnumerable().Select(row =>
                {
                    var objT = Activator.CreateInstance<T>();

                    foreach (var prop in properties)
                    {
                        if (columnNames.Contains(prop.Name))
                        {
                            object value = row[prop.Name];
                            if (value == DBNull.Value) continue;

                            // Si la propiedad es una lista y el valor es string JSON
                            if (prop.PropertyType.IsGenericType &&
                                prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>) &&
                                value is string jsonString)
                            {
                                var itemType = prop.PropertyType.GetGenericArguments()[0];
                                var listValue = JsonSerializer.Deserialize(jsonString, typeof(List<>).MakeGenericType(itemType));
                                prop.SetValue(objT, listValue);
                            }
                            else
                            {
                                prop.SetValue(objT, value);
                            }
                        }
                    }

                    return objT;
                }).ToList();

                lista.AddRange(resultado);
            }

            return lista;
        }

        #endregion

        #region Adición

        /// <inheritdoc />
        public async Task<T> AdicionarAsync(T entidad)
        {
            await _entidad.AddAsync(entidad);
            return entidad;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> AdicionarMasivoAsync(IEnumerable<T> entidades)
        {
            await _entidad.AddRangeAsync(entidades);
            return entidades;
        }

        #endregion

        #region Actualización

        /// <inheritdoc />
        public async Task ActualizarAsync(T entidad)
        {
            EntityEntry entry = _contexto.Entry(entidad);
            entry.State = EntityState.Modified;
            await Task.CompletedTask;
        }

        /// <inheritdoc />
        public async Task ActualizarMasivoAsync(IEnumerable<T> entidades)
        {
            _entidad.UpdateRange(entidades);
            await Task.CompletedTask;
        }

        #endregion

        #region Eliminación

        /// <inheritdoc />
        public async Task EliminarPorIdAsync<TKey>(TKey id) where TKey : struct
        {
            var entidad = await ConsultarPorIdAsync(id);
            if (entidad != null)
            {
                _entidad.Remove(entidad);
            }
        }

        /// <inheritdoc />
        public async Task EliminarAsync(T entidad)
        {
            _entidad.Remove(entidad);
            await Task.CompletedTask;
        }

        /// <inheritdoc />
        public async Task EliminarMasivoAsync(IEnumerable<T> entidades)
        {
            _entidad.RemoveRange(entidades);
            await Task.CompletedTask;
        }

        #endregion
    }
}
