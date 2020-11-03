using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestTaskRestAPI.Models;


namespace TestTaskRestAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        // GET: api/<Post>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_postService.GetPosts());
        }

        // GET api/<Post>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_postService.GetPost(id));
        }

        // POST api/<Post>
        [HttpPost]
        public ActionResult Create([FromForm] PostModel post)
        {
            try
            {
                _postService.InsertPost(post);
                return Ok();
            }
            catch
            {

                throw;
            }
        }

        // PUT api/<Post>
        [HttpPut]
        public ActionResult Update([FromForm] PostModel post)
        {
            try
            {
                _postService.UpdatePost(post);
                return Ok();
            }
            catch
            {

                throw;
            }
        }

        // DELETE api/<Post>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _postService.DeletePost(id);
                return Ok();
            }
            catch
            {
                throw;
            }
        }
        // GET: api/<Post>/GetPosts&Comments
        [Authorize] // JWT should be insert like Autorize param.
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        [HttpGet("GetPosts&Comments")]
        public ActionResult GetPostsAndComments()
        {
            return Ok(_postService.GetPostsAndComments());
        }
    }
}
