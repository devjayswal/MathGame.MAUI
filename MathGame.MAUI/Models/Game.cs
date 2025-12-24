using SQLite;

namespace MathGame.MAUI.Models;

[Table("game")]
public class Game
{
    [PrimaryKey, AutoIncrement, Column("Id")]
    public int Id { get; set; }
    public DateTime DatePlayed { get; set; }
    public int Score { get; set; }
    public GameOperation Type { get; set; }
}

public enum GameOperation
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}