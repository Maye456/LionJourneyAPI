using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LionJourneyApp.Models
{
    public class PostModel
    {
        [DisplayName("ID Number")]
        public int PostID { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Content")]
        public string Content { get; set; }


    public PostModel(int postID, string title, string content)
        {
            PostID = postID;
            Title = title;
            Content = content;
        }

        public PostModel()
        {

        }
    }
}
