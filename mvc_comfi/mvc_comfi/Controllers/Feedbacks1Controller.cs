using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_comfi.Models.comfi;

namespace mvc_comfi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Feedbacks1Controller : ControllerBase
    {
        private  comfifurnituresContext _context;

        public Feedbacks1Controller(comfifurnituresContext context)
        {
            _context = context;
        }

        
        // GET: api/Feedbacks1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
        {
            Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Origin", "*"));
            Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Headers", "Origin,X-Requested-With,Content-Type,Accept,Authorization"));
            return await _context.Feedbacks.ToListAsync();
        }

        // GET: api/Feedbacks1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedback(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);

            if (feedback == null)
            {
                return NotFound();
            }
            Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Origin", "*"));
            Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Headers", "Origin,X-Requested-With,Content-Type,Accept,Authorization"));
            return feedback;
        }

        // PUT: api/Feedbacks1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedback(int id, Feedback feedback)
        {
            if (id != feedback.Id)
            {
                return BadRequest();
            }
            Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Origin", "*"));
            Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Headers", "Origin,X-Requested-With,Content-Type,Accept,Authorization"));
            _context.Entry(feedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(id))
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

        // POST: api/Feedbacks1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        public async Task<ActionResult<Feedback>> PostFeedback(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Origin", "*"));
            Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Headers", "Origin,X-Requested-With,Content-Type,Accept,Authorization"));
            return CreatedAtAction("GetFeedback", new { id = feedback.Id }, feedback);
        }

        //[HttpPost]
        //public IActionResult Register(Feedback feedback)
        //{
        //    var register = new Feedback();
        //    register.FirstName = feedback.FirstName;
        //    register.LastName = feedback.LastName;

        //    register.Email = feedback.Email;
        //    register.Suggestions = feedback.Suggestions;





        //    _context.Feedbacks.Add(register);
        //    _context.SaveChanges();
        //    return Ok();
        //}

        // DELETE: api/Feedbacks1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Feedback>> DeleteFeedback(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Origin", "*"));
            Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Headers", "Origin,X-Requested-With,Content-Type,Accept,Authorization"));
            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();

            return feedback;
        }

        private bool FeedbackExists(int id)
        {
            return _context.Feedbacks.Any(e => e.Id == id);
        }
    }
}
