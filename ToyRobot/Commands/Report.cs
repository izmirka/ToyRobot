public class Report : ICommand
{
    public void Execute()
    {
        if (RobotState.Position == null)
        {
            throw new InvalidOperationException("Robot position is null");
        }
        if (RobotState.Direction == null)
        {
            throw new InvalidOperationException("Robot direction is null");
        }

        Console.WriteLine($"{RobotState.Position.X.ToString()},{RobotState.Position.Y.ToString()},{RobotState.Direction.ToString()}");
    }
}