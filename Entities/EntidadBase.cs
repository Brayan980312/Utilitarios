namespace Utilitarios.Entities
{
    /// <summary>Clase base abstracta para todas las entidades del dominio.
    /// Proporciona propiedades comunes, como por ejemplo identificador.
    /// </summary>
    public abstract class EntidadBase
    {
        /// <summary>Identificador único de la entidad.</summary>
        public int Id { get; set; }

        /// <summary>Inicializa una nueva instancia de la clase <see cref="EntidadBase"/>.
        /// Se utiliza principalmente para permitir herencia en las entidades de negocio.
        /// </summary>
        protected EntidadBase() { }
    }
}
