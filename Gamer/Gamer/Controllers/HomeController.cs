using Gamer.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace Gamer.Controllers
{
    public class HomeController : Controller
    {
        GamerContext db = new GamerContext();
        public async Task<ActionResult> Index()
        {
            var posts = db.Posts.OrderByDescending(o => o.PostedDate).Where(s=>s.Active==true).Take(4).Include(p => p.Category).Include(p => p.PostType);
            return View(await posts.ToListAsync());
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
        public ActionResult PaginationPost(int? page)
        {

            var posts = db.Posts.Include(p => p.Category).Include(p => p.PostType);

            return View(posts.OrderBy(a => a.PostedDate).ToPagedList(pageNumber: page ?? 1, pageSize: 6));
        }
    }
}