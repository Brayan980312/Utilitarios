namespace Utilitarios.Contracts.Crud
{
    /// <summary>Define la operación de consulta de todas las entidades (Read All).</summary>
    /// <typeparam name="T">Tipo de la entidad sobre la que se opera.</typeparam>
    public interface IReadAllService<T>
    {
        /// <summary>Consulta todas las entidades disponibles en el sistema.</summary>
        /// <returns>Lista de entidades encontradas.</returns>
        Task<IEnumerable<T>> GetAllAsync();
    }
}
