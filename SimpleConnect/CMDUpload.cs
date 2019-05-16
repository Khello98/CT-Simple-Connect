using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ControlTechniques.CommsServer;

namespace SimpleConnect
{
    class CMDUpload : ICommand
    {
        public CMDUpload(string name, string[] reqArgs, string[] optArgs)
        {
            this.name = name;
            this.reqArgs = reqArgs;
            this.optArgs = optArgs;
        }

        public string name { get; }

        public string[] reqArgs { get; }

        public string[] optArgs { get; }

        public void DoAction(Dictionary<string, string> cmdLineArgs, ref BlockingCommsUser oComms)
        {
            // If comms in not initliazed then initilize
            if (oComms == null)
            {
                oComms = new BlockingCommsUser();
            }

           
            // Set the IP address using value from command Line
            IPAddress ip = IPAddress.Parse(cmdLineArgs["IP"]);
            CommsAddress address = new CommsAddress(ip, 0);



            // Set the menu and parameter to read
            //ECMPReadRequest Req = new ECMPReadRequest(4,2,4);

            ParameterID PI = new ParameterID(19, 11);
            ParameterID PI1 = new ParameterID(19, 12);
            ParameterID PI2 = new ParameterID(19, 13);
            ParameterID PI3 = new ParameterID(19, 14);

            List<ParameterID> Test = new List<ParameterID>();
            Test.Add(PI);
            Test.Add(PI1);
            Test.Add(PI2);
            Test.Add(PI3);

            ECMPReadRequest test = new ECMPReadRequest(Test);

            // Set communication protocol
            Protocol prot = Protocol.EthernetProtocol();
             T_STATUS State = oComms.Go(prot);


            ECMPReadResponse Response = null; // Define variable to recieve response

             T_RESPONSE_STATUS Status = oComms.Read(address, test, out Response); // Read the parameter


        }
    }
}
