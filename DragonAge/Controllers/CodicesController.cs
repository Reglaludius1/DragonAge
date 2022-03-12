using System.ComponentModel;
using DragonAge.Data;
using DragonAge.Models;
using DragonAge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DragonAge.Controllers;

[ApiController]
[Route("[controller]")]
public class CodicesController : ControllerBase
{

    private readonly DatabaseContext _db;
    private readonly CodicesService _service;

    public CodicesController(DatabaseContext databaseContext)
    {
        _service = new CodicesService(databaseContext);
        _db = databaseContext;
    }

    [HttpGet]
    [Route("GetAll")]
    public ActionResult<List<Codex>> ReadAll() => _service.ReadAll();

    [HttpGet]
    [Route("{id:int}")]
    public ActionResult<Codex> GetById(int id)
    {
        return _db.Codices.Single(codex => codex.Id == id);
    }

    [HttpGet]
    [Route(("GetByCategory"))]

    public ActionResult<List<Codex>> GetByCategory(string category)
    {
        return _db.Codices.Where(codex => codex.Category == category).ToList();
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult<List<Codex>>> CreateNewGame(Codex codex)
    {
        _db.Codices.Add(codex);
        await _db.SaveChangesAsync();
        return StatusCode(201);

    }

    [HttpPatch]
    [Route("Edit")]


    public async Task<ActionResult<List<Codex>>> EditGame(int id, Codex codex)
    {
        var gameToEdit = _db.Codices.FirstOrDefault(x => x.Id == id);
        if (gameToEdit == null) return Ok();
        gameToEdit.Category = codex.Category;
        gameToEdit.Contents = codex.Contents;
        gameToEdit.Summary = codex.Summary;
        gameToEdit.Title = codex.Title;
        await _db.SaveChangesAsync();
        return StatusCode(201);

    }

    [HttpDelete]
    [Route("Deleteaz")]

    public async Task<ActionResult<List<Codex>>> DeleteGameById(int id, Codex codex)
    {
       _db.Codices.Remove(_db.Codices.Single(x => x.Id == id));
        await _db.SaveChangesAsync();
        return StatusCode(201);
    }
}
/*
[HttpPost]
public ActionResult Create(Game game)
{
    _service.Create(game);

    return CreatedAtAction(nameof(Create), new {id = game.Id}, game);
}
*/

    /*
    [HttpGet]
    [Route("{id:int}")]
    public ActionResult<Game> Read(int id)
    {
        var game = _service.Read(id);
            
        if (game == null)
        {
            return NotFound();
        }

        return game;
    }*/
    /*[HttpPatch]
    [Route("{id:int}")]
    public ActionResult Update(int id, Game game)
    {
        var existingGame = _service.Read(id);
            
        if (existingGame == null)
        {
            return NotFound();
        }

        _service.Update(id, game);

        return NoContent();
        
          [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            var game = _service.Read(id);
            
            if (game == null)
            {
                return NotFound();
            }

    }*/




