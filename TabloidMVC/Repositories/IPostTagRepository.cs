using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public interface IPostTagRepository
    {
        List<Tags> GetPostTags(int postId);
        void AddPostTag(int postId, List<int> tagIds);
        void DeletePostTag(int postTagId, List<int> tagIds);
    }
}
