using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class HospitalBranch : BaseEntity, IEntity
    {
        public string CoverPhoto { get; set; }
        public List<HospitalBranchPhoto> HospitalBranchPhotos { get; set; }
        public List<HospitalBranchLanguage> HospitalBranchLanguages { get; set; }
        public List<HospitalBranchFeature> HospitalBranchFeatures { get; set; }
    }
}
