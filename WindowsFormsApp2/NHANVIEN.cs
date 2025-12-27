namespace WindowsFormsApp2
{
    using System;
    using System.Collections.Generic;

    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            HOADONs = new HashSet<HOADON>();
            TAIKHOANs = new HashSet<TAIKHOAN>();
        }

        public int ma_nhanvien { get; set; }

        public string ho_ten { get; set; }

        public string sdt { get; set; }

        public string email { get; set; }

        public string chuc_vu { get; set; }

        public decimal luong { get; set; }

        public DateTime ngay_vao_lam { get; set; }

        public bool? trang_thai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAIKHOAN> TAIKHOANs { get; set; }
    }
}
