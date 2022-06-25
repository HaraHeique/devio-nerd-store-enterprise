namespace NSE.Identidade.API.Models
{
    public class AppSettings
    {
        public const string SettingsKey = "AppSettings";

        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
    }
}
