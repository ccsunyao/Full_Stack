using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaoSun.ApplicationCore.Models.Request
{
    public class CreateTaskRequestModel
    {
        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please make sure Title is not blank")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please make sure Description is not blank")]
        [StringLength(500)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [StringLength(1)]
        public char Priority { get; set; }
        public string Remarks { get; set; }
    }
}
