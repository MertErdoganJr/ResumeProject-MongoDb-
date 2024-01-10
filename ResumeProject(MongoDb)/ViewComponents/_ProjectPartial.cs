using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ResumeProject_MongoDb_.DAL.Entities;
using ResumeProject_MongoDb_.DAL.Settings;

namespace ResumeProject_MongoDb_.ViewComponents
{
	public class _ProjectPartial : ViewComponent
	{
		private readonly IMongoCollection<Project> _projectCollection;
		public _ProjectPartial(IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_projectCollection = database.GetCollection<Project>(_databaseSettings.ProjectCollectionName);
		}
		public IViewComponentResult Invoke()
		{
			var values = _projectCollection.Find(x => true).ToList();
			return View(values);
		}
	}
}
