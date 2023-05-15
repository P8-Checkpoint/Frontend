using CompOff_App.Models;
using FluentFTP;
using Microsoft.Maui.Devices.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Services.Impl
{
    public class FileService : IFileService
    {
        private readonly string _cacheDir = FileSystem.Current.CacheDirectory;
        public void AddScript(Guid jobId, string path)
        {
            string destination = _cacheDir + "/" + jobId.ToString() + ".py";
            File.Copy(path, destination, true);
        }

        public void UploadScript(Job job)
        {
            try 
            { 
                string[] subStr = job.SourcePath.Split(":");
                var ftpClient = new FtpClient(subStr[0], subStr[1], subStr[2]);
                var bytes = File.ReadAllBytes(_cacheDir + "/" + job.JobID.ToString() + ".py");
                ftpClient.Connect();
                ftpClient.UploadBytes(bytes, subStr[3]);
                ftpClient.Disconnect();
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
