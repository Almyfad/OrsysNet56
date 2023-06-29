using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Modele;

namespace GestionEvenements.Services.Sessions
{
    // Comme il s'agit d'une session, on n'utilise pas l'id des intérêts mais celui de l'ev.
    // Si elle enregistrée en base, on remplace l'ensemble des intérêts enregistrés par la nouvelle sélection
    public class SelectionInterets
    {
        HttpContext _context;
        List<Interet> _interets;
        private const string cleSession = "Interets";
        
        public SelectionInterets(HttpContext context)
        {
            _context = context;
            _interets = _context.Session.GetObjectFromJson<List<Interet>>(cleSession) ?? new List<Interet>();
        }
        public void ActualiserInterets(List<Interet> interets)
        {
            _interets = interets;
            MajSession();
        }
        void MajSession()
        {
            _context.Session.SetObjectAsJson(cleSession, _interets);
        }
        public List<Interet> Liste()
        {
            return _interets;
        }
        public bool Existe(int idEv)
        {
            return  _interets.SingleOrDefault(it => it.EvenementId == idEv) != null;
        }
        public Interet? Lire(int idEv)
        {
            return _interets.SingleOrDefault(it => it.EvenementId == idEv);
        }
        public void Ajouter(Interet interet)
        {
            if (Existe(interet.EvenementId)) return;

            _interets.Add(interet);
            MajSession();
        }
        public void Modifier(Interet interet)
        {
            var old = Lire(interet.EvenementId);
            if (old == null) return;

            _interets.Remove(old);
            _interets.Add(interet);
            MajSession();
        }
        public void Supprimer(int idEv)
        {
            if (!Existe(idEv)) return;

            var interet = Lire(idEv);
            if(interet != null) _interets.Remove(interet);
            MajSession();
        }
        public void DetruireSession()
        {
            _context.Session.Clear();
            _context.Session.Remove(_context.Session.Id);
        }
    }
}
