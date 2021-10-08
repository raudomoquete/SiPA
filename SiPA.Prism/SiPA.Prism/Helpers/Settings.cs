using Plugin.Settings;
using Plugin.Settings.Abstractions;


namespace SiPA.Prism.Helpers
{
    public static class Settings
    {
        private const string _token = "Token";
        private const string _request = "Request";
        private const string _parishioner = "Parishioner";
        private const string _isRemembered = "IsRemembered";
        private static readonly string _stringDefault = string.Empty;
        private static readonly bool _boolDefault = false;

        private static ISettings AppSettings => CrossSettings.Current;

        public static string Request
        {
            get => AppSettings.GetValueOrDefault(_request, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_request, value);
        }

        public static string Token
        {
            get => AppSettings.GetValueOrDefault(_token, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_token, value);
        }

        public static string Parishioner
        {
            get => AppSettings.GetValueOrDefault(_parishioner, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_parishioner, value);
        }

        public static bool IsRemembered
        {
            get => AppSettings.GetValueOrDefault(_isRemembered, _boolDefault);
            set => AppSettings.AddOrUpdateValue(_isRemembered, value);
        }
    }
}
