namespace P02_FootballBetting.Data.Common;
public static class ValidationConstraints
{
    //Team constraints
    public const int TeamNameLength = 255;
    public const int TeamUrlLogoLength = 2048; //max url length at all
    public const int TeamInitialsLength = 5;

    //Color constraint
    public const int ColorNameLength = 10;

    //Player constraint
    public const int PlayerNameLength = 250;

    //Position constraint
    public const int PositionNameLength = 20;

    //Game constraint
    public const int GameResultLength = 5;

    //Bet constraint
    public const int BetPredictionLength = 5;

    //User constraints
    public const int UserUsernameLength = 20;
    public const int UserPasswordLength = 255;
    public const int UserEmailLength = 320;
    public const int UserNameLength = 255;
}
