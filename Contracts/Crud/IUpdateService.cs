namespace Utilitarios.Contracts.Crud
{
    /// <summary>Define la operación de actualización (Update) para una entidad.</summary>
    /// <typeparam name="TIn">Tipo de datos de entrada (DTO o parámetros de actualización).</typeparam>
    /// <typeparam name="TOut">Tipo de datos de salida (Entidad actualizada o DTO resultante).</typeparam>
    public interface IUpdateService<TIn, TOut>
    {
        /// <summary>Actualiza una entidad existente en el sistema.</summary>
        /// <param name="entity">Datos de entrada necesarios para actualizar la entidad.</param>
        /// <returns>Entidad o DTO resultante después de la actualización.</returns>
        Task<TOut> UpdateAsync(TIn entity, int? userId = null);
    }
}
