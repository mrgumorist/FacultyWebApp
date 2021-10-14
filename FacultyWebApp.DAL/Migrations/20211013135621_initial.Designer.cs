﻿// <auto-generated />
using System;
using FacultyWebApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FacultyWebApp.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211013135621_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("FacultyWebApp.DAL.Entities.Dictionary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("EducationTypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("EducationTypeId");

                    b.ToTable("Dictionaries");
                });

            modelBuilder.Entity("FacultyWebApp.DAL.Entities.DictionarySubject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DictionaryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DictionaryId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Dictionaries_Subjects");
                });

            modelBuilder.Entity("FacultyWebApp.DAL.Entities.EducationType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(40)")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("EducationTypes");
                });

            modelBuilder.Entity("FacultyWebApp.DAL.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("FacultyWebApp.DAL.Entities.Shedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SubjectId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("SubjectId1")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubjectId1");

                    b.HasIndex("TeacherId");

                    b.ToTable("Shedules");
                });

            modelBuilder.Entity("FacultyWebApp.DAL.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("EducationTypeId")
                        .HasColumnType("uuid");

                    b.Property<int>("EntryYear")
                        .HasColumnType("integer");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeducted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(40)")
                        .HasMaxLength(40);

                    b.Property<string>("PhoneNum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("character varying(40)")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.HasIndex("EducationTypeId");

                    b.HasIndex("GroupId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("FacultyWebApp.DAL.Entities.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("FacultyWebApp.DAL.Entities.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("character varying(40)")
                        .HasMaxLength(40);

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasColumnType("character varying(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(40)")
                        .HasMaxLength(40);

                    b.Property<string>("PhoneNum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("character varying(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("character varying(40)")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("FacultyWebApp.DAL.Entities.Dictionary", b =>
                {
                    b.HasOne("FacultyWebApp.DAL.Entities.EducationType", "EducationType")
                        .WithMany("Dictionaries")
                        .HasForeignKey("EducationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FacultyWebApp.DAL.Entities.DictionarySubject", b =>
                {
                    b.HasOne("FacultyWebApp.DAL.Entities.Dictionary", "Dictionary")
                        .WithMany("DictionarySubjects")
                        .HasForeignKey("DictionaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FacultyWebApp.DAL.Entities.Subject", "Subject")
                        .WithMany("DictionarySubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FacultyWebApp.DAL.Entities.Shedule", b =>
                {
                    b.HasOne("FacultyWebApp.DAL.Entities.Group", "Group")
                        .WithMany("Shedules")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FacultyWebApp.DAL.Entities.Subject", "Subject")
                        .WithMany("Shedules")
                        .HasForeignKey("SubjectId1");

                    b.HasOne("FacultyWebApp.DAL.Entities.Teacher", "Teacher")
                        .WithMany("Shedules")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FacultyWebApp.DAL.Entities.Student", b =>
                {
                    b.HasOne("FacultyWebApp.DAL.Entities.EducationType", "EducationType")
                        .WithMany("Students")
                        .HasForeignKey("EducationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FacultyWebApp.DAL.Entities.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}