using System;
using System.Collections.Generic;

namespace test.Entities
{
    public partial class Mucphi
    {
        public Mucphi()
        {
            Dangkycungcaps = new HashSet<Dangkycungcap>();
        }

        public string MaMp { get; set; } = null!;
        public string DonGia { get; set; } = null!;
        public string? MoTa { get; set; }

        public virtual ICollection<Dangkycungcap> Dangkycungcaps { get; set; }
    }
}
