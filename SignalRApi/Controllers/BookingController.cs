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

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();

            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var booking = new Booking
            {
                Name = createBookingDto.Name,
                Description = createBookingDto.Description,
                Mail = createBookingDto.Mail,
                Phone = createBookingDto.Phone,
                Date = createBookingDto.Date,
                PersonCount = createBookingDto.PersonCount
            };

            _bookingService.TAdd(booking);

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
            var booking = new Booking
            {
                BookingId = updateBookingDto.BookingId,
                Mail = updateBookingDto.Mail,
                Name = updateBookingDto.Name,
                Phone = updateBookingDto.Phone,
                Date = updateBookingDto.Date,
                PersonCount = updateBookingDto.PersonCount
            };

            _bookingService.TUpdate(booking);

            return Ok("Rezervasyon başarıyla silindi.");
        }

        [HttpGet("GetBooking/{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetById(id);

            return Ok(values);
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
