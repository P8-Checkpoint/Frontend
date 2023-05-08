using CompOff_App.Models;
using CompOff_App.Pages.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CompOff_App.Models.Location;


namespace CompOff_App.Services;

public interface INetworkService
{
    void ConnectToNetwork(string networkSsid, string networkPassword);
    void DisconnectFromNetwork();
    string GetNetworkSsid();
    void FindNearbyNetworks();
}
