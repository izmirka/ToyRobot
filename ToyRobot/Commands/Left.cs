public class Left : ICommand
{
    public void Execute()
    {
        if (RobotState.Direction == null)
        {
            throw new InvalidOperationException("Robot direction is null");
        }

        RobotState.Direction = RobotState.Direction + 1 > Direction.EAST ? Direction.NORTH : RobotState.Direction + 1;
    }
}