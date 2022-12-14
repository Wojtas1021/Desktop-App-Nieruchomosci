//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nieruchomosci.Model.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class JednostkaMiary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JednostkaMiary()
        {
            this.Budynki = new HashSet<Budynki>();
            this.Lokale = new HashSet<Lokale>();
            this.PozycjeFaktury = new HashSet<PozycjeFaktury>();
        }
    
        public int IdJednostkiMiary { get; set; }
        public string Symbol { get; set; }
        public string Opis { get; set; }
        public string Uwagi { get; set; }
        public Nullable<int> IdAkcji { get; set; }
        public Nullable<bool> CzyAktywny { get; set; }
    
        public virtual Akcje Akcje { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Budynki> Budynki { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lokale> Lokale { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PozycjeFaktury> PozycjeFaktury { get; set; }
    }
}
