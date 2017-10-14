using MovieArchive.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieArchive.Controllers
{
    public class HomeController : Controller
    {
        // For xml
        static DataSet ds;
        static DataTable dt;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            if (System.IO.File.Exists(Server.MapPath("~/App_Data/contact.xml")))
            {
                ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/App_Data/contact.xml"));
                dt = ds.Tables["comment"];
            }
            else
            {
                ds = new DataSet("contacts");
                dt = new DataTable("comment");
                DataColumn email = new DataColumn("email");
                DataColumn name = new DataColumn("name");
                DataColumn description = new DataColumn("description");
                DataColumn timestamp = new DataColumn("timestamp");
                dt.Columns.Add(email);
                dt.Columns.Add(name);
                dt.Columns.Add(description);
                dt.Columns.Add(timestamp);
                ds.Tables.Add(dt);
            }
            return View();
        }

        // POST: Home/Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Email,Name,Comment")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                DataRow row = dt.NewRow();
                row["email"] = contact.Email;
                row["name"] = contact.Name;
                row["description"] = contact.Comment;
                row["timestamp"] = DateTime.Now;
                dt.Rows.Add(row);
                ds.AcceptChanges();
                ds.WriteXml(Server.MapPath("~/App_Data/contact.xml"));
                return View("Success");
            }
            else return View("Contact", contact);
        }
    }
}