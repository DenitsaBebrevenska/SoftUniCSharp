namespace ForumApp.Infrastructure.Constants;
/// <summary>
///	Constants for model validation
/// </summary>
public static class ValidationConstraints
{
	//Post

	/// <summary>
	///	Minimum length for post title
	/// </summary>
	///
	public const int PostTittleMinLength = 2;

	/// <summary>
	///	Maximum length for post title
	/// </summary>
	///
	public const int PostTittleMaxLength = 100;

	/// <summary>
	///	Minimum length for post content
	/// </summary>
	///
	public const int PostContentMinLength = 2;

	/// <summary>
	///	Maximum length for post title
	/// </summary>
	///
	public const int PostContentMaxLength = 500;
}
