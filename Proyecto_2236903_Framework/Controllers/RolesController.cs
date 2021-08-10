﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_2236903_Framework.Models;

namespace Proyecto_2236903_Framework.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            using(var db = new inventario2021Entities())
            {
                return View(db.roles.ToList());
            }
        }

        public ActionResult Create()
        {
           return View();            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(roles roles)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.roles.Add(roles);
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
                var findRol = db.roles.Find(id);
                return View(findRol);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using(var db = new inventario2021Entities())
                {
                    var findRol = db.roles.Find(id);
                    db.roles.Remove(findRol);
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
                using (var db = new inventario2021Entities())
                {
                    roles findRol = db.roles.Where( a => a.id == id).FirstOrDefault();
                    return View(findRol);
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
        public ActionResult Edit(roles editRol)
        {
            try
            {
                using(var db = new inventario2021Entities())
                {
                    roles rol = db.roles.Find(editRol.id);

                    rol.descripcion = editRol.descripcion;

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