// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using ToyAssignment;
using ToyAssignment.Board.Interface;
using ToyAssignment.ConsoleChecker;
using ToyAssignment.ConsoleChecker.Interface;
using ToyAssignment.Toy;
using ToyAssignment.Toy.Interface;
using ToyAssignment.Board;

var builder = new ServiceCollection()
            .AddSingleton<Application, Application>()
            .AddSingleton<IToyBoard, ToyBoard>()
            .AddSingleton<ICommandRunner, CommandRunner>()
            .AddSingleton<IToyBoard>(new ToyBoard(5,5))
            .AddSingleton<IInputParser, InputParser>()
            .AddSingleton<IToyRobot, ToyRobot>()
            .BuildServiceProvider();

Application app = builder.GetRequiredService<Application>();
app.Run();
