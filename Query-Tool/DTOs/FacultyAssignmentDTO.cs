using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.DTOs
{
    [PrimaryKey(nameof(SisId), nameof(FacultyNo))]
    public class FacultyAssignmentDTO
    {
        public string SisId { get; set; }
        public string FacultyNo { get; set; }
        public DateTime created {  get;}

        public FacultyAssignmentDTO()
        {
            created = DateTime.Now;
        }
    }
}
