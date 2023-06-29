using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using GestionEvenements.Services.App;
using GestionEvenements.Services.Sessions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modele;

namespace GestionEvenements.Services.Dal
{
    public class RepoInterets : RepoBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        public RepoInterets(GevDbContext context, UserManager<IdentityUser> userManager) : base(context)
        {
            _userManager = userManager;
        }

        private string? _userId;
        private string UserId(ClaimsPrincipal user)
        {
            if (string.IsNullOrEmpty(_userId))
            {
                if (Parametres.EnvironnementDev
                    && (user.Identity == null || !user.Identity.IsAuthenticated))
                {
                    _userId = Parametres.UserIdDev;
                }
                else
                {
                    _userId = _userManager.GetUserId(user);
                }
            }

            return _userId;
        }

        public async Task<int> Enregistrer(List<Interet> selection, ClaimsPrincipal user)
        {
            if (selection.Count == 0)
            {
                return 0;
            }

            string userId = UserId(user);
            foreach (Interet interet in selection)
            {
                interet.UserId = userId;
            }

            string sql = $"Delete From Interets Where UserId='{userId}'";
            await Context.Database.ExecuteSqlRawAsync(sql);

            await Context.Interets.AddRangeAsync(selection);
            return await Context.SaveChangesAsync();
        }

        public async Task<List<Interet>> Lire(ClaimsPrincipal user)
        {
            NoTracking();
            string userId = UserId(user);

            var interetsEnregistres = await Context.Interets
                .AsQueryable()
                .Where(it => it.UserId == userId)
                .Include(it => it.Evenement)
                .ToListAsync();

            // Recréer une nouvelle liste d'intérêts pour désactiver le tracking
            // avec pb d'existence de l'ID à l'insertion lorsque des entités ont été
            // rechargées après avoir été enregistrée en base (IsKeySet==true)

            List<Interet> interets = new List<Interet>();
            foreach (Interet interet in interetsEnregistres)
            {
                interets.Add(new Interet { EvenementId = interet.EvenementId, Rating = interet.Rating, TitreEvenement = interet.Evenement.Titre, Commentaires = interet.Commentaires });
            }
            return interets;
        }
    }
}
