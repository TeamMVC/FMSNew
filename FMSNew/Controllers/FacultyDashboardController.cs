using FMSAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace FMSNew.Controllers
{
    public class FacultyDashboardController : Controller
    {
        // GET: FacultyDashboard
        public string Url = "http://localhost:61500/api/";
        // GET: Faculty
        public ActionResult FacultyDashBoard()
        {

            GetFacultyData Faculty = new GetFacultyData();
            FMSNew.Models.GetFacultyData resultData = new Models.GetFacultyData();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("FacultyAPI?EmailId=" + Session["Email"].ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //var readTask = result.Content.ReadAsAsync<GetFacultyData>();
                    //  readTask.Wait();
                    var readTask = result.Content.ReadAsAsync<IEnumerable<GetFacultyData>>();
                    readTask.Wait();

                    var Faculty1 = readTask.Result.FirstOrDefault();
                    //return View(Faculty);
                    resultData.Faculty_Name = Faculty1.Faculty_Name;
                    resultData.Faculty_Qualification = Faculty1.Faculty_Qualification;
                    resultData.Gender = Faculty1.Gender;
                    resultData.ContactNo = Faculty1.ContactNo;
                    resultData.Address = Faculty1.Address;
                    resultData.Assign_Course = Faculty1.Assign_Course;
                    resultData.Dept_Name = Faculty1.Dept_Name;
                    resultData.EmailID = Faculty1.EmailID;
                    resultData.Password = Faculty1.Password;
                    //  resultData = readTask.Result.FirstOrDefault();
                }
            }
            return View(resultData);
        }

       
    }
}