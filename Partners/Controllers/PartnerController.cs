using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Dapper;
using Partners.Models;
using Partners.ViewModels;

namespace Partners.Controllers
{
    public class PartnerController : Controller
    {

        protected IEnumerable<ModelError> _modelStateErrors;

        public string GetRandomNumberString()
        {
            string chars = "0123456789";
            Random rnd = new Random();
            int rInt = rnd.Next(10, 20);

            if (rInt > chars.Length)
            {
                chars = string.Join("", Enumerable.Repeat(chars, 2).ToArray());
            }

            return new string(chars.Select(c => chars[rnd.Next(rInt)]).Take(rInt).ToArray());
        }
        public ActionResult Index(int? id)
        {
            PartnerVM partnerVM = new PartnerVM();
            List<Partner> PartnerList = new List<Partner>();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.AppSettings["constr"].ToString()))
            {

                PartnerList = db.Query<Partner>("Select * From Partners order by CreatedAtUtc desc").ToList();                
            }
            partnerVM.PartnerList = PartnerList;
            partnerVM.Id = id.HasValue ? id.Value : 0;
            return View(partnerVM);
        }

        // GET: Partner/Details/5
        public ActionResult Details(int id)
        {
            Partner displayPartner = new Partner();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.AppSettings["constr"].ToString()))

            {
                displayPartner = db.Query<Partner>("Select * from Partners " +
                                                    "where id =" + id, new { id }).SingleOrDefault();
            }

            return View(displayPartner);
            //return PartialView("getDetails");
        }



        // GET: Partner/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public JsonResult AjaxMethod(int id)
        {
            Partner displayPartner = new Partner();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.AppSettings["constr"].ToString()))

            {
                displayPartner = db.Query<Partner>("Select * from Partners " +
                                                    "where id =" + id, new { id }).SingleOrDefault();
            }
            return Json(displayPartner);
        }

        // POST: Partner/Create
        [HttpPost]
        public ActionResult Create(Partner createPartner)
        {
            int rowsAffected = 0;

            this._modelStateErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();

            if (!ModelState.IsValid)
                return View(createPartner);

            try
            {
                
                using (IDbConnection db = new SqlConnection(ConfigurationManager.AppSettings["constr"].ToString()))
                {

                    string sql = "Insert into Partners(FirstName, LastName, Address, PartnerNumber, CroatianPIN, PartnerTypeId, CreateByUser, IsForeign, ExternalCode, Gender) Values(@FirstName, @LastName, @Address, @PartnerNumber, @CroatianPIN, @PartnerTypeId, @CreateByUser, @IsForeign, '" + GetRandomNumberString() + "', @Gender); SELECT @@IDENTITY;";
                    rowsAffected = db.Query<int>(sql, createPartner).FirstOrDefault();                    
                }
                    
                    return RedirectToAction("Index", new {action = "newEntry", id= rowsAffected });

            }
            catch(Exception ex)
            {
                string ddd = ex.ToString();
                return View();
            }
        }

        // GET: Partner/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Partner/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Partner/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Partner/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
