using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.RequestDTO;

public record EmployeeAddRequest(string Name, int Age, string PhoneNumber, int TitleId, int HospitalId)
{
    public static Employee ConvertToEntity(EmployeeAddRequest request)
    {
        return new Employee()
        {
            Name = request.Name,
            Age = request.Age,
            PhoneNumber = request.PhoneNumber,
            TitleId = request.TitleId,
            HospitalId = request.HospitalId
        };
    }
}
