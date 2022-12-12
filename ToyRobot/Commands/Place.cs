public class Place : ICommand
{
    private readonly Position _position;
    private readonly Direction _direction;
    public Place(Position position, Direction direction)
    {
        _position = position;
        _direction = direction;
    }
    public void Execute()
    {
        if (!_position.IsValid())
        {
            Console.WriteLine($"Incorrect position.");
            return;
        }

        RobotState.Position = _position;
        RobotState.Direction = _direction;
    }
}