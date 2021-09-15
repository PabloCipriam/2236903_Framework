using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_2236903_Framework.Models;

namespace Proyecto_2236903_Framework.Controllers
{
    public class ClienteController : Controller
    {
        [Authorize]
        // GET: Cliente
        public ActionResult Index()
        {
            using(var db = new inventario2021Entities())
            {
                return View(db.cliente.ToList());
            }
        }

        public ActionResult Create()
        {
            using(var db = new inventario2021Entities())
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(cliente cliente)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using(var db = new inventario2021Entities())
                {
                    db.cliente.Add(cliente);
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
                var findCliente = db.cliente.Find(id);
                return View(findCliente);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    var findCliente = db.cliente.Find(id);
                    db.cliente.Remove(findCliente);
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

        public ActionResult Edit(int id)
        {
            try
            {
                using(var db = new inventario2021Entities())
                {
                    cliente findCliente = db.cliente.Where(a => a.id == id).FirstOrDefault();
                    return View(findCliente);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(cliente editCliente)
        {
            try
            {
                using(var db = new inventario2021Entities())
                {
                    cliente cliente = db.cliente.Find(editCliente.id);

                    cliente.nombre = editCliente.nombre;
                    cliente.documento = editCliente.documento;
                    cliente.email = editCliente.email;

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

        public ActionResult uploadCSV()
        {
            return View();
        }

        [HttpPost]
        public ActionResult uploadCSV(HttpPostedFileBase file)
        {
            try
            {
                //string para guardar la ruta
                string filePath = string.Empty;

                //condicion para saber si el archivo llego
                if(file != null)
                {
                    //ruta de la carpeta que guardará el archivo
                    string path = Server.MapPath("~/Uploads/");

                    //condicion para saber si la carpeta uploads existe
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    //obtener el nombre del archivo
                    filePath = path + Path.GetFileName(file.FileName);

                    //obtener la extensión del archivo
                    string extension = Path.GetExtension(file.FileName);

                    //guardar el archivo
                    file.SaveAs(filePath);

                    string csvData = System.IO.File.ReadAllText(filePath);

                    foreach(string row in csvData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            var newCliente = new cliente
                            {
                                nombre = row.Split(';')[0],
                                documento = row.Split(';')[1],
                                email = row.Split(';')[2]
                            };

                            using (var db = new inventario2021Entities())
                            {
                                db.cliente.Add(newCliente);
                                db.SaveChanges();
                            }
                        }
                    }
                }

                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }
    }
}