using FMSAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Security;

namespace FMSNew.Models
{
    public class CustomRoleProvide : RoleProvider
    {
        public string Url = "http://localhost:61500/api/";
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            IEnumerable<tbl_UserLogin> login = null;
            IEnumerable<tbl_Role> Role = null;
            IEnumerable<Tbl_RoleMapping> RoleMapping = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("UserLoginAPI");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<tbl_UserLogin>>();
                    readTask.Wait();

                    login = readTask.Result;
                }
              
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("RoleAPI");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask1 = result.Content.ReadAsAsync<IList<tbl_Role>>();
                    readTask1.Wait();

                    Role = readTask1.Result;
                }

            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("RoleMappingAPI");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask2 = result.Content.ReadAsAsync<IList<Tbl_RoleMapping>>();
                    readTask2.Wait();

                    RoleMapping = readTask2.Result;
                }

            }
            var User = (from u in login
                        join m in RoleMapping
                        on u.Id equals m.UserID
                        join r in Role
                        on m.RoleID equals r.RoleId
                        where u.Name == username
                        select r.RoleName).ToArray();

            return User;
            }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}