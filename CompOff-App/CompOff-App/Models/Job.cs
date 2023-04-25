using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Models
{
    public enum JobStatus
    {
        Created,
        Starting,
        InProgress,
        Canceled,
        Failed,
        Completed
    }
    public class Job
    {
        public Guid JobID { get; set; }
        public string Jobname { get; set; }
        public string Description { get; set; }
        public string Script { get; set; }
        public string Datafilepath { get; set; }
        public string Resultfilepath { get; set; }
        public JobStatus Status { get; set; }
        public DateTime Dateadded { get; set; }
        public DateTime Lastactivity  { get; set; }

    public Job(string jobname, string description, string script, string datafilepath)
        {
            JobID = Guid.NewGuid();
            Jobname = jobname;
            Description = description;
            Script = script;
            Datafilepath = datafilepath;
            Status = JobStatus.Created;
            Dateadded = DateTime.Now;
        }

    }
}
