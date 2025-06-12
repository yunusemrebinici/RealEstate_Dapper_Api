using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using RealEstate_Dapper_Api.Dtos.LoginDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly Context _context;

		public LoginController(Context context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task<IActionResult> SigIn(CreateLoginDto createLoginDto)
		{ 
		       string query= "Select * from AppUser where UserName=@UserName and Password=@Password	";
		       string query2= "Select UserId from AppUser where UserName=@UserName and Password=@Password";

			   var paramater = new DynamicParameters();
			    paramater.Add("@UserName", createLoginDto.UserName);
			    paramater.Add("@Password", createLoginDto.Password);
			using (var connection = _context.CrateConnection())
			{
				var values2 = await connection.QueryFirstOrDefaultAsync<GetAppUserIdDto>(query2, paramater);
				var values = await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query, paramater);
				if (values != null)
				{
					GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
					model.UserName= values.UserName;
					model.Id = values2.UserId;
					model.Role = "a";
					var token =JwtTokenGenerator.GenerateToken(model);
					return Ok(token);
				}
				else
				{
					return Ok("Başarısız");
				}
			}
		}
	}
}
