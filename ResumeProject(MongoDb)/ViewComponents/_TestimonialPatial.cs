using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ResumeProject_MongoDb_.DAL.Entities;
using ResumeProject_MongoDb_.DAL.Settings;

namespace ResumeProject_MongoDb_.ViewComponents
{
    public class _TestimonialPatial : ViewComponent
    {
		private readonly IMongoCollection<Testimonial> _testimonialCollection;
		public _TestimonialPatial(IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_testimonialCollection = database.GetCollection<Testimonial>(_databaseSettings.TestimonialCollectionName);

		}
		public IViewComponentResult Invoke()
		{
			var values = _testimonialCollection.Find(x => true).ToList();
			return View(values);
		}
	}
}
