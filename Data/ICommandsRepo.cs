using CommandsREST.Models;

namespace CommandsREST.Data;

    public interface ICommandsRepo
    {
         IEnumerable <Command> GetAppCommands();
         Command GetCommandById(int id);
    }
