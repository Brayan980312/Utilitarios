namespace Utilitarios.Helpers
{
    using System.Text.RegularExpressions;

    /// <summary>Proporciona métodos auxiliares basados en expresiones regulares (Regex) para validar cadenas de texto en distintos formatos.</summary>
    public static class RegexHelper
    {
        #region Números

        /// <summary>Verifica si la cadena contiene únicamente números enteros (0-9).</summary>
        /// <param name="input">Cadena a evaluar.</param>
        /// <returns><c>true</c> si la cadena es un número entero; de lo contrario, <c>false</c>.</returns>
        public static bool EsNumero(string input) =>
           Regex.IsMatch(input, @"^\d+$");

        /// <summary>Verifica si la cadena es un número decimal válido, positivo o negativo.</summary>
        /// <param name="input">Cadena a evaluar.</param>
        /// <returns><c>true</c> si la cadena es decimal; de lo contrario, <c>false</c>.</returns>
        public static bool EsDecimal(string input) =>
            Regex.IsMatch(input, @"^-?\d+(\.\d+)?$");

        /// <summary>Verifica si la cadena representa un número entero positivo (mayor que cero).</summary>
        /// <param name="input">Cadena a evaluar.</param>
        /// <returns><c>true</c> si la cadena es un entero positivo; de lo contrario, <c>false</c>.</returns>
        public static bool EsEnteroPositivo(string input) =>
            Regex.IsMatch(input, @"^[1-9]\d*$");

        /// <summary>Verifica si la cadena representa un número entero negativo.</summary>
        /// <param name="input">Cadena a evaluar.</param>
        /// <returns><c>true</c> si la cadena es un entero negativo; de lo contrario, <c>false</c>.</returns>
        public static bool EsEnteroNegativo(string input) =>
            Regex.IsMatch(input, @"^-\d+$");

        #endregion

        #region Texto

        /// <summary>Verifica si la cadena contiene solo letras (mayúsculas, minúsculas, acentos, ñ) y espacios.</summary>
        /// <param name="input">Cadena a evaluar.</param>
        /// <returns><c>true</c> si la cadena contiene únicamente letras y espacios; de lo contrario, <c>false</c>.</returns>
        public static bool SoloLetras(string input) =>
            Regex.IsMatch(input, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");

        /// <summary>Verifica si la cadena contiene solo letras, números y espacios (permite acentos y ñ).</summary>
        /// <param name="input">Cadena a evaluar.</param>
        /// <returns><c>true</c> si la cadena es alfanumérica con espacios; de lo contrario, <c>false</c>.</returns>
        public static bool SoloLetrasYNumeros(string input) =>
            Regex.IsMatch(input, @"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s]+$");

        /// <summary>Verifica si la cadena es alfanumérica y puede incluir guiones medios (-) o guiones bajos (_).</summary>
        /// <param name="input">Cadena a evaluar.</param>
        /// <returns><c>true</c> si la cadena es válida; de lo contrario, <c>false</c>.</returns>
        public static bool EsAlfanumericoConGuiones(string input) =>
            Regex.IsMatch(input, @"^[a-zA-Z0-9_-]+$");

        #endregion

        #region Fechas y horas

        /// <summary>Verifica si la cadena corresponde a una fecha en formato <c>DD/MM/YYYY</c>.</summary>
        /// <param name="input">Cadena a evaluar.</param>
        /// <returns><c>true</c> si la cadena tiene el formato de fecha válido; de lo contrario, <c>false</c>.</returns>
        public static bool EsFechaDDMMYYYY(string input) =>
            Regex.IsMatch(input, @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$");

        /// <summary>Verifica si la cadena corresponde a una fecha en formato <c>YYYY/MM/DD</c>.</summary>
        /// <param name="input">Cadena a evaluar.</param>
        /// <returns><c>true</c> si la cadena tiene el formato de fecha válido; de lo contrario, <c>false</c>.</returns>
        public static bool EsFechaYYYYMMDD(string input) =>
            Regex.IsMatch(input, @"^(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$");

        /// <summary>Verifica si la cadena corresponde a una hora en formato de 24 horas (HH:mm).</summary>
        /// <param name="input">Cadena a evaluar.</param>
        /// <returns><c>true</c> si la cadena tiene el formato de hora válido; de lo contrario, <c>false</c>.</returns>
        public static bool EsHora24H(string input) =>
            Regex.IsMatch(input, @"^([01]\d|2[0-3]):([0-5]\d)$");

        /// <summary>Verifica si la cadena corresponde a una hora en formato de 12 horas (hh:mm AM/PM).</summary>
        /// <param name="input">Cadena a evaluar.</param>
        /// <returns><c>true</c> si la cadena tiene el formato de hora válido; de lo contrario, <c>false</c>.</returns>
        public static bool EsHora12H(string input) =>
            Regex.IsMatch(input, @"^(0?[1-9]|1[0-2]):[0-5][0-9]\s?(AM|PM|am|pm)$");

        #endregion

        #region Correo

        /// <summary>Verifica si la cadena es un correo electrónico con un formato válido.</summary>
        /// <param name="input">Cadena a evaluar.</param>
        /// <returns><c>true</c> si la cadena es un correo válido; de lo contrario, <c>false</c>.</returns>
        public static bool EsCorreo(string input) =>
            Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        #endregion

        #region Seguridad

        /// <summary>Verifica si la cadena cumple con los criterios de una contraseña fuerte:
        /// <list type="bullet">
        /// <item><description>Longitud mínima de 8 caracteres.</description></item>
        /// <item><description>Al menos una letra mayúscula.</description></item>
        /// <item><description>Al menos una letra minúscula.</description></item>
        /// <item><description>Al menos un número.</description></item>
        /// <item><description>Al menos un carácter especial (@$!%*?&).</description></item>
        /// </list>
        /// </summary>
        /// <param name="input">Cadena que representa la contraseña.</param>
        /// <returns><c>true</c> si la contraseña es fuerte; de lo contrario, <c>false</c>.</returns>
        public static bool EsPasswordFuerte(string input) =>
            Regex.IsMatch(input, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");

        #endregion
    }

}
