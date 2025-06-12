using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
	public class ContactRepository : IContactRepository

	{
		private readonly Context _context;

		public ContactRepository(Context context)
		{
			_context = context;
		}

		public async Task CreateContact(CreateContactDto createContactDto)
		{
			string query = "insert into Contact  (Name,Subject,Email,Message,SendDate) values (@name,@subject,@mail,@message,@senddate)";
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@name", createContactDto.Name);
			parameters.Add("@subject", createContactDto.Subject);
			parameters.Add("@mail", createContactDto.Email);
			parameters.Add("@message", createContactDto.Message);
			parameters.Add("@senddate", createContactDto.SendDate);
			
			using (var connection = _context.CrateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task DeleteContaact(int id)
		{
			var query = "delete from Contact where ContactID=@id";
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@id", id);
			using (var connection = _context.CrateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultContactDto>> GetAllContact()
		{
			var query = "Select * from Contact";
			using (var connectin = _context.CrateConnection())
			{
				var values = await connectin.QueryAsync<ResultContactDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetByIdContactDto> GetContact(int id)
		{
			var query = "select * from Contact where ContactID=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@id", id);
			using (var connection = _context.CrateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIdContactDto>(query, parameters);
				return values;
			}
		}

		public async Task<List<Last4ContactResultDto>> GetLast4Contact()
		{
			var query = "select top(4) * from Contact order by ContactID desc";
			using (var connectin = _context.CrateConnection())
			{
				var values = await connectin.QueryAsync<Last4ContactResultDto>(query);
				return values.ToList();
			}
		}
	}
}
