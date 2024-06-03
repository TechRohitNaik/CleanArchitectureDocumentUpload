using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SqlScript : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Insert Into Products(ProductName)values('Product 1')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
