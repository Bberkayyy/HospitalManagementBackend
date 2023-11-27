using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Service.ServiceRules.Abstract;


namespace Service.ServiceRules.Concrete;

public class EmployeeRules : IEmployeeRules
{
    private readonly IEmployeeRepository _employeesRepository;
    private readonly ITitleRepository _titleRepository;
    private readonly IHospitalRepository _hospitalRepository;

    public EmployeeRules(IEmployeeRepository employeesRepository, ITitleRepository titleRepository, IHospitalRepository hospitalRepository)
    {
        _employeesRepository = employeesRepository;
        _titleRepository = titleRepository;
        _hospitalRepository = hospitalRepository;
    }

    public void EmployeeAgeNotBeLessThanEighteen(int age)
    {
        if (age < 18)
            throw new ServiceExceptions($"Çalışan yaşı 18 den küçük olamaz. ({age}) ");
    }

    public void EmployeeIsPresent(Guid id)
    {
        var employee = _employeesRepository.GetById(id);
        if (employee is null)
            throw new ServiceExceptions($"Girilen id'ye ait çalışan bulunamadı.");
    }

    public void EmployeePhoneNumberLengthMustBe11(string phoneNumber)
    {
        if (phoneNumber.Length is not 11)
            throw new ServiceExceptions($"Lütfen 11 haneli telefon numarası giriniz. ({phoneNumber.Length})");
    }

    public void EmployeePhoneNumberMustBeStartWithZero(string phoneNumber)
    {
        if (!phoneNumber.StartsWith("0"))
            throw new ServiceExceptions($"Telefon numarası 0 ile başlamalıdır. ({phoneNumber[0]})");
    }
    public void TitleIdIsPresent(int id)
    {
        var title = _titleRepository.GetById(id);
        if (title is null)
        {
            throw new ServiceExceptions($"Lütfen mevcut bir ünvan id giriniz. ({id})");
        }
    }
    public void HospitalIdIsPresent(int id)
    {
        var hospital = _hospitalRepository.GetById(id);
        if (hospital is null)
            throw new ServiceExceptions($"Lütfen mevcut bir hastane id giriniz. ({id})");
    }
}
