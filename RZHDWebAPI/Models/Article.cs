namespace RZHDWebAPI.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public List<Violation> Violations { get; set; }
        public string FilePath { get; set; }
    }
}
