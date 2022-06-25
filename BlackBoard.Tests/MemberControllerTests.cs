using BlackBoard.WebApi.Controllers;
using BlackBoard.WebApi.Intrerface;
using BlackBoard.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BlackBoard.Tests
{
    public class MemberControllerTests
    {
        private readonly MembersController _memberController;
        private readonly Mock<IMemberService> _memberService = new Mock<IMemberService>();

        public MemberControllerTests()
        {
            _memberController = new MembersController(_memberService.Object);
        }

        [Fact]
        public async Task Given_ValidRequest_ShouldReturn_Success_WhielAddingNewMember()
        {
            var mockRequest = ValidRequest();
            _memberService.Setup(service => service.Create(It.IsAny<Member>()));
            var response = await _memberController.Post(mockRequest);
            ((ObjectResult)response).StatusCode.Equals(HttpStatusCode.OK);
            _memberService.Verify(service => service.Create(mockRequest), Times.Once);
        }

        [Fact]
        public async Task Given_ValidRequest_ShouldReturn_Success_EditMember()
        {
            var mockRequest = ValidRequest();
            var id = 1;
            _memberService.Setup(service => service.Update(id, It.IsAny<Member>()));
            var response = await _memberController.Put(id, mockRequest);
            ((ObjectResult)response).StatusCode.Equals(HttpStatusCode.OK);
            _memberService.Verify(service => service.Update(id, mockRequest), Times.Once);
        }

        [Fact]
        public async Task Given_ValidRequest_ShouldReturn_Success_DeleteMember()
        {
            var id = 1;
            _memberService.Setup(service => service.Delete(It.IsAny<int>()));
            var response = await _memberController.Delete(id);
            ((ObjectResult)response).StatusCode.Equals(HttpStatusCode.OK);
            _memberService.Verify(service => service.Delete(id), Times.Once);
        }

        private Member ValidRequest()
        {
            return new Member()
            {
                FirstName = "Test_FirstName",
                MiddleName = "Test_LastName",
                LastName = "Test_LastName",
                Age = 39,
                Gender = "Male"
            };
        }
    }
}
