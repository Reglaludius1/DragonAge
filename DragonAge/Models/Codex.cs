using System.Text.Json.Serialization;

namespace DragonAge.Models;

public class Codex
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Category { get; set; }
    public string Title { get; set; }
    public string Contents { get; set; }
    public string? Summary { get; set; }
}