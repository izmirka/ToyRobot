public class Move : ICommand
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

        var newPosition = new Position(-1, -1);

        switch (RobotState.Direction)
        {
            case Direction.EAST:
                newPosition = new(RobotState.Position.X + 1, RobotState.Position.Y);
                break;
            case Direction.WEST:
                newPosition = new(RobotState.Position.X - 1, RobotState.Position.Y);
                break;
            case Direction.NORTH:
                newPosition = new(RobotState.Position.X, RobotState.Position.Y + 1);
                break;
            case Direction.SOUTH:
                newPosition = new(RobotState.Position.X, RobotState.Position.Y - 1);
                break;
        }

        UpdatePosition(newPosition);
    }

    private void UpdatePosition(Position newPosition)
    {
        if (newPosition.IsValid())
        {
            RobotState.Position = newPosition;
        }
        else
        {
            Console.WriteLine("Invalid movement");
        }
    }
}