using System;
using System.Collections.Generic;

namespace test.Entities
{
    public partial class Nhacungcap
    {
        public Nhacungcap()
        {
            Dangkycungcaps = new HashSet<Dangkycungcap>();
        }

        public string MaNhaCc { get; set; } = null!;
        public string TenNhaCc { get; set; } = null!;
        public string DiaChi { get; set; } = null!;
        public string? SoDt { get; set; }
        public string MaSoThue { get; set; } = null!;

        public virtual ICollection<Dangkycungcap> Dangkycungcaps { get; set; }
    }
}
