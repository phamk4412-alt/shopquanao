namespace WindowsFormsApp2
{
    using System;
    using System.Collections.Generic;

    public partial class THUONGHIEU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THUONGHIEU()
        {
            SANPHAMs = new HashSet<SANPHAM>();
        }

        public int ma_thuonghieu { get; set; }

        public string ten_thuonghieu { get; set; }

        public string quoc_gia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }
    }
}
