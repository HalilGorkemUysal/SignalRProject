using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ReferenceDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceController : ControllerBase
    {
        private readonly IReferenceService _referenceService;
        private readonly IMapper _mapper;

        public ReferenceController(IReferenceService referenceService, IMapper mapper)
        {
            _referenceService = referenceService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ReferenceList()
        {
            var value = _mapper.Map<List<ResultReferenceDto>>(_referenceService.TGetListAll());

            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateReference(CreateReferenceDto createReferenceDto)
        {
            var value = _mapper.Map<Reference>(createReferenceDto);

            _referenceService.TAdd(value);

            return Ok("Referans Başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReference(int id)
        {
            var value = _referenceService.TGetById(id);

            _referenceService.TDelete(value);
            return Ok("Referans Başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateReference(UpdateReferenceDto updateReferenceDto)
        {
            var value = _mapper.Map<Reference>(updateReferenceDto);

            _referenceService.TUpdate(value);
            return Ok("Referans Başarıyla Güncellendi");
        }

        [HttpGet("GetReference/{id}")]
        public IActionResult GetReference(int id)
        {
            var value = _referenceService.TGetById(id);

            return Ok(_mapper.Map<GetReferenceDto>(value));
        }
    }
}
