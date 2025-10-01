namespace Utilitarios.Contracts.Crud
{
    /// <summary>Define la operación de creación (Create) para una entidad.</summary>
    /// <typeparam name="TIn">Tipo de datos de entrada (DTO o parámetros de creación).</typeparam>
    /// <typeparam name="TOut">Tipo de datos de salida (Entidad creada o DTO resultante).</typeparam>
    public interface ICreateService<TIn, TOut>
    {
        /// <summary>Crea una nueva entidad en el sistema.</summary>
        /// <param name="entity">Datos de entrada necesarios para crear la entidad.</param>
        /// <returns>Entidad o DTO resultante después de la creación.</returns>
        Task<TOut> CreateAsync(TIn entity);
    }
}
