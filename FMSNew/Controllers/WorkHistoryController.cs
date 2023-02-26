using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using FMSAPI.Models;
namespace FMSNew.Controllers
{
    [Authorize(Roles = "Admin")]
    public class WorkHistoryController : Controller
    {
        public string Url = "http://localhost:61500/api/";
        // GET: WorkHistory
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("WorkExperienceAPI");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<GetWorkExperienceData>>();
                    readTask.Wait();

                    var Faculty = readTask.Result;
                    return View(Faculty);
                }
                else //web api sent error response 
                {
                    //log response status here..

                    //Faculty = Enumerable.Empty<Tbl_Faculty>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return View();
                }
            }

        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            Tbl_WorkExperience Work = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("WorkExperienceAPI?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Tbl_WorkExperience>();
                    readTask.Wait();

                    Work = readTask.Result;
                }
            }
            return View(Work);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            Tbl_WorkExperience Work = new Tbl_WorkExperience();
            IEnumerable<Tbl_Faculty> Faculty = null;
            string id = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("FacultyAPI?data=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Tbl_Faculty>>();
                    readTask.Wait();
                    Faculty = readTask.Result;
                    ViewBag.Faculty = new SelectList(Faculty, "Faculty_ID", "Faculty_Name");
                }
             

            }
            return View(Work);
        }

        // POST: Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacultyID,Course,Experience,Skills")] Tbl_WorkExperience Work)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                //HTTP POST
                IEnumerable<Tbl_Faculty> Faculty = null;
                string id = string.Empty;
                using (var client1 = new HttpClient())
                {
                    client1.BaseAddress = new Uri(Url);
                    //HTTP GET
                    var responseTask = client1.GetAsync("FacultyAPI?data=" + id.ToString());
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<Tbl_Faculty>>();
                        readTask.Wait();
                        Faculty = readTask.Result;
                        ViewBag.Faculty = new SelectList(Faculty, "Faculty_ID", "Faculty_Name");
                    }


                }

                var postTask = client.PostAsJsonAsync<Tbl_WorkExperience>("WorkExperienceAPI", Work);
                postTask.Wait();

                var result1 = postTask.Result;

                if (result1.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(Work);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            Tbl_WorkExperience Work = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("WorkExperienceAPI?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Tbl_WorkExperience>();
                    readTask.Wait();

                    Work = readTask.Result;
                }
            }
            return View(Work);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacultyID,Course,Experience,Skills")] Tbl_WorkExperience Work)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Tbl_WorkExperience>("WorkExperienceAPI?id=" + Work.WorkID.ToString(), Work);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Work);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            Tbl_WorkExperience Work = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("WorkExperienceAPI?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Tbl_WorkExperience>();
                    readTask.Wait();

                    Work = readTask.Result;
                }
            }
            return View(Work);
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
                var deleteTask = client.DeleteAsync("WorkExperienceAPI/" + id.ToString());
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