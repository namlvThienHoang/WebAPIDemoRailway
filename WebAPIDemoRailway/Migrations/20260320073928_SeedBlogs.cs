using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPIDemoRailway.Migrations
{
    /// <inheritdoc />
    public partial class SeedBlogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Nguyễn Văn An", "Python là ngôn ngữ lập trình bậc cao, dễ đọc và dễ học. Bài viết này giới thiệu các khái niệm cơ bản như biến, kiểu dữ liệu, câu lệnh điều kiện và vòng lặp. Phù hợp cho những ai muốn bước chân vào thế giới lập trình.", new DateTime(2026, 3, 20, 7, 31, 54, 903, DateTimeKind.Utc), "Học lập trình Python cơ bản cho người mới bắt đầu", new DateTime(2026, 3, 20, 7, 31, 54, 903, DateTimeKind.Utc) },
                    { 2, "Trần Thị Bích", "Đà Lạt vào những tháng cuối năm khoác lên mình màu vàng rực rỡ của hoa dã quỳ. Những cung đường như đèo Prenn, hồ Tuyền Lâm hay đồi chè Cầu Đất trở nên thơ mộng và hấp dẫn du khách. Đừng quên thưởng thức trà nóng và bánh tráng nướng khi đến đây.", new DateTime(2026, 3, 19, 10, 15, 30, 0, DateTimeKind.Utc), "Khám phá Đà Lạt mùa hoa dã quỳ", new DateTime(2026, 3, 20, 8, 20, 45, 123, DateTimeKind.Utc) },
                    { 3, "Lê Hoàng Mai", "Phở bò là món ăn truyền thống của Việt Nam, đặc biệt là phở Hà Nội. Bí quyết nằm ở nước dùng được hầm từ xương ống, thêm quế, hồi, gừng nướng và thảo quả. Thịt bò tái chần tới vừa chín tới, ăn kèm bánh phở mềm và rau thơm. Hãy thử ngay tại nhà!", new DateTime(2026, 3, 18, 2, 45, 12, 456, DateTimeKind.Utc), "Bí quyết nấu phở bò chuẩn vị Hà Nội", new DateTime(2026, 3, 18, 14, 30, 22, 789, DateTimeKind.Utc) },
                    { 4, "Phạm Minh Quân", "Trí tuệ nhân tạo (AI) tiếp tục bùng nổ với các mô hình ngôn ngữ lớn, ứng dụng trong y tế, giáo dục và sản xuất. Bài viết điểm qua những tiến bộ mới nhất như AI tạo sinh (Generative AI), học tăng cường và các vấn đề đạo đức liên quan.", new DateTime(2026, 3, 17, 19, 8, 33, 111, DateTimeKind.Utc), "Xu hướng công nghệ AI năm 2026", new DateTime(2026, 3, 19, 9, 12, 5, 678, DateTimeKind.Utc) },
                    { 5, "Hoàng Thị Thu", "Chạy bộ không chỉ giúp cải thiện sức khỏe tim mạch, tăng cường hệ miễn dịch mà còn giảm căng thẳng, cải thiện tinh thần. Bài viết chia sẻ kinh nghiệm chạy bộ đúng cách, chọn giày phù hợp và xây dựng lộ trình cho người mới.", new DateTime(2026, 3, 16, 5, 22, 44, 567, DateTimeKind.Utc), "Lợi ích của việc chạy bộ mỗi sáng", new DateTime(2026, 3, 17, 12, 34, 56, 789, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
