

using AutoMapper;
using DamascusComplaintSystem.Api.Controllers;
using DamascusComplaintSystem.Api.Infrastructure.Repositories.Interfaces;
using DamascusComplaintSystem.Api.Mapping;
using Moq;
using DamascusComplaintSystem.Api.DTOs;
using DamascusComplaintSystem.Api.Enums;
using DamascusComplaintSystem.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
namespace DamascusComplaintSystem.Test.Controllers
{
    public class ComplaintsControllerTests
    {
        private readonly Mock<IComplaintRepository> _mockRepo;
        private readonly IMapper _mapper;
        private readonly DamascusComplaintSystem.Api.Controllers.ComplaintsController _controller;

        public ComplaintsControllerTests()
        {
            _mockRepo = new Mock<IComplaintRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = config.CreateMapper();

            _controller = new DamascusComplaintSystem.Api.Controllers.ComplaintsController(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task GetById_ReturnsOk_WhenComplaintExists()
        {
            // Arrange
            var complaint = new Complaint
            {
                Id = 1,
                FullName = "محمد",
                NationalId = "12345678901",
                ComplaintType = new ComplaintType { Name = "مياه", ArabicName = "مياه" },
                Status = ComplaintStatus.Received
            };

            _mockRepo.Setup(r => r.GetByIdWithComplaintTypeAsync(1)).ReturnsAsync(complaint);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var dto = Assert.IsType<ComplaintReadDto>(okResult.Value);
            Assert.Equal("محمد", dto.FullName);
            Assert.Equal("تم الاستلام", dto.ComplaintStatusArabicName);
        }
        [Fact]
        public async Task GetAll_ReturnsListOfComplaintDtos()
        {
            // Arrange
            var complaints = new List<Complaint>
    {
        new Complaint { Id = 1, FullName = "أحمد", ComplaintText = "نص الشكوى", Status = ComplaintStatus.Received },
        new Complaint { Id = 2, FullName = "منى", ComplaintText = "شكوى أخرى", Status = ComplaintStatus.Resolved }
    };

            _mockRepo.Setup(repo => repo.GetAllAsync())
                     .ReturnsAsync(complaints);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<ComplaintDto>>(okResult.Value);

            Assert.Equal(2, returnValue.Count);
            Assert.Contains(returnValue, c => c.FullName == "أحمد");
            Assert.Contains(returnValue, c => c.FullName == "منى");
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenComplaintDoesNotExist()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetByIdWithComplaintTypeAsync(999)).ReturnsAsync((Complaint?)null); // nofound Complaint

            // Act
            var result = await _controller.GetById(999);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Create_ReturnsCreatedAtAction_WhenValidComplaint()
        {
            _controller.ModelState.Clear(); 
            // Arrange
            var createDto = new ComplaintDto
            {
                FullName = "خالد العمري",
                NationalId = "90014768329",
                ComplaintText = "تعدي على املاك الغير",
                ComplaintTypeId = 2
            };

            var complaint = new Complaint
            {
                Id = 15,
                FullName = "خالد العمري",
                NationalId = "90014768329",
                ComplaintText = "تعدي على املاك الغير",
                ComplaintTypeId = 2,
                Status = ComplaintStatus.Received
            };

            _mockRepo.Setup(r => r.AddAsync(It.IsAny<Complaint>()))
             .Callback<Complaint>(c => c.Id = 15)
             .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Create(createDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<ComplaintDto>(createdAtActionResult.Value);
            Assert.Equal("خالد العمري", returnValue.FullName);
        }
        [Fact]
        public async Task Update_ReturnsOk_WhenComplaintExists()
        {
            // Arrange
            var id = 15;

            var updateDto = new ComplaintDto
            {
                Id = id, 
                FullName = "خالد العمري",
                NationalId = "90014768329",
                ComplaintText = "تعدي على املاك الغير",
                ComplaintTypeId = 2,
                ComplaintRepeatCount = 1,
                ComplaintStatusId = (int)ComplaintStatus.Resolved
            };

            var existingComplaint = new Complaint
            {
                Id = id,
                FullName = "خالد العمري",
                NationalId = "90014768329",
                ComplaintText = "تعدي على املاك الغير",
                ComplaintTypeId = 2,
                Status = ComplaintStatus.Received
            };

            _mockRepo.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(existingComplaint);
            _mockRepo.Setup(r => r.Update(It.IsAny<Complaint>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Update(id, updateDto);

            // Assert
            var okResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal("تم تحديث بيانات الشكوى بنجاح.", okResult.Value);
        }




    }
}