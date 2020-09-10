using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MineCraft_Bedrock_Server_Manager.Models;

namespace MineCraft_Bedrock_Server_Manager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #region seed custom admin and member role
        protected override void OnModelCreating(ModelBuilder builder)
        {
            string ADMIN_ID = Guid.NewGuid().ToString();
            string MEMBER_ID = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ADMIN_ID,
                Name = "admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = MEMBER_ID,
                Name = "member",
                NormalizedName = "MEMBER"
            });

            base.OnModelCreating(builder);
            #endregion
        }
    }
}
