using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIDemoRailway.Data;
using WebAPIDemoRailway.Models;

namespace WebAPIDemoRailway.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogsController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public BlogsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
    {
        var blogs = await _dbContext.Blogs
            .OrderByDescending(blog => blog.CreatedAt)
            .ToListAsync();

        return Ok(blogs);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Blog>> GetBlog(int id)
    {
        var blog = await _dbContext.Blogs.FindAsync(id);

        if (blog is null)
        {
            return NotFound();
        }

        return Ok(blog);
    }

    [HttpPost]
    public async Task<ActionResult<Blog>> CreateBlog(Blog blog)
    {
        blog.CreatedAt = DateTime.UtcNow;
        blog.UpdatedAt = blog.CreatedAt;

        _dbContext.Blogs.Add(blog);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBlog), new { id = blog.Id }, blog);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBlog(int id, Blog blog)
    {
        if (id != blog.Id)
        {
            return BadRequest("Id in URL must match blog.Id.");
        }

        var existingBlog = await _dbContext.Blogs.FindAsync(id);
        if (existingBlog is null)
        {
            return NotFound();
        }

        existingBlog.Title = blog.Title;
        existingBlog.Content = blog.Content;
        existingBlog.Author = blog.Author;
        existingBlog.UpdatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBlog(int id)
    {
        var blog = await _dbContext.Blogs.FindAsync(id);
        if (blog is null)
        {
            return NotFound();
        }

        _dbContext.Blogs.Remove(blog);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
}
