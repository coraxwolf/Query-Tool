using CsvHelper;
using CsvHelper.Configuration;
using EO_Tool.Models;
using Microsoft.Win32;
using Query_Tool.Models;
using Query_Tool.Stores;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Query_Tool.Commands
{
    public class LoadQuery : CommandBase
    {
        private readonly QueryStore Store;

        public LoadQuery(QueryStore store)
        {
            Store = store;
        }

        public override void Execute(object? parameter)
        {
            // Open File Dialog to get Query CSV FileO
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Query CSV File";
            ofd.Filter = "Comma Seperated Values (*.csv)|*.csv";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            bool? fileOk = ofd.ShowDialog();

            if (fileOk == true)
            {
                string queryFilePath = ofd.FileName;
                var config = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)
                {
                    MissingFieldFound = null,
                    IgnoreBlankLines = true,
                };
                using var fileReader = new StreamReader(queryFilePath);
                using var csv = new CsvReader(fileReader, config);
                {
                    csv.Context.RegisterClassMap<QueryRowClassMap>();
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        QueryRow? record = csv.GetRecord<QueryRow>();
                        if (record != null)
                        {
                            string id = record.Term + "-" + record.ClassNbr + "-" + record.Subject + "-" + record.Catalog;
                            if (Store.ContainsKey(id))
                            {
                                Course courseRecord = Store.GetCourse(id);
                                List<Faculty> faculty = courseRecord.GetFaculty();
                                bool newFac = true;
                                foreach (Faculty fac in faculty)
                                {
                                    if (fac.FacultyNo == record.ID) { newFac = false; break; }
                                }
                                if (newFac)
                                {
                                    Faculty newFaculty = new(record.Name, record.ID);
                                    courseRecord.AddFaculty(newFaculty);
                                }

                            } else
                            {
                                Course course = new(
                                        id,
                                        record.Term,
                                        record.ClassNbr,
                                        record.Session,
                                        record.Subject,
                                        record.Catalog,
                                        record.Campus,
                                        record.Location,
                                        record.Descr,
                                        record.Mode,
                                        Int32.Parse(record.TotEnrl),
                                        Int32.Parse(record.Cap),
                                        record.ClassStat,
                                        record.StartDate,
                                        record.EndDate
                                    );
                                if (record.Name != null)
                                { 
                                    Faculty faculty = new Faculty(record.Name,record.ID);
                                    course.AddFaculty(faculty);
                                }
                                Store.AddCourse( course );
                            }
                        }

                    }
                }
                Debug.WriteLine("Finished");
            }



        }
    }
}
