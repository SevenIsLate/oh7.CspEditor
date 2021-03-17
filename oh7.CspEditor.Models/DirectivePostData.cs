namespace oh7.CspEditor.Models
{
    public class DirectivePostData
    {
        public int DirectiveId { get; set; }
        public string PropertyToChange { get; set; }
        public bool Value { get; set; }
    }
}