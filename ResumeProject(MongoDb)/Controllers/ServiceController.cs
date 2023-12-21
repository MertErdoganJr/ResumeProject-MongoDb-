using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ResumeProject_MongoDb_.DAL.Entities;
using ResumeProject_MongoDb_.DAL.Settings;

namespace ResumeProject_MongoDb_.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IMongoCollection<Service> _serviceCollection;
        public ServiceController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _serviceCollection = database.GetCollection<Service>(_databaseSettings.ServiceCollectionName);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
