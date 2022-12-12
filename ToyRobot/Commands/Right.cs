public class Right : ICommand
{
    public void Execute()
    {
        if (RobotState.Direction == null)
        {
            throw new InvalidOperationException("Robot direction is null");
        }

        RobotState.Direction = RobotState.Direction - 1 < Direction.NORTH ? Direction.EAST : RobotState.Direction - 1;
    }
}