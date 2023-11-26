
using Models.Entities;

namespace Models.DTOs.ResponseDTO;

public record EmployeeResponseDTO(string Name, int Age, string PhoneNumber, int TitleId, int HospitalId)
{
    public static EmployeeResponseDTO ConvertToResponse(Employee employee)
    {
        return new EmployeeResponseDTO(
            Name: employee.Name,
            Age: employee.Age,
            PhoneNumber: employee.PhoneNumber,
            TitleId: employee.TitleId,
            HospitalId: employee.HospitalId
            );
    }
}
