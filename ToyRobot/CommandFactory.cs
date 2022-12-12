public class CommandFactory
{
    public ICommand CreateCommand(ProcessedInput input)
    {
        switch (input.Command)
        {
            case Command.PLACE:
                return new Place(input.Position!, (Direction)input.Direction!);
            case Command.MOVE:
                return new Move();
            case Command.LEFT:
                return new Left();
            case Command.RIGHT:
                return new Right();
            case Command.REPORT:
                return new Report();
            default:
                throw new InvalidOperationException("Unknown command");
        }
    }
}