using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MySchool.Migrations
{
    public partial class AddClassSectionIdToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Classes_ClassId",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Student",
                newName: "ClassSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_ClassId",
                table: "Student",
                newName: "IX_Student_ClassSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_ClassSections_ClassSectionId",
                table: "Student",
                column: "ClassSectionId",
                principalTable: "ClassSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_ClassSections_ClassSectionId",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "ClassSectionId",
                table: "Student",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_ClassSectionId",
                table: "Student",
                newName: "IX_Student_ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Classes_ClassId",
                table: "Student",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
