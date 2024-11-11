using CV.Core.Models;

namespace Latvijas_Pasts.Models
{
    public class Experience : Entity
    {
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
    }
}
