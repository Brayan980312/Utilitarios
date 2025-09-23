using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Contracts
{
    using System.Linq.Expressions;
    using Utilitarios.Entities;

    /// <summary>
    /// Define la interfaz genérica para operaciones CRUD sobre una entidad de base de datos.
    /// Incluye soporte para consultas directas, procedimientos almacenados y operaciones masivas.
    /// </summary>
    /// <typeparam name="T">Entidad de dominio que hereda de <see cref="EntidadBase"/>.</typeparam>
    public interface ICrudSqlRepositorio<T> where T : EntidadBase
    {
        #region Consultas

        /// <summary>
        /// Obtiene una entidad a partir de su identificador único.
        /// </summary>
        /// <typeparam name="TKey">Tipo de clave primaria (int, long, Guid, etc.).</typeparam>
        /// <param name="id">Identificador de la entidad.</param>
        /// <returns>Entidad encontrada o <c>null</c> si no existe.</returns>
        Task<T?> ConsultarPorIdAsync<TKey>(TKey id) where TKey : struct;

        /// <summary>
        /// Obtiene la primera entidad que cumpla con un filtro de búsqueda.
        /// </summary>
        /// <param name="filtro">Expresión lambda que define la condición.</param>
        /// <returns>Entidad encontrada o <c>null</c> si no existe.</returns>
        Task<T?> ConsultarUnoAsync(Expression<Func<T, bool>> filtro);

        /// <summary>
        /// Obtiene todas las entidades registradas.
        /// </summary>
        /// <returns>Lista de todas las entidades.</returns>
        Task<IEnumerable<T>> ConsultarTodosAsync();

        /// <summary>
        /// Obtiene todas las entidades que cumplan con un filtro de búsqueda.
        /// </summary>
        /// <param name="filtro">Expresión lambda que define la condición.</param>
        /// <returns>Lista de entidades encontradas.</returns>
        Task<IEnumerable<T>> ConsultarListaAsync(Expression<Func<T, bool>> filtro);

        /// <summary>
        /// Ejecuta un procedimiento almacenado con múltiples parámetros y retorna resultados tipados.
        /// </summary>
        /// <typeparam name="TResult">Tipo de entidad de resultado esperado.</typeparam>
        /// <param name="procedure">Nombre del procedimiento almacenado.</param>
        /// <param name="parametros">Diccionario con nombre y valor de parámetros.</param>
        /// <returns>Lista de resultados según el tipo indicado.</returns>
        Task<IEnumerable<TResult>> ConsultarStoreProcedureAsync<TResult>(string procedure, IDictionary<string, object> parametros);

        /// <summary>
        /// Verifica si existe al menos un registro que cumpla con un filtro.
        /// </summary>
        Task<bool> ExisteAsync(Expression<Func<T, bool>> filtro);

        /// <summary>
        /// Obtiene el número de registros que cumplen con un filtro.
        /// </summary>
        Task<int> ContarAsync(Expression<Func<T, bool>> filtro);

        #endregion

        #region Adición

        /// <summary>
        /// Inserta un nuevo registro en la entidad.
        /// </summary>
        Task<T> AdicionarAsync(T entidad);

        /// <summary>
        /// Inserta múltiples registros de manera masiva.
        /// </summary>
        Task<IEnumerable<T>> AdicionarMasivoAsync(IEnumerable<T> entidades);

        #endregion

        #region Actualización

        /// <summary>
        /// Actualiza un registro existente en la entidad.
        /// </summary>
        Task ActualizarAsync(T entidad);

        /// <summary>
        /// Actualiza múltiples registros de manera masiva.
        /// </summary>
        Task ActualizarMasivoAsync(IEnumerable<T> entidades);

        #endregion

        #region Eliminación

        /// <summary>
        /// Elimina un registro por su identificador único.
        /// </summary>
        Task EliminarPorIdAsync<TKey>(TKey id) where TKey : struct;

        /// <summary>
        /// Elimina un registro existente en la entidad.
        /// </summary>
        Task EliminarAsync(T entidad);

        /// <summary>
        /// Elimina múltiples registros de manera masiva.
        /// </summary>
        Task EliminarMasivoAsync(IEnumerable<T> entidades);

        #endregion
    }

}
