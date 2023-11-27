using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Repositories.Abstract;
using Service.ServiceRules.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRules.Concrete;

public class TitleRules : ITitleRules
{
    private readonly ITitleRepository _titleRepository;

    public TitleRules(ITitleRepository titleRepository)
    {
        _titleRepository = titleRepository;
    }

    public void TitleIsPresent(int id)
    {
        var title = _titleRepository.GetById(id);
        if (title is not null)
            throw new ServiceExceptions($"Girilen id'ye ait ünvan bulunamadı.");
    }

    public void TitleNameMustBeUnique(string titleName)
    {
        var title = _titleRepository.GetByFilter(x => x.Name == titleName);
        if (title is not null)
            throw new ServiceExceptions($"Girilen ünvan mevcuttur. ({titleName})");
    }
}
