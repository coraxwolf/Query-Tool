using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.Models
{
    public class Faculty
    {
        public string Name;
        public string FacultyNo;
        public int? CanvasCode { get;  set; } = null;
        public string? CanvasName { get;  set; } = string.Empty;

        public Faculty(string name, string id) 
        {
            Name = name;
            FacultyNo = id;
        }

        public override string ToString()
        {
            if (CanvasName is null)
            {
                return $"{Name} ({FacultyNo})";
            } else
            {
                return $"{CanvasName} ({FacultyNo})";
            }
        }
    }
}
