

using Core.Repository.EntityBaseModel;

namespace Models.Entities;

public class Employee:Entity<Guid>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string PhoneNumber { get; set; }



    public int TitleId { get; set; }
    public Title Title { get; set; }
    public int HospitalId { get; set; }
    public Hospital Hospital { get; set; }

}
