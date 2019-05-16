using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlTechniques.CommsServer;

namespace SimpleConnect
{
    interface ICommand
    {
        string name { get; }            //The command name for this command object
        string [] reqArgs { get; }      //A List of required arguments for this command
        string [] optArgs { get; }      //A List of optional arguments for this command

        /// <summary>
        /// The main method to eexecute this command object
        /// </summary>
        /// <param name="cmdLineArgs">Dicitionary of command line arguments passed to the command</param>
        void DoAction(Dictionary<string, string> cmdLineArgs, ref BlockingCommsUser oComms);
        
    }

}
