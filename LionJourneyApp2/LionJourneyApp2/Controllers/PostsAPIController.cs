using LionJourneyApp.Models;
using LionJourneyApp.Service.DataService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Description;

namespace LionJourneyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PostsAPIController : ControllerBase
    {
        PostDataService repository = new PostDataService();

        public PostsAPIController()
        {
            repository = new PostDataService();
        }

        // No route specified since this is the default
        // /api/postsapi
        [HttpGet]
        [ResponseType(typeof(List<PostsDTO>))]
        public IEnumerable<PostsDTO> Index()
        {
            // Get the products
            List<PostModel> postList = repository.allPost();

            // Translate into DTO
            IEnumerable<PostsDTO> postDTOList = from p in postList
                                                   select
                                                     new PostsDTO(p.PostID, p.Title, p.Content);
            return postDTOList;
        }

        // GET /api/postsapi/searchresults/{searchTerm}
        [HttpGet("searchresults/{searchTerm}")]
        [ResponseType(typeof(List<PostsDTO>))]
        public IEnumerable<PostsDTO> SearchResults(string searchTerm)
        {
            List<PostModel> postList = repository.searchPost(searchTerm);

            // Translate into DTO
            List<PostsDTO> postDTOList = new List<PostsDTO>();
            foreach (PostModel p in postList)
            {
                postDTOList.Add(new PostsDTO(p.PostID, p.Title, p.Content));
            }
            return postDTOList;
        }

        // GET /api/postsapi/showonepost/3
        [HttpGet("showonepost/{Id}")]
        [ResponseType(typeof(PostsDTO))]
        public ActionResult<PostsDTO> ShowOnePost(int Id)
        {
            // Get the correct product from the database
            PostModel post = repository.getPostByID(Id);

            // Create a new DTO based on the project
            PostsDTO postDTO = new PostsDTO(post.PostID, post.Title, post.Content);

            // Return the DTO instead of the product
            return postDTO;
        }

        // GET /api/postsapi/deletebyid/1
        [HttpPut("deletebyid/{id}")]
        public ActionResult<IEnumerable<PostModel>> DeleteOnePost(int id)
        {
            repository.deletePost(id);
            return repository.allPost();
        }

        // GET /api/postsapi/createpost
        [HttpPost("createpost")]
        public ActionResult<IEnumerable<PostModel>> CreatePost(PostModel post)
        {
            repository.createPost(post);
            return repository.allPost();
        }

        // GET /api/postsapi/createpost
        [HttpPut("updatepost")]
        public ActionResult<IEnumerable<PostModel>> UpdatePost(PostModel post)
        {
            repository.Update(post);
            return repository.allPost();
        }
    }
}
