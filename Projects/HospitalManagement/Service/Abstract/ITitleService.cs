using Core.Shared;
using Models.DTOs.RequestDTO;
using Models.DTOs.ResponseDTO;

namespace Service.Abstract;

public interface ITitleService
{
    Response<TitleResponseDTO> Add(TitleAddRequest titleAddRequest);
    Response<TitleResponseDTO> Update(TitleUpdateRequest titleUpdateRequest);
    Response<TitleResponseDTO> Delete(int id);
    Response<TitleResponseDTO> GetById(int id);

    Response<List<TitleResponseDTO>> GetAll();
}
