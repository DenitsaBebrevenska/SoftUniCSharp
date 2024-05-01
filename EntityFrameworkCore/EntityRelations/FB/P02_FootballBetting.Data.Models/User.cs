using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;
public class User
{

    //•	User – UserId, Username, Password, Email, Name, Balance

    public int UserId { get; set; }

    [MaxLength(ValidationConstraints.UserUsernameLength)]
    public string Username { get; set; }

    [MaxLength(ValidationConstraints.UserPasswordLength)]
    public string Password { get; set; }

    [MaxLength(ValidationConstraints.UserEmailLength)]
    public string Email { get; set; }

    [MaxLength(ValidationConstraints.UserNameLength)]
    public string Name { get; set; }

    public decimal Balance { get; set; }
}
