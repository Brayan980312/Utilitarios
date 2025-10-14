namespace Utilitarios.Contracts.Crud
{
    /// <summary>Define la operación de consulta con parametros de todas las entidades (Read All With Params).</summary>
    /// <typeparam name="TIn">Tipo de datos de entrada (DTO o parámetros de busqueda).</typeparam>
    /// <typeparam name="TOut">Tipo de datos de salida (Resultado de la entidad consultada).</typeparam>
    public interface IReadWithParamsService<TIn, TOut>
    {
        /// <summary>Consulta la entidad bajo parametros de busqueda.</summary>
        /// <param name="entity">Datos de entrada necesarios para consultar la entidad.</param>
        /// <returns>Lista de datos encontrados.</returns>
        Task<TOut> GetWithParamsAsync(TIn entity, int? userId = null);
    }
}
