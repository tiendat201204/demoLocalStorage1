using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoLocalStorage1.Models
{
    public class PhieuNhap_ChiTietPN
    {
        public string MAPHIEU { get; set; }
        public System.DateTime NGAYNHAP { get; set; }
        public string MANCC { get; set; }
        public string GHICHU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
        public string TENNCC { get; set; }
        ///////////////////////////////////////////////////
        public string MANL { get; set; }
        public string SOLUONG { get; set; }

        public virtual NGUYENLIEU NGUYENLIEU { get; set; }
        public virtual PHIEUNHAPKHO PHIEUNHAPKHO { get; set; }
        ////////////////////////////////////////////////
        public string TENNL { get; set; }
        public string DVTINH { get; set; }
        public Nullable<int> COST { get; set; }
        public PhieuNhap_ChiTietPN()
        {
            CHITIETPHIEUNHAPs = new List<CHITIETPHIEUNHAP>();
        }

    }
}