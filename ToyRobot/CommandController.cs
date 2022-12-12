public class CommandController
{
    private readonly ICommandFactory _commandFactory;

    public CommandController(ICommandFactory factory)
    {
        ArgumentNullException.ThrowIfNull(factory);
        _commandFactory = factory;
    }

    public void HandleCommand(ProcessedInput input)
    {
        var command = _commandFactory.CreateCommand(input);

        if (!RobotState.IsPlaced && command.GetType() != typeof(Place))
        {
            Console.WriteLine("Please place the robot on the table before executing other commands.");
            return;
        }

        command.Execute();
    }
}