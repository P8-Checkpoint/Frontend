using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Services;

internal interface INetworkService
{
    void ConnectToNetwork(string networkSsid, string networkPassword);
    void DisconnectFromNetwork(string networkSsid);
    string GetNetworkSsid();
    void FindNearbyNetworks();
}
