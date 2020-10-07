using System;
using System.Collections.Generic;
using System.Text;
using CoreSight2.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreSight2.Data
{
    public class CoreSightDbContext : IdentityDbContext
    {

        public DbSet<Readings> Readings { get; set; }
        public CoreSightDbContext(DbContextOptions<CoreSightDbContext> options)
            : base(options)
        {

        }
    }
}
