using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.RequestDTO;

public record TitleUpdateRequest(int Id, string Name)
{
    public static Title ConverToEntity(TitleUpdateRequest request)
    {
        return new Title
        {
            Id = request.Id,
            Name = request.Name
        };
    }
}
