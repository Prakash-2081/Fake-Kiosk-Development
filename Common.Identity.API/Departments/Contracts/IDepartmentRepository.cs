using Commmon.Data.Data.Contracts;

namespace Common.Identity.API.Departments.Contracts
{
    public interface IDepartmentRepository:IGenericRepository<Department>
    {
       Task<Department> FindByDepartmentNameAsync(string departmentName);
    }
}
