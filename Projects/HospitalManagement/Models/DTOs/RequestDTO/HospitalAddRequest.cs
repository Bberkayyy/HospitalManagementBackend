using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.RequestDTO;

public record HospitalAddRequest(string Name)
{
    public static Hospital ConverToEntity(HospitalAddRequest request)
    {
        return new Hospital
        {
            Name = request.Name
        };
    }
}
