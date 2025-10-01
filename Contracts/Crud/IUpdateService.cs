namespace Utilitarios.Contracts.Crud
{
    /// <summary>Define la operación de actualización (Update) para una entidad.</summary>
    /// <typeparam name="T">Tipo de la entidad sobre la que se opera.</typeparam>
    public interface IUpdateService<T>
    {
        /// <summary>Actualiza una entidad existente en el sistema.</summary>
        /// <param name="entity">Entidad con los nuevos valores.</param>
        /// <returns>Entidad actualizada.</returns>
        Task<T> UpdateAsync(T entity);
    }
}
