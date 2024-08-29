namespace TaskBoardApp.Data;

/// <summary>
/// Constraints for the data models
/// </summary>
public static class DataConstraints
{
    /// <summary>
    /// Task title minimum length
    /// </summary>
    public const int TaskTitleMinLength = 5;

    /// <summary>
    /// Task title maximum length
    /// </summary>
    public const int TaskTitleMaxLength = 70;

    /// <summary>
    /// Task description minimum length
    /// </summary>
    public const int TaskDescriptionMinLength = 10;

    /// <summary>
    /// Task description maximum length
    /// </summary>
    public const int TaskDescriptionMaxLength = 1_000;

    /// <summary>
    /// Board name minimum length
    /// </summary>
    public const int BoardNameMinLength = 3;

    /// <summary>
    /// Board name maximum length
    /// </summary>
    public const int BoardNameMaxLength = 30;
}
