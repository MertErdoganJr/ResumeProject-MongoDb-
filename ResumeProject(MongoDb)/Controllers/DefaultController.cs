using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ResumeProject_MongoDb_.DAL.Entities;
using ResumeProject_MongoDb_.DAL.Settings;

namespace ResumeProject_MongoDb_.Controllers
{
    public class DefaultController : Controller
    {    
        private readonly IMongoCollection<Contact> _contactsCollection;
        public DefaultController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactsCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Contact contact)
        {
            await _contactsCollection.InsertOneAsync(contact);
            return RedirectToAction("Index");
        }
    }
}
