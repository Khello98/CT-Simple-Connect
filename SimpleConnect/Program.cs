using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ControlTechniques.CommsServer;

namespace SimpleConnect
{
    public class Program
    {
        private static ICommand[] commandList = {
                new CMDdownload("DOWNLOAD", new string[] {"IP","FILE"}, new string[]{null}),
                new CMDUpload("UPLOAD", new string[] {"IP","FILE"}, new string[]{null})
        };


        public static void Main(string[] args)
        {
            Dictionary<string, string> cmdLineArgs; //This is the list of all the command line arguments passed to the programme

            //ICommand command = processComandLine(args, out cmdLineArgs);
            //if(command != null)
            //{
            //    BlockingCommsUser oComms = new BlockingCommsUser();
            //    command.DoAction(cmdLineArgs, ref oComms);
            //}

            CTParameterFile paramterFile = new CTParameterFile();
            paramterFile.ReadActionXml(@"c:\Users\alhukh01\Documents\Visual Studio 2017\XML Test\Sample.parfile"); //***************

            Console.ReadLine();
        }

        private static ICommand processComandLine(string[] args, out Dictionary<string, string> cmdLineArgs)
        {
            //Check if we have at least the command argument
            if (args.Length < 1)
            {
                Console.WriteLine("Help");
                cmdLineArgs = null;
                return null;
            }
            
            //Look for a command and see if it matches what we requested
            ICommand foundCommand = null;
            foreach (ICommand cmd in commandList)
            {
                if(cmd.name.ToUpper().Equals(args[0].ToUpper()))
                {
                    foundCommand = cmd;
                    break;
                }
            }

            //Not found a valid command so return nothing
            if (foundCommand == null)
            {
                cmdLineArgs = null;
                return null;
            }

            // process the other command line arguments for returning
            cmdLineArgs = new Dictionary<string, string>();
            for (int i = 1; i < args.Length; i++)
            {
                string[] data = args[i].Split('=');
                cmdLineArgs.Add(data[0].Replace("-", ""), data[1]);
            }

            //Return the macthing command object
            return foundCommand;
        }
        
    }
}
