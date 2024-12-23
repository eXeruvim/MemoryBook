
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemoryBook.Models
{
    [Table("Feedbacks")]
    public class FeedbackMessage
    {
        [Key]
        [Column("feedback_id")]
        public int FeedbackId { get; set; }

        [Column("email")]
        public string Email { get; set; } = null!;

        [Column("msg")]
        public string? Msg { get; set; }

        [Column("file_path")]
        public string FilePath { get; set; } = null!;

        [Column("original_file_name")]
        public string? OriginalFileName { get; set; }

        [Column("submission_date")]
        public DateTime SubmissionDate { get; set; }
    }
}
