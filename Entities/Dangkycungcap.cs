using System;
using System.Collections.Generic;

namespace test.Entities
{
    public partial class Dangkycungcap
    {
        public string MaDkcc { get; set; } = null!;
        public string MaNhaCc { get; set; } = null!;
        public string MaLoaiDv { get; set; } = null!;
        public string DongXe { get; set; } = null!;
        public string MaMp { get; set; } = null!;
        public DateTime NgayBatDauCungCap { get; set; }
        public DateTime NgayKetThucCungCap { get; set; }
        public int? SoLuongXeDangKy { get; set; }

        public virtual Dongxe DongXeNavigation { get; set; } = null!;
        public virtual Loaidichvu MaLoaiDvNavigation { get; set; } = null!;
        public virtual Mucphi MaMpNavigation { get; set; } = null!;
        public virtual Nhacungcap MaNhaCcNavigation { get; set; } = null!;
    }
}
