using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chama.Signup.Repositories.Entities
{
    public class CourseSummaryEntity {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public double AverageAge { get; set; }
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public int Capacity { get; set; }
        public int NumberOfStudents { get; set; }
    }
}