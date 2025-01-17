﻿using System;
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
    public class EditionsController : ControllerBase
    {
        private readonly WebshopContext _context;

        public EditionsController(WebshopContext context)
        {
            _context = context;
        }

        // GET: api/Editions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Edition>>> GetEditions()
        {
            return await _context.Editions.ToListAsync();
        }

        // GET: api/Editions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Edition>> GetEdition(int id)
        {
            var edition = await _context.Editions.FindAsync(id);

            if (edition == null)
            {
                return NotFound();
            }

            return edition;
        }

        // PUT: api/Editions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEdition(int id, Edition edition)
        {
            if (id != edition.Id)
            {
                return BadRequest();
            }

            _context.Entry(edition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditionExists(id))
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

        // POST: api/Editions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Edition>> PostEdition(Edition edition)
        {
            _context.Editions.Add(edition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEdition", new { id = edition.Id }, edition);
        }

        // DELETE: api/Editions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Edition>> DeleteEdition(int id)
        {
            var edition = await _context.Editions.FindAsync(id);
            if (edition == null)
            {
                return NotFound();
            }

            _context.Editions.Remove(edition);
            await _context.SaveChangesAsync();

            return edition;
        }

        private bool EditionExists(int id)
        {
            return _context.Editions.Any(e => e.Id == id);
        }
    }
}
