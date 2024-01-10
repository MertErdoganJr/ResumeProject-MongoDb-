using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ResumeProject_MongoDb_.DAL.Entities;
using ResumeProject_MongoDb_.DAL.Settings;

namespace ResumeProject_MongoDb_.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMongoCollection<Contact> _contactCollcetion;
        public ContactController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactCollcetion = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
        }
        public async Task<IActionResult> Index()
        {
            var values = await _contactCollcetion.Find(x => true).ToListAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactCollcetion.DeleteOneAsync(x=>x.ContactID == id);
            return RedirectToAction("Index");

        }

        //public async Task<IActionResult> MessageDetail(string id)
        //{
        //    var values = await _contactCollcetion.Find(x => x.ContactID == id).FirstOrDefaultAsync();
        //    return View(values);
        //}
    }
}
