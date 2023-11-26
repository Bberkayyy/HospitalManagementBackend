using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.RequestDTO;

public record TitleAddRequest(string Name)
{
    public static Title ConvertToEntity(TitleAddRequest request)
    {
        return new Title
        {
            Name = request.Name,
        };
    }
}
