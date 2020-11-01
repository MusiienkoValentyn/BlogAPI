using Microsoft.AspNetCore.Mvc;
using TestTaskRestAPI.Interfaces;
using TestTaskRestAPI.Models;


namespace TestTaskRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: api/<Comment>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_commentService.GetComments());
            }
            catch
            {
                throw;
            }
        }

        // GET api/<Comment>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(_commentService.GetComment(id));
            }
            catch
            {
                throw;
            }
        }

        // GET api/<Comment>/5
        [HttpGet("GetComments/{id}")]
        public ActionResult GetPostsComments(int id)
        {
            try
            {
                return Ok(_commentService.GetCommentsByPostId(id));
            }
            catch
            {
                throw;
            }
        }

        // POST api/<Comment>
        [HttpPost]
        public ActionResult CreateComment([FromBody] CommentModel comment)
        {
            try
            {
                _commentService.InsertComment(comment);
                return Ok();
            }
            catch
            {
                throw;
            }

        }

        // PUT api/<Comment>
        [HttpPut]
        public ActionResult Update([FromBody] CommentModel comment)
        {
            try
            {
                _commentService.UpdateComment(comment);
                return Ok();
            }
            catch
            {
                throw;
            }
        }

        // DELETE api/<Comment>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _commentService.DeleteComment(id);
                return Ok();
            }
            catch
            {
                throw;
            }
        }
    }
}
