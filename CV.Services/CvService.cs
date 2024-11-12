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

        public void UpdateCv(Cv updatedCv)
        {
            var existingCv = _context.Cv
        .Include(c => c.EducationList)
        .Include(c => c.ExperienceList)
        .Include(c => c.Address)
        .FirstOrDefault(c => c.Id == updatedCv.Id);

            if (existingCv != null)
            {
                existingCv.Name = updatedCv.Name;
                existingCv.Surname = updatedCv.Surname;
                existingCv.Phone = updatedCv.Phone;
                existingCv.Email = updatedCv.Email;

                if (existingCv.Address != null && updatedCv.Address != null)
                {
                    existingCv.Address.Country = updatedCv.Address.Country;
                    existingCv.Address.City = updatedCv.Address.City;
                    existingCv.Address.Street = updatedCv.Address.Street;
                    existingCv.Address.PostalCode = updatedCv.Address.PostalCode;
                    existingCv.Address.HouseNumber = updatedCv.Address.HouseNumber;
                }

                _context.Educations.RemoveRange(
                    existingCv.EducationList.Where(e => !updatedCv.EducationList.Any(ue => ue.Id == e.Id)));

                foreach (var education in updatedCv.EducationList)
                {
                    if (education.Id == 0)
                    {
                        existingCv.EducationList.Add(education);
                    }
                    else
                    {
                        var existingEducation = existingCv.EducationList.FirstOrDefault(e => e.Id == education.Id);
                        if (existingEducation != null)
                        {
                            existingEducation.InstitutionName = education.InstitutionName;
                            existingEducation.Faculty = education.Faculty;
                            existingEducation.StudyField = education.StudyField;
                            existingEducation.Degree = education.Degree;
                            existingEducation.Status = education.Status;
                            existingEducation.Duration = education.Duration;
                        }
                    }
                }

                _context.Experiences.RemoveRange(
                    existingCv.ExperienceList.Where(e => !updatedCv.ExperienceList.Any(ue => ue.Id == e.Id)));

                foreach (var experience in updatedCv.ExperienceList)
                {
                    if (experience.Id == 0)
                    {
                        existingCv.ExperienceList.Add(experience);
                    }
                    else
                    {
                        var existingExperience = existingCv.ExperienceList.FirstOrDefault(e => e.Id == experience.Id);
                        if (existingExperience != null)
                        {
                            existingExperience.CompanyName = experience.CompanyName;
                            existingExperience.Position = experience.Position;
                            existingExperience.Duration = experience.Duration;
                            existingExperience.Description = experience.Description;
                        }
                    }
                }

                _context.SaveChanges();
            }
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
