using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.HospitalBranchDTOs
{
    public class HospitalBranchAddDTO
    {
        public IFormFile CoverPhoto { get; set; }

        public List<string> BranchName { get; set; }
        public List<string> LangCode { get; set; }
        public List<string> HospitalName { get; set; }
        public List<string> Description { get; set; }

        public List<IFormFile> PhotoUrl { get; set; }

        public List<HospitalBranchFeatureAddDTO> HospitalBranchFeatures { get; set; }
    }

    public class HospitalBranchFeatureAddDTO
    {
        public string Count { get; set; }
        public List<string> FeatureDescription { get; set; }
        //public IFormFile FeaturePhotoUrl { get; set; }  
    }

}
