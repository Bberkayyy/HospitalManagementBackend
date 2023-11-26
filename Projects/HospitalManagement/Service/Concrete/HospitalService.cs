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

public class HospitalService : IHospitalService
{
    private readonly IHospitalRepository _hospitalRepository;

    public HospitalService(IHospitalRepository hospitalRepository)
    {
        _hospitalRepository = hospitalRepository;
    }

    public Response<HospitalResponseDTO> Add(HospitalAddRequest hospitalAddRequest)
    {
        Hospital hospital = HospitalAddRequest.ConverToEntity(hospitalAddRequest);
        _hospitalRepository.Add(hospital);
        HospitalResponseDTO response = HospitalResponseDTO.ConvertToTesponse(hospital);
        return new Response<HospitalResponseDTO>()
        {
            Data = response,
            Message = "Hastane eklendi.",
            StatusCode = System.Net.HttpStatusCode.Created
        };
    }

    public Response<HospitalResponseDTO> Delete(int id)
    {
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
        Hospital? hospital = _hospitalRepository.GetById(id);
        HospitalResponseDTO response = HospitalResponseDTO.ConvertToTesponse(hospital);
        return new Response<HospitalResponseDTO>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<HospitalResponseDTO> Update(HospitalUpdateRequest hospitalUpdateRequest)
    {
        Hospital hospital = HospitalUpdateRequest.ConvertToEntity(hospitalUpdateRequest);
        _hospitalRepository.Uptade(hospital);
        HospitalResponseDTO response = HospitalResponseDTO.ConvertToTesponse(hospital);
        return new Response<HospitalResponseDTO>()
        {
            Data = response,
            Message = "Hastane güncellendi.",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }
}
