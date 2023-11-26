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

public class TitleRepository : EfRepositoryBase<BaseDbContext, Title, int>, ITitleRepository
{
    public TitleRepository(BaseDbContext context) : base(context)
    {
    }
}
