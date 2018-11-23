using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order2.API.Controllers.Items.DTO;
using Order2.API.Controllers.Items.Mapper;
using Order2.Domain.Items;
using Order2.Services.Items;

namespace Order2.API.Controllers.Items
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IItemMapper _itemsMapper;

        public ItemsController(IItemService itemService, IItemMapper itemsMapper)
        {
            _itemService = itemService;
            _itemsMapper = itemsMapper;
        }

        [HttpPost]
        public ActionResult<Item> CreateItem([FromBody]ItemDTO_Request itemDTO)
        {
            try
            {
                var item = _itemService.CreateItem(_itemsMapper.ToDomain(itemDTO));
                return Ok(_itemsMapper.ToDTO(item));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}