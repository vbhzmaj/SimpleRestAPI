using CommandsREST.Models;

namespace CommandsREST.Data;

    public interface ICommandsRepo
    {
         bool SaveChanges();
         
         IEnumerable <Command> GetAllCommands();
         Command GetCommandById(int id);
         void CreateCommand(Command cmd);
         void UpdateCommand(Command cmd);
         void DeleteCommand(Command cmd);
        
    }
