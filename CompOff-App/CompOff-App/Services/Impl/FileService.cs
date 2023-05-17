using CommunityToolkit.Maui.Alerts;
using CompOff_App.Models;
using FluentFTP;
using FluentFTP.Proxy.SyncProxy;
using Microsoft.Maui.Devices.Sensors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;

namespace CompOff_App.Services.Impl
{
    public class FileService : IFileService
    {
        private readonly string _cacheDir = FileSystem.Current.CacheDirectory;
        
        public FileService()
        {
            
        }
        public void AddScript(Guid jobId, string path)
        {
            string destination = _cacheDir + "/" + jobId.ToString() + ".py";
            File.Copy(path, destination, true);
        }

        public bool DownloadCheckpointIsh(Job job)
        {
            try 
            { 
                string[] subStr = job.ResultPath.Split(":");
                var ftpClient = new FtpClient(subStr[0], subStr[1], subStr[2]);
                var split = subStr[3].Split("/");
                var remote = split[0] + "/" +  split[1];
                var local = _cacheDir + "/" + job.JobID + "_Directory";
                var path = $"{Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).Path}/{job.JobName.Replace(" ", "")}_Directory";
                ftpClient.Connect();
                ftpClient.DownloadDirectory(local, remote);
                ftpClient.DownloadDirectory(path, remote);
                ftpClient.Disconnect();
                return true;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool UploadCheckpointIsh(Job job)
        {
            try 
            { 
                string[] subStr = job.ResultPath.Split(":");
                var ftpClient = new FtpClient(subStr[0], subStr[1], subStr[2]);
                var split = subStr[3].Split("/");
                var remote = split[0];
                var local = _cacheDir + "/" + job.JobID + $"_Directory" + $"/home/ftpuser/{remote}";
                ftpClient.Connect();
                ftpClient.UploadDirectory(local, remote, existsMode: FtpRemoteExists.Overwrite);
                ftpClient.Disconnect();
                return true;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool UploadScript(Job job)
        {
            try 
            { 
                string[] subStr = job.SourcePath.Split(":");
                var ftpClient = new FtpClient(subStr[0], subStr[1], subStr[2]);
                var bytes = File.ReadAllBytes(_cacheDir + "/" + job.JobID.ToString() + ".py");
                var directory = subStr[3].Remove(subStr[3].LastIndexOf("/"));
                ftpClient.Connect();
                ftpClient.CreateDirectory(directory);
                ftpClient.CreateDirectory(job.BackupPath.Split(":")[3]);
                ftpClient.CreateDirectory(job.ResultPath.Split(":")[3]);
                ftpClient.UploadBytes(bytes, subStr[3]);
                ftpClient.Disconnect();
                return true;
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool DownloadScript(Job job)
        {
            try
            {
                string[] subStr = job.ResultPath.Split(":");
                var ftpClient = new FtpClient(subStr[0], subStr[1], subStr[2]);                
                var path = $"{Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).Path}/{job.JobName.Replace(" ", "")}_Result.txt";
                ftpClient.Connect();
                ftpClient.DownloadFile(path, subStr[3] + "/done.txt");
                ftpClient.Disconnect();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }


        }
    }
}
