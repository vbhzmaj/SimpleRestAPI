using CommandsREST.Models;

namespace CommandsREST.Data;

    public interface ICommandsRepo
    {
         bool SaveChanges();
         
         IEnumerable <Command> GetAllCommands();
         Command GetCommandById(int id);
        void CreateCommand(Command cmd);
        
    }
