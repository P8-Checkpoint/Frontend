using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Services.Impl
{
    class DataService : IDataService
    {
        public DataService()
        {
            Console.WriteLine("Dataservice initialized \n");
        }
        //Create a lot of mockup data to test these methods on

        public void getcurrentuser() //TODO: possibly async?
        {
            throw new NotImplementedException();
        }

        public void getjobs()
        {
            throw new NotImplementedException();
        }

        public void getlocations()
        {
            throw new NotImplementedException();
        }
    }
}
