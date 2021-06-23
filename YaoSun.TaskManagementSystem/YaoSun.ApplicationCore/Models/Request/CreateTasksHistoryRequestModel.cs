using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaoSun.ApplicationCore.Models.Request
{
    public class CreateTasksHistoryRequestModel
    {
        [Required]
        public int TaskId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public DateTime Completed { get; set; }
        public string Remarks { get; set; }
    }
}
