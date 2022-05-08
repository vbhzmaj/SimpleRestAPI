using Microsoft.EntityFrameworkCore;
using CommandsREST.Models;

namespace CommandsREST.Data
{
    public class CommanderContext:DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {      }

        public DbSet<Command> Commands {get; set;}
        
    }
}