namespace P02_FootballBetting.Data.Models;
public class PlayerStatistic
{
    public int GameId { get; set; }
    public virtual Game Game { get; set; }

    public int PlayerId { get; set; }
    public virtual Player Player { get; set; }

    public byte ScoredGoals { get; set; }

    public byte Assists { get; set; }

    public int MinutesPlayed { get; set; }
}
