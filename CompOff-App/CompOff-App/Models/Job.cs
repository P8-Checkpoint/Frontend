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
        Guid _jobID { get; set; }
        string _jobname { get; set; }
        string _description { get; set; }
        string _script { get; set; }
        string _datafilepath { get; set; }
        string _resultfilepath { get; set; }

        JobStatus _status { get; set; }

        DateTime _dateadded { get; set; }
        DateTime _lastactivity  { get; set; }

    public Job(string jobname, string description, string script, string datafilepath)
        {
            _jobID = Guid.NewGuid();
            _jobname = jobname;
            _description = description;
            _script = script;
            _datafilepath = datafilepath;
            _status = JobStatus.Created;

            _dateadded = DateTime.Now;
        }

    }
}
