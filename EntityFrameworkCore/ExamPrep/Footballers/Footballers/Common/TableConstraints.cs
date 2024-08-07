﻿namespace Footballers.Common;

public class TableConstraints
{
    //Footballer
    public const int FootballerNameMinLength = 2;
    public const int FootballerNameMaxLength = 40;

    //Team
    public const int TeamNameMinLength = 3;
    public const int TeamNameMaxLength = 40;
    public const string TeamNamePattern = @"[A-Za-z\d \.-]+";
    public const int TeamNationalityMinLength = 2;
    public const int TeamNationalityMaxLength = 40;
    public const int TeamMinimumTrophyCount = 1;

    //Coach
    public const int CoachNameMinLength = 2;
    public const int CoachNameMaxLength = 40;


}
