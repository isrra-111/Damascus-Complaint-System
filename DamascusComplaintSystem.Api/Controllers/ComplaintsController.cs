using AutoMapper;
using DamascusComplaintSystem.Api.DTOs;
using DamascusComplaintSystem.Api.Enums;
using DamascusComplaintSystem.Api.Infrastructure.Repositories.Interfaces;
using DamascusComplaintSystem.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DamascusComplaintSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        private readonly IComplaintRepository _repository;
        private readonly IMapper _mapper;
        public ComplaintsController(IComplaintRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
                  
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ComplaintDto>>> GetAll()
        {
            var complaints = await _repository.GetAllAsync();

            var dtoList = _mapper.Map<List<ComplaintDto>>(complaints);

            return Ok(dtoList);

        }
        [HttpGet("{id}")]

        public async Task <ActionResult<ComplaintDto>>GetById(int id)
        {
            var complaint = await _repository.GetByIdWithComplaintTypeAsync(id);
            if (complaint == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<ComplaintReadDto>(complaint);
            return Ok(dto);

        }
        [HttpPost]
        public async Task<ActionResult<ComplaintDto>> Create([FromBody] ComplaintDto complaintDto)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);

            }
            try
            {

                var complaint = _mapper.Map<Complaint>(complaintDto);

                
                complaint.SubmittedAt = DateTime.Now;
                complaint.Status = (ComplaintStatus)complaintDto.ComplaintStatusId;

                await _repository.AddAsync(complaint);

                complaintDto.Id = complaint.Id;

                return CreatedAtAction(nameof(GetById), new { id = complaint.Id }, complaintDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"حدث خطأ أثناء إنشاء الشكوى: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody]ComplaintDto complaintDto)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState); }

            if (id != complaintDto.Id)
            {
                return BadRequest("رقم المعرف غير متطابق");
            }

            var existingComplaint = await _repository.GetByIdAsync(id);
            if (existingComplaint == null)
            {
                return NotFound("لم يتم العثور على الشكوى");
            }
            try
            {

                _mapper.Map(complaintDto, existingComplaint);

                if (complaintDto.ComplaintStatusId != 0)
                {
                    existingComplaint.Status = (ComplaintStatus)complaintDto.ComplaintStatusId;
                }


                await _repository.Update(existingComplaint);
                return StatusCode(200,$"تم تحديث بيانات الشكوى بنجاح.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"حدث خطأ أثناء تحديث الشكوى: {ex.Message}");
            }
            
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult>Delete(int id)
        {
            var existingComplaint=await _repository.GetByIdAsync(id);
            if (existingComplaint == null)
                return NotFound();

            try
            {
                await _repository.Delete(id);
                return StatusCode(200,$"تم حذف الشكوى بنجاح:");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"حدث خطأ أثناء حذف الشكوى: {ex.Message}");
            }

            
        }
    }
}
