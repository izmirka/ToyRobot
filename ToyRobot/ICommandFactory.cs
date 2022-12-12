public interface ICommandFactory
{
    ICommand CreateCommand(ProcessedInput input);
}