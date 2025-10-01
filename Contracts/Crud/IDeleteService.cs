namespace Utilitarios.Contracts.Crud
{
    /// <summary>Define la operación de eliminación (Delete) para una entidad.</summary>
    /// <typeparam name="T">Tipo de la entidad sobre la que se opera.</typeparam>
    public interface IDeleteService<T>
    {
        /// <summary>Elimina una entidad del sistema usando su identificador único.</summary>
        /// <param name="id">Identificador único de la entidad a eliminar.</param>
        Task DeleteAsync(int id);
    }
}
