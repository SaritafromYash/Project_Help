
using MVC_EduHub.Models;

namespace MVC_EduHub.services
{
    public interface IMaterialService
    {
        Material  GetMaterial (int materialId);
        IEnumerable<Material> GetAllMaterials ();
        IEnumerable<Material> GetMaterialByCourseId(int courseId);
        void CreateMaterial (Material newMaterial);
        void   UpdateMaterial (int materialId, Material updatedMaterial);
        bool DeleteMaterial (int materialId);
    }
}
