namespace Validation.Models
{
    internal class RegexConstants
    {
        public const string PinRegexPattern = @"^[0-9]{4}$";
        public const string PhoneRegexPattern = @"^(\(?\+?[0-9]*\)?)?[0-9_\/\- \(\)]*$";
    }
}
