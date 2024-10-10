
using Microsoft.EntityFrameworkCore;
using MVC_EduHub.Models;
using MVC_EduHub.services;

namespace EduHub_Project.repository
{
    public class MaterialRepository : IMaterialService
    {
        private readonly AppDbContext _context;

        public MaterialRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateMaterial(Material newMaterial)
        {
            
            _context.Materials.Add(newMaterial);
            _context.SaveChanges();

        }

        public bool DeleteMaterial(int materialId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Material> GetAllMaterials()
        {
            throw new NotImplementedException();
        }

        public Material GetMaterial(int materialId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Material> GetMaterialByCourseId(int courseId)
        {
            throw new NotImplementedException();
        }

        public void UpdateMaterial(int materialId, Material updatedMaterial)
        {
            throw new NotImplementedException();
        }
    }
}