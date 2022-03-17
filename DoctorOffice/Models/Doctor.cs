using System.Collections.Generic;

namespace DoctorOffice.Models
{
  public class Doctor
  {
    public Doctor()
    {
      this.JoinEntities = new HashSet<DoctorPatient>();
      this.JoinEntities2 = new HashSet<SpecialtyDoctor>();
    }

    public int DoctorId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<DoctorPatient> JoinEntities { get; set; }
    public virtual ICollection<SpecialtyDoctor> JoinEntities2 { get; set; }
  }
}