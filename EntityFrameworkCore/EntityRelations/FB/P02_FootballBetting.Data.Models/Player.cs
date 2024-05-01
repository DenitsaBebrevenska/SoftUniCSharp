using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;
public class Player
{

    //•	Player – PlayerId, Name, SquadNumber, Assists, TownId, PositionId, IsInjured, TeamId

    public int PlayerId { get; set; }

    [MaxLength(ValidationConstraints.PlayerNameLength)]
    public string Name { get; set; }
    public byte SquadNumber { get; set; }
    public byte Assists { get; set; }
    public int TownId { get; set; }
    public int PositionId { get; set; }
    public bool IsInjured { get; set; }
    public int TeamId { get; set; }


}
