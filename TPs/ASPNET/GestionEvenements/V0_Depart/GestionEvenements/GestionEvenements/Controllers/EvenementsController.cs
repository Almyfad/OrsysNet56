#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionEvenements.Services.Dal;
using Modele;

namespace GestionEvenements.Controllers
{
    public class EvenementsController : Controller
    {
        private readonly RepoEvenements _repo;

        public EvenementsController(RepoEvenements repo)
        {
            _repo = repo;
        }

        // GET: Evenements
        public async Task<IActionResult> Index()
        {
            return View(await _repo.Liste().ToListAsync());
        }

        // GET: Evenements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evenement = await _repo.LireAsync(id.Value);
            if (evenement == null)
            {
                return NotFound();
            }

            return View(evenement);
        }

        // GET: Evenements/Create
        public IActionResult Create()
        {
            ViewBag.TypeEvenementId = new SelectList(_repo.TypesEvenementAvecValeurVide, "TypeEvenementId", "Libelle");
            return View();
        }

        // POST: Evenements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvenementId,TypeEvenementId,Annee,DateEvenement,Titre,Description,Url,AdresseId")] Evenement evenement)
        {
            if (ModelState.IsValid)
            {
                await _repo.Creer(evenement);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TypeEvenementId = new SelectList(_repo.TypesEvenementAvecValeurVide, "TypeEvenementId", "Libelle", evenement.TypeEvenementId);
            return View(evenement);
        }

        // GET: Evenements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evenement = await _repo.LireAsync(id.Value);
            if (evenement == null)
            {
                return NotFound();
            }
            ViewBag.TypeEvenementId = new SelectList(_repo.TypesEvenementAvecValeurVide, "TypeEvenementId", "Libelle", evenement.TypeEvenementId);
            return View(evenement);
        }

        // POST: Evenements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvenementId,TypeEvenementId,Annee,DateEvenement,Titre,Description,Url,AdresseId")] Evenement evenement)
        {
            if (id != evenement.EvenementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Modifier(evenement);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_repo.Existe(evenement.EvenementId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TypeEvenementId = new SelectList(_repo.TypesEvenementAvecValeurVide, "TypeEvenementId", "Libelle", evenement.TypeEvenementId);
            return View(evenement);
        }

        // GET: Evenements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evenement = await _repo.LireAsync(id.Value);
            if (evenement == null)
            {
                return NotFound();
            }

            return View(evenement);
        }

        // POST: Evenements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evenement = await _repo.LireAsync(id);
            await _repo.Supprimer(evenement);
            return RedirectToAction(nameof(Index));
        }
    }
}
