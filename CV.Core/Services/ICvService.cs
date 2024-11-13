using Latvijas_Pasts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Core.Services
{
    public interface ICvService
    {
        IEnumerable<Cv> GetCvs();
        Cv GetCvById(int id);
        void AddCv(Cv cv);
        void UpdateCv(Cv cv);
        void DeleteCv(int id);
    }
}
