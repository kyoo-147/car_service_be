using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Entities;

namespace test.Controllers;

[ApiController]
[Route("[controller]")]
public class NhacungcapsController : ControllerBase
{
    private readonly ontapContext _context;
        public NhacungcapsController(ontapContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        
        public IActionResult GetAll()
        {
            return Ok(_context.Nhacungcaps.ToList());
        }

        // [HttpPost]

        // public async Task<ActionResult<Nhacungcap>> ThemCus(Nhacungcap cus)
        // {
        //     _context.Nhacungcaps.Add(cus);
        //     await _context.SaveChangesAsync();
        //     return Ok(_context.Nhacungcaps.ToList());
        // }

        [HttpPost]

        public async Task<ActionResult<Dongxe>> ThemCus(Dongxe cus)
        {
            _context.Dongxes.Add(cus);
            await _context.SaveChangesAsync();
            return Ok(_context.Dongxes.ToList());
        }

        // [HttpGet("{MaCus}")]
        
        // public async Task<ActionResult<Nhacungcap>> getCusbyMaCus(string MaCus)
        // {
        //     var cus = await _context.Nhacungcaps.FindAsync(MaCus);
        //     if (cus == null)
        //     {
        //         return NotFound();
        //     }
        //     return cus;
        // }

        // Tìm kiếm dòng xe theo mã gần đúng
        [HttpGet("{MaCus}")]
        
        public async Task<ActionResult<Dongxe>> getCusbyMaCus(string MaCus)
        {
            var cus = await _context.Dongxes.FindAsync(MaCus);
            if (cus == null)
            {
                return NotFound();
            }
            return cus;
        }


        [HttpDelete("{MaCus}")]
        public async Task<IActionResult> DeleteCus(string MaCus) 
        {
            var cus= await _context.Nhacungcaps.FindAsync(MaCus);
            if (cus == null)
            {
                return NotFound();
            }
            var relatedDangkycungcaps = _context.Dangkycungcaps.Where(d => d.MaNhaCc == MaCus);
            _context.Dangkycungcaps.RemoveRange(relatedDangkycungcaps);
            _context.Nhacungcaps.Remove(cus);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{MaCus}")]
        public async Task<IActionResult> UpdateCus(string MaCus, Nhacungcap cus) 
        {
            // var cus= await _context.Customers.FindAsync(MaCus);
            if (MaCus != cus.MaNhaCc)
            {
                return BadRequest();
            }
            _context.Entry(cus).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            try{
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(CusExists(MaCus)))
                {
                    return NotFound();
                }
                else{
                    throw;
                }
            }
            // await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CusExists(string MaCus)
        {
            return _context.Nhacungcaps.Any(e => e.MaNhaCc ==MaCus);
        }

}
