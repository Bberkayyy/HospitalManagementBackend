using Core.Repository.Repositories;
using Models.Entities;


namespace DataAccess.Repositories.Abstract;

public interface ITitleRepository : IEntityRepository<Title, int>
{
}
