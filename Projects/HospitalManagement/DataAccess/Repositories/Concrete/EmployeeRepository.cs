using Core.Repository.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using Models.DTOs.ResponseDTO;
using Models.Entities;

namespace DataAccess.Repositories.Concrete;

public class EmployeeRepository : EfRepositoryBase<BaseDbContext, Employee, Guid>, IEmployeeRepository
{
    public EmployeeRepository(BaseDbContext context) : base(context)
    {
    }

    public List<EmployeeDetailDTO> GetAllEmployeeDetail()
    {
        return Context.Employees.Join(
            Context.Titles,
            e => e.TitleId,
            t => t.Id,
            (employee, title) => new { employee, title }).Join(
            Context.Hospitals,
            et => et.employee.HospitalId,
            h => h.Id,
            (et, hospital) => new { et.employee, et.title, hospital }).Select(eth => new EmployeeDetailDTO
            {
                Id = eth.employee.Id,
                Age = eth.employee.Age,
                Name = eth.employee.Name,
                PhoneNumber = eth.employee.PhoneNumber,
                HospitalName = eth.hospital.Name,
                TitleName = eth.title.Name
            }).ToList();


    }

    public List<EmployeeDetailDTO> GetDetailsByTitleId(int titleId)
    {
        return Context.Employees.Join(
            Context.Titles.Where(x => x.Id == titleId),
            e => e.TitleId,
            t => t.Id,
            (employee, title) => new { employee, title }).Join(
            Context.Hospitals,
            et => et.employee.HospitalId,
            h => h.Id,
            (et, hospital) => new { et.employee, et.title, hospital }).Select(eth => new EmployeeDetailDTO
            {
                Id = eth.employee.Id,
                Age = eth.employee.Age,
                Name = eth.employee.Name,
                PhoneNumber = eth.employee.PhoneNumber,
                HospitalName = eth.hospital.Name,
                TitleName = eth.title.Name
            }).ToList();
    }

    public EmployeeDetailDTO GetEmployeeDetail(Guid id)
    {
        var details = Context.Employees.Join(
            Context.Titles,
            e => e.TitleId,
            t => t.Id,
            (employee, title) => new { employee, title }).Join(
            Context.Hospitals,
            et => et.employee.HospitalId,
            h => h.Id,
            (et, hospital) => new { et.employee, et.title, hospital }).Select(eth => new EmployeeDetailDTO
            {
                Id = eth.employee.Id,
                Age = eth.employee.Age,
                Name = eth.employee.Name,
                PhoneNumber = eth.employee.PhoneNumber,
                HospitalName = eth.hospital.Name,
                TitleName = eth.title.Name
            }).SingleOrDefault(x => x.Id == id);

        return details;
    }

}
