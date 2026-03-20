using Microsoft.EntityFrameworkCore;
using WebAPIDemoRailway.Models;

namespace WebAPIDemoRailway.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Blog> Blogs => Set<Blog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.ToTable("Blogs");
            entity.HasKey(blog => blog.Id);
            entity.Property(blog => blog.Title).IsRequired().HasMaxLength(200);
            entity.Property(blog => blog.Content).IsRequired();
            entity.Property(blog => blog.Author).HasMaxLength(100);
            entity.Property(blog => blog.CreatedAt).HasColumnType("timestamp with time zone");
            entity.Property(blog => blog.UpdatedAt).HasColumnType("timestamp with time zone");
            entity.HasData(
                new Blog
                {
                    Id = 1,
                    Title = "H\u1ecdc l\u1eadp tr\u00ecnh Python c\u01a1 b\u1ea3n cho ng\u01b0\u1eddi m\u1edbi b\u1eaft \u0111\u1ea7u",
                    Content = "Python l\u00e0 ng\u00f4n ng\u1eef l\u1eadp tr\u00ecnh b\u1eadc cao, d\u1ec5 \u0111\u1ecdc v\u00e0 d\u1ec5 h\u1ecdc. B\u00e0i vi\u1ebft n\u00e0y gi\u1edbi thi\u1ec7u c\u00e1c kh\u00e1i ni\u1ec7m c\u01a1 b\u1ea3n nh\u01b0 bi\u1ebfn, ki\u1ec3u d\u1eef li\u1ec7u, c\u00e2u l\u1ec7nh \u0111i\u1ec1u ki\u1ec7n v\u00e0 v\u00f2ng l\u1eb7p. Ph\u00f9 h\u1ee3p cho nh\u1eefng ai mu\u1ed1n b\u01b0\u1edbc ch\u00e2n v\u00e0o th\u1ebf gi\u1edbi l\u1eadp tr\u00ecnh.",
                    Author = "Nguy\u1ec5n V\u0103n An",
                    CreatedAt = new DateTime(2026, 3, 20, 7, 31, 54, 903, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 3, 20, 7, 31, 54, 903, DateTimeKind.Utc)
                },
                new Blog
                {
                    Id = 2,
                    Title = "Kh\u00e1m ph\u00e1 \u0110\u00e0 L\u1ea1t m\u00f9a hoa d\u00e3 qu\u1ef3",
                    Content = "\u0110\u00e0 L\u1ea1t v\u00e0o nh\u1eefng th\u00e1ng cu\u1ed1i n\u0103m kho\u00e1c l\u00ean m\u00ecnh m\u00e0u v\u00e0ng r\u1ef1c r\u1ee1 c\u1ee7a hoa d\u00e3 qu\u1ef3. Nh\u1eefng cung \u0111\u01b0\u1eddng nh\u01b0 \u0111\u00e8o Prenn, h\u1ed3 Tuy\u1ec1n L\u00e2m hay \u0111\u1ed3i ch\u00e8 C\u1ea7u \u0110\u1ea5t tr\u1edf n\u00ean th\u01a1 m\u1ed9ng v\u00e0 h\u1ea5p d\u1eabn du kh\u00e1ch. \u0110\u1eebng qu\u00ean th\u01b0\u1edfng th\u1ee9c tr\u00e0 n\u00f3ng v\u00e0 b\u00e1nh tr\u00e1ng n\u01b0\u1edbng khi \u0111\u1ebfn \u0111\u00e2y.",
                    Author = "Tr\u1ea7n Th\u1ecb B\u00edch",
                    CreatedAt = new DateTime(2026, 3, 19, 10, 15, 30, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 3, 20, 8, 20, 45, 123, DateTimeKind.Utc)
                },
                new Blog
                {
                    Id = 3,
                    Title = "B\u00ed quy\u1ebft n\u1ea5u ph\u1edf b\u00f2 chu\u1ea9n v\u1ecb H\u00e0 N\u1ed9i",
                    Content = "Ph\u1edf b\u00f2 l\u00e0 m\u00f3n \u0103n truy\u1ec1n th\u1ed1ng c\u1ee7a Vi\u1ec7t Nam, \u0111\u1eb7c bi\u1ec7t l\u00e0 ph\u1edf H\u00e0 N\u1ed9i. B\u00ed quy\u1ebft n\u1eb1m \u1edf n\u01b0\u1edbc d\u00f9ng \u0111\u01b0\u1ee3c h\u1ea7m t\u1eeb x\u01b0\u01a1ng \u1ed1ng, th\u00eam qu\u1ebf, h\u1ed3i, g\u1eebng n\u01b0\u1edbng v\u00e0 th\u1ea3o qu\u1ea3. Th\u1ecbt b\u00f2 t\u00e1i ch\u1ea7n t\u1edbi v\u1eeba ch\u00edn t\u1edbi, \u0103n k\u00e8m b\u00e1nh ph\u1edf m\u1ec1m v\u00e0 rau th\u01a1m. H\u00e3y th\u1eed ngay t\u1ea1i nh\u00e0!",
                    Author = "L\u00ea Ho\u00e0ng Mai",
                    CreatedAt = new DateTime(2026, 3, 18, 2, 45, 12, 456, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 3, 18, 14, 30, 22, 789, DateTimeKind.Utc)
                },
                new Blog
                {
                    Id = 4,
                    Title = "Xu h\u01b0\u1edbng c\u00f4ng ngh\u1ec7 AI n\u0103m 2026",
                    Content = "Tr\u00ed tu\u1ec7 nh\u00e2n t\u1ea1o (AI) ti\u1ebfp t\u1ee5c b\u00f9ng n\u1ed5 v\u1edbi c\u00e1c m\u00f4 h\u00ecnh ng\u00f4n ng\u1eef l\u1edbn, \u1ee9ng d\u1ee5ng trong y t\u1ebf, gi\u00e1o d\u1ee5c v\u00e0 s\u1ea3n xu\u1ea5t. B\u00e0i vi\u1ebft \u0111i\u1ec3m qua nh\u1eefng ti\u1ebfn b\u1ed9 m\u1edbi nh\u1ea5t nh\u01b0 AI t\u1ea1o sinh (Generative AI), h\u1ecdc t\u0103ng c\u01b0\u1eddng v\u00e0 c\u00e1c v\u1ea5n \u0111\u1ec1 \u0111\u1ea1o \u0111\u1ee9c li\u00ean quan.",
                    Author = "Ph\u1ea1m Minh Qu\u00e2n",
                    CreatedAt = new DateTime(2026, 3, 17, 19, 8, 33, 111, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 3, 19, 9, 12, 5, 678, DateTimeKind.Utc)
                },
                new Blog
                {
                    Id = 5,
                    Title = "L\u1ee3i \u00edch c\u1ee7a vi\u1ec7c ch\u1ea1y b\u1ed9 m\u1ed7i s\u00e1ng",
                    Content = "Ch\u1ea1y b\u1ed9 kh\u00f4ng ch\u1ec9 gi\u00fap c\u1ea3i thi\u1ec7n s\u1ee9c kh\u1ecfe tim m\u1ea1ch, t\u0103ng c\u01b0\u1eddng h\u1ec7 mi\u1ec5n d\u1ecbch m\u00e0 c\u00f2n gi\u1ea3m c\u0103ng th\u1eb3ng, c\u1ea3i thi\u1ec7n tinh th\u1ea7n. B\u00e0i vi\u1ebft chia s\u1ebb kinh nghi\u1ec7m ch\u1ea1y b\u1ed9 \u0111\u00fang c\u00e1ch, ch\u1ecdn gi\u00e0y ph\u00f9 h\u1ee3p v\u00e0 x\u00e2y d\u1ef1ng l\u1ed9 tr\u00ecnh cho ng\u01b0\u1eddi m\u1edbi.",
                    Author = "Ho\u00e0ng Th\u1ecb Thu",
                    CreatedAt = new DateTime(2026, 3, 16, 5, 22, 44, 567, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 3, 17, 12, 34, 56, 789, DateTimeKind.Utc)
                });
        });
    }
}
