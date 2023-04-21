using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Models
{
    class Job
    {
        string _jobname,
               _description,
               _script,
               _datafilepath,
               _status,
               _resultfilepath;

        DateTime _dateadded = new DateTime(),
                 _lastactivity = new DateTime();

        public Job()
        {
            
        }

    }
}
