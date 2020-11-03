using AutoMapper;
using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            try
            {
                var posts = _postService.GetPosts();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PostDTO, PostViewModel>()).CreateMapper();
                var result = mapper.Map<IEnumerable<PostDTO>, List<PostViewModel>>(posts);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch
            {

                throw;
            }

        }

        // GET api/<Post>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var post = _postService.GetPost(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PostDTO, PostViewModel>()).CreateMapper();
            var result = mapper.Map<PostDTO, PostViewModel>(post);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST api/<Post>
        [HttpPost]
        public ActionResult Create([FromForm] PostViewModel post)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PostViewModel, PostDTO>()).CreateMapper();
            PostDTO result = mapper.Map<PostViewModel, PostDTO>(post);
            try
            {
                _postService.InsertPost(result);
                return Ok();
            }
            catch
            {

                throw;
            }
        }

        // PUT api/<Post>
        [HttpPut]
        public ActionResult Update([FromForm] PostViewModel post)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PostViewModel, PostDTO>()).CreateMapper();
            PostDTO result = mapper.Map<PostViewModel, PostDTO>(post);
            try
            {
                _postService.UpdatePost(result);
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
            try
            {
                return Ok(_postService.GetPostsAndComments());
            }
            catch
            {
                throw;
            }
        }
    }
}
