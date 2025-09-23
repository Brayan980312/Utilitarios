namespace Utilitarios.Security
{
    using System.Text.RegularExpressions;
    /// <summary>
    /// Métodos para sanitización de entradas y prevención de inyección SQL / XSS.
    /// </summary>
    public static class InputSanitizer
    {
        /// <summary>
        /// Detecta si un texto contiene patrones de SQL Injection.
        /// </summary>
        public static bool ContieneSqlInjection(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

            string pattern = @"(\b(SELECT|INSERT|UPDATE|DELETE|DROP|EXEC|UNION|--|;)\b)";
            return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Elimina etiquetas HTML y scripts (prevención básica de XSS).
        /// </summary>
        public static string SanitizeHtml(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;
            return Regex.Replace(input, "<.*?>", string.Empty);
        }
    }
}
