public class ProcessedInput
{
    public Command Command { get; set; }
    public Position? Position { get; set; }
    public Direction? Direction { get; set; }
    public bool IsValid { get; set; }
    public string? ValidationMessage { get; set; }
}