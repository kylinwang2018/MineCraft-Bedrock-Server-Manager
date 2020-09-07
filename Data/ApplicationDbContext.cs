﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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
                NormalizedName = "admin"
            }, 
            new IdentityRole
            {
                Id = MEMBER_ID,
                Name = "member",
                NormalizedName = "member"
            });

            base.OnModelCreating(builder);
        }
        #endregion
    }
}
