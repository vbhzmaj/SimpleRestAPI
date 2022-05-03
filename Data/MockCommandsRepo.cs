using System.Collections.Generic;
using CommandsREST.Models;

namespace CommandsREST.Data;

    public class MockCommandsRepo : ICommandsRepo
    {
        public IEnumerable <Command> GetAppCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle&Pan"},
                new Command{Id=1, HowTo="Cut bread", Line="Get a knife", Platform="Knife $ chopping board"},
                new Command{Id=2, HowTo="Make cup of tea", Line="Place teabag in cup", Platform="Kettle& cup"}
            };

            return commands;
        }
         public Command GetCommandById(int id)
         {
             return new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle&Pan"};

         }
        
    }


