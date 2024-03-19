using AutoMapper;
using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tools.Tools;

namespace LanDotBien_BackEnd.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomRegistrationsController : ControllerBase
    {
        private readonly IRoomRegistrationsService _roomRegistrationsService;
        private readonly IMapper _mapper;

        public RoomRegistrationsController(IRoomRegistrationsService roomRegistrationsService, IMapper mapper)
        {
            _roomRegistrationsService = roomRegistrationsService;
            _mapper = mapper;
        }

        [HttpPost("AddRoomRegistration")]
        public async Task<IActionResult> AddRoomRegistration(RoomRegistrationsDTORequest roomRegistrationsDTO)
        {
            try
            {
                var createdRoomRegistration = await _roomRegistrationsService.CreateAsync(roomRegistrationsDTO);
                var response = new ApiResponse<RoomRegistrationsDTOResponse>(createdRoomRegistration, HttpStatusCode.Accepted);
                return Ok(response);
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<RoomRegistrationsDTOResponse>(HttpStatusCode.Conflict, ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet("GetRoomRegistration/{id}")]
        public async Task<IActionResult> GetRoomRegistration(long id)
        {
            try
            {
                var roomRegistration = await _roomRegistrationsService.GetByIdAsync(id);
                return Ok(roomRegistration);
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<RoomRegistrationsDTOResponse>(HttpStatusCode.NotFound, ex.Message);
                return NotFound(response);
            }
        }

        [HttpPut("UpdateRoomRegistration/{id}")]
        public async Task<IActionResult> UpdateRoomRegistration(long id, RoomRegistrationsDTORequest roomRegistrationsDTO)
        {
            try
            {
                var updatedRoomRegistration = await _roomRegistrationsService.UpdateAsync(id, roomRegistrationsDTO);
                var response = new ApiResponse<RoomRegistrationsDTOResponse>(updatedRoomRegistration, HttpStatusCode.Accepted);
                return Ok(response);
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<RoomRegistrationsDTOResponse>(HttpStatusCode.Conflict, ex.Message);
                return BadRequest(response);
            }
        }

        [HttpDelete("DeleteRoomRegistration/{id}")]
        public async Task<IActionResult> DeleteRoomRegistration(long id)
        {
            try
            {
                await _roomRegistrationsService.DeleteAsync(id);
                var response = new ApiResponse<string>("Room registration deleted successfully", HttpStatusCode.OK);
                return Ok(response);
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<string>(HttpStatusCode.NotFound, ex.Message);
                return NotFound(response);
            }
        }
    }
}
