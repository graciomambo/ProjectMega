using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gamer.Context;
using Gamer.Models;
using System.IO;

namespace Gamer.Controllers
{
    public class PostsController : Controller
    {
        private GamerContext db = new GamerContext();

        // GET: Posts
        public async Task<ActionResult> Index()
        {
            var posts = db.Posts.Include(p => p.Category).Include(p => p.PostType);
            return View(await posts.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
      

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");           
            ViewBag.PostTypeId = new SelectList(db.PostTypes,"PostTypeId", "Name");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PostId,PostTypeId,LayoutId,CategoryId,Title,CreatedDate,PostedDate,Content,Url,Excerpt,Active")] Post post, HttpPostedFileBase url)
        {
           

            if (ModelState.IsValid)
            {
                try
                {
                    if (url != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Files"), Path.GetFileName(url.FileName));
                        url.SaveAs(path);
                        post.validateAttributes();
                        db.Posts.Add(post);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
                {
                    ViewBag.FileStatus = "Error while file uploading."; ;
                }

            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", post.CategoryId);
            ViewBag.PostTypeId = new SelectList(db.PostTypes, "PostTypeId", "Name", post.PostTypeId);
            return View(post);
        }

    

        // GET: Posts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", post.CategoryId);         
            ViewBag.PostTypeId = new SelectList(db.PostTypes, "PostTypeId", "Name", post.PostTypeId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PostId,PostTypeId,LayoutId,CategoryId,Title,CreatedDate,PostedDate,Content,Url,Excerpt,Active")] Post post)
        {
           
            if (ModelState.IsValid)
            {
                post.validateAttributes();
                db.Entry(post).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", post.CategoryId);
          
            ViewBag.PostTypeId = new SelectList(db.PostTypes, "PostTypeId", "Name", post.PostTypeId);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Post post = await db.Posts.FindAsync(id);
            db.Posts.Remove(post);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // GET: Posts/Details/5
        public async Task<ActionResult> Browse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            post.Views++;
            return View(post);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
