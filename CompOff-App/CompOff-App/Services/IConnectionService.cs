using CompOff_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Services;

public interface IConnectionService
{
    public Task LoginAsync(string username, string password);
    public Task<IEnumerable<Job>> GetJobsAsync();
    public Task<Job> GetJobByIdAsync(Guid id);
    public Task CreateJobAsync(string name, string description);
    public Task UpdateJobAsync(Job job);
    public Task CancelJobAsync(Job job);
}
