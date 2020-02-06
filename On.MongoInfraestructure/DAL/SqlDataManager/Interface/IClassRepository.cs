using Domain_Application.DTO.SqlDTO;
using Domain_Application.Models.SqlDbModels;
using System.Collections.Generic;

namespace UserDomain.Interfaces.Repositories
{
    public interface IClassRepository 
    {
        IList<ClassDTO> GetClassByIdSchool(int schoolId);

    }
}
