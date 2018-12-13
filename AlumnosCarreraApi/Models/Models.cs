using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AlumnosCarreraApi.Models
{
    public class Models
    {
    }
    public class cat_tipos_generales
    {
        [Key]
        [Required]
        public Int16 IdTipoGeneral { get; set; }
        public String DesTipo { get; set; }
    }

    public class cat_generales
    {
        [Key]
        [Required]
        public Int16 IdGeneral { get; set; }
        public Int16 IdTipoGeneral { get; set; }
        public string Clave { get; set; }
        public string DesGeneral { get; set; }
    }
    public class cat_periodos
    {
        [Key]
        [Required]
        public Int16 IdPeriodo { get; set; }
        public string DesPeriodo { get; set; }
        public string NombreCorto { get; set; }
        public DateTime PeriodoIni { get; set; }
        public DateTime PeriodoFin { get; set; }
        public Int16 Año { get; set; }
        public string NumPeriodo { get; set; }
    }

    public class eva_cat_reticulas
    {
        [Key]
        [Required]
        public Int32 IdReticula { get; set; }
        public string Clave { get; set; }
        public string DesReticula { get; set; }
        public string Actual { get; set; }       
    }

    public class rh_cat_alumnos
    {
        [Key]
        [Required]
        public Int32 IdAlumno { get; set; }
        public string NumControl { get; set; }
        public DateTime FechaReg { get; set; }
    }

    public class rh_cat_personas
    {
        [Key]
        [Required]
        public Int32 IdPersona { get; set; }
        public Int16 IdInstituto { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
    }

    public class eva_cat_especialidades
    {
        [Key]
        [Required]
        public Int16 IdEspecialidad { get; set; }
        public string DesEspecialidad { get; set; }
    }

    public class eva_cat_carreras
    {
        [Key]
        [Required]
        public Int16 IdCarrera { get; set; }
        public string ClaveCarrera { get; set; }
        public string ClaveOficial { get; set; }
        public string DesCarrera { get; set; }
        public string Alias { get; set; }
    }

    public class eva_alumnos_carreras
    {
        [Key]
        [Required]
        public Int16 IdCarrera { get; set;}
        public Int32 IdAlumno { get; set; }
        public Int32 IdReticula { get; set; }
        public Int16 IdEspecialidad { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEgreso { get; set;}
        public DateTime FechaTitulacion { get; set; }
        public DateTime FechaUltModSII { get; set; }
        public Double PromedioActual { get; set; }
        public Int32 PromedioPeriodoAnt { get; set; }
        public Double PromedioFinal { get; set; }
        public Double CreditosAprobados { get; set; }
        public Double CreditosCursados { get; set; }
        public Double TotalPuntosVigentes { get; set; }
        public Double TotalPuntosGenerados { get; set; }
        public Int16 SemestreActual { get; set; }
        public Int16 IdPeriodoIngreso { get; set; }
        public Int16 IdPeriodoUltimo { get; set; }
        public Int16 IdPeriodoTitulacion { get; set; }
        public Int16 IdTipoGenPlanEstudio { get; set; }
        public Int16 IdGenPlanEstudio { get; set; }
        public Int16 IdTipoGenOpcionTitulacion { get; set; }
        public Int16 IdGenOpcionTitulacion { get; set; }
        public Int16 IdTipoGenNivelEscolar { get; set; }
        public Int16 IdGenNivelEscolar { get; set; }
        public Int16 IdTipoGenIngreso { get; set; }
        public Int16 IdGenIngreso { get; set; }
        public String Activo { get; set; }
        public String Borrado { get; set; }
        public DateTime FechaReg { get; set; }
        public String UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public String UsuarioMod { get; set; }
    }

}
