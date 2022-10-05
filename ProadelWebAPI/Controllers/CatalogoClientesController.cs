using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProadelWebAPI.Models;
using System.Collections.Generic;
using ProadelWebAPI.Models.Response;
using ProadelWebAPI.Models.Request;

namespace ProadelWebAPI.Controllers
{
    [Route("proadel/[controller]")]

    [ApiController]
    public class CatalogoClientesController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            Response response = new Response();

            try
            {
                using (PROADELContext db = new PROADELContext())
                {
                    var list = db.CatalogoClientesData.OrderByDescending(d=>d.Codigo).ToList();
                    response.Exito = 1;
                    response.Data = list;
                }
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }

            return Ok(response);

        }

        [HttpPost]
        public IActionResult Add(ClienteRequest clienteRequest)
        {
            Response response = new Response();

            try
            {
                using (PROADELContext db = new PROADELContext())
                {
                    CatalogoClientesDatum clienteNuevo = new CatalogoClientesDatum();
                    clienteNuevo.Codigo = clienteRequest.Codigo;
                    clienteNuevo.Nombre = clienteRequest.Nombre;
                    clienteNuevo.Direccion = clienteRequest.Direccion;
                    clienteNuevo.Telefono = clienteRequest.Telefono;
                    clienteNuevo.LimiteDeCredito = clienteRequest.LimiteDeCredito;

                    db.CatalogoClientesData.Add(clienteNuevo);
                    db.SaveChanges();
                    response.Exito = 1;

                }
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;

            }

            return Ok(response);
        }

        [HttpPut]

        public IActionResult Modify(ClienteRequest clientRequest)
        {
            Response response = new Response();

            try
            {
                using (PROADELContext db = new PROADELContext())
                {
                    CatalogoClientesDatum clienteModify = db.CatalogoClientesData.Find(clientRequest.Codigo);
                    clienteModify.Codigo = clientRequest.Codigo;
                    clienteModify.Nombre = clientRequest.Nombre;
                    clienteModify.Direccion = clientRequest.Direccion;
                    clienteModify.Telefono = clientRequest.Telefono;
                    clienteModify.LimiteDeCredito = clientRequest.LimiteDeCredito;

                    db.Entry(clienteModify).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();


                    response.Exito = 1;

                }


            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete("{codigo}")]

        public IActionResult Delete(string codigo)
        {
            Response response = new Response();

            try
            {
                using (PROADELContext db = new PROADELContext())
                {
                    CatalogoClientesDatum clienteDelete = db.CatalogoClientesData.Find(codigo);
                    db.Remove(clienteDelete);
                    db.SaveChanges();
                    response.Exito = 1;

                }
            }

            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }
    }
}



