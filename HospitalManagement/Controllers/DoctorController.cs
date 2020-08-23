﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalManagement.Models;

namespace HospitalManagement.Controllers
{
    public class DoctorController : Controller
    {
        private HospitalContext db = new HospitalContext();

        // GET: Doctor
        public ActionResult Index()
        {
            return View(db.DoctorTable.ToList());
        }

        public ActionResult Homepage()
        {
            return View();
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.DoctorTable.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctorId,Name,Email,Username,Password,ConfirmPassword,Phone,Address,Department")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.DoctorTable.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctor);
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.DoctorTable.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctorId,Name,Email,Username,Password,ConfirmPassword,Phone,Address,Department")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.DoctorTable.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.DoctorTable.Find(id);
            db.DoctorTable.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
