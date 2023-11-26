using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.ResponseDTO;

public record HospitalResponseDTO(int Id, string Name)
{
    public static HospitalResponseDTO ConvertToTesponse(Hospital hospital)
    {
        return new HospitalResponseDTO(
            Id: hospital.Id,
            Name: hospital.Name
            );
    }
}
