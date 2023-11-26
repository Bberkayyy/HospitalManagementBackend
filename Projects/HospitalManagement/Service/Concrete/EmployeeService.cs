using Core.CrossCuttingConcerns.Exceptions;
using Core.Shared;
using DataAccess.Repositories.Abstract;
using Models.DTOs.RequestDTO;
using Models.DTOs.ResponseDTO;
using Models.Entities;
using Service.Abstract;
using Service.ServiceRules.Abstract;


namespace Service.Concrete;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEmployeeRules _employeeRules;

    public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeRules employeeRules)
    {
        _employeeRepository = employeeRepository;
        _employeeRules = employeeRules;
    }

    public Response<EmployeeResponseDTO> Add(EmployeeAddRequest employeeAddRequest)
    {
        try
        {
            Employee employee = EmployeeAddRequest.ConvertToEntity(employeeAddRequest);
            _employeeRules.EmployeeAgeNotBeLessThanEighteen(employee.Age);
            _employeeRules.EmployeePhoneNumberLengthMustBe11(employee.PhoneNumber);
            _employeeRules.EmployeePhoneNumberMustBeStartWithZero(employee.PhoneNumber);
            _employeeRules.TitleIdIsValid(employee.TitleId);
            _employeeRules.HospitalIdIsValid(employee.HospitalId);
            employee.Id = new Guid();
            _employeeRepository.Add(employee);

            var data = EmployeeResponseDTO.ConvertToResponse(employee);

            return new Response<EmployeeResponseDTO>()
            {
                Data = data,
                Message = "Çalışan eklendi.",
                StatusCode = System.Net.HttpStatusCode.Created
            };
        }
        catch (ServiceExceptions ex)
        {

            return new Response<EmployeeResponseDTO>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

    }

    public Response<EmployeeResponseDTO> Delete(Guid id)
    {
        try
        {
            _employeeRules.EmployeeIsPresent(id);
            var employee = _employeeRepository.GetById(id);
            _employeeRepository.Delete(employee);
            var data = EmployeeResponseDTO.ConvertToResponse(employee);
            return new Response<EmployeeResponseDTO>()
            {
                Data = data,
                Message = "Çalışan silindi.",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (ServiceExceptions ex)
        {

            return new Response<EmployeeResponseDTO>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

    }

    public Response<List<EmployeeResponseDTO>> GetAll()
    {
        var employees = _employeeRepository.GetAll();
        var response = employees.Select(x => EmployeeResponseDTO.ConvertToResponse(x)).ToList();
        return new Response<List<EmployeeResponseDTO>>()
        {
            Data = response,
            Message = "Çalışanlar listelendi.",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<EmployeeResponseDTO>> GetAllByAgeRange(int min, int max)
    {
        var employees = _employeeRepository.GetAll(x => x.Age >= min && x.Age <= max);
        var response = employees.Select(x => EmployeeResponseDTO.ConvertToResponse(x)).ToList();
        return new Response<List<EmployeeResponseDTO>>()
        {
            Data = response,
            Message = "Çalışanlar yaş aralığına göre listelendi.",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<EmployeeDetailDTO>> GetAllDetailByTitleId(int titileId)
    {
        var details = _employeeRepository.GetDetailsByTitleId(titileId);
        return new Response<List<EmployeeDetailDTO>>()
        {
            Data = details,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<EmployeeDetailDTO>> GetAllEmployeeDetails()
    {
        var details = _employeeRepository.GetAllEmployeeDetail();
        return new Response<List<EmployeeDetailDTO>>()
        {
            Data = details,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<EmployeeDetailDTO> GetByDetailId(Guid id)
    {
        var detail = _employeeRepository.GetEmployeeDetail(id);
        return new Response<EmployeeDetailDTO>()
        {
            Data = detail,
            Message = "Çalışan detayları getirildi.",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<EmployeeResponseDTO> GetById(Guid id)
    {
        var employee = _employeeRepository.GetById(id);
        var response = EmployeeResponseDTO.ConvertToResponse(employee);
        return new Response<EmployeeResponseDTO>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<EmployeeResponseDTO> Update(EmployeeUpdateRequest employeeUpdateRequest)
    {
        var employee = EmployeeUpdateRequest.ConvertToEntity(employeeUpdateRequest);
        _employeeRepository.Uptade(employee);
        var data = EmployeeResponseDTO.ConvertToResponse(employee);
        return new Response<EmployeeResponseDTO>
        {
            Data = data,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }
}
