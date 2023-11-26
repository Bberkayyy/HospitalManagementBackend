using Core.Shared;
using Models.DTOs.RequestDTO;
using Models.DTOs.ResponseDTO;


namespace Service.Abstract;

public interface IHospitalService
{
    Response<HospitalResponseDTO> Add(HospitalAddRequest hospitalAddRequest);
    Response<HospitalResponseDTO> Update(HospitalUpdateRequest hospitalUpdateRequest);
    Response<HospitalResponseDTO> Delete(int id);
    Response<HospitalResponseDTO> GetById(int id);

    Response<List<HospitalResponseDTO>> GetAll();
}
