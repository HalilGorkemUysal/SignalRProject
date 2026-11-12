using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();

            return Ok(_mapper.Map<ResultBookingDto>(values));
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {

            _bookingService.TAdd(_mapper.Map<Booking>(createBookingDto));

            return Ok("Rezervasyon başarıyla oluşturuldu.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);

            _bookingService.TDelete(value);

            return Ok("Rezervasyon başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var booking = _mapper.Map<Booking>(updateBookingDto);

            _bookingService.TUpdate(booking);

            return Ok("Rezervasyon başarıyla silindi.");
        }

        [HttpGet("GetBooking/{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetById(id);

            return Ok(_mapper.Map<GetBookingDto>(values));
        }

        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.TBookingStatusApproved(id);

            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }

        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            _bookingService.TBookingStatusCancelled(id);

            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }
    }
}
