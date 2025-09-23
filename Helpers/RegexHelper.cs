namespace Utilitarios.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    public static class RegexHelper
    {
        #region Numeros
        public static bool EsNumero(string input) =>
           Regex.IsMatch(input, @"^\d+$");

        public static bool EsDecimal(string input) =>
            Regex.IsMatch(input, @"^-?\d+(\.\d+)?$");

        public static bool EsEnteroPositivo(string input) =>
            Regex.IsMatch(input, @"^[1-9]\d*$");

        public static bool EsEnteroNegativo(string input) =>
            Regex.IsMatch(input, @"^-\d+$");
        #endregion

        #region Texto
        public static bool SoloLetras(string input) =>
            Regex.IsMatch(input, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");

        public static bool SoloLetrasYNumeros(string input) =>
            Regex.IsMatch(input, @"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s]+$");

        public static bool EsAlfanumericoConGuiones(string input) =>
            Regex.IsMatch(input, @"^[a-zA-Z0-9_-]+$");
        #endregion

        #region Fechas y horas
        public static bool EsFechaDDMMYYYY(string input) =>
            Regex.IsMatch(input, @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$");

        public static bool EsFechaYYYYMMDD(string input) =>
            Regex.IsMatch(input, @"^(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$");

        public static bool EsHora24H(string input) =>
            Regex.IsMatch(input, @"^([01]\d|2[0-3]):([0-5]\d)$");

        public static bool EsHora12H(string input) =>
            Regex.IsMatch(input, @"^(0?[1-9]|1[0-2]):[0-5][0-9]\s?(AM|PM|am|pm)$");
        #endregion

        #region Correo
        public static bool EsCorreo(string input) =>
            Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        #endregion

        #region Seguridad
        public static bool EsPasswordFuerte(string input) =>
            Regex.IsMatch(input, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
        // Min 8 caracteres, al menos: 1 mayúscula, 1 minúscula, 1 número y 1 símbolo
        #endregion
    }
}
