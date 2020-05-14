﻿// <auto-generated />
using System;
using BigScreen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BigScreen.Migrations
{
    [DbContext(typeof(BigScreenContext))]
    [Migration("20200514080239_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("BigScreen.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BigScreen.Models.Arena", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ArenaName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Arena");
                });

            modelBuilder.Entity("BigScreen.Models.ArenaEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContentType")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LengthOfMedia")
                        .HasColumnType("TEXT");

                    b.Property<int>("TifoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TifoId");

                    b.ToTable("ArenaEvent");
                });

            modelBuilder.Entity("BigScreen.Models.ArenaEventSeat", b =>
                {
                    b.Property<int>("ArenaEventId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeatId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Registered")
                        .HasColumnType("INTEGER");

                    b.HasKey("ArenaEventId", "SeatId");

                    b.HasIndex("SeatId");

                    b.ToTable("ArenaEventSeat");
                });

            modelBuilder.Entity("BigScreen.Models.ArenaEventTifoPartScreen", b =>
                {
                    b.Property<int>("ArenaEventId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TifoPartScreenId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ArenaEventId", "TifoPartScreenId");

                    b.HasIndex("TifoPartScreenId");

                    b.ToTable("ArenaEventTifoPartScreen");
                });

            modelBuilder.Entity("BigScreen.Models.ArenaSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArenaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SectionHeight")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SectionWidth")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ArenaId");

                    b.ToTable("ArenaSection");
                });

            modelBuilder.Entity("BigScreen.Models.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArenaSectionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SeatHeight")
                        .HasColumnType("TEXT");

                    b.Property<string>("SeatWidth")
                        .HasColumnType("TEXT");

                    b.Property<int>("SectionColumn")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SectionRow")
                        .HasColumnType("INTEGER");

                    b.HasKey("SeatId");

                    b.HasIndex("ArenaSectionId");

                    b.ToTable("Seat");
                });

            modelBuilder.Entity("BigScreen.Models.Tifo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContentType")
                        .HasColumnType("TEXT");

                    b.Property<long>("LengthOfMedia")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.Property<int>("TifoHeight")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TifoWidth")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tifo");
                });

            modelBuilder.Entity("BigScreen.Models.TifoPartScreen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AbsScreenHeight")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AbsScreenWidth")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("DotsPerInch")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("DotsPerPixel")
                        .HasColumnType("TEXT");

                    b.Property<int>("TifoPartScreenHeight")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TifoPartScreenWidth")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("TifoPartScreen");
                });

            modelBuilder.Entity("BigScreen.Models.UserSeat", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("SeatId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "SeatId");

                    b.HasIndex("SeatId");

                    b.ToTable("UserSeat");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BigScreen.Models.ArenaEvent", b =>
                {
                    b.HasOne("BigScreen.Models.Tifo", "Tifo")
                        .WithMany("ArenaEvents")
                        .HasForeignKey("TifoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BigScreen.Models.ArenaEventSeat", b =>
                {
                    b.HasOne("BigScreen.Models.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("ArenaEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BigScreen.Models.ArenaEvent", "ArenaEvent")
                        .WithMany("ArenaEventSeat")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BigScreen.Models.ArenaEventTifoPartScreen", b =>
                {
                    b.HasOne("BigScreen.Models.TifoPartScreen", "TifoPartScreen")
                        .WithMany("ArenaEventTifoPartScreen")
                        .HasForeignKey("ArenaEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BigScreen.Models.ArenaEvent", "ArenaEvent")
                        .WithMany("ArenaEventTifoPartScreen")
                        .HasForeignKey("TifoPartScreenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BigScreen.Models.ArenaSection", b =>
                {
                    b.HasOne("BigScreen.Models.Arena", "Arena")
                        .WithMany("ArenaSections")
                        .HasForeignKey("ArenaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BigScreen.Models.Seat", b =>
                {
                    b.HasOne("BigScreen.Models.ArenaSection", "ArenaSection")
                        .WithMany("Seats")
                        .HasForeignKey("ArenaSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BigScreen.Models.TifoPartScreen", b =>
                {
                    b.HasOne("BigScreen.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("TifoPartScreen")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("BigScreen.Models.UserSeat", b =>
                {
                    b.HasOne("BigScreen.Models.Seat", "Seat")
                        .WithMany("UserSeats")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BigScreen.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserSeats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BigScreen.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BigScreen.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BigScreen.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BigScreen.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
