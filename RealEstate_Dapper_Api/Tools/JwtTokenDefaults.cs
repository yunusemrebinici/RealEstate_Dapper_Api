using System.Security.AccessControl;

namespace RealEstate_Dapper_Api.Tools
{
	public class JwtTokenDefaults
	{
		public const string ValidAudience = "https://localhost";
		public const string ValidIssuer = "https://localhost";
		public const string Key = "realEstateDapperApiSecretKey";
		public const int Expire =5;
	}
}
