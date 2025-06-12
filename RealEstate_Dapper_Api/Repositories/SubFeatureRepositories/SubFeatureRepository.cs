﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.SubFeatureDtos;
using RealEstate_Dapper_Api.Models.DapperContext;


namespace RealEstate_Dapper_Api.Repositories.SubFeatureRepositories
{
    public class SubFeatureRepository : ISubFeatureRepository
    {
        private readonly Context _context;
        public SubFeatureRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultSubFeatureDtos>> GetAllSubFeature()
        {
            string query = "select * from SubFeature";
            using (var connection=_context.CrateConnection())
            {
                var values = await connection.QueryAsync<ResultSubFeatureDtos>(query);
                return values.ToList();
            }
        }
    }
}
