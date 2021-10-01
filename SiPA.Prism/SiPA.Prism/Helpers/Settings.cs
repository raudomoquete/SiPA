using Plugin.Settings;
using Plugin.Settings.Abstractions;


namespace SiPA.Prism.Helpers
{
    public static class Settings
    {
        private const string _token = "Token";
        private const string _christening = "Acta Bautismal";
        private const string _firstCommunion = "Certificado de Primera Comunión";
        private const string _confirmation = "Certificado de Confirmación";
        private const string _wedding = "Acta de Matrimonio";
        private const string _parishioner = "Parishioner";
        private const string _isRemembered = "IsRemembered";
        private static readonly string _stringDefault = string.Empty;
        private static readonly bool _boolDefault = false;

        private static ISettings AppSettings => CrossSettings.Current;

        public static string Christening
        {
            get => AppSettings.GetValueOrDefault(_christening, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_christening, value);
        }

        public static string FirstCommunion
        {
            get => AppSettings.GetValueOrDefault(_firstCommunion, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_firstCommunion, value);
        }

        public static string Confirmation
        {
            get => AppSettings.GetValueOrDefault(_confirmation, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_confirmation, value);
        }

        public static string Wedding
        {
            get => AppSettings.GetValueOrDefault(_wedding, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_wedding, value);
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
