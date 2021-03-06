﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PromosuiteDbContext : DbContext
    {
        public PromosuiteDbContext()
            : base("name=PromosuiteDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<MobileLoggedInUser> MobileLoggedInUsers { get; set; }
        public virtual DbSet<StationLink> StationLinks { get; set; }
    
        public virtual ObjectResult<MobileLoginDetails_Result> MobileLoginDetails(string verificationCode)
        {
            var verificationCodeParameter = verificationCode != null ?
                new ObjectParameter("VerificationCode", verificationCode) :
                new ObjectParameter("VerificationCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobileLoginDetails_Result>("MobileLoginDetails", verificationCodeParameter);
        }
    }
}
