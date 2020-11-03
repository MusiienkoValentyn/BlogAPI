using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BLL.Services;
using DAL.Interfaces;
using BLL;
using DAL.Entities;
using TestTaskRestAPI.Controllers;
using BLL.Interfaces;
using Moq;

namespace TestTaskRestAPI.Services.Tests
{
    [TestClass()]
    public class CommentServiceTests
    {
        private Mock<ICommentService> service= new Mock<ICommentService>();

        [TestMethod()]
        public void CountComments_AllComments_TwoCommentsReturned()
        {
            // arrange
            var mock = new Mock<ICommentService>();
            mock.Setup(r => r.GetComments());
            var controller = new CommentController(mock.Object);

            // act
            var res = controller.Get();

            // assert
            
            Assert.AreEqual(res, 2);
        }

        [TestMethod()]
        public void GetCommentContent_ParamIs312_ItIsAwesomePlaceReturned()
        {
            
            // arrange

            // act
           

            // assert
          
           // Assert.AreEqual(res, "It is awesome place");
        }
    }
}