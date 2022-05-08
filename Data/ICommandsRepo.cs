using CommandsREST.Models;

namespace CommandsREST.Data;

    public interface ICommandsRepo
    {
         IEnumerable <Command> GetAllCommands();
         Command GetCommandById(int id);
    }
