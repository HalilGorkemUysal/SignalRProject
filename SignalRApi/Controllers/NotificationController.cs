using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _notificationService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }

        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationByFalse());
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var notification = new Notification()
            {
                Icon = createNotificationDto.Icon,
                Type = createNotificationDto.Type,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Description = createNotificationDto.Description,
                Status =false
            };
            _notificationService.TAdd(notification);
            return Ok("Ekleme işlemi başarıyla yapıldı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);

            return Ok("Bildirim Silindi.");
        }

        [HttpGet("GetNotification/{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            return Ok(value);
        }

        [HttpGet("NotificationStatusChangeToFalse/{id}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            _notificationService.TNotificationStatusChangeToFalse(id);
            return Ok("Güncelleme Yapıldı");
        }
        [HttpGet("NotificationStatusChangeToTrue/{id}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationStatusChangeToTrue(id);
            return Ok("Güncelleme Yapıldı");
        }


        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var notification = new Notification
            {
                NotificationId= updateNotificationDto.NotificationId,
                Icon = updateNotificationDto.Icon,
                Type = updateNotificationDto.Type,
                Date = updateNotificationDto.Date,
                Description = updateNotificationDto.Description,
                Status = updateNotificationDto.Status
            };

            _notificationService.TUpdate(notification);

            return Ok("Bildirim Güncellendi.");
        }
    }
}
