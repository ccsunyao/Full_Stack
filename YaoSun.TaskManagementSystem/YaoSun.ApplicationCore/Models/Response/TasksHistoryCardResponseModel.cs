using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaoSun.ApplicationCore.Models.Response
{
    public  class TasksHistoryCardResponseModel
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime Completed { get; set; }
        public string Remarks { get; set; }
    }
}
