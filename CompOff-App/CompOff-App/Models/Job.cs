using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Models;

public enum JobStatus
{
    New,
    InQueue,
    Waiting,
    Running,
    Cancelled,
    Done
}
public class Job
{
    public Guid JobID { get; set; }
    public string Jobname { get; set; }
    public string Description { get; set; }
    public string Script { get; set; }
    public string DataFilePath { get; set; }
    public string ResultFilePath { get; set; }
    public JobStatus Status { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime LastActivity  { get; set; }

public Job(string jobname, string description, string script, string datafilepath)
    {
        JobID = Guid.NewGuid();
        Jobname = jobname;
        Description = description;
        Script = script;
        DataFilePath = datafilepath;
        Status = JobStatus.New;
        DateAdded = DateTime.Now;
    }

}
