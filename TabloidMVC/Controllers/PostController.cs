using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System.Security.Claims;
using TabloidMVC.Models;
using TabloidMVC.Models.ViewModels;
using TabloidMVC.Repositories;

namespace TabloidMVC.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITagsRepository _tagRepository;
        private readonly IPostTagRepository _postTagRepository;

        public PostController(IPostRepository postRepository, ICategoryRepository categoryRepository, ITagsRepository tagRepository, IPostTagRepository postTagRepository)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _postTagRepository = postTagRepository;
        }

        public IActionResult Index()
        {
            var posts = _postRepository.GetAllPublishedPosts();
            return View(posts);
        }

        public IActionResult MyPostsIndex()
        {
            int currentUserId = GetCurrentUserProfileId();
            var posts = _postRepository.GetPostsByUserId(currentUserId);
            return View(posts);
        }

        public IActionResult Details(int id)
        {
            var post = _postRepository.GetPublishedPostById(id);
            if (post == null)
            {
                int userId = GetCurrentUserProfileId();
                post = _postRepository.GetUserPostById(id, userId);
                if (post == null)
                {
                    return NotFound();
                }
            }
            return View(post);
        }

        public IActionResult Create()
        {
            var vm = new PostCreateViewModel();
            vm.CategoryOptions = _categoryRepository.GetAll();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(PostCreateViewModel vm)
        {
            try
            {
                vm.Post.CreateDateTime = DateAndTime.Now;
                vm.Post.IsApproved = true;
                vm.Post.UserProfileId = GetCurrentUserProfileId();

                _postRepository.Add(vm.Post);

                return RedirectToAction("Details", new { id = vm.Post.Id });
            } 
            catch
            {
                vm.CategoryOptions = _categoryRepository.GetAll();
                return View(vm);
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            Post postToDelete = _postRepository.GetPublishedPostById(id);
            return View(postToDelete);
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Post post)
        {
            try
            {
                _postRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private int GetCurrentUserProfileId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }

        //--------------- Post Tag ----------------------
        // CREATE (GET) POST TAG: PostController/CreatePostTag/2
        public IActionResult CreatePostTag(int postId)
        {
            PostTagCreateViewModel vm = new PostTagCreateViewModel();
            vm.TagOptions = _tagRepository.GetAll();
            vm.Post = _postRepository.GetPublishedPostById(postId);
            return View(vm);
        }

        // CREATE (POST) POST TAG: PostController/CreatePostTag/2
        [HttpPost]
        public IActionResult CreatePostTag(PostTagCreateViewModel vm)
        {
            try
            {
                _postTagRepository.AddPostTag(vm.Post.Id, vm.TagsIdsToAdd);

                return RedirectToAction("Details", new { id = vm.Post.Id });
            }
            catch
            {
                vm.TagOptions = _tagRepository.GetAll();
                return View(vm);
            }
        }
    }
}
