using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabloidMVC.Models.ViewModels
{
    public class PostTagCreateViewModel
    {
        public List<Tags> TagOptions { get; set; }
        public List<int> TagIds { get; set; }
        //public List<int> TagsIdsToRemove { get; set; }
        public Post Post { get; set; }
    }
}
