using Windows.ApplicationModel.Resources;

namespace Validation.Resources
{
    public static class ErrorMessagesHelper
    {
        private static readonly ResourceLoader ResourceLoader;

        private const string ErrorRequired = "ErrorRequired";
        private const string ErrorRegex = "ErrorRegex";
        private const string ErrorPhoneNumber = "ErrorPhoneNumber";
        private const string ErrorInvalidPin = "ErrorInvalidPIN";
        private const string ErrorSex = "ErrorSex";

        static ErrorMessagesHelper()
        {
            ResourceLoader = new ResourceLoader();
        }

        // actual error messages
        public static string ErrorRequiredMessage => ResourceLoader.GetString(ErrorRequired);
        public static string ErrorRegexMessage => ResourceLoader.GetString(ErrorRegex);
        public static string ErrorPhoneNumberMessage => ResourceLoader.GetString(ErrorPhoneNumber);
        public static string ErrorInvalidPinMessage => ResourceLoader.GetString(ErrorInvalidPin);
        public static string ErrorSexMessage => ResourceLoader.GetString(ErrorSex);

        // error message property names (no magic strings in code)
        public const string ErrorRequiredMessageName = nameof(ErrorRequiredMessage);
        public const string ErrorRegexMessageName = nameof(ErrorRegexMessage);
        public const string ErrorPhoneNumberMessageName = nameof(ErrorPhoneNumberMessage);
        public const string ErrorInvalidPinMessageName = nameof(ErrorInvalidPinMessage);
        public const string ErrorSexMessageName = nameof(ErrorSexMessage);
    }
}