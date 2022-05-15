using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CommandsREST.Models;
using CommandsREST.Data;
using AutoMapper;
using CommandsREST.DTOs;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.JsonPatch;

namespace CommandsREST.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommandsController : ControllerBase
{
    private readonly ICommandsRepo _repository;
    private readonly IMapper _mapper;

    public CommandsController(ICommandsRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    //GET api/commands
    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDTO>> GetAllComands()
    {
        var commandItems = _repository.GetAllCommands();
        return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commandItems));
    }

    //GET api/commands/{id}
    [HttpGet("{id}", Name="GetCommandById")]
    public ActionResult<CommandReadDTO> GetCommandById(int id)
    {
        var commandItem = _repository.GetCommandById(id);
        if (commandItem != null)
        {
            return Ok(_mapper.Map<CommandReadDTO>(commandItem));
        }

        return NotFound();

    }

    //POST api/commands
    [HttpPost]
    public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO commandCreateDTO)
        {
        var commandModel = _mapper.Map<Command>(commandCreateDTO);
        _repository.CreateCommand(commandModel);
        _repository.SaveChanges();

        var commandReadDTO = _mapper.Map<CommandReadDTO>(commandModel);

        //return Ok(commandReadDTO);
        return CreatedAtRoute(nameof(GetCommandById), new {Id=commandReadDTO.Id}, commandReadDTO);
        }

    //PUT api/commands
    [HttpPut("{id}")]
    public ActionResult UpdateCommand(int id, CommandUpdateDTO commandUpdateDTO)
    {
        var commandModelFromRepo = _repository.GetCommandById(id);
        if(commandModelFromRepo == null)
        {
            return NotFound();
        }

        _mapper.Map(commandUpdateDTO, commandModelFromRepo);

        _repository.UpdateCommand(commandModelFromRepo);

        _repository.SaveChanges();

        return NoContent();
    }

    //PATCH api/commands/{id}
    [HttpPatch("{id}")]
    public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDTO> patchDoc)
    {
        var commandModelFromRepo = _repository.GetCommandById(id);
        if(commandModelFromRepo == null)
        {
            return NotFound();
        }

        var commandToPatch = _mapper.Map<CommandUpdateDTO>(commandModelFromRepo);
        patchDoc.ApplyTo(commandToPatch, ModelState);
        if(!TryValidateModel(commandToPatch))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(commandToPatch, commandModelFromRepo);
        _repository.UpdateCommand(commandModelFromRepo);
        _repository.SaveChanges();
        return NoContent();
    }

    //DELETE api/commands/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteCommand(int id)
    {
        var commandModelFromRepo = _repository.GetCommandById(id);
        if(commandModelFromRepo == null)
        {
            return NotFound();
        }
        _repository.DeleteCommand(commandModelFromRepo);
        _repository.SaveChanges();

        return NoContent();
    }
}