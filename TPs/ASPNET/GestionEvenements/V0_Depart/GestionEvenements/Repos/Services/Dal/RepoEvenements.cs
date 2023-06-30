using Microsoft.EntityFrameworkCore;
using Modele;
using System.Linq.Expressions;

namespace GestionEvenements.Services.Dal
{
    public class RepoEvenements : RepoBase, IRepositoryEvenements
    {      
        public RepoEvenements(GevDbContext context) : base(context)
        {
           
        }

        public async Task<int> Creer(Evenement Evenement)
        {
            return await Enregistrer(Evenement, EntityState.Added);
        }

        public bool Existe(int id)
        {
            NoTracking();
            return Context.Evenements.Any(e => e.EvenementId == id);
        }

        public async Task<Evenement?> LireAsync(int id)
        {
            NoTracking();
            var Evenement = Context.Evenements
                .Include(it => it.Adresse)
                .Include(it => it.TypeEvenement)
                .Include(it => it.Participations)
                .ThenInclude(it => it.Participant)
                .SingleOrDefaultAsync(it => it.EvenementId == id);
            return await Evenement;
        }

        public IAsyncEnumerable<Evenement> Liste()
        {
            NoTracking();
            return Context.Evenements
                .Include(it => it.TypeEvenement)
                .AsQueryable()
                .OrderBy(it => it.Annee)
                .AsAsyncEnumerable();
        }

        public IQueryable<Evenement> ListeIncluding(params Expression<Func<Evenement, object>>[] includeProperties)
        {
            NoTracking();
            return includeProperties.Aggregate<Expression<Func<Evenement, object>>, IQueryable<Evenement>>(Context.Evenements, (current, includeProperty) => current.Include(includeProperty));
        }

        public async Task<int> Modifier(Evenement Evenement)
        {
            return await Enregistrer(Evenement, EntityState.Modified);
        }

        public async Task<int> Supprimer(Evenement Evenement)
        {
            return await Enregistrer(Evenement, EntityState.Deleted);
        }

        private static readonly TypeEvenement _typeEvNull = new TypeEvenement { TypeEvenementId = -1, Libelle = "(Type d'événement)" };

        private static List<TypeEvenement> _typesEvenementAvecValeurVide;
        public List<TypeEvenement> TypesEvenementAvecValeurVide
        {
            get
            {
                if (_typesEvenementAvecValeurVide == null)
                {
                    _typesEvenementAvecValeurVide =
                        Context.TypesEvenement.AsQueryable().OrderBy(it => it.Libelle).ToList();

                    _typesEvenementAvecValeurVide.Insert(0, _typeEvNull);
                }

                return _typesEvenementAvecValeurVide;
            }
        }

        public void RazTypesEvenement()
        {
            _typesEvenementAvecValeurVide = null;
        }
    }
}
