namespace ToyRobotTests;

[TestClass]
public class InputProcessorTests
{
    private InputProcessor _inputProcessor;

    [TestInitialize]
    public void Setup()
    {
        _inputProcessor = new InputProcessor();
    }

    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void Process_InputIsEmpty_ReturnsInvalid(string input)
    {
        var actual = _inputProcessor.Process(input);

        Assert.IsFalse(actual.IsValid);
    }

    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void Process_InputIsEmpty_ReturnsValidationMessage(string input)
    {
        var actual = _inputProcessor.Process(input);

        Assert.AreEqual(actual.ValidationMessage, "Please provide input");
    }

    [TestMethod]
    public void Process_UnknownCommand_ReturnsInvalid()
    {
        var actual = _inputProcessor.Process("not a command");

        Assert.IsFalse(actual.IsValid);
    }

    [TestMethod]
    public void Process_UnknownCommand_ReturnsValidationMessage()
    {
        var actual = _inputProcessor.Process("not a command");

        Assert.AreEqual(actual.ValidationMessage, "Unknown command. Acceptable commands are 'PLACE X,Y,F', 'MOVE', 'LEFT', 'RIGHT', 'REPORT'.");
    }

    [TestMethod]
    [DataRow("place somewhere")]
    [DataRow("place a,b,c")]
    [DataRow("place 1,b,north")]
    [DataRow("place b,0,north")]
    [DataRow("place 1,2,northwest")]
    [DataRow("place 1, 2, north")]
    public void Process_PlaceCommand_InvalidFormat_ReturnsInvalid(string input)
    {
        var actual = _inputProcessor.Process(input);

        Assert.IsFalse(actual.IsValid);
    }

    [TestMethod]
    [DataRow("place somewhere")]
    [DataRow("place a,b,c")]
    [DataRow("place 1,b,north")]
    [DataRow("place b,0,north")]
    [DataRow("place 1,2,northwest")]
    [DataRow("place 1, 2, north")]
    public void Process_PlaceCommand_InvalidFormat_ReturnsValidationMessage(string input)
    {
        var actual = _inputProcessor.Process(input);

        Assert.AreEqual(actual.ValidationMessage, "Invalid command format");
    }

    [TestMethod]
    [DataRow("place 1,1,north")]
    [DataRow("left")]
    [DataRow("right")]
    [DataRow("move")]
    [DataRow("report")]
    public void Process_ValidFormat_ReturnsValid(string input)
    {
        var actual = _inputProcessor.Process(input);

        Assert.IsTrue(actual.IsValid);
    }

    [TestMethod]
    [DataRow("place 1,1,north")]
    [DataRow("left")]
    [DataRow("right")]
    [DataRow("move")]
    [DataRow("report")]
    public void Process_ValidFormat_ReturnsExpectedCommand(string input)
    {
        Enum.TryParse<Command>(input, ignoreCase: true, out var expectedEnum);

        var actual = _inputProcessor.Process(input);

        Assert.AreEqual(actual.Command, expectedEnum);
    }

    [TestMethod]
    public void Process_Place_ValidFormat_ReturnsExpectedPosition()
    {
        var expectedCoordinates = 1;

        var actual = _inputProcessor.Process($"place 1,1,north");

        Assert.AreEqual(actual.Position.X, expectedCoordinates);
        Assert.AreEqual(actual.Position.Y, expectedCoordinates);
    }

    [TestMethod]
    public void Process_Place_ValidFormat_ReturnsExpectedDirection()
    {
        var expectedDirection = Direction.NORTH;

        var actual = _inputProcessor.Process($"place 1,1,north");

        Assert.AreEqual(actual.Direction, expectedDirection);
    }

}