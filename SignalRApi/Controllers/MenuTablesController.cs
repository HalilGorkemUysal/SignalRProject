using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTablesController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            var values = _menuTableService.TMenuTableCount();

            return Ok(values);
        }
        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = _menuTableService.TGetListAll();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            var menuTable = new MenuTable
            {
                Name = createMenuTableDto.Name,
                Status = false
            };

            _menuTableService.TAdd(menuTable);

            return Ok("Masa başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            _menuTableService.TDelete(value);

            return Ok("Masa silindi.");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            var menuTable = new MenuTable
            {
                MenuTableId = updateMenuTableDto.MenuTableId,
                Name = updateMenuTableDto.Name,
                Status = false
            };

            _menuTableService.TUpdate(menuTable);

            return Ok("Masa güncellendi.");
        }

        [HttpGet("GetMenuTable/{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            return Ok(value);
        }
    }
}
