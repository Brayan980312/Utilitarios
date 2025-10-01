namespace Utilitarios.Security
{
    using System.Text.RegularExpressions;

    /// <summary>Métodos para sanitización de entradas y prevención de inyección SQL / XSS.</summary>
    public static class InputSanitizer
    {
        /// <summary>Detecta si una cadena de texto contiene patrones comunes asociados a intentos de inyección SQL (SQL Injection).</summary>
        /// <param name="input">Texto a evaluar.</param>
        /// <returns><c>true</c> si el texto contiene palabras clave o secuencias sospechosas como SELECT, INSERT, UPDATE, DELETE, DROP, EXEC, UNION, comentarios (--), o punto y coma (;).  De lo contrario, <c>false</c>.</returns>
        public static bool ContieneSqlInjection(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

            string pattern = @"(\b(SELECT|INSERT|UPDATE|DELETE|DROP|EXEC|UNION|--|;)\b)";
            return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>Elimina etiquetas HTML y scripts de una cadena de texto como medida de sanitización básica para prevenir ataques XSS (Cross-Site Scripting).</summary>
        /// <param name="input">Texto potencialmente inseguro que puede contener HTML o scripts.</param>
        /// <returns>Cadena limpia sin etiquetas HTML ni scripts.</returns>
        public static string SanitizeHtml(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;
            return Regex.Replace(input, "<.*?>", string.Empty);
        }
    }
}
