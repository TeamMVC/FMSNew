using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMSAPI.Models;
using System.Net.Http;

namespace FMSNew.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BookPublishController : Controller
    {
        // GET: BookPublish
        public string Url = "http://localhost:61500/api/";
        // GET: WorkHistory
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("BookPublishAPI");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<GetBookPublishData>>();
                    readTask.Wait();

                    var Book = readTask.Result;
                    return View(Book);
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

        // GET: Course/Create
        public ActionResult Create()
        {
            Tbl_BookPublish book = new Tbl_BookPublish();
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
            return View(book);
        }

        // POST: Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookName,Publish_Date,FacultyID")] Tbl_BookPublish book)
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

                var postTask = client.PostAsJsonAsync<Tbl_BookPublish>("BookPublishAPI", book);
                postTask.Wait();

                var result1 = postTask.Result;

                if (result1.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(book);
        }
    }
}