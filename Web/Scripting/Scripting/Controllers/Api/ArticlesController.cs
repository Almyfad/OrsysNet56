using Microsoft.AspNetCore.Mvc;
using Scripting.Data;

namespace Scripting.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        // GET: api/Articles
        [HttpGet]
        public IEnumerable<Article> Get()
        {
            return RepoArticles.ListeArticles();
        }

        [HttpGet("{id}")]
        public Article? Get(int id)
        {
            if (id < 0)
            {
                RepoArticles.RazArticles();
                return null;
            }
            return RepoArticles.LireArticle(id);
        }

        [HttpPost]
        public void Post(Article article)
        {
            RepoArticles.AjouterArticle(article);
        }

        [HttpPut("{id}")]

        //public void Put(int id, Article article)
        //{
        //    RepoArticles.ModifierArticle(id, article);
        //}
        public void Put(int id, [FromBody] string value)
        {
            RepoArticles.ModifierArticle(id, new Article());
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            RepoArticles.SupprimeArticle(id);
        }
    }
}
