using EduHub_Project.Models;
using EduHub_Project.services;
using Microsoft.EntityFrameworkCore;

namespace EduHub_Project.repository
{
    public class MaterialRepository : IMaterialService
    {
        private readonly AppDbContext _context;

        public MaterialRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Material> GetMaterialAsync(int materialId)
        {
            return await _context.Materials.FindAsync(materialId);
        }

        public async Task<IEnumerable<Material>> GetAllMaterialsAsync()
        {
            return await _context.Materials.ToListAsync();
        }

        public async Task<Material> CreateMaterialAsync(Material newMaterial)
        {
            _context.Materials.Add(newMaterial);
            await _context.SaveChangesAsync();
            return newMaterial;
        }

        public async Task<Material> UpdateMaterialAsync(int materialId, Material updatedMaterial)
        {
            var existingMaterial = await _context.Materials.FindAsync(materialId);
            if (existingMaterial == null)
                return null;

            existingMaterial.CourseId = updatedMaterial.CourseId;
            existingMaterial.Title = updatedMaterial.Title;
            existingMaterial.Description = updatedMaterial.Description;
            existingMaterial.URL = updatedMaterial.URL;
            existingMaterial.UploadDate = updatedMaterial.UploadDate;
            existingMaterial.ContentType = updatedMaterial.ContentType;

            await _context.SaveChangesAsync();
            return existingMaterial;
        }

        public async Task<bool> DeleteMaterialAsync(int materialId)
        {
            var material = await _context.Materials.FindAsync(materialId);
            if (material == null)
                return false;

            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Material>> GetMaterialByCourseId(int id)
        {
            return await _context.Materials.Where(c => c.CourseId == id).ToListAsync();
        }
    }
}