﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PsicoAppAPI.Data;

#nullable disable

namespace PsicoAppAPI.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PsicoAppAPI.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AppointmentStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BookedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("RequestedUserId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("RequestingUserId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentStatusId");

                    b.HasIndex("RequestedUserId");

                    b.HasIndex("RequestingUserId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.AppointmentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("AppointmentStatuses");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.AvailabilitySlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsAvailableOverride")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AvailabilitySlots");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ForumPostId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("ForumPostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.FeedPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("PublishedOn")
                        .HasColumnType("date");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("UserId");

                    b.ToTable("FeedPosts");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.ForumPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("PublishedOn")
                        .HasColumnType("date");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("UserId");

                    b.ToTable("ForumPosts");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.GptRules", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Rules")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("GptRules");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.Specialist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("SpecialityId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("SpecialityId");

                    b.HasIndex("UserId");

                    b.ToTable("Specialists");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.Speciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstLastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("SecondLastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.Appointment", b =>
                {
                    b.HasOne("PsicoAppAPI.Models.AppointmentStatus", "AppointmentStatus")
                        .WithMany("Appointment")
                        .HasForeignKey("AppointmentStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PsicoAppAPI.Models.User", "RequestedUser")
                        .WithMany()
                        .HasForeignKey("RequestedUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PsicoAppAPI.Models.User", "RequestingUser")
                        .WithMany()
                        .HasForeignKey("RequestingUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AppointmentStatus");

                    b.Navigation("RequestedUser");

                    b.Navigation("RequestingUser");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.AvailabilitySlot", b =>
                {
                    b.HasOne("PsicoAppAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.Comment", b =>
                {
                    b.HasOne("PsicoAppAPI.Models.ForumPost", "ForumPost")
                        .WithMany("Comments")
                        .HasForeignKey("ForumPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PsicoAppAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ForumPost");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.FeedPost", b =>
                {
                    b.HasOne("PsicoAppAPI.Models.Tag", "Tag")
                        .WithMany("FeedPosts")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PsicoAppAPI.Models.User", "User")
                        .WithMany("FeedPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.ForumPost", b =>
                {
                    b.HasOne("PsicoAppAPI.Models.Tag", "Tag")
                        .WithMany("ForumPosts")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PsicoAppAPI.Models.User", "User")
                        .WithMany("ForumPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.Specialist", b =>
                {
                    b.HasOne("PsicoAppAPI.Models.Speciality", "Speciality")
                        .WithMany("Specialists")
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PsicoAppAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Speciality");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.User", b =>
                {
                    b.HasOne("PsicoAppAPI.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.AppointmentStatus", b =>
                {
                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.ForumPost", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.Speciality", b =>
                {
                    b.Navigation("Specialists");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.Tag", b =>
                {
                    b.Navigation("FeedPosts");

                    b.Navigation("ForumPosts");
                });

            modelBuilder.Entity("PsicoAppAPI.Models.User", b =>
                {
                    b.Navigation("FeedPosts");

                    b.Navigation("ForumPosts");
                });
#pragma warning restore 612, 618
        }
    }
}
