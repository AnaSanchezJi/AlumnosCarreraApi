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
        [Route("GetCarrera")]
        public ContentResult GetCarrera(Int16 id)
        {
            var res = from ac in LoDBContext.eva_cat_carreras
                      select new
                      {
                          ac.IdCarrera,
                          ac.DesCarrera,
                          ac.Alias,
                          ac.ClaveCarrera,
                          ac.ClaveOficial                                                    
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
        public ActionResult<string> Get(Int16 id)
        {
            var edificio = LoDBContext.eva_alumnos_carreras.Find(id);
            if (edificio == null) { return new ObjectResult("No encontrado"); }
            string result = JsonConvert.SerializeObject(edificio);
            return Content(result, "application/json");
        }


    }
}