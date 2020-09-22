using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webshop.Data;
using Webshop.Domain;

namespace WebshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVersionsController : ControllerBase
    {
        private readonly WebshopContext _context;

        public ProductVersionsController(WebshopContext context)
        {
            _context = context;
        }

        // GET: api/ProductVersions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVersion>>> GetProductVersions()
        {
            return await _context.ProductVersions.ToListAsync();
        }

        // GET: api/ProductVersions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVersion>> GetProductVersion(int id)
        {
            var productVersion = await _context.ProductVersions.FindAsync(id);

            if (productVersion == null)
            {
                return NotFound();
            }

            return productVersion;
        }

        // PUT: api/ProductVersions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductVersion(int id, ProductVersion productVersion)
        {
            if (id != productVersion.Id)
            {
                return BadRequest();
            }

            _context.Entry(productVersion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductVersionExists(id))
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

        // POST: api/ProductVersions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductVersion>> PostProductVersion(ProductVersion productVersion)
        {
            _context.ProductVersions.Add(productVersion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductVersion", new { id = productVersion.Id }, productVersion);
        }

        // DELETE: api/ProductVersions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductVersion>> DeleteProductVersion(int id)
        {
            var productVersion = await _context.ProductVersions.FindAsync(id);
            if (productVersion == null)
            {
                return NotFound();
            }

            _context.ProductVersions.Remove(productVersion);
            await _context.SaveChangesAsync();

            return productVersion;
        }

        private bool ProductVersionExists(int id)
        {
            return _context.ProductVersions.Any(e => e.Id == id);
        }
    }
}
