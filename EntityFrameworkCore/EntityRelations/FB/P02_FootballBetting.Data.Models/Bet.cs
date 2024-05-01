using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;
public class Bet
{
    //•	Bet – BetId, Amount, Prediction, DateTime, UserId, GameId

    public int BetId { get; set; }
    public decimal Amount { get; set; }

    [MaxLength(ValidationConstraints.BetPredictionLength)]
    public string Prediction { get; set; }

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }
    public int GameId { get; set; }
}
