﻿using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstate_Dapper_Api.Tools
{
	public class JwtTokenGenerator
	{
		public static TokenResponseViewModel GenerateToken (GetCheckAppUserViewModel model)
		{
			var claims = new List<Claim>();

			if (!string.IsNullOrEmpty(model.Role))
			{
				claims.Add(new Claim(ClaimTypes.Role, model.Role));

				claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()));
			}
			if (!string.IsNullOrWhiteSpace(model.UserName))
			{
				claims.Add(new Claim("UserName", model.UserName));
			}
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
			var signingCredantials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expireDate =DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);
			JwtSecurityToken token = new JwtSecurityToken(issuer:JwtTokenDefaults.ValidIssuer,audience:JwtTokenDefaults.ValidAudience,claims:claims,notBefore:DateTime.UtcNow,expires:expireDate,signingCredentials:signingCredantials);
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			return new TokenResponseViewModel(tokenHandler.WriteToken(token), expireDate);
			
				
			
		}
		
	}
}
