﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeleleTravel.Database_Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SeleleEntities : DbContext
    {
        public SeleleEntities()
            : base("name=SeleleEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<accommodation> accommodations { get; set; }
        public virtual DbSet<accommodationdetail> accommodationdetails { get; set; }
        public virtual DbSet<agencydetail> agencydetails { get; set; }
        public virtual DbSet<airlinedetail> airlinedetails { get; set; }
        public virtual DbSet<cabservice> cabservices { get; set; }
        public virtual DbSet<carhire> carhires { get; set; }
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<conference> conferences { get; set; }
        public virtual DbSet<dailyserviceupdate> dailyserviceupdates { get; set; }
        public virtual DbSet<@event> events { get; set; }
        public virtual DbSet<flight> flights { get; set; }
        public virtual DbSet<invoice> invoices { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<quote> quotes { get; set; }
        public virtual DbSet<staff> staffs { get; set; }
        public virtual DbSet<voucher> vouchers { get; set; }
    }
}
