using ComposantsBlazor.Composants;
using ComposantsBlazor.Data;
using Microsoft.AspNetCore.Components;

namespace ComposantsBlazor.Pages
{
    public partial class EditionArticle
    {
        [Parameter]
        public string? Id { get; set; }
        public WeatherForecast? Article { get; set; } = new WeatherForecast();
        public string? ModeEdition { get; set; }

        protected override Task OnInitializedAsync()
        {

            modeAjout = string.IsNullOrEmpty(Id);

            ModeEdition = modeAjout ? "Nouvel article" : "Mise à jour";

            if (!modeAjout)
            {
                Article = RepoArticles.Articles?.FirstOrDefault(e => e.Id.ToString() == Id);
            }
           
            return base.OnInitializedAsync();
        }

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        [Parameter]
        public string? ArticleId { get; set; }

        private bool modeAjout;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        private async void Valider()
        {
            // Les opérations de mise à jour seront fait dans le TP suivant
            StatusClass = "alert-success";
            Message = modeAjout ? "Article créé !" : "Article mis à jour !";
            Saved = true;

            await InvokeAsync(StateHasChanged);
        }
    }
}

