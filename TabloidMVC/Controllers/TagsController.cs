using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabloidMVC.Models;
using TabloidMVC.Repositories;

namespace TabloidMVC.Controllers
{
    [Authorize]
    public class TagsController : Controller
    {
        private readonly ITagsRepository _tagsRepository;
        private readonly IPostRepository _postRepository;

        public TagsController(ITagsRepository tagsRepository, IPostRepository postRepository)
        {
            _tagsRepository = tagsRepository;
            _postRepository = postRepository;
        }

        // GET: TagsController1
        public ActionResult Index()
        {
            List<Tags> tags = _tagsRepository.GetAll().OrderBy(c => c.Name).ToList();
            return View(tags);
        }

        // GET: TagsController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TagsController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TagsController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TagsController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TagsController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TagsController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
