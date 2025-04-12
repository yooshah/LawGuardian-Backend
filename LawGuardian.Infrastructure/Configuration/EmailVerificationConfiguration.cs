using LawGuardian.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Infrastructure.Configuration
{
    public class EmailVerificationConfiguration : IEntityTypeConfiguration<EmailVerification>
    {
        public void Configure(EntityTypeBuilder<EmailVerification> builder)
        {
            builder.HasKey(u=>u.Id);

            builder.Property(u => u.Id)
                   .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(u => u.Email)
                 .IsRequired()
                 .HasMaxLength(60);

            builder.Property(u=>u.Otp)
                .HasMaxLength(6);

            
            builder.Property(u => u.IsValidated)
                .HasDefaultValue(false);

            builder.Property(u => u.IsUsed)
                .HasDefaultValue(false);

            builder.Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

        }
    }
}
