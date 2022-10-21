using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class Vital : Base
	{
		[NotMapped]
		public static string TableName = "vital";

		[Key]
		public int vitalID { get; set; }

		[ForeignKey("PatientAllocation")]
		public int patientAllocationID { get; set; }

		//[JsonIgnore]
		public virtual PatientAllocation PatientAllocation { get; set; }

		public int afterMeal { get; set; }

		[Column(TypeName = "decimal(3,1)")]
		public decimal temperature { get; set; }
		public int systolicBP { get; set; }
		public int diastolicBP { get; set; }
		public int heartRate { get; set; }
		public int spO2 { get; set; }
		public int bloodSugarlevel { get; set; }

		[Column(TypeName = "decimal(3,2)")]
		public decimal height { get; set; }

		[Column(TypeName = "decimal(4,1)")]
		public decimal weight { get; set; }
		public string vitalRemarks { get; set; }
	}
}