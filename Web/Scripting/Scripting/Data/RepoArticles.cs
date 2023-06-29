
namespace Scripting.Data
{
    public class RepoArticles
    {
        private static List<Article>? _listeArticles;
        public static IEnumerable<Article> ListeArticles()
        {
            if (_listeArticles == null)
            {
                _listeArticles = new List<Article>();

                for (int i = 1; i <= 10; i++)
                {
                    var article = new Article
                    {
                        ArticleId = i,
                        Designation = "Désignation article #" + i
                    };
                    _listeArticles.Add(article);
                }
            }

            return _listeArticles.AsEnumerable();
        }

        public static Article? LireArticle(int articleId)
        {
            return ListeArticles().SingleOrDefault(it => it.ArticleId == articleId);
        }

        public static void AjouterArticle(Article article)
        {
            article.ArticleId = ListeArticles().ToList().Max(a => a.ArticleId) + 1;
            _listeArticles?.Add(article);
        }
        public static void ModifierArticle(int articleId, Article article)
        {
            var a = ListeArticles().SingleOrDefault(it => it.ArticleId == articleId);
            if (a != null)
            {
                a.Designation = article.Designation;
            }
        }

        public static void SupprimeArticle(int index)
        {
            _listeArticles?.RemoveAt(index);
        }

        public static void RazArticles()
        {
            _listeArticles = null;
        }
    }
}
