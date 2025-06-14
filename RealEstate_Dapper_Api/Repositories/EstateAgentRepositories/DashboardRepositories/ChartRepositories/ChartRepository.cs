﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.ChartDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories
{
	public class ChartRepository : IChartRepository
	{
		private readonly Context _context;

		public ChartRepository(Context context)
		{
			_context = context;
		}

		public async Task<List<ResultChartDto>> Get5CityForChart()
		{
			string query = "select top(5) City ,Count(*) as 'CityCount' from Product  group by City order by CityCount desc";
			using (var connection = _context.CrateConnection())
			{
				var values =await connection.QueryAsync<ResultChartDto>(query);
				return values.ToList();
			}

		}
	}
}
