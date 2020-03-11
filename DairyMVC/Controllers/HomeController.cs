using DairyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace DairyMVC.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection sqlcon = new SqlConnection();
        SqlCommand sqlcmd = new SqlCommand();
        SqlDataReader sqldr;


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult sendLoginCheck(mainLogin instance)
        {
            sqlcon.ConnectionString = "Data Source=DESKTOP-7U8UBCP\\SQLEXPRESS;Initial Catalog=DiaryDB;Integrated Security=True";




            sqlcon.Open();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = "select * from admin_table where login_name='" + instance.User + "' and login_pass='" + instance.Password + "'";

            sqldr = sqlcmd.ExecuteReader();

            if (sqldr.Read())
            {
                sqlcon.Close();
                return View("Working");
            }
            else
            {
                sqlcon.Close();
                return View("Invalid");
            }


        }



        public ActionResult Login()
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
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}