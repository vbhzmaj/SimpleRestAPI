using System.Collections.Generic;
using System.Linq;
using CommandsREST.Models;

namespace CommandsREST.Data
{
    public class SQLCommandsRepo : ICommandsRepo
    {
        private readonly CommanderContext _context;
        
        public SQLCommandsRepo(CommanderContext context)
        {
            _context = context;
        }

        public IEnumerable <Command> GetAllCommands()
        {
           return _context.Commands.ToList();
        }
         public Command GetCommandById(int id)
         {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
         }
    }
}