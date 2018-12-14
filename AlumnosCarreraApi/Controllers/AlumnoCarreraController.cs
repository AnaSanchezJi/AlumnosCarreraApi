using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlumnosCarreraApi.Data;
using AlumnosCarreraApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AlumnosCarreraApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AlumnoCarreraController : Controller
    {
        private readonly DBContext LoDBContext;
        public AlumnoCarreraController(DBContext PaDBContext)
        {
            LoDBContext = PaDBContext;
        }

        public IActionResult Index()
        {
            return null;
        }
        [HttpGet]
        [Route("GetAlumnoCarrera")]
        public ContentResult GetAlumnoCarrera()
        {
            var res = from ac in LoDBContext.eva_alumnos_carreras
                      select new
                      {
                          ac.IdAlumno,
                          ac.IdCarrera,
                          ac.IdReticula,
                          ac.IdEspecialidad,
                          ac.FechaIngreso,
                          ac.FechaEgreso,
                          ac.FechaTitulacion,
                          ac.FechaUltModSII,
                          ac.PromedioActual,
                          ac.PromedioPeriodoAnt,
                          ac.PromedioFinal,
                          ac.CreditosAprobados,
                          ac.CreditosCursados,
                          ac.TotalPuntosVigentes,
                          ac.TotalPuntosGenerados,
                          ac.SemestreActual,
                          ac.IdPeriodoIngreso,
                          ac.IdPeriodoUltimo,
                          ac.IdPeriodoTitulacion,
                          ac.IdTipoGenPlanEstudio,
                          ac.IdGenPlanEstudio,
                          ac.IdTipoGenOpcionTitulacion,
                          ac.IdGenOpcionTitulacion,
                          ac.IdTipoGenNivelEscolar,
                          ac.IdGenNivelEscolar,
                          ac.IdTipoGenIngreso,
                          ac.IdGenIngreso,
                          ac.Activo,
                          ac.Borrado,
                          ac.FechaReg,
                          ac.UsuarioReg,
                          ac.FechaUltMod,
                          ac.UsuarioMod
                      };
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [HttpGet]
        [Route("GetDetallesAlumnoCarrera/{id}")]
        public ContentResult GetDetallesAlumnoCarrera(int id)
        {
            var res = (from eac in LoDBContext.eva_alumnos_carreras
                       where eac.IdAlumno.Equals(id)
                       join rcp in LoDBContext.rh_cat_personas on eac.IdAlumno equals rcp.IdPersona
                       join ecc in LoDBContext.eva_cat_carreras on eac.IdCarrera equals ecc.IdCarrera
                       join ecr in LoDBContext.eva_cat_reticulas on eac.IdReticula equals ecr.IdReticula
                       join ece in LoDBContext.eva_cat_especialidades on eac.IdEspecialidad equals ece.IdEspecialidad

                       select new
                       {
                           eac.IdAlumno,
                           rcp.Nombre,
                           rcp.ApPaterno,
                           rcp.ApMaterno,
                           ecc.DesCarrera,
                           ecr.DesReticula,
                           ece.DesEspecialidad,
                           eac.FechaIngreso,
                           eac.FechaEgreso,
                           eac.FechaTitulacion,
                           eac.FechaUltModSII,
                           eac.PromedioActual,
                           eac.PromedioPeriodoAnt,
                           eac.PromedioFinal,
                           eac.CreditosAprobados,
                           eac.CreditosCursados,
                           eac.TotalPuntosVigentes,
                           eac.TotalPuntosGenerados,
                           eac.SemestreActual,
                           eac.Activo,
                           eac.Borrado,
                           eac.FechaReg,
                           eac.UsuarioReg,
                           eac.FechaUltMod,
                           eac.UsuarioMod
                       }).First();

            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [Route("ListaAlumnoCarrera")]
        [HttpGet]
        public ContentResult GetAlumnoCarreraList()
        {
            var res = from eac in LoDBContext.eva_alumnos_carreras
                      join rcp in LoDBContext.rh_cat_personas on eac.IdAlumno equals rcp.IdPersona
                      join ecc in LoDBContext.eva_cat_carreras on eac.IdCarrera equals ecc.IdCarrera
                      select new
                      {
                          IdAlumno = eac.IdAlumno,
                          Nombre = rcp.Nombre,
                          ApPaterno = rcp.ApPaterno,
                          ApMaterno = rcp.ApMaterno,
                          DesCarrera = ecc.DesCarrera,
                          FechaIngreso = eac.FechaIngreso,
                          FechaEgreso = eac.FechaEgreso,
                          FechaTitulacion = eac.FechaTitulacion,
                          PromedioActual = eac.PromedioActual,
                          CreditosAprobados = eac.CreditosAprobados,
                          SemestreActual = eac.SemestreActual
                      };

            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [HttpGet]
        [Route("GetCarrera")]
        public ContentResult GetCarrera2()
        {
            var res = from ac in LoDBContext.eva_cat_carreras
                      
                      select new
                      {                         
                          ac.IdCarrera,
                          ac.DesCarrera                         
                      };
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [HttpGet]
        [Route("GetEspecialidad")]
        public ContentResult GetEspecialidad()
        {
            var res = from ac in LoDBContext.eva_cat_especialidades
                      select new
                      {
                          ac.IdEspecialidad,
                          ac.DesEspecialidad
                      };
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [HttpGet]
        [Route("GetReticula")]
        public ContentResult GetReticula()
        {
            var res = from ac in LoDBContext.eva_cat_reticulas
                      select new
                      {
                          ac.IdReticula,
                          ac.DesReticula
                      };
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [HttpGet]
        [Route("GetAlumno")]
        public ContentResult GetAlumno()
        {
            var res = from ac in LoDBContext.rh_cat_personas
                      select new
                      {
                          ac.IdPersona,
                          ac.Nombre
                      };
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [HttpGet]
        [Route("GetPeriodo")]
        public ContentResult GetPeriodo()
        {
            var res = from ac in LoDBContext.cat_periodos
                      select new
                      {
                          ac.IdPeriodo,
                          ac.DesPeriodo
                      };
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [HttpGet]
        [Route("GetGenerales17")]
        public ContentResult GetGenerales17()
        {
            var res = from ac in LoDBContext.cat_generales
                      where ac.IdTipoGeneral == 17
                      select new
                      {
                          ac.IdGeneral,
                          ac.DesGeneral
                      };
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [HttpGet]
        [Route("GetGenerales25")]
        public ContentResult GetGenerales25()
        {
            var res = from ac in LoDBContext.cat_generales
                      where ac.IdTipoGeneral == 25
                      select new
                      {
                          ac.IdGeneral,
                          ac.DesGeneral
                      };
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [HttpGet]
        [Route("GetGenerales27")]
        public ContentResult GetGenerales27()
        {
            var res = from ac in LoDBContext.cat_generales
                      where ac.IdTipoGeneral == 27
                      select new
                      {
                          ac.IdGeneral,
                          ac.DesGeneral
                      };
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }
        [HttpGet]
        [Route("GetGenerales28")]
        public ContentResult GetGenerales28()
        {
            var res = from ac in LoDBContext.cat_generales
                      where ac.IdTipoGeneral == 28
                      select new
                      {
                          ac.IdGeneral,
                          ac.DesGeneral
                      };
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }      
        // POST
        [HttpPost]
        [Route("AddAlumnoCarrera")]
        public IActionResult Create(eva_alumnos_carreras ac)
        {
            LoDBContext.eva_alumnos_carreras.Add(ac);
            LoDBContext.SaveChanges();
            return new ObjectResult("Correcto!");
        }

        //UPDATE
        // PUT api/5
        [HttpPut("{id}")]
        public IActionResult Update(Int16 id, eva_alumnos_carreras ac)
        {
            var edificio = LoDBContext.eva_alumnos_carreras.Find(id);

            if (edificio == null) { return new ObjectResult("Incorrecto!"); }
            edificio.IdAlumno = ac.IdAlumno;
            edificio.IdCarrera = ac.IdCarrera;
            edificio.IdReticula = ac.IdReticula;
            edificio.IdEspecialidad = ac.IdEspecialidad;
            edificio.FechaIngreso = ac.FechaIngreso;
            edificio.FechaEgreso = ac.FechaEgreso;
            edificio.FechaTitulacion = ac.FechaTitulacion;
            edificio.FechaUltModSII = ac.FechaUltModSII;
            edificio.PromedioActual = ac.PromedioActual;
            edificio.PromedioPeriodoAnt = ac.PromedioPeriodoAnt;
            edificio.PromedioFinal = ac.PromedioFinal;
            edificio.CreditosAprobados = ac.CreditosAprobados;
            edificio.CreditosCursados = ac.CreditosCursados;
            edificio.TotalPuntosVigentes = ac.TotalPuntosVigentes;
            edificio.TotalPuntosGenerados = ac.TotalPuntosGenerados;
            edificio.SemestreActual = ac.SemestreActual;
            edificio.IdPeriodoIngreso = ac.IdPeriodoIngreso;
            edificio.IdPeriodoUltimo = ac.IdPeriodoUltimo;
            edificio.IdPeriodoTitulacion = ac.IdPeriodoTitulacion;
            edificio.IdTipoGenPlanEstudio = ac.IdTipoGenPlanEstudio;
            edificio.IdGenPlanEstudio = ac.IdGenPlanEstudio;
            edificio.IdTipoGenOpcionTitulacion = ac.IdTipoGenOpcionTitulacion;
            edificio.IdGenOpcionTitulacion = ac.IdGenOpcionTitulacion;
            edificio.IdTipoGenNivelEscolar = ac.IdTipoGenNivelEscolar;
            edificio.IdGenNivelEscolar = ac.IdGenNivelEscolar;
            edificio.IdTipoGenIngreso = ac.IdTipoGenIngreso;
            edificio.IdGenIngreso = ac.IdGenIngreso;
            edificio.Activo = ac.Activo;
            edificio.Borrado = ac.Borrado;
            edificio.FechaReg = ac.FechaReg;
            edificio.UsuarioReg = ac.UsuarioReg;
            edificio.FechaUltMod = ac.FechaUltMod;
            edificio.UsuarioMod = ac.UsuarioMod;

            LoDBContext.eva_alumnos_carreras.Update(edificio);
            LoDBContext.SaveChanges();
            return new ObjectResult("Correcto!");
        }

        // DELETE api/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Int16 id)
        {
            var edificio = LoDBContext.eva_alumnos_carreras.Find(id);
            if (edificio == null) { return new ObjectResult("Incorrecto!"); }
            LoDBContext.eva_alumnos_carreras.Remove(edificio);
            LoDBContext.SaveChanges();
            return new ObjectResult("Correcto!");
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetCarrera(Int16 id)
        {
            var edificio = LoDBContext.eva_alumnos_carreras.Find(id);
            if (edificio == null) { return new ObjectResult("No encontrado"); }
            string result = JsonConvert.SerializeObject(edificio);
            return Content(result, "application/json");
        }


    }
}