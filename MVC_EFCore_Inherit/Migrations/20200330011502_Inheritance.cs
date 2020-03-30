using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_EFCore.Migrations
{
    public partial class Inheritance : Migration
    {
        #region MyRegion
        //protected override void Up(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropForeignKey(
        //        name: "FK_enrollment_course_CourseID",
        //        table: "enrollment");

        //    migrationBuilder.DropIndex(name: "IX_Enrollment_StudentID", table: "enrollment");

        //    migrationBuilder.RenameTable(name: "Instructor", newName: "Person");
        //    migrationBuilder.AddColumn<DateTime>(name: "EnrollmentDate", table: "Person", nullable: true);
        //    migrationBuilder.AddColumn<string>(name: "Discriminator", table: "Person", nullable: false, maxLength: 128, defaultValue: "Instructor");
        //    migrationBuilder.AlterColumn<DateTime>(name: "HireDate", table: "Person", nullable: true);
        //    migrationBuilder.AddColumn<int>(name: "OldId", table: "Person", nullable: true);

        //    // Copy existing Student data into new Person table.
        //    migrationBuilder.Sql("INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator, OldId) SELECT LastName, FirstName, null AS HireDate, EnrollmentDate, 'Student' AS Discriminator, ID AS OldId FROM Student");
        //    // Fix up existing relationships to match new PK's.
        //    migrationBuilder.Sql("UPDATE Enrollment SET StudentId = (SELECT ID FROM Person WHERE OldId = Enrollment.StudentId AND Discriminator = 'Student')");

        //    // Remove temporary key
        //    migrationBuilder.DropColumn(name: "OldID", table: "Person");

        //    migrationBuilder.DropTable(
        //        name: "Student");

        //    migrationBuilder.CreateIndex(
        //         name: "IX_Enrollment_StudentID",
        //         table: "Enrollment",
        //         column: "StudentID");

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_Enrollment_Person_StudentID",
        //        table: "Enrollment",
        //        column: "StudentID",
        //        principalTable: "Person",
        //        principalColumn: "ID",
        //        onDelete: ReferentialAction.Cascade);
        //}
        #endregion
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_CourseAssignment_Instructor_InstructorID",
            //    table: "CourseAssignment");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Department_Instructor_InstructorID",
            //    table: "Department");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_enrollment_student_StudentID",
            //    table: "enrollment");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_OfficeAssignment_Instructor_InstructorID",
            //    table: "OfficeAssignment");

            //migrationBuilder.DropTable(
            //    name: "Instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_student",
                table: "student");

            migrationBuilder.RenameTable(
                name: "student",
                newName: "Person");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "Department",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6)",
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Person",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20) CHARACTER SET utf8mb4",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Person",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20) CHARACTER SET utf8mb4",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Person",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Person",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssignment_Person_InstructorID",
                table: "CourseAssignment",
                column: "InstructorID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Person_InstructorID",
                table: "Department",
                column: "InstructorID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_enrollment_Person_StudentID",
                table: "enrollment",
                column: "StudentID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeAssignment_Person_InstructorID",
                table: "OfficeAssignment",
                column: "InstructorID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
            // Copy existing Student data into new Person table.
            migrationBuilder.Sql("INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator, OldId) SELECT LastName, FirstName, null AS HireDate, EnrollmentDate, 'Student' AS Discriminator, ID AS OldId FROM Student");
            // Fix up existing relationships to match new PK's.
            migrationBuilder.Sql("UPDATE Enrollment SET StudentId = (SELECT ID FROM Person WHERE OldId = Enrollment.StudentId AND Discriminator = 'Student')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssignment_Person_InstructorID",
                table: "CourseAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Person_InstructorID",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_enrollment_Person_StudentID",
                table: "enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeAssignment_Person_InstructorID",
                table: "OfficeAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "student");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "Department",
                type: "timestamp(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldRowVersion: true,
                oldNullable: true)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "student",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "student",
                type: "varchar(20) CHARACTER SET utf8mb4",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "student",
                type: "varchar(20) CHARACTER SET utf8mb4",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_student",
                table: "student",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssignment_Instructor_InstructorID",
                table: "CourseAssignment",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Instructor_InstructorID",
                table: "Department",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_enrollment_student_StudentID",
                table: "enrollment",
                column: "StudentID",
                principalTable: "student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeAssignment_Instructor_InstructorID",
                table: "OfficeAssignment",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
