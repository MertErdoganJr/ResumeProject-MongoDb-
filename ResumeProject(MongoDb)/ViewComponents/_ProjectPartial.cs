using Microsoft.AspNetCore.Mvc;

namespace ResumeProject_MongoDb_.ViewComponents
{
    public class _ProjectPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
