using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Contracts
{
    using System.Linq.Expressions;
    using Utilitarios.Entities;

    /// <summary>Define la interfaz genérica para operaciones CRUD sobre una entidad de base de datos.
    /// Incluye soporte para consultas directas, procedimientos almacenados y operaciones masivas.
    /// </summary>
    /// <typeparam name="T">Entidad de dominio que hereda de <see cref="EntidadBase"/>.</typeparam>
    public interface ICrudSqlRepositorio<T> where T : EntidadBase
    {
        #region Consultas

        /// <summary>Obtiene una entidad a partir de su identificador único.</summary>
        /// <typeparam name="TKey">Tipo de clave primaria (int, long, Guid, etc.).</typeparam>
        /// <param name="id">Identificador de la entidad.</param>
        /// <returns>Entidad encontrada o <c>null</c> si no existe.</returns>
        Task<T?> ConsultarPorIdAsync<TKey>(TKey id) where TKey : struct;

        /// <summary>Obtiene la primera entidad que cumpla con un filtro de búsqueda.</summary>
        /// <param name="filtro">Expresión lambda que define la condición.</param>
        /// <returns>Entidad encontrada o <c>null</c> si no existe.</returns>
        Task<T?> ConsultarUnoAsync(Expression<Func<T, bool>> filtro);

        /// <summary>Obtiene todas las entidades registradas.</summary>
        /// <returns>Lista de todas las entidades.</returns>
        Task<IEnumerable<T>> ConsultarTodosAsync();

        /// <summary>Obtiene todas las entidades que cumplan con un filtro de búsqueda.</summary>
        /// <param name="filtro">Expresión lambda que define la condición.</param>
        /// <returns>Lista de entidades encontradas.</returns>
        Task<IEnumerable<T>> ConsultarListaAsync(Expression<Func<T, bool>> filtro);

        /// <summary>Metodo para consultar procedimiento almacenado multiparametro enviando un tipo T entidad de resultado.</summary>
        /// <param name="procedure">Nombre del procedimiento.</param>
        /// <param name="variables">Nombre parametro.</param>
        /// <param name="parameters">Valor parametro.</param>
        /// <returns>Lista de registro segun entidad T transferida.</returns>
        Task<IEnumerable<T>> ConsultarStoreProcedureAsync<T>(string procedure, object[] variables, object[] parameters);

        /// <summary>Verifica de manera asíncrona si existe al menos un registro en la entidad que cumpla con la condición especificada en el filtro.</summary>
        /// <param name="filtro">Expresión lambda que define la condición a evaluar sobre la entidad.</param>
        /// <returns>Devuelve <c>true</c> si existe al menos un registro que cumpla la condición; de lo contrario, <c>false</c>.</returns>
        Task<bool> ExisteAsync(Expression<Func<T, bool>> filtro);

        /// <summary>Obtiene de manera asíncrona el número total de registros en la entidad que cumplen con la condición especificada en el filtro.</summary>
        /// <param name="filtro">Expresión lambda que define la condición a evaluar sobre la entidad.</param>
        /// <returns>Número de registros que cumplen con la condición especificada.</returns>
        Task<int> ContarAsync(Expression<Func<T, bool>> filtro);

        #endregion

        #region Adición

        /// <summary>Inserta de manera asíncrona un nuevo registro en la entidad.</summary>
        /// <param name="entidad">Instancia de la entidad a insertar.</param>
        /// <returns>La entidad insertada, incluyendo los valores generados automáticamente (por ejemplo, su identificador).</returns>
        Task<T> AdicionarAsync(T entidad);

        /// <summary>Inserta de manera asíncrona múltiples registros en la entidad.</summary>
        /// <param name="entidades">Colección de entidades a insertar.</param>
        /// <returns>La colección de entidades insertadas.</returns>
        Task<IEnumerable<T>> AdicionarMasivoAsync(IEnumerable<T> entidades);

        #endregion

        #region Actualización

        /// <summary>Actualiza de manera asíncrona un registro existente en la entidad.</summary>
        /// <param name="entidad">Instancia de la entidad a actualizar.</param>
        /// <returns>Tarea que representa la operación asíncrona.</returns>
        Task ActualizarAsync(T entidad);

        /// <summary>Actualiza de manera asíncrona múltiples registros existentes en la entidad.</summary>
        /// <param name="entidades">Colección de entidades a actualizar.</param>
        /// <returns>Tarea que representa la operación asíncrona.</returns>
        Task ActualizarMasivoAsync(IEnumerable<T> entidades);

        #endregion

        #region Eliminación

        /// <summary>Elimina de manera asíncrona un registro en la entidad según su identificador único.</summary>
        /// <typeparam name="TKey">Tipo del identificador único de la entidad (por ejemplo, int, Guid, long).</typeparam>
        /// <param name="id">Valor del identificador único que corresponde al registro a eliminar.</param>
        /// <returns>Tarea que representa la operación asíncrona.</returns>
        Task EliminarPorIdAsync<TKey>(TKey id) where TKey : struct;

        /// <summary>Elimina de manera asíncrona un registro existente en la entidad.</summary>
        /// <param name="entidad">Instancia de la entidad a eliminar.</param>
        /// <returns>Tarea que representa la operación asíncrona.</returns>
        Task EliminarAsync(T entidad);

        /// <summary>Elimina de manera asíncrona múltiples registros existentes en la entidad.</summary>
        /// <param name="entidades">Colección de entidades a eliminar.</param>
        /// <returns>Tarea que representa la operación asíncrona.</returns>
        Task EliminarMasivoAsync(IEnumerable<T> entidades);

        #endregion
    }

}
