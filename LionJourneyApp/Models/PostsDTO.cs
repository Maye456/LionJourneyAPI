using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LionJourneyApp.Models
{
    public class PostsDTO
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public PostsDTO(int postID, string title, string content)
        {
            PostID = postID;
            Title = title;
            Content = content;
        }
    }
}
