using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Entities;

namespace test.Controllers;

[ApiController]
[Route("[controller]")]
public class DongxesController : ControllerBase
{
    private readonly ontapContext _context;
        public DongxesController(ontapContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        
        public IActionResult GetAll()
        {
            return Ok(_context.Dongxes.ToList());
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

        [HttpPost("ThemDongXe")]
        public async Task<IActionResult> ThemDongXe(Dongxe dongXe)
        {
            // Kiểm tra xem dòng xe đã tồn tại trong cơ sở dữ liệu hay không
            var existingDongXe = await _context.Dongxes.FirstOrDefaultAsync(x => x.DongXe1 == dongXe.DongXe1);

            if (existingDongXe != null)
            {
                // Nếu dòng xe đã tồn tại, kiểm tra số chỗ ngồi
                if (existingDongXe.SoChoNgoi == dongXe.SoChoNgoi)
                {
                    return BadRequest("Dòng xe đã tồn tại với số chỗ ngồi này.");
                }
                else
                {
                    // Nếu số chỗ ngồi khác, cập nhật dòng xe
                    existingDongXe.SoChoNgoi = dongXe.SoChoNgoi;
                    await _context.SaveChangesAsync();
                    return Ok("Cập nhật dòng xe thành công.");
                }
            }
            else
            {
                // Nếu dòng xe chưa tồn tại, thêm một dòng xe mới
                _context.Dongxes.Add(dongXe);
                await _context.SaveChangesAsync();
                return Ok("Thêm dòng xe mới thành công.");
            }
        }

       [HttpPost("ThemCungDongXe")]
        public async Task<IActionResult> ThemCungDongXe(Dongxe dongXe)
        {
            // Gỡ bỏ trạng thái của đối tượng
            _context.Entry(dongXe).State = EntityState.Added;

            // Thêm một bản ghi mới vào cơ sở dữ liệu
            await _context.SaveChangesAsync();

            return Ok("Thêm dòng xe mới thành công.");
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
        [HttpGet("{TimKiemDongXe}")]
        
        public async Task<ActionResult<Dongxe>> getCusbyMaCus(string MaCus)
        {
            var cus = await _context.Dongxes.FindAsync(MaCus);
            if (cus == null)
            {
                return NotFound();
            }
            return cus;
        }

        // [HttpGet("{MaCusXe}")]
        
        // public async Task<ActionResult<Dongxe>> getCusXebyMaCusXe(string MaCusXe)
        // {
        //     var cusxe = await _context.Dongxes.FindAsync(MaCusXe);
        //     if (cusxe == null)
        //     {
        //         return NotFound();
        //     }
        //     return cusxe;
        // }
        
        [HttpGet("ThongKeSoLuongXe")]
        public IActionResult ThongKeSoLuongXe()
        {
            var thongKe = _context.Dongxes
                                .GroupBy(x => x.SoChoNgoi)
                                .Select(g => new { SoChoNgoi = g.Key, SoLuongXe = g.Count() })
                                .ToList();
            
            return Ok(thongKe);
        }


        // [HttpDelete("{MaCus}")]
        // public async Task<IActionResult> DeleteCus(string MaCus) 
        // {
        //     var cus= await _context.Nhacungcaps.FindAsync(MaCus);
        //     if (cus == null)
        //     {
        //         return NotFound();
        //     }
        //     var relatedDangkycungcaps = _context.Dangkycungcaps.Where(d => d.MaNhaCc == MaCus);
        //     _context.Dangkycungcaps.RemoveRange(relatedDangkycungcaps);
        //     _context.Nhacungcaps.Remove(cus);
        //     await _context.SaveChangesAsync();
        //     return NoContent();
        // }

        [HttpDelete("{XoaDongXeTruyenVao}")]
        public async Task<IActionResult> XoaDongXeChuaDangKy(string MaDongXe) 
        {
            var cus= await _context.Dongxes.FindAsync(MaDongXe);
            if (cus == null)
            {
                return NotFound();
            }
            var relatedDangkycungcaps = _context.Dangkycungcaps.Where(d => d.DongXe == MaDongXe);
            _context.Dangkycungcaps.RemoveRange(relatedDangkycungcaps);
            _context.Dongxes.Remove(cus);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // [HttpDelete("{MaCus}")]
        // public async Task<IActionResult> XoaXe(string MaCus) 
        // {
        //     var cus= await _context.Dongxes.FindAsync(MaCus);
        //     if (cus == null)
        //     {
        //         return NotFound();
        //     }
        //     var relatedDangkycungcaps = _context.Dangkycungcaps.Where(d => d.DongXe == MaCus);
        //     _context.Dangkycungcaps.RemoveRange(relatedDangkycungcaps);
        //     _context.Dongxes.Remove(cus);
        //     await _context.SaveChangesAsync();
        //     return NoContent();
        // }

        // [HttpPut("{MaCus}")]
        // public async Task<IActionResult> UpdateCus(string MaCus, Nhacungcap cus) 
        // {
        //     // var cus= await _context.Customers.FindAsync(MaCus);
        //     if (MaCus != cus.MaNhaCc)
        //     {
        //         return BadRequest();
        //     }
        //     _context.Entry(cus).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //     try{
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!(CusExists(MaCus)))
        //         {
        //             return NotFound();
        //         }
        //         else{
        //             throw;
        //         }
        //     }
        //     // await _context.SaveChangesAsync();
        //     return NoContent();
        // }

        [HttpPut("{CapNhapDongXe}")]
        public async Task<IActionResult> UpdateDongXe(string MaCus, Dongxe cus) 
        {
            // var cus= await _context.Customers.FindAsync(MaCus);
            if (MaCus != cus.DongXe1)
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
