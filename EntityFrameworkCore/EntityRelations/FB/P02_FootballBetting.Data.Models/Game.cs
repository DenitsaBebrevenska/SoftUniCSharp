using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;
public class Game
{
    //•	Game – GameId, HomeTeamId, AwayTeamId, HomeTeamGoals, AwayTeamGoals, DateTime, HomeTeamBetRate, AwayTeamBetRate, DrawBetRate, Result

    public int GameId { get; set; }
    public int HomeTeamId { get; set; }
    public int AwayTeamId { get; set; }
    public byte HomeTeamGoals { get; set; }
    public byte AwayTeamGoals { get; set; }
    public DateTime DateTime { get; set; }
    public decimal HomeTeamBetRate { get; set; }
    public decimal AwayTeamBetRate { get; set; }
    public decimal DrawBetRate { get; set; }

    [MaxLength(ValidationConstraints.GameResultLength)]
    public string Result { get; set; }
}
