namespace Utilitarios.Contracts.Crud
{
    /// <summary>Define la operación de eliminación (Delete) para una entidad.</summary>
    /// <typeparam name="TId">Tipo del identificador único utilizado para eliminar la entidad (por ejemplo, Guid o int).</typeparam>
    public interface IDeleteService<TId>
    {
        /// <summary>Elimina una entidad existente a partir de su identificador único.</summary>
        /// <param name="id">Identificador de la entidad a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa; False en caso contrario.</returns>
        Task<bool> DeleteAsync(TId id);
    }
}
