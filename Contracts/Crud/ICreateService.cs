namespace Utilitarios.Contracts.Crud
{
    /// <summary>Define la operación de creación (Create) para una entidad.</summary>
    /// <typeparam name="T">Tipo de la entidad sobre la que se opera.</typeparam>
    public interface ICreateService<T>
    {
        /// <summary>Crea una nueva entidad en el sistema.</summary>
        /// <param name="entity">Entidad a crear.</param>
        /// <returns>Entidad creada con los valores resultantes (por ejemplo, con su Id asignado).</returns>
        Task<T> CreateAsync(T entity);
    }
}
