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
    
    public partial class Kontrahenci
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kontrahenci()
        {
            this.AdresKontrahenta = new HashSet<AdresKontrahenta>();
        }
    
        public int IdKontrahenta { get; set; }
        public string Nazwa { get; set; }
        public string Nip { get; set; }
        public string Regon { get; set; }
        public Nullable<int> IdRodzajuKontrahenta { get; set; }
        public string Telefon1 { get; set; }
        public string Telefon2 { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Url { get; set; }
        public Nullable<int> IdAkcji { get; set; }
        public string Uwagi { get; set; }
        public Nullable<bool> CzyAktywny { get; set; }
        public string Kod { get; set; }
        public string Dokument { get; set; }
        public Nullable<int> IdAdresu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdresKontrahenta> AdresKontrahenta { get; set; }
        public virtual Adresy Adresy { get; set; }
        public virtual Akcje Akcje { get; set; }
        public virtual RodzajKontrahenta RodzajKontrahenta { get; set; }
    }
}
