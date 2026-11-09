using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListAll();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            var message = new Message
            {
                Mail = createMessageDto.Mail,
                Phone = createMessageDto.Phone,
                MessageContent = createMessageDto.MessageContent,
                Subject = createMessageDto.Subject,
                MessageSendDate= createMessageDto.MessageSendDate,
                NameSurname = createMessageDto.NameSurname,
                Status = createMessageDto.Status
            };

            _messageService.TAdd(message);

            return Ok("Mesaj başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetById(id);
            _messageService.TDelete(value);

            return Ok("Mesaj silindi.");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var message = new Message
            {
                MessageId = updateMessageDto.MessageId,
                Mail = updateMessageDto.Mail,
                Phone = updateMessageDto.Phone,
                MessageContent = updateMessageDto.MessageContent,
                Subject = updateMessageDto.Subject,
                MessageSendDate = updateMessageDto.MessageSendDate,
                NameSurname = updateMessageDto.NameSurname,
                Status = updateMessageDto.Status
            };


            _messageService.TUpdate(message);

            return Ok("Mesaj güncellendi.");
        }

        [HttpGet("GetMessage/{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetById(id);
            return Ok(value);
        }
    }
}
