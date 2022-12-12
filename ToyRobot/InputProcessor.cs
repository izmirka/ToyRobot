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

        result.Command = command;

        if (command == Command.PLACE)
        {
            return ValidatePlaceCommand(splitInputs, result);
        }

        result.IsValid = true;
        return result;
    }

    private ProcessedInput ValidatePlaceCommand(string[] input, ProcessedInput result)
    {
        if (input.Length != 4
                || !int.TryParse(input[1], out var x)
                || !int.TryParse(input[2], out var y)
                || !Enum.TryParse<Direction>(input[3], ignoreCase: true, out var direction))
        {
            result.ValidationMessage = "Invalid command format";
        }
        else
        {
            result.Direction = direction;
            result.Position = new Position(x, y);
            result.IsValid = true;
        }
        return result;
    }
}