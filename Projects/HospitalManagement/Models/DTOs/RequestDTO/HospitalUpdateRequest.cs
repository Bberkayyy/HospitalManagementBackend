using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.RequestDTO;

public record HospitalUpdateRequest(int Id, string Name)
{
    public static Hospital ConvertToEntity(HospitalUpdateRequest request)
    {
        return new Hospital
        {
            Id = request.Id,
            Name = request.Name
        };
    }
}
