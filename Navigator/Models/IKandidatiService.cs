using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigator.Models
{
    public interface IKandidatiService
    {
        List<Kandidat> GetAll();
        bool Add(Kandidat objNoviKandidat);
        bool Update(Kandidat objKandidatToUpdate);
        bool Delete(string jmbg);
        List<Kandidat> Search(string vrednostKojaSePretrazuje);
    }
}
