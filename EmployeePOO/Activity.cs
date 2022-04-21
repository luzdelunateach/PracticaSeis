using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePOO
{
    class Activity
    {
        public String Description {  get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public bool Valid { get; set; }
        public int Id { get; set; }

        public int IdProject { get; set; }

        public Activity(string Description, DateTime Date, int Hour, bool Valid, int Id, int IdProject )
        {
            this.Description = Description;
            this.Date = Date;
            this.Hours = Hour;
            this.Valid = Valid;
            this.Id = Id;
            this.IdProject = IdProject;
        }
    }
}
