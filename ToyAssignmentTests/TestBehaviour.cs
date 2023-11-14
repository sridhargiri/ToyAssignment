
using ToyAssignment.Board;
using ToyAssignment.Board.Interface;
using ToyAssignment.ConsoleChecker;
using ToyAssignment.ConsoleChecker.Interface;
using ToyAssignment.Toy;
using ToyAssignment.Toy.Interface;
using Moq;

namespace ToyAssignmentTests
{
    [TestFixture]
    public class TestBehaviour
    {
        private Mock<IInputParser> _inputParser;
        private Mock<IToyBoard> _toyBoard;
        private Mock<IToyRobot> _toyRobot;

        [SetUp]
        public void TestInitialize()
        {
            this._toyRobot = new Mock<IToyRobot>();
            this._toyBoard = new Mock<IToyBoard>();
            this._inputParser = new Mock<IInputParser>();
            _toyBoard.Object.Rows = 5;
            _toyBoard.Object.Columns = 5;

        }

        [Test]
        public void TestValidBehaviourPlace()
        {
            Position pos = new Position(1, 4);
            PlaceCommandParameter pcm = new PlaceCommandParameter(pos, Direction.East);
            string[] input = new string[] { "PLACE", "1,4,EAST" };
            // arrange
            _toyRobot.Setup(x=>x.Position).Returns(pos);
            _toyRobot.Setup(x=>x.Direction).Returns(Direction.East);
            _toyRobot.Setup(p => p.Place(pos, Direction.East));
            
            _toyBoard.Setup(v => v.IsValidPosition(pos)).Returns(true);

            _inputParser.Setup(x => x.ParseCommand(input)).Returns(Command.Place);
            _inputParser.Setup(x => x.ParseCommandParameter(input)).Returns(pcm);

            // act
            var simulator = new CommandRunner(_toyRobot.Object, _toyBoard.Object, _inputParser.Object);
            simulator.ProcessCommand("PLACE 1,4,EAST".Split(' '));

            // assert
            Assert.AreEqual(1, _toyRobot.Object.Position.X);
            Assert.AreEqual(4, _toyRobot.Object.Position.Y);
            Assert.AreEqual(Direction.East, _toyRobot.Object.Direction);
        }
        /// <summary>
        /// Test an invalid place command
        /// </summary>
        [Test]
        public void TestInvalidBehaviourPlace()
        {
            Position pos = null;
            PlaceCommandParameter pcm = new PlaceCommandParameter(pos, Direction.East);
            string[] input = new string[] { "PLACE", "9,7,EAST" };
            // arrange
            _toyRobot.Setup(x => x.Position).Returns(pos);
            _toyRobot.Setup(x => x.Direction).Returns(Direction.East);
            _toyRobot.Setup(p => p.Place(pos, Direction.East));

            _toyBoard.Setup(v => v.IsValidPosition(pos)).Returns(true);

            _inputParser.Setup(x => x.ParseCommand(input)).Returns(Command.Place);
            _inputParser.Setup(x => x.ParseCommandParameter(input)).Returns(pcm);

            // act
            var simulator = new CommandRunner(_toyRobot.Object, _toyBoard.Object, _inputParser.Object);
            simulator.ProcessCommand("PLACE 9,7,EAST".Split(' '));

            // assert
            Assert.IsNull(_toyRobot.Object.Position);
        }

        /// <summary>
        /// Test a valid move command
        /// </summary>
        [Test]
        public void TestValidBehaviourMove()
        {
            Position pos = new Position(3, 2);
            PlaceCommandParameter pcm = new PlaceCommandParameter(pos, Direction.South);
            string[] input = new string[] { "PLACE", "3,2,SOUTH" };
            // arrange
            _toyRobot.Setup(x => x.Position).Returns(pos);
            _toyRobot.Setup(x => x.Direction).Returns(Direction.South);
            _toyRobot.Setup(p => p.Place(pos, Direction.South));

            _toyBoard.Setup(v => v.IsValidPosition(pos)).Returns(true);

            _inputParser.Setup(x => x.ParseCommand(input)).Returns(Command.Place);
            _inputParser.Setup(x => x.ParseCommandParameter(input)).Returns(pcm);

            // act
            var simulator = new CommandRunner(_toyRobot.Object, _toyBoard.Object, _inputParser.Object);
            simulator.ProcessCommand(input);
            _inputParser.Setup(x => x.ParseCommand(new string[] { "MOVE" })).Returns(Command.Move);
            simulator.ProcessCommand(new string[] { "MOVE" });
            _inputParser.Setup(x => x.ParseCommand(new string[] { "REPORT" })).Returns(Command.Report);
            simulator.ProcessCommand(new string[] { "REPORT" });

            // assert
            Assert.AreEqual("Output: 3,1,SOUTH", simulator.GetReport());
        }
    }
}