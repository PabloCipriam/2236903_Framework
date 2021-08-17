using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_2236903_Framework.Models;

namespace Proyecto_2236903_Framework.Controllers
{
    public class ProductoImagenController : Controller
    {
        // GET: ProductoImagen
        public ActionResult Index()
        {
            using(var db = new inventario2021Entities())
            {
                return View(db.producto_imagen.ToList());
            }
        }
        
        public static string NombreProducto(int idProducto)
        {
            using(var db = new inventario2021Entities())
            {
                return db.producto.Find(idProducto).nombre;
            }
        }

        public ActionResult ListarProductos()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.producto.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(producto_imagen producto_Imagen)
        {
            if (!ModelState.IsValid)
                return View();
            
            try
            {
                using(var db = new inventario2021Entities())
                {
                    db.producto_imagen.Add(producto_Imagen);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using(var db = new inventario2021Entities())
            {
                return View(db.producto_imagen.Find(id));
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using(var db = new inventario2021Entities())
                {
                    producto_imagen producto_ImagenEdit = db.producto_imagen.Where(a => a.id == id).FirstOrDefault();
                    return View(producto_ImagenEdit);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "error"+ex);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(producto_imagen producto_ImagenEdit)
        {
            try
            {
                using(var db = new inventario2021Entities())
                {
                    var oldProducto_Imagen = db.producto_imagen.Find(producto_ImagenEdit.id);

                    oldProducto_Imagen.imagen = producto_ImagenEdit.imagen;
                    oldProducto_Imagen.id_producto = producto_ImagenEdit.id_producto;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using(var db = new inventario2021Entities())
                {
                    producto_imagen producto_Imagen = db.producto_imagen.Find(id);
                    db.producto_imagen.Remove(producto_Imagen);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }
    }
}