using CompOff_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Services
{
    public interface IFileService
    {
        public void AddScript(Guid jobId, string path);
        public bool UploadScript(Job job);
        public bool DownloadScript(Job job);
        public bool UploadCheckpointIsh(Job job);
        public bool DownloadCheckpointIsh(Job job);
    }
}
