using Core.Repository.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete;

public class HospitalRepository : EfRepositoryBase<BaseDbContext, Hospital, int>, IHospitalRepository
{
    public HospitalRepository(BaseDbContext context) : base(context)
    {
    }
}
