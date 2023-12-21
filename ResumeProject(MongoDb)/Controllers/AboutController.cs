using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ResumeProject_MongoDb_.DAL.Entities;
using ResumeProject_MongoDb_.DAL.Settings;

namespace ResumeProject_MongoDb_.Controllers
{
    public class AboutController : Controller
    {
        private readonly IMongoCollection<About> _about;
        public AboutController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _about = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
