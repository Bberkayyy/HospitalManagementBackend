
using Core.Repository.EntityBaseModel;

namespace Models.Entities;

public class Hospital:Entity<int>
{

    public string Name { get; set; }


    public List<Employee> Employees { get; set; }

}
