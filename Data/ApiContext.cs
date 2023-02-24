using Microsoft.EntityFrameworkCore;
using BookBorrowingAPI.Models;
using BookBorrowingAPI.Controllers;
using BookBorrowingAPI.Data;

namespace BookBorrowingAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
           
        }
    }
}