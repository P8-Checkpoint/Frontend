using CompOff_App.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Models;


public enum JobStatus
{
    Waiting,
    InQueue,
    Running,
    Cancelled,
    Done
}

public class Job
{
    public Guid JobID { get; set; }
    public string JobName { get; set; }
    public string Description { get; set; }
    public JobStatus Status { get; set; }
    public string SourcePath { get; set; }
    public string BackupPath { get; set; }
    public string ResultPath { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime LastActivity { get; set; }

    public Job(string jobName, string description, string sourcePath, string backupPath, string resultPath)
    {
        JobID = Guid.NewGuid();
        JobName = jobName;
        Description = description;
        Status = JobStatus.Waiting;
        SourcePath = sourcePath;
        BackupPath = backupPath;
        ResultPath = resultPath;
        DateAdded = DateTime.Now;
        LastActivity = DateTime.Now;
    }

    public Job(JobDto job)
    {
        JobID = job.id;
        JobName = job.name;
        Description = job.description;
        Status = (JobStatus)job.status;
        SourcePath = job.sourcePath;
        BackupPath = job.backupPath;
        ResultPath = job.resultPath;
        DateAdded = job.dateAdded;
        LastActivity = job.lastActivity;

    }

    public Job()
    {
    }
}
