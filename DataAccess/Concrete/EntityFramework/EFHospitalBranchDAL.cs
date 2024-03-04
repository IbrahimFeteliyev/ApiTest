using Core.DataAccess.EntityFramework;
using Core.Helper;
using DataAccess.Abstarct;
using Entities.Concrete;
using Entities.DTOs.HospitalBranchDTOs;


namespace DataAccess.Concrete.EntityFramework
{
    public class EFHospitalBranchDAL : EfEntityRepositoryBase<HospitalBranch, AppDbContext>, IHospitalBranchDAL
    {
        public async Task<bool> AddHospitalBranch(HospitalBranchAddDTO hospitalBranchAddDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                HospitalBranch hospitalBranch = new()
                {
                    CoverPhoto = await hospitalBranchAddDTO.CoverPhoto.SaveFileAsync(webRootPath),
                };

                await context.HospitalBranchs.AddAsync(hospitalBranch);
                await context.SaveChangesAsync();

                for (int i = 0; i < hospitalBranchAddDTO.BranchName.Count; i++)
                {
                    HospitalBranchLanguage hospitalBranchLanguage = new()
                    {
                        HospitalBranchId = hospitalBranch.Id,
                        BranchName = hospitalBranchAddDTO.BranchName[i],
                        HospitalName = hospitalBranchAddDTO.HospitalName[i],
                        Description = hospitalBranchAddDTO.Description[i],
                        LangCode = hospitalBranchAddDTO.LangCode[i]
                    };
                    await context.HospitalBranchLanguages.AddAsync(hospitalBranchLanguage);
                }

                for (int i = 0; i < hospitalBranchAddDTO.HospitalBranchFeatures.Count; i++)
                {
                    HospitalBranchFeature hospitalBranchFeature = new()
                    {
                        HospitalBranchId = hospitalBranch.Id,
                        Count = hospitalBranchAddDTO.HospitalBranchFeatures[i].Count,
                        //PhotoUrl = await hospitalBranchAddDTO.HospitalBranchFeatureAddDTO[i].FeaturePhotoUrl.SaveFileAsync(webRootPath),
                        PhotoUrl = "dasdas",
                    };
                    await context.HospitalBranchFeatures.AddAsync(hospitalBranchFeature);

                    for (int j = 0; j < hospitalBranchAddDTO.HospitalBranchFeatures[i].FeatureDescription.Count; j++)
                    {
                        HospitalBranchFeatureLanguage hospitalBranchFeatureLanguage = new()
                        {
                            HospitalBranchFeatureId = hospitalBranchFeature.Id,
                            Description = hospitalBranchAddDTO.HospitalBranchFeatures[i].FeatureDescription[j],
                            LangCode = hospitalBranchAddDTO.LangCode[j]
                        };
                        await context.HospitalBranchFeatureLanguages.AddAsync(hospitalBranchFeatureLanguage);
                    }
                }

                for (int i = 0; i < hospitalBranchAddDTO.PhotoUrl.Count; i++)
                {
                    HospitalBranchPhoto hospitalBranchPhoto = new()
                    {
                        HospitalBranchId = hospitalBranch.Id,
                        PhotoUrl = await hospitalBranchAddDTO.PhotoUrl[i].SaveFileAsync(webRootPath),
                    };
                    await context.HospitalBranchPhotos.AddAsync(hospitalBranchPhoto);
                }

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
