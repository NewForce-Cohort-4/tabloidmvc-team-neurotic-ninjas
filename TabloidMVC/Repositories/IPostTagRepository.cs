using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public interface IPostTagRepository
    {
        void AddPostTag(int postId, List<int> tagIds);
        void DeletePostTag(int postTagId);
    }
}
