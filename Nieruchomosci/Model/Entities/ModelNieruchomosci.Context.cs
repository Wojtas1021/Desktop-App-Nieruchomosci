﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NieruchomosciEntities : DbContext
    {
        public NieruchomosciEntities()
            : base("name=NieruchomosciEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdresKontrahenta> AdresKontrahenta { get; set; }
        public virtual DbSet<Adresy> Adresy { get; set; }
        public virtual DbSet<AdresyWlascicieli> AdresyWlascicieli { get; set; }
        public virtual DbSet<Akcje> Akcje { get; set; }
        public virtual DbSet<Budynki> Budynki { get; set; }
        public virtual DbSet<Czynsze> Czynsze { get; set; }
        public virtual DbSet<Faktury> Faktury { get; set; }
        public virtual DbSet<JednostkaMiary> JednostkaMiary { get; set; }
        public virtual DbSet<Kontrahenci> Kontrahenci { get; set; }
        public virtual DbSet<Lokale> Lokale { get; set; }
        public virtual DbSet<LokaleWspolnoty> LokaleWspolnoty { get; set; }
        public virtual DbSet<Oplaty> Oplaty { get; set; }
        public virtual DbSet<PozycjeFaktury> PozycjeFaktury { get; set; }
        public virtual DbSet<Pracownicy> Pracownicy { get; set; }
        public virtual DbSet<RachunkiBankowe> RachunkiBankowe { get; set; }
        public virtual DbSet<RodzajAdresu> RodzajAdresu { get; set; }
        public virtual DbSet<RodzajKontrahenta> RodzajKontrahenta { get; set; }
        public virtual DbSet<RodzajLokalu> RodzajLokalu { get; set; }
        public virtual DbSet<SposobPlatnosci> SposobPlatnosci { get; set; }
        public virtual DbSet<StawkiVat> StawkiVat { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Uslugi> Uslugi { get; set; }
        public virtual DbSet<Wlasciciele> Wlasciciele { get; set; }
        public virtual DbSet<WspolnotyMieszkaniowe> WspolnotyMieszkaniowe { get; set; }
    }
}
