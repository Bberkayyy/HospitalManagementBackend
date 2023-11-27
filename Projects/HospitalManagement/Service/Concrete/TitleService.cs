using Core.CrossCuttingConcerns.Exceptions;
using Core.Shared;
using DataAccess.Repositories.Abstract;
using Models.DTOs.RequestDTO;
using Models.DTOs.ResponseDTO;
using Models.Entities;
using Service.Abstract;
using Service.ServiceRules.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete;

public class TitleService : ITitleService
{

    private readonly ITitleRepository _titleRepository;
    private readonly ITitleRules _titleRules;

    public TitleService(ITitleRepository titleRepository, ITitleRules titleRules)
    {
        _titleRepository = titleRepository;
        _titleRules = titleRules;
    }

    public Response<TitleResponseDTO> Add(TitleAddRequest titleAddRequest)
    {
        try
        {
            var title = TitleAddRequest.ConvertToEntity(titleAddRequest);
            _titleRules.TitleNameMustBeUnique(title.Name);
            _titleRepository.Add(title);
            TitleResponseDTO response = TitleResponseDTO.ConvertToResponse(title);
            return new Response<TitleResponseDTO>()
            {
                Data = response,
                Message = "Ünvan eklendi.",
                StatusCode = System.Net.HttpStatusCode.Created
            };
        }
        catch (ServiceExceptions ex)
        {

            return new Response<TitleResponseDTO>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

    }

    public Response<TitleResponseDTO> Delete(int id)
    {
        try
        {
            _titleRules.TitleIsPresent(id);
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
        catch (ServiceExceptions e)
        {

            return new Response<TitleResponseDTO>()
            {
                Message = e.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

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
        try
        {
            _titleRules.TitleIsPresent(id);
            Title title = _titleRepository.GetById(id);
            TitleResponseDTO response = TitleResponseDTO.ConvertToResponse(title);
            return new Response<TitleResponseDTO>()
            {
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (ServiceExceptions e)
        {

            return new Response<TitleResponseDTO>()
            {
                Message = e.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

    }

    public Response<TitleResponseDTO> Update(TitleUpdateRequest titleUpdateRequest)
    {
        try
        {
            Title title = TitleUpdateRequest.ConverToEntity(titleUpdateRequest);
            _titleRules.TitleNameMustBeUnique(title.Name);
            _titleRepository.Uptade(title);
            TitleResponseDTO response = TitleResponseDTO.ConvertToResponse(title);
            return new Response<TitleResponseDTO>()
            {
                Data = response,
                Message = "Ünvan güncellendi.",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (ServiceExceptions e)
        {

            return new Response<TitleResponseDTO>()
            {
                Message = e.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }


    }
}
