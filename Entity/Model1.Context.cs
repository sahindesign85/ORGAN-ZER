﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ORGANİZER.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class istakipEntities2 : DbContext
    {
        public istakipEntities2()
            : base("name=istakipEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TblAdmin> TblAdmin { get; set; }
        public virtual DbSet<TblDepartmanlar> TblDepartmanlar { get; set; }
        public virtual DbSet<TblFirmalar> TblFirmalar { get; set; }
        public virtual DbSet<TblGorevDetaylar> TblGorevDetaylar { get; set; }
        public virtual DbSet<TblGorevler> TblGorevler { get; set; }
        public virtual DbSet<TblPersonel> TblPersonel { get; set; }
        public virtual DbSet<TblSatinalmaTeklif> TblSatinalmaTeklif { get; set; }
        public virtual DbSet<TblFirmaCari> TblFirmaCari { get; set; }
    }
}
