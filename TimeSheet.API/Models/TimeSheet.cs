using System.ComponentModel.DataAnnotations;

namespace TimeSheets.API.Models
{
    public class TimeSheet
    {
        [Key]
        public string EmployeeID { get; set; } 
        public string EmployeeName { get; set; }
        public string ProjectName { get; set; }
        public string Activity { get; set; }
        public string Task { get; set; }
        public string Date { get; set; }
        public string WorkHours { get; set; }
    }
}
