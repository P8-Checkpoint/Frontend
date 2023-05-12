using CompOff_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompOff_App.Pages.Tabs;
using static CompOff_App.Models.Location;

namespace CompOff_App.Services
{
    public interface IDataService
    {
        public Task<User> GetCurrentUserAsync();
        public Task UpdateJobAsync(Job job);
        public Task<IEnumerable<Job>> GetJobsAsync();
        public Task<IEnumerable<Models.Location>> GetLocationsAsync();
        public Task<Job> GetJobByIdAsync(Guid id);
        public Task AddJobAsync(string name, string description);
        public Task ClearDataAndLogout();
    }
}
