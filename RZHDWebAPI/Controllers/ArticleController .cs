using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using RZHDWebAPI.Models;
using RZHDWebAPI.DTO;

namespace RZHDWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ArticleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("article/{id}")]
        [Authorize]
        public IActionResult GetArticle(int id)
        {
            var article = _context.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpGet("content/{search}")]
        [Authorize]
        public IActionResult SearchContent(string search)
        {
            var content = _context.Articles.Where(a => a.Title.Contains(search)).ToList();
            return Ok(content);
        }

        [HttpGet("download/{id}")]
        [Authorize]
        public IActionResult DownloadArticle(int id)
        {
            var article = _context.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }
            var content = System.IO.File.ReadAllBytes(article.FilePath);
            return File(content, "application/octet-stream", article.Title + ".mp3");
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Article>> PostArticle(Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            article.Date = DateTime.UtcNow;

            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArticle), new { id = article.Id }, article);
        }
    }
}
