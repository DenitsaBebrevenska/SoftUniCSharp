using HouseRentingSystem.Core.Contracts;
using System.Text.RegularExpressions;

namespace HouseRentingSystem.Core.Extensions;
public static class ModelExtensions
{
	public static string GetInformation(this IHouseModel model)
	{
		string info = model.Title.Replace(" ", "-") + GetAddress(model.Address);
		info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

		return info;
	}

	private static string GetAddress(string address)
	{
		string result = string.Join("-", address.Split(" ").Take(3));

		return result;
	}
}
