using EduHub_Project.Models;
using EduHub_Project.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduHub_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet("{materialId}")]
        public async Task<IActionResult> GetMaterial(int materialId)
        {
            var material = await _materialService.GetMaterialAsync(materialId);
            if (material == null)
                return NotFound();

            return Ok(material);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMaterials()
        {
            var materials = await _materialService.GetAllMaterialsAsync();
            return Ok(materials);
        }
        [HttpGet]
        [Route("GetMaterialsByCourseId/{id}")]
        public async Task<IActionResult> GetMaterialsByCourseId(int id)
        {
            var materials = await _materialService.GetMaterialByCourseId(id);
            return Ok(materials);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaterial(Material newMaterial)
        {
            var createdMaterial = await _materialService.CreateMaterialAsync(newMaterial);
            return CreatedAtAction(nameof(GetMaterial), new { materialId = createdMaterial.MaterialId }, createdMaterial);
        }

        [HttpPut("{materialId}")]
        public async Task<IActionResult> UpdateMaterial(int materialId, Material updatedMaterial)
        {
            var material = await _materialService.UpdateMaterialAsync(materialId, updatedMaterial);
            if (material == null)
                return NotFound();

            return Ok(material);
        }

        [HttpDelete("{materialId}")]
        public async Task<IActionResult> DeleteMaterial(int materialId)
        {
            var result = await _materialService.DeleteMaterialAsync(materialId);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
