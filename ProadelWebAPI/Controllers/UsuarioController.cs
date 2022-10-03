using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProadelWebAPI.Models;
using ProadelWebAPI.Models.Response;
using System.Collections.Generic;
using ProadelWebAPI.Models.Request;

namespace ProadelWebAPI.Controllers
{
    [Route("proadel/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            Response response = new Response();

            try
            {
                using (PROADELContext db = new PROADELContext())
                {
                    var list = db.LoginAccessData.ToList();
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

        public IActionResult Add(UsuarioRequest oModel)
        {
            Response response = new Response();

            try
            {
                using (PROADELContext db = new PROADELContext())
                {
                    DateTime thisDay = DateTime.Today;
                    LoginAccessDatum usuarioRequest = new LoginAccessDatum();
                    usuarioRequest.Nombre = oModel.Nombre;
                    usuarioRequest.Usuario = oModel.Usuario;
                    usuarioRequest.Contraseña = oModel.Contraseña;
                    usuarioRequest.Permiso = oModel.Permiso;
                    usuarioRequest.InsertionDate = thisDay;
                    usuarioRequest.ModificationDate = thisDay;

                    db.LoginAccessData.Add(usuarioRequest);
                    db.SaveChanges();
                    response.Exito = 1;


                }
            }
            catch(Exception ex)
            {
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]

        public IActionResult Modify(UsuarioRequest oModel)
        {
            Response response = new Response();
            using (PROADELContext db = new PROADELContext())
            {
                try
                {
                    DateTime thisDay = DateTime.Today;
                    LoginAccessDatum usuarioRequest = db.LoginAccessData.Find(oModel.Id);
                    usuarioRequest.Nombre = oModel.Nombre;
                    usuarioRequest.Usuario = oModel.Usuario;
                    usuarioRequest.Contraseña = oModel.Contraseña;
                    usuarioRequest.Permiso = oModel.Permiso;
                    usuarioRequest.InsertionDate = thisDay;
                    usuarioRequest.ModificationDate = thisDay;

                    db.Entry(usuarioRequest).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();


                    response.Exito = 1;
                }
                catch (Exception ex)
                {
                    response.Mensaje = ex.Message;

                }

                return Ok(response);
            }  
            
        }

        [HttpDelete("{Id}")]

        public IActionResult Delete(long Id)
        {
            Response response = new Response();
            using (PROADELContext db = new PROADELContext())
            {
                try
                {
                    DateTime thisDay = DateTime.Today;
                    LoginAccessDatum usuarioRequest = db.LoginAccessData.Find(Id);
                    db.Remove(usuarioRequest);
                    db.SaveChanges();
                    response.Exito = 1;
                }
                catch (Exception ex)
                {
                    response.Mensaje = ex.Message;

                }

                return Ok(response);
            }

        }


    }
}
