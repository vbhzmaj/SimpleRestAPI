using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CommandsREST.Models;
using CommandsREST.Data;

namespace CommandsREST.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
       private readonly ICommandsRepo _repository;

       public CommandsController (ICommandsRepo repository)
       {
            _repository = repository;
       }
       //GET api/commands
       [HttpGet]
       public ActionResult <IEnumerable<Command>> GetAllComands()
       {
            var commandItems = _repository.GetAppCommands();
            return Ok(commandItems);
       } 

       //GET api/commands/5
       [HttpGet("{id}")] 
       public ActionResult<Command> GetCommandById(int id)
       {
            var commandItem = _repository.GetCommandById(id);
            return Ok(commandItem);
       }
    }
