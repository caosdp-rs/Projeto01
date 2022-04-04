using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto01.Models;
using System.Linq;
namespace Projeto01.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria() {
            CategoriaID = 1,
            Nome = "Notebooks"},
            new Categoria() {
            CategoriaID = 2,
            Nome = "Monitores"},
            new Categoria() {
            CategoriaID = 3,
            Nome = "Impressoras"},
            new Categoria() {
            CategoriaID = 4,
            Nome = "Mouses"},
            new Categoria() {
            CategoriaID = 5,
            Nome = "Desktops"}
        };
        //GET: Categorias
        public ActionResult Index()
        {
            return View(categorias);
        }

        //GET: Create()
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            categorias.Add(categoria);
            categoria.CategoriaID = categorias.Select(m => m.CategoriaID).Max() + 1;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            return View(categorias.Where(m => m.CategoriaID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            //categorias.Remove(categorias.Where(c => c.CategoriaID == categoria.CategoriaID).First());
            //categorias.Add(categoria);
            categorias[categorias.IndexOf(categorias.Where(c => c.CategoriaID == categoria.CategoriaID).First())] = categoria;
            return RedirectToAction("Index");
        }


        public ActionResult Details(long id)
        {
            return View(categorias.Where(m => m.CategoriaID == id).First());
        }


        public ActionResult Delete(long id)
        {
            return View(categorias.Where(m => m.CategoriaID == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaID == categoria.CategoriaID).First());
            return RedirectToAction("Index");
        }

    }
}