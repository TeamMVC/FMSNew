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
    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        public string Url = "http://localhost:61500/api/";
        // GET: Course
        public ActionResult Index()
        {
            IEnumerable<Tbl_Course> Course = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("CourseAPI");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Tbl_Course>>();
                    readTask.Wait();

                    Course = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Course = Enumerable.Empty<Tbl_Course>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Course);
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            Tbl_Course Course = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("CourseAPI?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Tbl_Course>();
                    readTask.Wait();

                    Course = readTask.Result;
                }
            }
            return View(Course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            Tbl_Course Course = new Tbl_Course();
            //  tbl_Department.Dept_ID = 1;

            Course.Course_Name = string.Empty;
            Course.Course_Description = string.Empty;
            return View(Course);
        }

        // POST: Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Course_ID,Course_Name,Course_Description,createdOn,updatedOn,createdBy,UpdatedBy")] Tbl_Course Course)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                Course.createdOn = DateTime.Now;
                Course.updatedOn = DateTime.Now;
                //HTTP POST
                var postTask = client.PostAsJsonAsync<Tbl_Course>("CourseAPI", Course);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(Course);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            Tbl_Course Course = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("CourseAPI?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Tbl_Course>();
                    readTask.Wait();

                    Course = readTask.Result;
                }
            }
            return View(Course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Course_ID,Course_Name,Course_Description,createdOn,updatedOn,createdBy,UpdatedBy")] Tbl_Course Course)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Tbl_Course>("CourseAPI?id=" + Course.Course_ID.ToString(), Course);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Course);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            Tbl_Course Course = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("CourseAPI?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Tbl_Course>();
                    readTask.Wait();

                    Course = readTask.Result;
                }
            }
            return View(Course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("CourseAPI/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
       
    }
}
