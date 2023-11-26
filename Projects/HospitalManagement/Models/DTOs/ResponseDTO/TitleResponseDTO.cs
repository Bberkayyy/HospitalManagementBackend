using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.ResponseDTO;

public record TitleResponseDTO(int Id, string Name)
{
    public static TitleResponseDTO ConvertToResponse(Title title)
    {
        return new TitleResponseDTO(
            Id: title.Id,
            Name: title.Name
            );
    }
}
