using Business.Abstarct;
using Entities.DTOs.CategoryDTOs;
using Entities.DTOs.HospitalBranchDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalBranchController : ControllerBase
    {
        private readonly IHospitalBranchService _hospitalBranchService;
        private readonly IWebHostEnvironment _env;

        public HospitalBranchController(IHospitalBranchService hospitalBranchService, IWebHostEnvironment env)
        {
            _hospitalBranchService = hospitalBranchService;
            _env = env;
        }

        [HttpPost("CreateHospitalBranch")]
        public async Task<IActionResult> CreateHospitalBranch(HospitalBranchAddDTO hospitalBranchAddDTO)
        {
            var result = await _hospitalBranchService.AddHospitalBranchByLanguageAsync(hospitalBranchAddDTO, _env.WebRootPath);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
