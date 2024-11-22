using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROG6212CMCSAPP.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }

        [Required(ErrorMessage = "Lecturer name is required")]
        public string LecturerName { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Notes must be between 5 and 500 characters", MinimumLength = 5)]
        public string Notes { get; set; }

        [Required]
        [Range(0, 10000, ErrorMessage = "Hourly rate must be between 0 and 10000")]
        [Display(Name = "Hourly Rate")]
        public decimal HourlyRate { get; set; }

        [Required]
        [Range(1, 500, ErrorMessage = "Hours worked must be between 1 and 500")]
        [Display(Name = "Hours Worked")]
        public int HoursWorked { get; set; }

        // Mark the TotalAmount as NotMapped so it's not included in the database schema
        [NotMapped]
        public decimal TotalAmount
        {
            get
            {
               
                return HourlyRate * HoursWorked; // Automatically calculate TotalAmount if it's not set
            }
        }

        public string Status { get; set; } = "Pending";

        [Display(Name = "Submission Date")]
        public DateTime? SubmissionDate { get; set; }

        [Display(Name = "Approval Date")]
        public DateTime? ApprovalDate { get; set; }

        public byte[] DocumentData { get; set; }

        public string DocumentType { get; set; }

        [StringLength(1000)]
        public string RejectionReason { get; set; }

        public string ApprovedBy { get; set; }

        // Foreign key reference for ApplicationUser
        public string LecturerId { get; set; }
        public virtual ApplicationUser Lecturer { get; set; }
    }
}
