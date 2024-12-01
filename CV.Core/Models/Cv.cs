using CV.Core.Models;

namespace Latvijas_Pasts.Models
{
    public class Cv : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Education> EducationList { get; set; }
        public List<Experience> ExperienceList { get; set; }
        public Address Address { get; set; } 
    }
}
