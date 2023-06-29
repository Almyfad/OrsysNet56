using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace ComposantBlazor.Composants
{
    public partial class DialogueConfirmation
    {
        public bool Visible { get; set; }
        
        public string DesignationArticle { get; set; }
		
        [Parameter]
        public EventCallback<bool> ReponseCallback { get; set; }
		
        public void Afficher(string designationArticle)
        {
            DesignationArticle = designationArticle;
            Visible = true;
            StateHasChanged();
        }
		
        public async void Masquer()
        {
            Visible = false;
            await ReponseCallback.InvokeAsync(false);
            StateHasChanged();
        }

        public async void Supprimer()
        {
            Visible = false;
            await ReponseCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }
}
