using CV.Core.Models;

namespace Latvijas_Pasts.Models
{
    public class Education : Entity
    {
        public int CvId { get; set; }
        public string InstitutionName { get; set; }
        public string Faculty { get; set; }
        public string StudyField { get; set; }
        public string Degree { get; set; }
        public string Status { get; set; }
        public string Duration { get; set; }
    }
}
