using CV.Core.Services;
using CV.Data;
using Latvijas_Pasts.Models;
using Microsoft.EntityFrameworkCore;

namespace CV.Services
{
    public class CvService : ICvService
    {
        private readonly CvDbContext _context;

        public CvService(CvDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cv> GetCvs()
        {
            return _context.Cv.Include(c => c.Address).Include(c => c.EducationList).Include(c => c.ExperienceList).ToList();
        }

        public Cv GetCvById(int id)
        {
            return _context.Cv.Include(c => c.Address).Include(c => c.EducationList).Include(c => c.ExperienceList).FirstOrDefault(c => c.Id == id);
        }

        public void AddCv(Cv cv)
        {
            _context.Cv.Add(cv);
            _context.SaveChanges();
        }

        public void UpdateCv(Cv cv)
        {
            _context.Cv.Update(cv);
            _context.SaveChanges();
        }

        public void DeleteCv(int id)
        {
            var cv = _context.Cv.Find(id);
            if (cv != null)
            {
                _context.Cv.Remove(cv);
                _context.SaveChanges();
            }
        }

    }
}
