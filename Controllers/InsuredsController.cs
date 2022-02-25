#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GridironInsuranceAPI.Data;
using GridironInsuranceAPI.Models;
using AutoMapper;
using GridironInsuranceAPI.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace GridironInsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuredsController : ControllerBase
    {
        private readonly DataContext _context;

        private readonly IMapper _mapper;

        public InsuredsController(DataContext context, IMapper mapper)
        {
            _context = context;
          
            _mapper = mapper;
        }

        // GET: api/Insureds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsuredReadDto>>> GetInsureds()
        {
            var insureds = await _context.Insureds.Include(i => i.Address)
                                                   .Include(i => i.Rate)
                                                   .ToListAsync();

            var insuredReadDto = _mapper.Map<List<InsuredReadDto>>(insureds);
            
            return Ok(insuredReadDto);
        }


        // GET: api/Insureds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InsuredReadDto>> GetInsured(int id) 
        {
            var insured = await _context.Insureds.Include(i => i.Address)
                                                 .Include(i => i.Rate)
                                                 .FirstOrDefaultAsync(i => i.Id == id);

            if (insured == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<InsuredReadDto>(insured));
        }

        // PUT: api/Insureds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsured(int id, InsuredUpdateDto insuredUpdateDto)
        {
            var insured = await _context.Insureds.Include(i => i.Address)
                                                 .Include(i => i.Rate)
                                                 .FirstOrDefaultAsync(i => i.Id == id);

            if (id != insured.Id)
            {
                return BadRequest();
            }

            _mapper.Map(insuredUpdateDto, insured);

            _context.Entry(insured).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuredExists(id))
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

        // PATCH: api/Insureds/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialInsured(int id, JsonPatchDocument<InsuredUpdateDto> patchDoc)
        {
            var insured = await _context.Insureds.Include(i => i.Address)
                                                .Include(i => i.Rate)
                                                .FirstOrDefaultAsync(i => i.Id == id);

            if (insured == null)
            {
                return NotFound();
            }

            var insuredToPatch = _mapper.Map<InsuredUpdateDto>(insured);
            patchDoc.ApplyTo(insuredToPatch, ModelState);

            if (!TryValidateModel(insuredToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(insuredToPatch, insured);

            _context.Update(insured);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Insureds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Insured>> PostInsured(InsuredCreateDto insuredCreateDto)
        {
            var insured = _mapper.Map<Insured>(insuredCreateDto);

            _context.Insureds.Add(insured);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsured", new { id = insured.Id }, insured);
        }

        // DELETE: api/Insureds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsured(int id)
        {
            var insured = await _context.Insureds.Include(i => i.Address)
                                                 .Include(i => i.Rate)
                                                 .FirstOrDefaultAsync(i => i.Id == id);

            if (insured == null)
            {
                return NotFound();
            }

            _context.Insureds.Remove(insured);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InsuredExists(int id)
        {
            return _context.Insureds.Any(e => e.Id == id);
        }
    }
}
