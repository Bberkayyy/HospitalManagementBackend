using Core.Shared;
using Models.DTOs.RequestDTO;
using Models.DTOs.ResponseDTO;

namespace Service.Abstract;

public interface IEmployeeService
{
    Response<EmployeeResponseDTO> Add(EmployeeAddRequest employeeAddRequest);
    Response<EmployeeResponseDTO> Update(EmployeeUpdateRequest employeeUpdateRequest);
    Response<EmployeeResponseDTO> Delete(Guid id);
    Response<EmployeeResponseDTO> GetById(Guid id);
    Response<List<EmployeeResponseDTO>> GetAll();
    Response<List<EmployeeResponseDTO>> GetAllByAgeRange(int min, int max);
    Response<EmployeeDetailDTO> GetByDetailId(Guid id);
    Response<List<EmployeeDetailDTO>>GetAllEmployeeDetails();
    Response<List<EmployeeDetailDTO>> GetAllDetailByTitleId(int titileId);


}
