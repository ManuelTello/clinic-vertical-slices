using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NET.Clinic.API.Entities
{
    [Table("Appointments")]
    public class Appointment
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id",TypeName = "int",Order = 0)]
        public int Id { get; init; }
     
        [Column("patient_name", TypeName = "varchar(255)", Order = 1)]
        public string Name { get; init; } = string.Empty;
        
        [Column("identification", TypeName = "integer", Order = 2)]
        public int Identification { get; init; }
        
        [Column("appointment_date", TypeName = "timestamp", Order = 3)]
        public DateTime AppointmentDate { get; init; }

        [Column("did_assist", TypeName = "boolean", Order = 4)]
        public bool DidAssist { get; init; } = false;
    }
}

