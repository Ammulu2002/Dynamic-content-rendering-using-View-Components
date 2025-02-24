using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ViewComponentDemo.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private static List<Article> articles = new List<Article>
        {
            new Article("ASP.NET Core Basics", "ASP.NET Core is a cross-platform framework..."),
            new Article("Introduction to View Components", "View Components allow you to..."),
            new Article("MVC vs Razor Pages", "MVC and Razor Pages are two UI frameworks...")
        };

        [HttpGet]
        public IActionResult GetLatestArticles()
        {
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public IActionResult GetArticleDetails(int id)
        {
            var article = articles.FirstOrDefault(a => a.Id == id);
            if (article == null) return NotFound("Article not found.");
            return Ok(article);
        }

        [HttpPost]
        [HttpPost]
        public IActionResult AddArticle([FromBody] Article newArticle)
        {
            if (string.IsNullOrEmpty(newArticle.Title) || string.IsNullOrEmpty(newArticle.Content))
                return BadRequest("Title and Content are required.");

            newArticle.Id = articles.Count + 1;
            articles.Add(newArticle);
            return CreatedAtAction(nameof(GetArticleDetails), new { id = newArticle.Id }, newArticle);
        }

    }

    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Article(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}
