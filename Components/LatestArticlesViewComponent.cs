using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ViewComponentDemo.Components
{
    public class LatestArticlesViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LatestArticlesViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync("http://localhost:5000/api/articles");
            var articles = JsonSerializer.Deserialize<List<Article>>(response);

            return View(articles);
        }

        public class Article
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }
    }
}
