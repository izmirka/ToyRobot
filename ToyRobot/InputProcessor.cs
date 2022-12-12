public class InputProcessor
{
    private char[] _separators = { ' ', ',' };

    public ProcessedInput Process(string? input)
    {
        var result = new ProcessedInput();

        if (string.IsNullOrWhiteSpace(input))
        {
            result.ValidationMessage = "Please provide input";
            return result;
        }

        var splitInputs = input.ToUpper().Split(_separators);

        if (!Enum.TryParse<Command>(splitInputs[0], ignoreCase: true, out var command))
        {
            result.ValidationMessage = "Unknown command. Acceptable commands are 'PLACE X,Y,F', 'MOVE', 'LEFT', 'RIGHT', 'REPORT'.";
            return result;
        }

        if (command == Command.PLACE)
        {
            if (splitInputs.Length != 4
                || !int.TryParse(splitInputs[1], out var x)
                || !int.TryParse(splitInputs[2], out var y)
                || !Enum.TryParse<Direction>(splitInputs[3], ignoreCase: true, out var direction))
            {
                result.ValidationMessage = "Invalid command format";
                return result;
            }
            else
            {
                result.Direction = direction;
                result.Position = new Position(x, y);
            }
        }

        result.Command = command;
        result.IsValid = true;
        return result;
    }
}