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
    
    public partial class Akcje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Akcje()
        {
            this.AdresKontrahenta = new HashSet<AdresKontrahenta>();
            this.Adresy = new HashSet<Adresy>();
            this.AdresyWlascicieli = new HashSet<AdresyWlascicieli>();
            this.Budynki = new HashSet<Budynki>();
            this.Czynsze = new HashSet<Czynsze>();
            this.Faktury = new HashSet<Faktury>();
            this.JednostkaMiary = new HashSet<JednostkaMiary>();
            this.Kontrahenci = new HashSet<Kontrahenci>();
            this.Lokale = new HashSet<Lokale>();
            this.LokaleWspolnoty = new HashSet<LokaleWspolnoty>();
            this.Oplaty = new HashSet<Oplaty>();
            this.PozycjeFaktury = new HashSet<PozycjeFaktury>();
            this.RachunkiBankowe = new HashSet<RachunkiBankowe>();
            this.RodzajAdresu = new HashSet<RodzajAdresu>();
            this.RodzajKontrahenta = new HashSet<RodzajKontrahenta>();
            this.RodzajLokalu = new HashSet<RodzajLokalu>();
            this.SposobPlatnosci = new HashSet<SposobPlatnosci>();
            this.StawkiVat = new HashSet<StawkiVat>();
            this.Uslugi = new HashSet<Uslugi>();
            this.Wlasciciele = new HashSet<Wlasciciele>();
            this.WspolnotyMieszkaniowe = new HashSet<WspolnotyMieszkaniowe>();
        }
    
        public int IdAkcji { get; set; }
        public string Rodzaj { get; set; }
        public Nullable<int> IdPracownika { get; set; }
        public string Uwagi { get; set; }
        public Nullable<bool> CzyAktywny { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdresKontrahenta> AdresKontrahenta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adresy> Adresy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdresyWlascicieli> AdresyWlascicieli { get; set; }
        public virtual Pracownicy Pracownicy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Budynki> Budynki { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Czynsze> Czynsze { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Faktury> Faktury { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JednostkaMiary> JednostkaMiary { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kontrahenci> Kontrahenci { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lokale> Lokale { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LokaleWspolnoty> LokaleWspolnoty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oplaty> Oplaty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PozycjeFaktury> PozycjeFaktury { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RachunkiBankowe> RachunkiBankowe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RodzajAdresu> RodzajAdresu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RodzajKontrahenta> RodzajKontrahenta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RodzajLokalu> RodzajLokalu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SposobPlatnosci> SposobPlatnosci { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StawkiVat> StawkiVat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uslugi> Uslugi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wlasciciele> Wlasciciele { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WspolnotyMieszkaniowe> WspolnotyMieszkaniowe { get; set; }
    }
}
