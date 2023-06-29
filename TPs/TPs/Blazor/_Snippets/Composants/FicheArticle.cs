using Microsoft.AspNetCore.Components;
using ComposantsBlazor.Data;

namespace ComposantsBlazor.Pages
{
    public partial class FicheArticle
    {
        [Parameter]
        public string? Id { get; set; }
        public WeatherForecast? Article { get; set; }

        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        protected override Task OnInitializedAsync()
        {
            Article = RepoArticles.Articles?.FirstOrDefault(e => e.Id.ToString() == Id);
            return base.OnInitializedAsync();
        }
        private void EditionArticle()
        {
            NavigationManager?.NavigateTo("/edition-article/" + Id);
        }
    }
}
