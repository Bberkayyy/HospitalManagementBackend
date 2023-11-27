using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Repositories.Abstract;
using Service.ServiceRules.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRules.Concrete;

public class HospitalRules : IHospitalRules
{
    private readonly IHospitalRepository _hospitalRepository;

    public HospitalRules(IHospitalRepository hospitalRepository)
    {
        _hospitalRepository = hospitalRepository;
    }

    public void HospitalIsPresent(int id)
    {
        var hospital = _hospitalRepository.GetById(id);
        if (hospital is null)
            throw new ServiceExceptions($"Girilen id'ye ait hastane bulunamadı.");
    }

    public void HospitalNameMustBeUnique(string hospitalName)
    {
        var hospital = _hospitalRepository.GetByFilter(x => x.Name == hospitalName);
        if (hospital is not null)
            throw new ServiceExceptions($"Girilen hastane mevcuttur. ({hospitalName})");
    }
}
