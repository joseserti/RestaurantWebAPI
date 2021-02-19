using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestaurantWebAPI.Context;
using RestaurantWebAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatilloController : ControllerBase
    {
        private readonly AppDbContext context;

        public PlatilloController(AppDbContext context)
        {
            this.context = context;
        }
        //************************************************************
        // GET: api/<Platillo>
        //[HttpGet]
        //public IEnumerable<Platillo> GetPlatillos()
        //{
        //    return context.tbPlatillos.ToList();
        //}

        // GET api/<Platillo>/5
        //[HttpGet("{id}")]
        //public Platillo GetPorEmpresa(long id)
        //{
        //    var platillo = context.tbPlatillos.FirstOrDefault(p=>p.EmpresaPkId==id);
        //    //Retornamos el producto ya filtrado
        //    return platillo;
        //}
        //************************************************************

        // LISTAR TODOS --> GET: api/Platillo/Todos/Aqui el numero de la empresa
        [HttpGet("[action]/{lngEmpresaPkId}")]
        public async Task<ActionResult> Todos([FromRoute] long lngEmpresaPkId)
        {
            var _platillo = context.tbPlatillos.AsQueryable();
            _platillo = context.tbPlatillos.Where(i => i.EmpresaPkId == lngEmpresaPkId);


            if (_platillo == null)
            {
                return NotFound();
            }

            return Ok(_platillo);
        }

        // OBTENER POR ID --> GET: api/Platillo/PorId/Aqui el Id del Platillo
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult> PorId([FromRoute] long id)
        {
            var c = await context.tbPlatillos.FindAsync(id);

            if (c == null)
            {
                return NotFound();
            }

            return Ok(new Platillo
            {
                EmpresaPkId = c.EmpresaPkId,
                PlatilloPkId = c.PlatilloPkId,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                FotoUrl = c.FotoUrl,
                Activo = c.Activo
            });
        }











        // POST api/<Platillo>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Platillo>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Platillo>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
