using System;
using System.Collections.Generic;

namespace test.Entities
{
    public partial class Dongxe
    {
        public Dongxe()
        {
            Dangkycungcaps = new HashSet<Dangkycungcap>();
        }

        public string DongXe1 { get; set; } = null!;
        public string HangXe { get; set; } = null!;
        public int SoChoNgoi { get; set; }

        public virtual ICollection<Dangkycungcap> Dangkycungcaps { get; set; }
    }
}
