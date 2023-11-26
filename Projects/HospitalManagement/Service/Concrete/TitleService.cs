using Core.Shared;
using DataAccess.Repositories.Abstract;
using Models.DTOs.RequestDTO;
using Models.DTOs.ResponseDTO;
using Models.Entities;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete;

public class TitleService : ITitleService
{

    private readonly ITitleRepository _titleRepository;

    public TitleService(ITitleRepository titleRepository)
    {
        _titleRepository = titleRepository;
    }

    public Response<TitleResponseDTO> Add(TitleAddRequest titleAddRequest)
    {
        var title = TitleAddRequest.ConvertToEntity(titleAddRequest);
        _titleRepository.Add(title);
        TitleResponseDTO response = TitleResponseDTO.ConvertToResponse(title);
        return new Response<TitleResponseDTO>()
        {
            Data = response,
            Message = "Ünvan eklendi.",
            StatusCode = System.Net.HttpStatusCode.Created
        };
    }

    public Response<TitleResponseDTO> Delete(int id)
    {
        var title = _titleRepository.GetById(id);
        _titleRepository.Delete(title);
        TitleResponseDTO response = TitleResponseDTO.ConvertToResponse(title);
        return new Response<TitleResponseDTO>()
        {
            Data = response,
            Message = "Ünvan silindi.",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<TitleResponseDTO>> GetAll()
    {
        List<Title> titles = _titleRepository.GetAll();
        List<TitleResponseDTO> response = titles.Select(x => TitleResponseDTO.ConvertToResponse(x)).ToList();
        return new Response<List<TitleResponseDTO>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };

    }

    public Response<TitleResponseDTO> GetById(int id)
    {
        Title title = _titleRepository.GetById(id);
        TitleResponseDTO response = TitleResponseDTO.ConvertToResponse(title);
        return new Response<TitleResponseDTO>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<TitleResponseDTO> Update(TitleUpdateRequest titleUpdateRequest)
    {
        Title title = TitleUpdateRequest.ConverToEntity(titleUpdateRequest);
        _titleRepository.Uptade(title);
        TitleResponseDTO response = TitleResponseDTO.ConvertToResponse(title);
        return new Response<TitleResponseDTO>()
        {
            Data = response,
            Message = "Ünvan güncellendi.",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }
}
