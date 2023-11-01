using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EO_Tool.Models
{
    public class QueryRow
    {
        public string AcadGroup { get; set; } = string.Empty;
        public string Campus { get; set; } = string.Empty;
        public string Session { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Catalog { get; set; } = string.Empty;
        public string Descr { get; set; } = string.Empty;
        public string Section { get; set; } = string.Empty;
        public string Assoc { get; set; } = string.Empty;
        public string ClassNbr { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string FacilID { get; set; } = string.Empty;
        public string Mon { get; set; } = string.Empty;
        public string Tue { get; set; } = string.Empty;
        public string Wed { get; set; } = string.Empty;
        public string Thu { get; set; } = string.Empty;
        public string Fri { get; set; } = string.Empty;
        public string Sat { get; set; } = string.Empty;
        public string Sun { get; set; } = string.Empty;
        public string Time_Start { get; set; } = string.Empty;
        public string Time_End { get; set; } = string.Empty;
        public string Mode { get; set; } = string.Empty;
        public string Consent { get; set; } = string.Empty;
        public string ClassStat { get; set; } = string.Empty;
        public string TotEnrl { get; set; } = string.Empty;
        public string Cap { get; set; } = string.Empty;
        public string INSTR_ASSIG_SEQ { get; set; } = string.Empty;
        public string ID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string? NoteNbr { get; set; }
        public string PrintNote { get; set; } = string.Empty;
        public string Descrlong_A_Clsnotes { get; set; } = string.Empty;
        public string ClassFee { get; set; } = string.Empty;
        public string CrseFee { get; set; } = string.Empty;
        public string SchPrint { get; set; } = string.Empty;
        public string RqGroup { get; set; } = string.Empty;
        public string CrseAttr { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public string AcadOrg { get; set; } = string.Empty;
        public string Acad_Org_Descr { get; set; } = string.Empty;
        public string Term { get; set; } = string.Empty;
        public DateTime Date_Time { get; set; }
    }

    public class QueryRowClassMap : ClassMap<QueryRow>
    {
        public QueryRowClassMap()
        {
            Map(m => m.AcadGroup).Name("Acad Group");
            Map(m => m.Campus).Name("Campus");
            Map(m => m.Session).Name("Session");
            Map(m => m.Location).Name("Location");
            Map(m => m.Subject).Name("Subject");
            Map(m => m.Catalog).Name("Catalog");
            Map(m => m.Descr).Name("Descr");
            Map(m => m.Section).Name("Section");
            Map(m => m.Assoc).Name("Assoc");
            Map(m => m.ClassNbr).Name("Class Nbr");
            Map(m => m.StartDate).Name("Start Date");
            Map(m => m.EndDate).Name("End Date");
            Map(m => m.FacilID).Name("Facil ID");
            Map(m => m.Mon).Name("Mon");
            Map(m => m.Tue).Name("Tue");
            Map(m => m.Wed).Name("Wed");
            Map(m => m.Thu).Name("Thu");
            Map(m => m.Fri).Name("Fri");
            Map(m => m.Sat).Name("Sat");
            Map(m => m.Sun).Name("Sun");
            Map(m => m.Time_Start).Name("Time_Start");
            Map(m => m.Time_End).Name("Time_End");
            Map(m => m.Mode).Name("Mode");
            Map(m => m.Consent).Name("Consent");
            Map(m => m.ClassStat).Name("Class Stat");
            Map(m => m.TotEnrl).Name("Tot Enrl");
            Map(m => m.Cap).Name("Cap");
            Map(m => m.INSTR_ASSIG_SEQ).Name("INSTR_ASSIG_SEQ");
            Map(m => m.ID).Name("ID");
            Map(m => m.Name).Name("Name");
            Map(m => m.Role).Name("Role");
            Map(m => m.NoteNbr).Name("Note Nbr");
            Map(m => m.PrintNote).Name("Print Note");
            Map(m => m.Descrlong_A_Clsnotes).Name("Descrlong_A_Clsnotes");
            Map(m => m.ClassFee).Name("Class Fee");
            Map(m => m.CrseFee).Name("Crse Fee");
            Map(m => m.SchPrint).Name("Sch Print");
            Map(m => m.RqGroup).Name("Rq Group");
            Map(m => m.CrseAttr).Name("Crse Attr");
            Map(m => m.FileType).Name("File Type");
            Map(m => m.AcadOrg).Name("Acad Org");
            Map(m => m.Acad_Org_Descr).Name("Acad_Org_Descr");
            Map(m => m.Term).Name("Term");
            Map(m => m.Date_Time).Name("Date_Time");
        }
    }

}
