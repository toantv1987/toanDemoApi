using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using toanDemoApi.Data.Entities;
using toanDemoApi.Service;
using toanDemoApi.Service.Interfaces;
namespace toanDemoApi.Controllers
{
    [ApiController]
    [Route("api/v1/orderItems")]
    public class OrderItemController : ControllerBase
    {
        private IOrderItemRepository _orderItemRepository;
        public OrderItemController(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository ?? throw new ArgumentNullException(nameof(orderItemRepository));
        }
        [HttpGet()]
        public ActionResult<IEnumerable<OrderItem>> GetOrderItem()
        {
            var orderItemsFromRepo = _orderItemRepository.GetOrderItem();
            return Ok(orderItemsFromRepo);
        }
        [HttpGet("{orderItemId}",Name = "GetOrderItem")]
        public ActionResult<OrderItem> GetOrderItem(int orderItemId)
        {
            var orderItemsFromRepo = _orderItemRepository.GetOrderItem(orderItemId);
            if (orderItemsFromRepo==null)
            {
                return NotFound();
            }
            return Ok(orderItemsFromRepo);
        }
        [HttpPost]
        public ActionResult<OrderItem> AddOrderItem(OrderItem orderItem)
        {
            _orderItemRepository.AddOrderItem(orderItem);
            _orderItemRepository.Save();

            return CreatedAtRoute("GetOrderItem", new { orderItem.OrderItemId }, orderItem);
        }
    }
}
