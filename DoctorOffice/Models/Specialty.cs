using System.Collections.Generic;

namespace DoctorOffice.Models
{
  public class Specialty
  {
    public Specialty()
    {
      this.JoinEntities2 = new HashSet<SpecialtyDoctor>();
    }
    public int SpecialtyId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<SpecialtyDoctor> JoinEntities2 { get; set; }
  }
}