public class Controller
{
    private readonly CommandFactory _commandFactory;

    public Controller()
    {
        _commandFactory = new();
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