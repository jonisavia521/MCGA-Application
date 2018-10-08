using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCGA.Entities;

namespace MCGA.UI.Process
{
    public class ProfesionalProcess
    {
        private MCGA.Business.ProfesionalBi profesionalBi;

        public ProfesionalProcess()
        {
            profesionalBi = new Business.ProfesionalBi();
        }
        public List<Profesional> getProfesionales()
        {
            return profesionalBi.getProfesionales();
        }

        public Profesional getProfesional(int? id)
        {
            return profesionalBi.getProfesional(id);
        }

        public bool saveProfesional(Profesional profesional)
        {
            return profesionalBi.saveProfesional(profesional);
        }

        public bool updateProfesional(Profesional profesional)
        {
            return profesionalBi.updateProfesional(profesional);
        }

        public bool deleteProfesional(int id)
        {
            return profesionalBi.deleteProfesional(id);
        }

      
    }
}
