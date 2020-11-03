using AutoMapper;
using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
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
                var comments = _commentService.GetComments();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>()).CreateMapper();
                var result = mapper.Map<IEnumerable<CommentDTO>, List<CommentViewModel>>(comments);
                if (result == null)
                    return NotFound();
                return Ok(result);
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
                var comment = _commentService.GetComment(id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>()).CreateMapper();
                var result = mapper.Map<CommentDTO, CommentViewModel>(comment);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        // GET api/Comment/<GetComments>/5
        [HttpGet("GetComments/{id}")]
        public ActionResult GetPostsComments(int id)
        {
            try
            {
                var comment = _commentService.GetCommentsByPostId(id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserCommentDTO, UserCommentViewModel>()).CreateMapper();
                var result = mapper.Map<IEnumerable<UserCommentDTO>, List<UserCommentViewModel>>(comment);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        // POST api/<Comment>
        [HttpPost]
        public ActionResult CreateComment([FromBody] CommentViewModel comment)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentViewModel, CommentDTO>()).CreateMapper();
            CommentDTO result = mapper.Map<CommentViewModel, CommentDTO>(comment);
            try
            {
                _commentService.InsertComment(result);
                return Ok();
            }
            catch
            {
                throw;
            }

        }

        // PUT api/<Comment>
        [HttpPut]
        public ActionResult Update([FromBody] CommentViewModel comment)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentViewModel, CommentDTO>()).CreateMapper();
            CommentDTO result = mapper.Map<CommentViewModel, CommentDTO>(comment);

            try
            {
                _commentService.UpdateComment(result);
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
