using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCGA.Entities;

namespace MCGA.Business
{
    public class ProfesionalBi
    {
        private MCGA.Data.MedicureEntities da;
        public ProfesionalBi()
        {
            da = new Data.MedicureEntities();
        }
        public List<Profesional> getProfesionales()
        {
            try
            {
                return da.Profesional.ToList();
            }
            catch
            {
                throw;
            }
           
        }

        public Profesional getProfesional(int? id)
        {
            try
            {
                return da.Profesional.Find(id);
            }
            catch
            {
                throw;
            }
        }

        public bool saveProfesional(Profesional profesional)
        {
            try
            {
                    da.Profesional.Add(profesional);
                    return da.SaveChanges() != 0;
                
            }
            catch
            {
                throw;
            }
        }

        public bool updateProfesional(Profesional profesional)
        {
            try
            {
                da.Entry(profesional).State = EntityState.Modified;
                return da.SaveChanges() != 0;


            }
            catch
            {
                throw;
            }
        }

        public bool deleteProfesional(int id)
        {
            try
            {
                    da.Profesional.Remove(da.Profesional.Find(id));
                    return da.SaveChanges() != 0;

            }
            catch
            {
                throw;
            }
        }
    }
}
