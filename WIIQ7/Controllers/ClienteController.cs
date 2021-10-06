using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WIIQ7.Context;
using WIIQ7.Models;

namespace WIIQ7.Controllers
{
    public class ClienteController : Controller
    {
        private WIIContext context = new WIIContext();

        // GET: Cliente
        public ActionResult Index()
        {
            return View(context.Clientes.OrderBy(c => c.Nome));
        }

 
        // GET: Cliente/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = context.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Cliente cliente = context.Clientes.Find(id);
                context.Clientes.Remove(cliente);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
