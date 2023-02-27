﻿// <auto-generated />
using System;
using BudgetApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BudgetApp.Data.Migrations
{
    [DbContext(typeof(BudgetContext))]
    [Migration("20210712141548_AddConfiguration")]
    partial class AddConfiguration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0-preview.5.21301.9");

            modelBuilder.Entity("BudgetApp.Data.Models.Budget", b =>
                {
                    b.Property<int>("YearMonth")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("YearMonth");

                    b.ToTable("Budget");
                });

            modelBuilder.Entity("BudgetApp.Data.Models.Debt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasPrecision(9, 2)
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("DebtType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Debts");
                });

            modelBuilder.Entity("BudgetApp.Data.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BudgetYearMonth")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cost")
                        .HasPrecision(9, 2)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("date");

                    b.Property<string>("ExpenseName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int?>("IncomeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .HasMaxLength(800)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BudgetYearMonth");

                    b.HasIndex("IncomeId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("BudgetApp.Data.Models.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasPrecision(9, 2)
                        .HasColumnType("TEXT");

                    b.Property<int?>("BudgetYearMonth")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("PayDate")
                        .IsRequired()
                        .HasColumnType("date");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BudgetYearMonth");

                    b.ToTable("Income");
                });

            modelBuilder.Entity("BudgetApp.Data.Models.Expense", b =>
                {
                    b.HasOne("BudgetApp.Data.Models.Budget", null)
                        .WithMany("Expenses")
                        .HasForeignKey("BudgetYearMonth");

                    b.HasOne("BudgetApp.Data.Models.Income", null)
                        .WithMany("Expenses")
                        .HasForeignKey("IncomeId");
                });

            modelBuilder.Entity("BudgetApp.Data.Models.Income", b =>
                {
                    b.HasOne("BudgetApp.Data.Models.Budget", null)
                        .WithMany("Incomes")
                        .HasForeignKey("BudgetYearMonth");
                });

            modelBuilder.Entity("BudgetApp.Data.Models.Budget", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Incomes");
                });

            modelBuilder.Entity("BudgetApp.Data.Models.Income", b =>
                {
                    b.Navigation("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}
