using CreativeBox.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeBox.Domain.Interface
{
    public interface IUniversity
    {
        List<UniversityEntity> SelectUniversityList();

        UniversityEntity FetchUniversityDetail(int universityid);

        int OperationUniversity(UniversityEntity objUniversityEntity);

        int OperationUniversityDelete(UniversityEntity objUniversityEntity);
    }
}
