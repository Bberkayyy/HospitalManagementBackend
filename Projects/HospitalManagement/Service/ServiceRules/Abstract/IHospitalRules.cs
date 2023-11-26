using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRules.Abstract;

public interface IHospitalRules
{
    void HospitalNameMustBeUnique(string hospitalName);
}
