using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyAssignment.ConsoleChecker.Interface;
using ToyAssignment.Toy;

namespace ToyAssignment.ConsoleChecker
{
    public class InputParser : IInputParser
    {
        // this method takes a string array and compares the first element to the list of commands
        // if the command doesn't exist then an error is thrown, otherwise the command is returned
        public Command ParseCommand(string[] rawInput)
        {
            Command command;
            if (!Enum.TryParse(rawInput[0], true, out command))
                throw new ArgumentException("Sorry, your command was not recognised. Please try again using the following format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT");
            return command;
        }

        // Extracts the parameters from the user input and returns it       
        public PlaceCommandParameter ParseCommandParameter(string[] input)
        {
            var thisPlaceCommandParameter = new PlaceCommandParameterParser();
            return thisPlaceCommandParameter.ParseParameters(input);
        }
    }
}
