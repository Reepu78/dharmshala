﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dharmshalaAPI.Data;
using dharmshalaAPI.Model;
using NuGet.Protocol;

namespace dharmshalaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MembersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Members>>> GetMembers()
        {
          if (_context.Members == null)
          {
              return NotFound();
          }
            return await _context.Members.ToListAsync();
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Members>> GetMembers(int id)
        {
          if (_context.Members == null)
          {
              return NotFound();
          }
            var members = await _context.Members.FindAsync(id);

            if (members == null)
            {
                return NotFound();
            }

            return members;
        }

        // PUT: api/Members/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMembers(int id, Members members)
        {
            if (id != members.Id)
            {
                return BadRequest(new { Message = "Not Found Data!" });
            }
            
            _context.Entry(members).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembersExists(id))
                {
                    return BadRequest(new {Message="Not Found Data!"});
                }
                else
                {
                    throw;
                }
            }

            return Ok(new {Message="Data has been updated!"});
        }

        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Members>> PostMembers(Members members)
        {
          if (_context.Members == null)
          {
              return Problem("Entity set 'AppDbContext.Members'  is null.");
          }

          if (_context.Members.Any(e => e.Email == members.Email)== true)
            {
                return BadRequest(new {Message = "Email is Already Exit!"});
            }

            members.Created = DateTime.Now;
            members.Updated = DateTime.Now;
            _context.Members.Add(members);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMembers", new { id = members.Id }, members);
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembers(int id)
        {
            if (_context.Members == null)
            {
                return BadRequest(new {Message="No Record Found!"});
            }
            var members = await _context.Members.FindAsync(id);
            if (members == null)
            {
                return BadRequest(new { Message = "No Record Found!" });
            }

            _context.Members.Remove(members);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Record Deleted Successfuly!" });
        }

        private bool MembersExists(int id)
        {
            return (_context.Members?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
