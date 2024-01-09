using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ResumeProject_MongoDb_.DAL.Entities;
using ResumeProject_MongoDb_.DAL.Settings;
using System.Security.Cryptography.Pkcs;

namespace ResumeProject_MongoDb_.ViewComponents
{
    public class _ContactPartial : ViewComponent
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        public _ContactPartial(IDatabaseSettings _databaseSettings )
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
        }
        public IViewComponentResult Invoke()
        {
            var values = _contactCollection.Find(x => true).ToList();
            return View(values);
        }
       
    }
}
