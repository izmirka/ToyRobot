InputProcessor processor = new();
CommandFactory factory = new();
CommandController controller = new(factory);

while (true)
{
    var input = Console.ReadLine();

    var processedInput = processor.Process(input);
    if (!processedInput.IsValid)
    {
        Console.WriteLine(processedInput.ValidationMessage);
        continue;
    }

    controller.HandleCommand(processedInput);
}