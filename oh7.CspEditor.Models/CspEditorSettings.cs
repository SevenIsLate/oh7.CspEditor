namespace oh7.CspEditor.Models
{
    public class CspEditorSettings
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public static class CspEditorSettingsConstants
    {
        public static string DefaultCssStyle => "DefaultCssStyling";
    }
}