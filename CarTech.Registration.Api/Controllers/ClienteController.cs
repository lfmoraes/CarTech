using AutoMapper;
using CarTech.Domain.Models;
using CarTech.Registration.Api.DTO;
using CarTech.Registration.Data.Interface.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarTech.Registration.Api.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public ClienteController(IRepositoryWrapper repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientes = await _repository.Cliente.GetAllClientesAsync();

                var clientesToReturn = _mapper.Map<List<ClienteDTO>>(clientes);

                return Ok(clientesToReturn);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            try
            {
                var cliente = await _repository.Cliente.GetClienteByIdAsync(id);

                if(cliente == null)
                {
                    return NotFound();
                }

                var clienteToReturn = _mapper.Map<ClienteDTO>(cliente);

                return clienteToReturn;
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ClienteDTO cliente)
        {
            try
            {
                if (cliente == null)
                {
                    return BadRequest("Objeto Cliente está nulo.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Objeto Cliente inválido");
                }

                var entityCliente = _mapper.Map<Cliente>(cliente);
                _repository.Cliente.CreateCliente(entityCliente);
                
                if(await _repository.SaveAsync())
                {
                    return CreatedAtAction("Get", new { id = cliente.Id }, cliente);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody]ClienteDTO cliente)
        {
            try
            {
                if (cliente == null)
                {
                    return BadRequest("Objeto Cliente está nulo.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Objeto Cliente inválido");
                }

                var entityCliente = await _repository.Cliente.GetClienteByIdAsync(id);

                if (entityCliente == null)
                {
                    return NotFound();
                }

                _mapper.Map(cliente, entityCliente);

                _repository.Cliente.UpdateCliente(entityCliente);

                if (await _repository.SaveAsync())
                {
                    return CreatedAtAction("Get", new { id = cliente.Id }, cliente);
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
