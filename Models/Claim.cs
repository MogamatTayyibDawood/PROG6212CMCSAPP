using System.ComponentModel.DataAnnotations;

namespace PROG6212CMCSAPP.Models
{
    public class Claim
    {
        //submitted by lecturers
        [Key]
        public int ClaimId { get; set; }
        //DAta for database
        [Required]
        [Display(Name = "Lecturer Name")]
        public string LecturerName { get; set; }

        [Required]
        [Display(Name = "Hours Worked")]
        [Range(1, 1000, ErrorMessage = "Hours must be between 1 and 1000.")]
        public int HoursWorked { get; set; }

        [Required]
        [Display(Name = "Hourly Rate")]
        [Range(0.01, 1000, ErrorMessage = "Rate must be between 0.01 and 1000.")]
        public decimal HourlyRate { get; set; }

        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Display(Name = "Supporting Document")]
        public byte[] DocumentData { get; set; }

        [Display(Name = "Document Type")]
        public string DocumentType { get; set; }

        [Required]
        public string Status { get; set; }

        [Display(Name = "Submission Date")]
        public DateTime SubmissionDate { get; set; }

        [Display(Name = "Approval Date")]
        public DateTime? ApprovalDate { get; set; }
    }
}
