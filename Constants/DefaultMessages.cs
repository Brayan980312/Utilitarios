namespace Utilitarios.Constants
{
    public static class DefaultMessages
    {
        // ======================
        // Operaciones CRUD
        // ======================
        public const string CreatedSuccessfully = "Guardado exitosamente.";
        public const string UpdatedSuccessfully = "Actualización realizada con éxito.";
        public const string DeletedSuccessfully = "Eliminación realizada con éxito.";
        public const string RetrievedSuccessfully = "Datos obtenidos correctamente.";

        public const string CreateFailed = "No se pudo guardar el registro.";
        public const string UpdateFailed = "No se pudo actualizar el registro.";
        public const string DeleteFailed = "No se pudo eliminar el registro.";
        public const string NotFound = "El registro solicitado no existe.";
        public const string AlreadyExists = "Ya existe un registro con la misma información.";

        // ======================
        //  Validaciones
        // ======================
        public const string FieldRequired = "El campo es obligatorio.";
        public const string FieldRequiredWithName = "El campo '{0}' es obligatorio.";
        public const string InvalidFormat = "El formato del campo no es válido.";
        public const string InvalidEmail = "El correo electrónico no tiene un formato valido.";
        public const string InvalidPhone = "El número de teléfono no es válido.";
        public const string InvalidNumber = "El valor debe ser numérico.";
        public const string InvalidNumberWithName = "El campo '{0}' debe ser numérico.";
        public const string InvalidNumberMin = "El campo '{0}' debe ser mayor a '{1}'";
        public const string InvalidNumberMax = "El campo '{0}' debe ser menos a '{1}'";
        public const string InvalidDate = "La fecha no es válida.";
        public const string MinLength = "El campo '{0}' debe tener al menos {1} caracteres.";
        public const string MaxLength = "El campo '{0}' no puede superar los {1} caracteres.";
        public const string RangeError = "El campo '{0}' debe estar entre {1} y {2}.";
        public const string PasswordTooWeak = "La clave no cumple con los requisitos de seguridad.";

        // ======================
        // Seguridad / Autenticación
        // ======================
        public const string Unauthorized = "No tiene autorización para realizar esta acción.";
        public const string Forbidden = "Acceso denegado.";
        public const string InvalidCredentials = "Usuario o clave incorrectos.";
        public const string AccountLocked = "La cuenta ha sido bloqueada temporalmente.";
        public const string AccountInactive = "La cuenta no está activa.";
        public const string SessionExpired = "La sesión ha expirado, por favor inicie sesión nuevamente.";
        public const string TokenInvalid = "El token de acceso no es válido.";
        public const string TokenExpired = "El token ha expirado.";

        // ======================
        // Errores técnicos
        // ======================
        public const string UnexpectedError = "Ha ocurrido un error inesperado.";
        public const string DatabaseError = "Error al acceder a la base de datos.";
        public const string ServiceUnavailable = "El servicio no está disponible en este momento.";
        public const string NetworkError = "Error de conexión con el servidor.";
        public const string TimeoutError = "La operación tardó demasiado tiempo en responder.";
        public const string DependencyError = "Un servicio externo no respondió correctamente.";
        public const string ConfigurationError = "La aplicación no está configurada correctamente.";

        // ======================
        // Notificaciones / UI
        // ======================
        public const string ConfirmDelete = "¿Está seguro de eliminar este registro?";
        public const string ActionConfirmation = "¿Desea continuar con la acción?";
        public const string OperationSuccessful = "Operación realizada exitosamente.";
        public const string Welcome = "¡Bienvenido a la aplicación!";
        public const string Goodbye = "Sesión finalizada, hasta pronto.";
        public const string AccessRestricted = "Restricción de acceso.";

        // ======================
        // Otros mensajes útiles
        // ======================
        public const string ContactSupport = "Por favor, contacte al soporte técnico.";
        public const string TryAgainLater = "Intente nuevamente más tarde.";
        public const string FeatureNotAvailable = "La funcionalidad aún no está disponible.";
        public const string InvalidOperation = "La operación solicitada no es válida.";

        // ======================
        // Personalizados
        // ======================
        public const string UserAlreadyExistsById = "Ya existe un usuario con la identificación ingresada.";
        public const string UserAlreadyExistsByEmail = "Ya existe un usuario con el correo ingresado.";
        public const string PasswordsDoNotMatch = "Las claves no coinciden.";
        public const string UserNotFound = "El usuario ingresado no existe.";
        public const string DataNotFound = "'{0}' no existe en el sistema.";

    }
}   