using RZHDWebAPI.Models;

namespace RZHDWebAPI.DTO
{
    public class CreateArticle
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string FilePath { get; set; }
    }
}
