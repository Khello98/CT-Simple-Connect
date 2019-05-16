using ControlTechniques.CommsServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace SimpleConnect
{
    class CMDdownload : ICommand
    {
        public CMDdownload(string name, string[] reqArgs, string[] optArgs)
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


            //ParameterValue Number = new ParameterValue(50);
            // Set the menu and parameter to write

            //ECMPWriteRequest Req = new ECMPWriteRequest(19, 13, 70, 0);
            ParameterID PI = new ParameterID(18, 11);
            ParameterID PI1 = new ParameterID(18, 12);
            ParameterID PI2 = new ParameterID(18, 13);

            List<ParameterID> writelist = new List<ParameterID>();
            writelist.Add(PI);
            writelist.Add(PI1);
            writelist.Add(PI2);

            ParameterValue vale = new ParameterValue(10);
            ParameterValue vale1 = new ParameterValue(120);
            ParameterValue vale2 = new ParameterValue(150);

            List<ParameterValue> ValeList = new List<ParameterValue>(3);
            ValeList[0] = vale;
            ValeList[1] = vale1;
            ValeList[2] = vale2;

            ECMPWriteRequest Result = new ECMPWriteRequest();

            // Set communication protocol
            Protocol prot = Protocol.EthernetProtocol();
            T_STATUS State = oComms.Go(prot);

            //ECMPWriteResponse Response; // Define variable to recieve response

            T_RESPONSE_STATUS Status = oComms.Write(address, Result, out ECMPWriteResponse Response);

        }

    }
}
