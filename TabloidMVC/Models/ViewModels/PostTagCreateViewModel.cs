using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabloidMVC.Models.ViewModels
{
    public class PostTagCreateViewModel
    {
        public List<Tags> TagOptions { get; set; }
        public List<Tags> CurrentTags { get; set; }
        public List<int> TagIdsToAdd { get; set; }
        public List<int> TagIdsToRemove { get; set; }
        public Post Post { get; set; }
    }
}
