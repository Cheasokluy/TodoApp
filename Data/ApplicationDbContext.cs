using Microsoft.AspNetCore.Identity.EntityFrameworkCore ;
using Microsoft.EntityFrameworkCore ;
using Microsoft.AspNetCore.Identity;
using TodoApi.Data;
using TodoApi.Models;
namespace TodoApi.Data 
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<TodoModel> Todo { get; set; }

        public ApplicationDbContext( 
            DbContextOptions<ApplicationDbContext> options 
        ) : base( options )
        {
            
            // To be implemented.
        }

        

    }
}