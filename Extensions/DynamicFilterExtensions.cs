namespace Utilitarios.Extensions
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>Extensiones para construir expresiones de filtrado dinámico a partir de objetos de parámetros</summary>
    public static class DynamicFilterExtensions
    {
        /// <summary>Convierte un objeto de parámetros en una expresión de filtro del tipo <see cref="Expression{Func{T, Boolean}}"/>.</summary>
        /// <typeparam name="T">Tipo de entidad a filtrar.</typeparam>
        /// <param name="parametros">Objeto con propiedades no nulas a usar como criterios.</param>
        /// <returns>Expresión lambda lista para ser usada en LINQ o EF.</returns>
        public static Expression<Func<T, bool>> ToFilterExpression<T>(this object parametros)
        {
            // "x" será el parámetro de la expresión (ej: x => ...)
            var parameter = Expression.Parameter(typeof(T), "x");

            // Expresión inicial: true (sirve como base neutra para combinar con AND)
            Expression combined = Expression.Constant(true);

            // Iteramos todas las propiedades públicas del objeto recibido
            foreach (PropertyInfo prop in parametros.GetType().GetProperties())
            {
                // Si la propiedad se llama "Id" (ignorar mayúsculas/minúsculas), se omite
                if (string.Equals(prop.Name, "Id", StringComparison.OrdinalIgnoreCase))
                    continue;

                // Obtenemos el valor actual de la propiedad
                var value = prop.GetValue(parametros);

                // Si el valor es nulo o vacio, se omite
                if (value == null) continue;

                // Accedemos a la propiedad correspondiente en la entidad T
                var member = Expression.Property(parameter, typeof(T).GetProperty(prop.Name));

                // Creamos la constante que representa el valor
                var constant = Expression.Constant(value);

                // Si la propiedad es Nullable<T>, convertimos ambas expresiones a su tipo subyacente
                if (Nullable.GetUnderlyingType(prop.PropertyType) != null)
                {
                    var memberValue = Expression.Convert(member, Nullable.GetUnderlyingType(prop.PropertyType));
                    var constantValue = Expression.Convert(constant, Nullable.GetUnderlyingType(prop.PropertyType));
                    combined = Expression.AndAlso(combined, Expression.Equal(memberValue, constantValue));
                }
                else
                {
                    // Comparación por igualdad directa (member == constant)
                    combined = Expression.AndAlso(combined, Expression.Equal(member, constant));
                }
            }

            // Retornamos una lambda que puede usarse en LINQ o EF
            return Expression.Lambda<Func<T, bool>>(combined, parameter);
        }
    }
}
