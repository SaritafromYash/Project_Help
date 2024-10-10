using EduHub_Project.Models;

namespace EduHub_Project.services
{
    public interface IMaterialService
    {
        Task<Material> GetMaterialAsync(int materialId);
        Task<IEnumerable<Material>> GetAllMaterialsAsync();
        Task<IEnumerable<Material>>GetMaterialByCourseId(int courseId);
        Task<Material> CreateMaterialAsync(Material newMaterial);
        Task<Material> UpdateMaterialAsync(int materialId, Material updatedMaterial);
        Task<bool> DeleteMaterialAsync(int materialId);
    }
}
