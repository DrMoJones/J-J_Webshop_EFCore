using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webshop.Data;
using Webshop.Domain;

namespace WebshopAPI.Controllers
{
    public class Cart
    {
        public int productId { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int amount { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class OrderLinesController : ControllerBase
    {
        private readonly WebshopContext _context;
        

        public OrderLinesController(WebshopContext context)
        {
            _context = context;
        }

        // GET: api/OrderLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderLine>>> GetOrderLines()
        {
            return await _context.OrderLines.ToListAsync();
        }

        // GET: api/OrderLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<OrderLine>>> GetOrderLine(int id)
        {
            var orderLine = await _context.OrderLines
                .Where(s => s.OrderId == id)
                .Include(s => s.Product)
                .ThenInclude(s => s.Genre)
                .ToListAsync();

            if (orderLine == null)
            {
                return NotFound();
            }

            return orderLine;
        }

        // PUT: api/OrderLines/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderLine(int id, OrderLine orderLine)
        {
            if (id != orderLine.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderLineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderLines
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrderLine>> PostOrderLine(List<Cart> carts)
        {
            Order order = new Order
            {
                StatusId = 1,
                CustomerId = 1,
                Date = DateTime.Now
            };            
        
            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            OrderLine orderLine;
            for (int i = 0; i <= carts.Count; i++)
            {
                var product = await _context.Products.Where(s => s.Id == carts[i].productId).FirstOrDefaultAsync();

                orderLine = new OrderLine
                {
                    OrderId = order.Id,
                    ProductId = carts[i].productId,
                    Amount = carts[i].amount,
                    Price = product.Price * carts[i].amount
                };
                _context.OrderLines.Add(orderLine);
                await _context.SaveChangesAsync();

            }

            orderLine = new OrderLine();
            
            return CreatedAtAction("GetOrderLine", new { id = orderLine.Id }, orderLine);
        }

        // DELETE: api/OrderLines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderLine>> DeleteOrderLine(int id)
        {
            var orderLine = await _context.OrderLines.FindAsync(id);
            if (orderLine == null)
            {
                return NotFound();
            }

            _context.OrderLines.Remove(orderLine);
            await _context.SaveChangesAsync();

            return orderLine;
        }

        private bool OrderLineExists(int id)
        {
            return _context.OrderLines.Any(e => e.Id == id);
        }
    }
}
