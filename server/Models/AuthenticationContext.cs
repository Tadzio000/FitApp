using Microsoft.EntityFrameworkCore;  
namespace WebApi.Models {     
public class TodoContext : DbContext     
  {         
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)         
{         
}       
    public DbSet<AuthenticateModel> Users { get; set; }     

   } 
}