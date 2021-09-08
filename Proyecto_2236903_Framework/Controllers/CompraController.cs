﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_2236903_Framework.Models;

namespace Proyecto_2236903_Framework.Controllers
{
    public class CompraController : Controller
    {
        [Authorize]
        // GET: Compra
        public ActionResult Index()
        {
            using(var db = new inventario2021Entities())
            {
                return View(db.compra.ToList());
            }
        }

        public static string NombreUsuario(int idUsuario)
        {
            using(var db = new inventario2021Entities())
            {
                return db.usuario.Find(idUsuario).nombre;
            }
        }

        public ActionResult ListarUsuario()
        {
            using(var db = new inventario2021Entities())
            {
                return PartialView(db.usuario.ToList());
            }
        }

        public static string NombreCliente(int idCliente)
        {
            using(var db = new inventario2021Entities())
            {
                return db.cliente.Find(idCliente).nombre;
            }
        }

        public ActionResult ListarCliente()
        {
            using(var db = new inventario2021Entities())
            {
                return PartialView(db.cliente.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(compra compra)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using(var db = new inventario2021Entities())
                {
                    db.compra.Add(compra);
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
                return View(db.compra.Find(id));
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using(var db = new inventario2021Entities())
                {
                    compra compraEdit = db.compra.Where(a => a.id == id).FirstOrDefault();
                    return View(compraEdit);
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
        public ActionResult Edit(compra compraEdit)
        {
            try
            {
                using(var db = new inventario2021Entities())
                {
                    var oldCompra = db.compra.Find(compraEdit.id);

                    oldCompra.fecha = compraEdit.fecha;
                    oldCompra.total = compraEdit.total;
                    oldCompra.id_usuario = compraEdit.id_usuario;
                    oldCompra.id_cliente = compraEdit.id_cliente;

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
                    compra compra = db.compra.Find(id);
                    db.compra.Remove(compra);
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