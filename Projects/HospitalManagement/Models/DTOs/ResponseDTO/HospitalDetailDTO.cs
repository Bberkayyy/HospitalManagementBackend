using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.ResponseDTO;

public record HospitalDetailDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }


    public List<Employee>? Employees { get; set; }
}
