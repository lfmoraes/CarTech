using AutoMapper;
using CarTech.Data.Interface.Base;
using CarTech.Domain.Models;
using CarTech.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarTech.Registration.Api.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public CategoriaController(IRepositoryWrapper repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categorias = await _repository.Categoria.GetAllCategoriasAsync();

                var categoriasToReturn = _mapper.Map<List<CategoriaViewModel>>(categorias);

                return Ok(categoriasToReturn);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaViewModel>> Get(int id)
        {
            try
            {
                var categoria = await _repository.Categoria.GetCategoriaByIdAsync(id);

                if (categoria == null)
                {
                    return NotFound();
                }

                var categoriaToReturn = _mapper.Map<CategoriaViewModel>(categoria);

                return categoriaToReturn;
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoriaViewModel categoria)
        {
            try
            {
                if (categoria == null)
                {
                    return BadRequest("Objeto Categoria está nulo.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Objeto Categoria inválido");
                }

                var entityCategoria = _mapper.Map<Categoria>(categoria);
                _repository.Categoria.CreateCategoria(entityCategoria);

                if (await _repository.SaveAsync())
                {
                    return CreatedAtAction("Get", new { id = categoria.Id }, categoria);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] CategoriaViewModel categoria)
        {
            try
            {
                if (categoria == null)
                {
                    return BadRequest("Objeto Categoria está nulo.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Objeto Categoria inválido");
                }

                var entityCategoria = await _repository.Categoria.GetCategoriaByIdAsync(id);

                if (entityCategoria == null)
                {
                    return NotFound();
                }

                _mapper.Map(categoria, entityCategoria);

                _repository.Categoria.UpdateCategoria(entityCategoria);

                if (await _repository.SaveAsync())
                {
                    return CreatedAtAction("Get", new { id = categoria.Id }, categoria);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

            return BadRequest();
        }
    }
}
