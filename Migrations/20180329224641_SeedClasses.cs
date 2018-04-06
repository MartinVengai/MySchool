using Microsoft.EntityFrameworkCore.Migrations;

namespace MySchool.Migrations
{
    public partial class SeedClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Classes (Name) VALUES ('Class1')");
            migrationBuilder.Sql("INSERT INTO Classes (Name) VALUES ('Class2')");
            migrationBuilder.Sql("INSERT INTO Classes (Name) VALUES ('Class3')");
            migrationBuilder.Sql("INSERT INTO Classes (Name) VALUES ('Class4')");

            migrationBuilder.Sql("INSERT INTO ClassSections (Name, ClassId) VALUES ('Class1-A', (SELECT Id FROM Classes WHERE Name = 'Class1'))");
            migrationBuilder.Sql("INSERT INTO ClassSections (Name, ClassId) VALUES ('Class1-B', (SELECT Id FROM Classes WHERE Name = 'Class1'))");
            migrationBuilder.Sql("INSERT INTO ClassSections (Name, ClassId) VALUES ('Class1-C', (SELECT Id FROM Classes WHERE Name = 'Class1'))");

            migrationBuilder.Sql("INSERT INTO ClassSections (Name, ClassId) VALUES ('Class2-A', (SELECT Id FROM Classes WHERE Name = 'Class2'))");
            migrationBuilder.Sql("INSERT INTO ClassSections (Name, ClassId) VALUES ('Class2-B', (SELECT Id FROM Classes WHERE Name = 'Class2'))");
            migrationBuilder.Sql("INSERT INTO ClassSections (Name, ClassId) VALUES ('Class2-C', (SELECT Id FROM Classes WHERE Name = 'Class2'))");

            migrationBuilder.Sql("INSERT INTO ClassSections (Name, ClassId) VALUES ('Class3-A', (SELECT Id FROM Classes WHERE Name = 'Class3'))");
            migrationBuilder.Sql("INSERT INTO ClassSections (Name, ClassId) VALUES ('Class3-B', (SELECT Id FROM Classes WHERE Name = 'Class3'))");
            migrationBuilder.Sql("INSERT INTO ClassSections (Name, ClassId) VALUES ('Class3-C', (SELECT Id FROM Classes WHERE Name = 'Class3'))");

            migrationBuilder.Sql("INSERT INTO ClassSections (Name, ClassId) VALUES ('Class4-A', (SELECT Id FROM Classes WHERE Name = 'Class4'))");
            migrationBuilder.Sql("INSERT INTO ClassSections (Name, ClassId) VALUES ('Class4-B', (SELECT Id FROM Classes WHERE Name = 'Class4'))");
            migrationBuilder.Sql("INSERT INTO ClassSections (Name, ClassId) VALUES ('Class4-C', (SELECT Id FROM Classes WHERE Name = 'Class4'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Classes WHERE Name In ('Class1', 'Class2', 'Class3', 'Class4')");
        }
    }
}
