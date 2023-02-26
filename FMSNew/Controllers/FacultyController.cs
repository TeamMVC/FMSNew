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
    public class FacultyController : Controller
    {
        public string Url = "http://localhost:61500/api/";
        // GET: Faculty
        public ActionResult Index()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("FacultyAPI");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<GetFacultyData>>();
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

        // GET: Faculty/Details/5
        public ActionResult Details(int? id)
        {
            GetFacultyData Faculty = new GetFacultyData();
            FMSNew.Models.GetFacultyData resultData = new Models.GetFacultyData();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("FacultyAPI?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<GetFacultyData>();
                    readTask.Wait();
                    
                    resultData.Faculty_Name = readTask.Result.Faculty_Name;
                    resultData.Faculty_Qualification = readTask.Result.Faculty_Qualification;
                    resultData.Gender = readTask.Result.Gender;
                    resultData.ContactNo = readTask.Result.ContactNo;
                    resultData.Address = readTask.Result.Address;
                    resultData.Assign_Course = readTask.Result.Assign_Course;
                    resultData.Dept_Name = readTask.Result.Dept_Name;
                    resultData.EmailID = readTask.Result.EmailID;
                    resultData.Password = readTask.Result.Password;
                    Faculty = readTask.Result;
                }
            }
            return View(resultData);
        }

        // GET: Faculty/Create
        public ActionResult Create()
        {
            Tbl_Faculty Faculty = new Tbl_Faculty();
            //  tbl_Department.Dept_ID = 1;

            Faculty.Faculty_Name = string.Empty;
            Faculty.Faculty_Qualification = string.Empty;
          
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
                ViewBag.Department = new SelectList(Department, "Dept_ID", "Dept_Name");
               
            }

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
                ViewBag.Course = new SelectList(Course, "Course_ID", "Course_Name");

            }
            
            return View(Faculty);
        }

        // POST: Faculty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Faculty_ID,Faculty_Name,Faculty_Qualification,Gender,ContactNo,Address,Dept_ID,Assign_Course_ID,createdOn,updatedOn,createdBy,UpdatedBy,EmailID,Passward")] Tbl_Faculty Faculty,string Password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                Faculty.createdOn = DateTime.Now;
                Faculty.updatedOn = DateTime.Now;
                //HTTP POST
                IEnumerable<Tbl_Department> Department = null;

                using (var client2 = new HttpClient())
                {
                    client2.BaseAddress = new Uri(Url);
                    //HTTP GET
                    var responseTask = client2.GetAsync("DepartmentAPI");
                    responseTask.Wait();

                    var result2 = responseTask.Result;
                    if (result2.IsSuccessStatusCode)
                    {
                        var readTask = result2.Content.ReadAsAsync<IList<Tbl_Department>>();
                        readTask.Wait();
                        Department = readTask.Result;
                    }
                    ViewBag.Department = new SelectList(Department, "Dept_ID", "Dept_Name");

                }

                IEnumerable<Tbl_Course> Course = null;

                using (var client1 = new HttpClient())
                {
                    client1.BaseAddress = new Uri(Url);
                    //HTTP GET
                    var responseTask = client1.GetAsync("CourseAPI");
                    responseTask.Wait();

                    var result1 = responseTask.Result;
                    if (result1.IsSuccessStatusCode)
                    {
                        var readTask = result1.Content.ReadAsAsync<IList<Tbl_Course>>();
                        readTask.Wait();
                        Course = readTask.Result;
                    }
                    ViewBag.Course = new SelectList(Course, "Course_ID", "Course_Name");

                }

                var postTask = client.PostAsJsonAsync<Tbl_Faculty>("FacultyAPI", Faculty);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    tbl_UserLogin user = new tbl_UserLogin();
                    user.Email = Faculty.EmailID;
                    user.Passward = Password;
                    user.RoleId = 2;
                    user.Name = Faculty.Faculty_Name;
                    var postTask1 = client.PostAsJsonAsync<tbl_UserLogin>("UserLoginAPI",user);
                    postTask1.Wait();

                    var result1 = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(Faculty);
        }

        // GET: Faculty/Edit/5
        public ActionResult Edit(int? id)
        {
            Tbl_Faculty Faculty = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("FacultyAPI?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Tbl_Faculty>();
                    readTask.Wait();

                    Faculty = readTask.Result;
                    IEnumerable<Tbl_Department> Department = null;

                    using (var client2 = new HttpClient())
                    {
                        client2.BaseAddress = new Uri(Url);
                        //HTTP GET
                        var responseTask2 = client2.GetAsync("DepartmentAPI");
                        responseTask2.Wait();

                        var result2 = responseTask2.Result;
                        if (result2.IsSuccessStatusCode)
                        {
                            var readTask2 = result2.Content.ReadAsAsync<IList<Tbl_Department>>();
                            readTask2.Wait();
                            Department = readTask2.Result;
                        }
                        ViewBag.Department = new SelectList(Department, "Dept_ID", "Dept_Name");

                    }

                    IEnumerable<Tbl_Course> Course = null;

                    using (var client1 = new HttpClient())
                    {
                        client1.BaseAddress = new Uri(Url);
                        //HTTP GET
                        var responseTask1 = client1.GetAsync("CourseAPI");
                        responseTask1.Wait();

                        var result1 = responseTask1.Result;
                        if (result1.IsSuccessStatusCode)
                        {
                            var readTask1 = result1.Content.ReadAsAsync<IList<Tbl_Course>>();
                            readTask1.Wait();
                            Course = readTask1.Result;
                        }
                        ViewBag.Course = new SelectList(Course, "Course_ID", "Course_Name");

                    }
                }
            }
            return View(Faculty);
        }

        // POST: Faculty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Faculty_ID,Faculty_Name,Faculty_Qualification,Gender,ContactNo,Address,Dept_ID,Assign_Course_ID,createdOn,updatedOn,createdBy,UpdatedBy,EmailID,Passward")] Tbl_Faculty Faculty,string Password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                //HTTP POST
                IEnumerable<Tbl_Department> Department = null;

                using (var client2 = new HttpClient())
                {
                    client2.BaseAddress = new Uri(Url);
                    //HTTP GET
                    var responseTask2 = client2.GetAsync("DepartmentAPI");
                    responseTask2.Wait();

                    var result2 = responseTask2.Result;
                    if (result2.IsSuccessStatusCode)
                    {
                        var readTask2 = result2.Content.ReadAsAsync<IList<Tbl_Department>>();
                        readTask2.Wait();
                        Department = readTask2.Result;
                    }
                    ViewBag.Department = new SelectList(Department, "Dept_ID", "Dept_Name");

                }

                IEnumerable<Tbl_Course> Course = null;

                using (var client1 = new HttpClient())
                {
                    client1.BaseAddress = new Uri(Url);
                    //HTTP GET
                    var responseTask1 = client1.GetAsync("CourseAPI");
                    responseTask1.Wait();

                    var result1 = responseTask1.Result;
                    if (result1.IsSuccessStatusCode)
                    {
                        var readTask1 = result1.Content.ReadAsAsync<IList<Tbl_Course>>();
                        readTask1.Wait();
                        Course = readTask1.Result;
                    }
                    ViewBag.Course = new SelectList(Course, "Course_ID", "Course_Name");

                }
                var putTask = client.PutAsJsonAsync<Tbl_Faculty>("FacultyAPI?id=" + Faculty.Faculty_ID.ToString(), Faculty);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //tbl_UserLogin user = new tbl_UserLogin();
                    //user.Email = Faculty.EmailID;
                    //user.Passward = Password;
                    //user.RoleId = 2;
                    //user.Name = Faculty.Faculty_Name;
                    //if (Session["UserId"] != null)
                    //{
                    //    var postTask1 = client.PutAsJsonAsync<tbl_UserLogin>("UserLoginAPI?id=" + Session["UserId"].ToString(), user);
                    //    postTask1.Wait();

                    //    var result1 = putTask.Result;
                    //    if (result1.IsSuccessStatusCode)
                    //    {
                            return RedirectToAction("Index");
                    //    }
                    //}
                }
            }
            return View(Faculty);
        }

        // GET: Faculty/Delete/5
        public ActionResult Delete(int? id)
        {
            Tbl_Faculty Faculty = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("FacultyAPI?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Tbl_Faculty>();
                    readTask.Wait();

                    Faculty = readTask.Result;
                }
            }
            return View(Faculty);
        }

        // POST: Faculty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("FacultyAPI/" + id.ToString());
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
