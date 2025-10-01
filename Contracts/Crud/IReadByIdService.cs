namespace Utilitarios.Contracts.Crud
{
    /// <summary>Define la operación de consulta por identificador único (Read by Id).</summary>
    /// <typeparam name="TOut">Tipo de datos de salida (Entidad o DTO resultante).</typeparam>
    /// <typeparam name="TId">Tipo del identificador único utilizado para buscar la entidad (por ejemplo, Guid o int).</typeparam>
    public interface IReadByIdService<TOut, TId>
    {
        /// <summary>Consulta una entidad específica por su identificador único.</summary>
        /// <param name="id">Identificador único de la entidad.</param>
        /// <returns>La entidad encontrada o <c>null</c> si no existe.</returns>
        Task<TOut?> GetByIdAsync(TId id);
    }
}
