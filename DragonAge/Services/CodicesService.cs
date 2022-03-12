using DragonAge.Data;
using DragonAge.Models;

namespace DragonAge.Services;

public class CodicesService
{
    private readonly DatabaseContext _db;

    public CodicesService(DatabaseContext db) => _db = db;

    public List<Codex> ReadAll() => _db.Codices.ToList();
    
    /*public Game Read(int id)
    {
        try
        {
            return _db.Games.Include(game => game.Categories).Single(game => game.Id == id);
        }
        catch
        {
            return null;
        }
    }*/
    
    
    
    
    /*public void Create(Game game)
    {
        _db.Add(game);
        _db.SaveChanges();
    }*/

    /*
    public void Update(int id, Game game)
    {
        var existingGame = _db.Games.Single(existingGame => existingGame.Id == id);

        existingGame.Update(game);

        _db.SaveChanges();
    }

    public void Delete(int id)
    {
        var game = _db.Games.Include(game => game.Categories).Single(game => game.Id == id);

        _db.Remove(game);

        _db.SaveChanges();
    }*/
}