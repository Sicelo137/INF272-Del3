﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace INF272_Deliverable_2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FeedAfricaEntities1 : DbContext
    {
        public FeedAfricaEntities1()
            : base("name=FeedAfricaEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<Donor> Donors { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Sponsorship> Sponsorships { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }
    }
}