﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryRepository.GetAllCategory();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
			await _categoryRepository.CreateCategory(createCategoryDto);
            return Ok("Kategori Başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteCategory(int id)
        {
			await _categoryRepository.DeleteCategory(id);
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult>UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
			await _categoryRepository.UpdateCategory(updateCategoryDto);
            return Ok("Güncelleme Başarılı");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var value=await _categoryRepository.GetByIdCategory(id);
            return Ok(value);
        }
    }
}
