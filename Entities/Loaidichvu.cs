using System;
using System.Collections.Generic;

namespace test.Entities
{
    public partial class Loaidichvu
    {
        public Loaidichvu()
        {
            Dangkycungcaps = new HashSet<Dangkycungcap>();
        }

        public string MaLoaiDv { get; set; } = null!;
        public string TenLoaiDv { get; set; } = null!;

        public virtual ICollection<Dangkycungcap> Dangkycungcaps { get; set; }
    }
}
