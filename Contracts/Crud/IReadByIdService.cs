namespace Utilitarios.Contracts.Crud
{
    /// <summary>Define la operación de consulta por identificador único (Read by Id).</summary>
    /// <typeparam name="T">Tipo de la entidad sobre la que se opera.</typeparam>
    public interface IReadByIdService<T>
    {
        /// <summary>Consulta una entidad específica por su identificador único.</summary>
        /// <param name="id">Identificador único de la entidad.</param>
        /// <returns>La entidad encontrada o <c>null</c> si no existe.</returns>
        Task<T?> GetByIdAsync(int id);
    }
}
