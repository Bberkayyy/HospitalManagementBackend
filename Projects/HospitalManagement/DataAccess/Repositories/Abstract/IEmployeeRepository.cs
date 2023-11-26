using Core.Repository.Repositories;
using Models.DTOs.ResponseDTO;
using Models.Entities;


namespace DataAccess.Repositories.Abstract;

public interface IEmployeeRepository : IEntityRepository<Employee, Guid>
{
    List<EmployeeDetailDTO> GetAllEmployeeDetail();
    List<EmployeeDetailDTO> GetDetailsByTitleId(int titleId);
    EmployeeDetailDTO GetEmployeeDetail(Guid id);
}
