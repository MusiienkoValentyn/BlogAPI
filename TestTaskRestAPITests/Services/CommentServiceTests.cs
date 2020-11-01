using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTaskRestAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TestTaskRestAPI.Interfaces;
using System.Linq;

namespace TestTaskRestAPI.Services.Tests
{
    [TestClass()]
    public class CommentServiceTests
    {
        [TestMethod()]
        public void GetCommentsByPostId_NotExistPost_ZeroCommentsReturned()
        {
            // arrange
            ICommentService commentService = new CommentService();

            // act
            var res = commentService.GetCommentsByPostId(0).Count();

            // assert
            Assert.AreEqual(res, 0);
        }

        [TestMethod()]
        public void GetCommentContent_ParamIs312_ItIsAwesomePlaceReturned()
        {
            // arrange
            ICommentService commentService = new CommentService();

            // act
            var res = commentService.GetComment(312).Content;

            // assert
            Assert.AreEqual(res, "It is awesome place!!!");
        }
    }
}