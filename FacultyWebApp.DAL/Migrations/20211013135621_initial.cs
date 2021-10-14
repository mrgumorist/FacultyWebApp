using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FacultyWebApp.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Surname = table.Column<string>(maxLength: 40, nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    FatherName = table.Column<string>(maxLength: 40, nullable: false),
                    Degree = table.Column<string>(maxLength: 40, nullable: false),
                    Position = table.Column<string>(maxLength: 40, nullable: false),
                    PhoneNum = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dictionaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Education = table.Column<string>(nullable: false),
                    EducationTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dictionaries_EducationTypes_EducationTypeId",
                        column: x => x.EducationTypeId,
                        principalTable: "EducationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Surname = table.Column<string>(maxLength: 40, nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    EntryYear = table.Column<int>(nullable: false),
                    PhoneNum = table.Column<string>(nullable: false),
                    EducationTypeId = table.Column<Guid>(nullable: false),
                    IsDeducted = table.Column<bool>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_EducationTypes_EducationTypeId",
                        column: x => x.EducationTypeId,
                        principalTable: "EducationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Semester = table.Column<string>(nullable: false),
                    SubjectId1 = table.Column<Guid>(nullable: true),
                    SubjectId = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    TeacherId = table.Column<Guid>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shedules_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shedules_Subjects_SubjectId1",
                        column: x => x.SubjectId1,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shedules_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dictionaries_Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SubjectId = table.Column<Guid>(nullable: false),
                    DictionaryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionaries_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dictionaries_Subjects_Dictionaries_DictionaryId",
                        column: x => x.DictionaryId,
                        principalTable: "Dictionaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dictionaries_Subjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dictionaries_EducationTypeId",
                table: "Dictionaries",
                column: "EducationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Dictionaries_Subjects_DictionaryId",
                table: "Dictionaries_Subjects",
                column: "DictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dictionaries_Subjects_SubjectId",
                table: "Dictionaries_Subjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Shedules_GroupId",
                table: "Shedules",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Shedules_SubjectId1",
                table: "Shedules",
                column: "SubjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_Shedules_TeacherId",
                table: "Shedules",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_EducationTypeId",
                table: "Students",
                column: "EducationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dictionaries_Subjects");

            migrationBuilder.DropTable(
                name: "Shedules");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Dictionaries");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "EducationTypes");
        }
    }
}
