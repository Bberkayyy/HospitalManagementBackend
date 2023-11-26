using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRules.Abstract;

public interface IEmployeeRules
{
    void EmployeePhoneNumberLengthMustBe11(string phoneNumber);
    void EmployeeAgeNotBeLessThanEighteen(int age);

    void EmployeeIsPresent(Guid id);
    void EmployeePhoneNumberMustBeStartWithZero(string phoneNumber);

    public void TitleIdIsValid(int id);

    public void HospitalIdIsValid(int id);
}
