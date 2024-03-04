using Entities.DTOs.CategoryDTOs;
using Entities.DTOs.HospitalBranchDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IHospitalBranchService
    {
        Task<Core.Utilities.Results.Abstract.IResult> AddHospitalBranchByLanguageAsync(HospitalBranchAddDTO hospitalBranchAddDTO, string webRootPath);
    }
}
