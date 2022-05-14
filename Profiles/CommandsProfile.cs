using AutoMapper;
using CommandsREST.DTOs;
using CommandsREST.Models;

namespace CommandsREST.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source -> Target
            CreateMap<Command, CommandReadDTO>();
            CreateMap<CommandCreateDTO, Command>();
        }

    }
}