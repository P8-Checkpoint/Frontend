using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Services;

public interface IConnectionService
{
    public Task LoginAsync(string username, string password);
}
