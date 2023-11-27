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

public class HospitalService : IHospitalService
{
    private readonly IHospitalRepository _hospitalRepository;
    private readonly IHospitalRules _hospitalRules;

    public HospitalService(IHospitalRepository hospitalRepository, IHospitalRules hospitalRules)
    {
        _hospitalRepository = hospitalRepository;
        _hospitalRules = hospitalRules;
    }

    public Response<HospitalResponseDTO> Add(HospitalAddRequest hospitalAddRequest)
    {
        try
        {
            Hospital hospital = HospitalAddRequest.ConverToEntity(hospitalAddRequest);
            _hospitalRules.HospitalNameMustBeUnique(hospital.Name);
            _hospitalRepository.Add(hospital);
            HospitalResponseDTO response = HospitalResponseDTO.ConvertToTesponse(hospital);
            return new Response<HospitalResponseDTO>()
            {
                Data = response,
                Message = "Hastane eklendi.",
                StatusCode = System.Net.HttpStatusCode.Created
            };
        }
        catch (ServiceExceptions ex)
        {

            return new Response<HospitalResponseDTO>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

    }

    public Response<HospitalResponseDTO> Delete(int id)
    {
        try
        {
            _hospitalRules.HospitalIsPresent(id);
            Hospital? hospital = _hospitalRepository.GetById(id);
            _hospitalRepository.Delete(hospital);
            HospitalResponseDTO response = HospitalResponseDTO.ConvertToTesponse(hospital);
            return new Response<HospitalResponseDTO>()
            {
                Data = response,
                Message = "Hastane silindi.",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (ServiceExceptions ex)
        {

            return new Response<HospitalResponseDTO>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

    }

    public Response<List<HospitalResponseDTO>> GetAll()
    {
        List<Hospital> hospitals = _hospitalRepository.GetAll();
        List<HospitalResponseDTO> response = hospitals.Select(x => HospitalResponseDTO.ConvertToTesponse(x)).ToList();
        return new Response<List<HospitalResponseDTO>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<HospitalResponseDTO> GetById(int id)
    {
        try
        {
            _hospitalRules.HospitalIsPresent(id);
            Hospital? hospital = _hospitalRepository.GetById(id);
            HospitalResponseDTO response = HospitalResponseDTO.ConvertToTesponse(hospital);
            return new Response<HospitalResponseDTO>()
            {
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (ServiceExceptions ex)
        {

            return new Response<HospitalResponseDTO>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

    }

    public Response<HospitalResponseDTO> Update(HospitalUpdateRequest hospitalUpdateRequest)
    {
        try
        {
            Hospital hospital = HospitalUpdateRequest.ConvertToEntity(hospitalUpdateRequest);
            _hospitalRules.HospitalNameMustBeUnique(hospital.Name);
            _hospitalRepository.Uptade(hospital);
            HospitalResponseDTO response = HospitalResponseDTO.ConvertToTesponse(hospital);
            return new Response<HospitalResponseDTO>()
            {
                Data = response,
                Message = "Hastane güncellendi.",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (ServiceExceptions ex)
        {
            return new Response<HospitalResponseDTO>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

    }
}
