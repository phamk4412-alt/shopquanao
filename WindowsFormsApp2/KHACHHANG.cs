namespace WindowsFormsApp2
{
    using System;
    using System.Collections.Generic;

    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            HOADONs = new HashSet<HOADON>();
        }

        public int ma_khachhang { get; set; }

        public string ho_ten { get; set; }

        public string sdt { get; set; }

        public string email { get; set; }

        public string dia_chi { get; set; }

        public string gioi_tinh { get; set; }

        public DateTime? ngay_dang_ky { get; set; }

        public int? diem_tich_luy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
