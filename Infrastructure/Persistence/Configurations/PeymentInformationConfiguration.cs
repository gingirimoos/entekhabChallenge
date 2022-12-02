﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Eefa.Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using Domain.Entities;

namespace Eefa.Admin.Domain.Entities.Configurations
{
    public partial class PaymentInformationConfiguration : IEntityTypeConfiguration<PaymentInformation>
    {
        public void Configure(EntityTypeBuilder<PaymentInformation> entity)
        {
            entity.ToTable("PaymentInformations");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.PersonId);
            entity.Property(e => e.Allowance);
            entity.Property(e => e.Date);
            entity.Property(e => e.BasicSalary);
            entity.Property(e => e.Transportation);


            entity.HasOne(x => x.Person)
                .WithMany(x => x.PaymentInformations)
                .HasForeignKey(x => x.PersonId)
                .HasConstraintName("FK_Person_PersonInformation");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<PaymentInformation> entity);
    }
}
