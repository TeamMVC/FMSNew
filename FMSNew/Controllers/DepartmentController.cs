using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using FMSAPI.Models;


namespace FMSNew.Controllers
{
    [Authorize (Roles ="Admin")]
    public class DepartmentController : Controller
    {
        public string Url = "http://localhost:61500/api/";
      
        // GET: Department
        [HttpGet]
        
        public ActionResult Index()
        {
            IEnumerable<Tbl_Department> Department = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("DepartmentAPI");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Tbl_Department>>();
                    readTask.Wait();

                    Department = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Department = Enumerable.Empty<Tbl_Department>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Department);
        }


        // GET: Department/Details/5
        public ActionResult Details(int id)
        {

            Tbl_Department Department = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("DepartmentAPI?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Tbl_Department>();
                    readTask.Wait();

                    Department = readTask.Result;
                }
            }
            return View(Department);
        }

        // GET: Department/Create

        public ActionResult Create()
        {
            Tbl_Department department = new Tbl_Department();
            //  tbl_Department.Dept_ID = 1;

            department.Dept_Name = string.Empty;
            department.Description = string.Empty;
            return View(department);
        }

        // POST: Department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tbl_Department Department)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                Department.createdOn = DateTime.Now;
                Department.updatedOn = DateTime.Now;
                //HTTP POST
                var postTask = client.PostAsJsonAsync<Tbl_Department>("DepartmentAPI", Department);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(Department);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int? id)
        {
            Tbl_Department Department = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("DepartmentAPI?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Tbl_Department>();
                    readTask.Wait();

                    Department = readTask.Result;
                }
            }
            return View(Department);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Dept_ID,Dept_Name,Description,createdOn,updatedOn,createdBy,UpdatedBy")] Tbl_Department Department)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Tbl_Department>("DepartmentAPI?id=" + Department.Dept_ID.ToString(), Department);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Department);
        }


        // GET: Department/Delete/5
        public ActionResult Delete(int? id)
        {
            Tbl_Department Department = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("DepartmentAPI?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Tbl_Department>();
                    readTask.Wait();

                    Department = readTask.Result;
                }
            }
            return View(Department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("DepartmentAPI/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
