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
        // TODO change return type from VOID to w/e is needed
        public Task<User> GetCurrentUserAsync();
        public Task<IEnumerable<Job>> GetJobsAsync();
        public Task<IEnumerable<Models.Location>> GetLocationsAsync();

    }
}
