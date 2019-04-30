using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineCourseSystem.DAL.Migrations
{
    public partial class fixedManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CoursesToCategories",
                table: "CoursesToCategories");

            migrationBuilder.DropIndex(
                name: "IX_CoursesToCategories_CategoryId",
                table: "CoursesToCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoursesToCategories",
                table: "CoursesToCategories",
                columns: new[] { "CategoryId", "CourseId" });

            migrationBuilder.CreateIndex(
                name: "IX_CoursesToCategories_CourseId",
                table: "CoursesToCategories",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CoursesToCategories",
                table: "CoursesToCategories");

            migrationBuilder.DropIndex(
                name: "IX_CoursesToCategories_CourseId",
                table: "CoursesToCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoursesToCategories",
                table: "CoursesToCategories",
                columns: new[] { "CourseId", "CategoryId" });

            migrationBuilder.CreateIndex(
                name: "IX_CoursesToCategories_CategoryId",
                table: "CoursesToCategories",
                column: "CategoryId");
        }
    }
}
