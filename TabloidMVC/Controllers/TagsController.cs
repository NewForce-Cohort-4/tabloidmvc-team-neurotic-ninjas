using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabloidMVC.Models;
using TabloidMVC.Models.ViewModels;
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

        // GET: TagsController
        public ActionResult Index()
        {
            List<Tags> tags = _tagsRepository.GetAll().OrderBy(c => c.Name).ToList();
            return View(tags);
        }

        // GET: TagsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TagsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tags tags)
        {
            try
            {
            _tagsRepository.AddTags(tags);
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TagsController/Edit/5
        public ActionResult Edit(int id)
        {
            Tags tagToEdit = _tagsRepository.GetTagById(id);

            return View(tagToEdit);
        }

        // POST: TagsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tags tags)
        {
            try
            {
                _tagsRepository.EditTag(tags.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TagsController/Delete/5
        public ActionResult Delete(int id)
        {
            Tags tagToDelete = _tagsRepository.GetTagById(id);

            return View(tagToDelete);
        }

        // POST: TagsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Tags tags)
        {
            try
            {
                _tagsRepository.DeleteTag(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
