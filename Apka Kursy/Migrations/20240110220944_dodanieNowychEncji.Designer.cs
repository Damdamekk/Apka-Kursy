﻿// <auto-generated />
using System;
using Apka_Kursy.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApkaKursy.Migrations
{
    [DbContext(typeof(Apka_KursyDBContext))]
    [Migration("20240110220944_dodanieNowychEncji")]
    partial class dodanieNowychEncji
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Apka_Kursy.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<int>("CourseCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SignupMessageId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("CourseId");

                    b.HasIndex("CourseCategoryId");

                    b.HasIndex("SignupMessageId")
                        .IsUnique();

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.CourseDate", b =>
                {
                    b.Property<int>("CourseDateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseDateId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Hour")
                        .HasColumnType("int");

                    b.Property<int>("Weekday")
                        .HasColumnType("int");

                    b.HasKey("CourseDateId");

                    b.ToTable("CourseDate");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.CoursesCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("CoursesCategory");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.ForumCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("ForumCategory");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.ForumPost", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"));

                    b.Property<string>("AttachedMedia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("PostId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UsersId");

                    b.ToTable("ForumPost");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.Lesson", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LessonId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HasHomework")
                        .HasColumnType("bit");

                    b.Property<int>("LessonVideoId")
                        .HasColumnType("int");

                    b.Property<string>("PriceString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LessonId");

                    b.HasIndex("CourseId");

                    b.HasIndex("LessonVideoId");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.LessonVideo", b =>
                {
                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LessonId");

                    b.ToTable("LessonVideo");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Kursant"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Nauczyciel"
                        });
                });

            modelBuilder.Entity("Apka_Kursy.Entities.Signup", b =>
                {
                    b.Property<int>("SignupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SignupId"));

                    b.Property<DateTime>("ActiveFrom")
                        .HasColumnType("datetime2");

                    b.Property<int>("CourseDateId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiresIn")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SignupId");

                    b.HasIndex("CourseDateId")
                        .IsUnique();

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("Signup");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.SignupMessage", b =>
                {
                    b.Property<int>("SignupMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SignupMessageId"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SignupMessageId");

                    b.ToTable("SignupMessage");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GetDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password_hash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.Course", b =>
                {
                    b.HasOne("Apka_Kursy.Entities.CoursesCategory", "CoursesCategory")
                        .WithMany("Courses")
                        .HasForeignKey("CourseCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apka_Kursy.Entities.SignupMessage", "SignupMessage")
                        .WithOne("Course")
                        .HasForeignKey("Apka_Kursy.Entities.Course", "SignupMessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoursesCategory");

                    b.Navigation("SignupMessage");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.ForumPost", b =>
                {
                    b.HasOne("Apka_Kursy.Entities.ForumCategory", "ForumCategory")
                        .WithMany("ForumPosts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apka_Kursy.Entities.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ForumCategory");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.Lesson", b =>
                {
                    b.HasOne("Apka_Kursy.Entities.Course", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apka_Kursy.Entities.LessonVideo", "LessonVideo")
                        .WithMany()
                        .HasForeignKey("LessonVideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("LessonVideo");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.LessonVideo", b =>
                {
                    b.HasOne("Apka_Kursy.Entities.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.Payment", b =>
                {
                    b.HasOne("Apka_Kursy.Entities.Course", "Course")
                        .WithMany("Payments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apka_Kursy.Entities.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.Signup", b =>
                {
                    b.HasOne("Apka_Kursy.Entities.CourseDate", "CourseDate")
                        .WithOne("Signup")
                        .HasForeignKey("Apka_Kursy.Entities.Signup", "CourseDateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apka_Kursy.Entities.Course", "Course")
                        .WithMany("Signups")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apka_Kursy.Entities.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("CourseDate");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.Users", b =>
                {
                    b.HasOne("Apka_Kursy.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.Course", b =>
                {
                    b.Navigation("Lessons");

                    b.Navigation("Payments");

                    b.Navigation("Signups");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.CourseDate", b =>
                {
                    b.Navigation("Signup")
                        .IsRequired();
                });

            modelBuilder.Entity("Apka_Kursy.Entities.CoursesCategory", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.ForumCategory", b =>
                {
                    b.Navigation("ForumPosts");
                });

            modelBuilder.Entity("Apka_Kursy.Entities.SignupMessage", b =>
                {
                    b.Navigation("Course")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
