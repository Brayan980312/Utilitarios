namespace Utilitarios.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.Data;
    using System.Linq.Expressions;
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
        public async Task<IEnumerable<TResult>> ConsultarStoreProcedureAsync<TResult>(
            string procedure, IDictionary<string, object> parametros)
        {
            var lista = new List<TResult>();

            using var cnn = _contexto.Database.GetDbConnection();
            using var cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedure;

            if (parametros != null)
            {
                foreach (var kvp in parametros)
                {
                    var p = cmd.CreateParameter();
                    p.ParameterName = kvp.Key;
                    p.Value = kvp.Value ?? DBNull.Value;
                    cmd.Parameters.Add(p);
                }
            }

            await cnn.OpenAsync();

            using var reader = await cmd.ExecuteReaderAsync();
            var dt = new DataTable();
            dt.Load(reader);

            var propiedades = typeof(TResult).GetProperties();
            var columnas = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();

            lista.AddRange(
                dt.AsEnumerable().Select(row =>
                {
                    var obj = Activator.CreateInstance<TResult>();
                    foreach (var prop in propiedades)
                    {
                        if (columnas.Contains(prop.Name))
                        {
                            var valor = row[prop.Name];
                            prop.SetValue(obj, valor == DBNull.Value ? null : valor);
                        }
                    }
                    return obj;
                })
            );

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
