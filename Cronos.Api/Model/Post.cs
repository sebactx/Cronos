namespace Cronos.Api.Model
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime? DateInsertion { get; set; }
        public DateTime? DateLastUpdate { get; set; }
        public string? Text { get; set; }
    }
}
