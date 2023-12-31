﻿using APIHealthClinic.Domain;
using APIHealthClinic.Interface;
using APIHealthClinic.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIHealthClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository;

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        [HttpPost]
        public IActionResult CadMedico(Medico medico)
        {
            try
            {
                _medicoRepository.CadastrarMedico(medico);
                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _medicoRepository.Remover(id);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Medico medico)
        {
            try
            {
                _medicoRepository.AtualizarMedico(id, medico);
                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetId(Guid id)
        {
            try
            {
                Medico result = _medicoRepository.BuscarId(id);
                return StatusCode(201, result);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet]
        public IActionResult GetMeds()
        {
            try
            {
                return Ok(_medicoRepository.ListarMedicos());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        [HttpGet("(BuscaConsulta)")]
        public IActionResult GetConsultas(string Nome)
        {
            try
            {
                _medicoRepository.ListarConsulta(Nome);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


    }
}
