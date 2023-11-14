using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyAssignment.ConsoleChecker.Interface
{
    public interface ICommandRunner
    {
        string ProcessCommand(string[] input);
    }
}
