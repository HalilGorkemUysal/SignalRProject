using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());

            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            createDiscountDto.Status = false;
            var value = _mapper.Map<Discount>(createDiscountDto);

            _discountService.TAdd(value);

            return Ok("İndirim Başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);

            _discountService.TDelete(value);
            return Ok("İndirim Başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var value = _mapper.Map<Discount>(updateDiscountDto);

            _discountService.TUpdate(value);
            return Ok("İndirim Başarıyla Güncellendi");
        }

        [HttpGet("GetDiscount/{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);

            return Ok(_mapper.Map<GetDiscountDto>(value));
        }

        [HttpGet("ChangeStatusToFalse/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _discountService.TChangeStatusToFalse(id);

            return Ok("Ürün İndirimi Pasif Hale getirildi.");
        }

        [HttpGet("ChangeStatusToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _discountService.TChangeStatusToTrue(id);

            return Ok("Ürün İndirimi Aktif Hale getirildi.");
        }

        [HttpGet("GetListByStatusTrue")]
        public IActionResult GetListByStatusTrue()
        {
            var values = _discountService.TGetListByStatusTrue();

            return Ok(values);
        }
    }
}
