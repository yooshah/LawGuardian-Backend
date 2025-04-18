﻿using LawGuardian.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Infrastructure.Configuration
{
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
       
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.UserId)
                   .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(u => u.Password)
                   .IsRequired()
                   .HasMaxLength(100);


            builder.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(u => u.UserType)
             .HasConversion<string>() 
             .IsRequired()
             .HasMaxLength(20);

            builder.Property(u => u.Phone)
              .IsRequired()
              .HasMaxLength(15);

            builder.Property(u => u.IsProfileComplete)
                .HasDefaultValue(false);

            builder.Property(u=>u.IsEmailVerified)
                .HasDefaultValue (false);

            builder.Property(u => u.IsBlocked)
                   .HasDefaultValue(false);

            builder.Property(u => u.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(u => u.UpdatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
