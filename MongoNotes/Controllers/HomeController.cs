using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoNotes.DAL;
using MongoNotes.Models;

namespace MongoNotes.Controllers
{
    public class HomeController : Controller, IDisposable
    {
        private Dal dal = new Dal();
        private bool disposed = false;

        public ActionResult Index()
        {
            return View(dal.GetAllNotes());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Note note)
        {
            try
            {
                dal.CreateNote(note);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        # region IDisposable


        new protected void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        new protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dal.Dispose();
                }
            }
            
            this.disposed = true;
        }
        
        # endregion
    }
}