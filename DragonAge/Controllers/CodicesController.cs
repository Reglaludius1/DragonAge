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
        
    public ActionResult<Codex> GetById(int id) =>  _db.Codices.Single(codex => codex.Id == id);

    [HttpGet]
    [Route(("GetByCategory"))]

    public ActionResult<List<Codex>> GetByCategory(string category) => _db.Codices.Where(codex => codex.Category == category).ToList();

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





