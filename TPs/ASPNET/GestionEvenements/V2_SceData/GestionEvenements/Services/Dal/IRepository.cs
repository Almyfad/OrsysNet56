using Modele;
using System.Linq.Expressions;

namespace GestionEvenements.Services.Dal
{
    public interface IRepository<T>
    {
        IAsyncEnumerable<T> Liste();
        IQueryable<T> ListeIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<T?> LireAsync(int id);
        bool Existe(int id);
        Task<int> Creer(T entite);
        Task<int> Modifier(T entite);
        Task<int> Supprimer(T entite);
    }
    public interface IRepositoryParticipants : IRepository<Participant>
    {
    }
    public interface IRepositoryEvenements : IRepository<Evenement>
    {
    }
    public interface IRepositoryAdresses : IRepository<Adresse>
    {
    }
}
