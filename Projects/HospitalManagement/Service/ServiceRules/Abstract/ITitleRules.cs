using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRules.Abstract;

public interface ITitleRules
{
    void TitleNameMustBeUnique(string titleName);
    void TitleIsPresent(int id);
}
