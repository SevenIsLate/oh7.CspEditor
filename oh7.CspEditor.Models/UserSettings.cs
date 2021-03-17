namespace oh7.CspEditor.Models
{
    public class UserSettings
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public static class UserSettingsConstants
    {
        public static string MyCssStyle => "MyCssStyle";
        public static string IsDarkTheme => "IsDarkTheme";
    }
}