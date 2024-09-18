using Microsoft.AspNetCore.Identity.EntityFrameworkCore ;
using Microsoft.EntityFrameworkCore ;
using Microsoft.AspNetCore.Identity;
using TodoApi.Data;
namespace TodoApi.Data 
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext( 
            DbContextOptions<ApplicationDbContext> options 
        ) : base( options )
        {
            // To be implemented.
        }

        

    }
}