InputProcessor processor = new();
Controller controller = new();

while (true)
{
    var input = Console.ReadLine();

    //process input
    var processedInput = processor.Process(input);
    if (!processedInput.IsValid)
    {
        Console.WriteLine(processedInput.ValidationMessage);
        continue;
    }

    //execute command
    controller.HandleCommand(processedInput);
}