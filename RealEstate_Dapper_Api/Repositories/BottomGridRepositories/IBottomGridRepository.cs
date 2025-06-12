﻿using RealEstate_Dapper_Api.Dtos.BottomGridDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
	public interface IBottomGridRepository
	{
		Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();

		Task  CreateBottomGrid(CreateBottomGridDto createBottomGridDto);

		Task  DeleteBottomGrid(int id);

		Task  UpdaterBottomGrid(UpdateBottomGridDto updateBottomGridDto);

		Task<GetBottomGridDto> GetBottomGrid(int id);
	}
}
