using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ResumeProject_MongoDb_.DAL.Entities;
using ResumeProject_MongoDb_.DAL.Settings;

namespace ResumeProject_MongoDb_.Controllers
{
    public class DefaultController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }
    }
}
