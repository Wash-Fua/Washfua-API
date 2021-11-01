using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WashFua.Dtos;
using WashFua.Entities;
using WashFua.Repositories;

namespace WashFua.Controllers
{
   
        [ApiController]
        [Route("mamas")]
        public class MamaFuaController : ControllerBase
        {
            private readonly IMamaFuaRepository repository;

            public MamaFuaController(IMamaFuaRepository repository)
            {
                this.repository = repository;
            }
            
            // GET /mamafuas
            [HttpGet]
            public IEnumerable<MamaFuaDto> GetMamasFuas()
            {
                var mamas = repository.GetMamaFuas().Select(mamaFua => mamaFua.AsDto());
                return mamas;
            }
            
            // GET /mamas/{id}
            [HttpGet("{id}")]
            public ActionResult<MamaFuaDto> GetMamaFua(Guid id)
            {
                var mamaFua = repository.GetMamaFua(id);

                if (mamaFua is null)
                {
                    return NotFound();
                }
                return mamaFua.AsDto();
            }

            // POST /mamas
            [HttpPost]
            public ActionResult<MamaFuaDto> CreateMamaFua(CreateMamaFuaDto mamaFuaDto)
            {
                MamaFua mamaFua = new()
                {
                    Id = Guid.NewGuid(),
                    firstName = mamaFuaDto.firstName,
                    lastName = mamaFuaDto.lastName,
                    email = mamaFuaDto.email,
                    username = mamaFuaDto.username,
                    password = mamaFuaDto.password,
                    dateCreated = DateTime.UtcNow
                };
                
                repository.CreateMamaFua(mamaFua);
                
                return CreatedAtAction(nameof(GetMamaFua), new {id = mamaFua.Id}, mamaFua.AsDto());
            }
            
            // PUT /mamas/{id}
            [HttpPut("{id}")]
            public ActionResult UpdateMamaFua(Guid id, UpdateMamaFuaDto mamaFuaDto)
            {
                var existingMama = repository.GetMamaFua(id);
            
                if (existingMama is null)
                {
                    return NotFound();
                }
            
                MamaFua updatedMama = existingMama with
                {
                    firstName = mamaFuaDto.firstName,
                    lastName = mamaFuaDto.lastName,
                    email = mamaFuaDto.email,
                    username = mamaFuaDto.username,
                    password = mamaFuaDto.password
                };
                
                repository.UpdateMamaFua(updatedMama);
            
                return NoContent();
            }
            
            // DELETE /mamas/{id}
            [HttpDelete("{id}")]
            public ActionResult DeleteMamaFua(Guid id)
            {
                var existingMama = repository.GetMamaFua(id);
            
                if (existingMama is null)
                {
                    return NotFound();
                }
                
                repository.DeleteMamaFua(id);
            
                return NoContent();
            }
        }
    
}