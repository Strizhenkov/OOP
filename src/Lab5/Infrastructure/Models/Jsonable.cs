using System.Text.Json;

namespace Infrastructure.Models;

public abstract class Jsonable
{
    protected JsonSerializerOptions? Options { get; set; }
    public abstract string Serial();
    public abstract override string ToString();
    public abstract Jsonable? Deserial(string jsonString);
}