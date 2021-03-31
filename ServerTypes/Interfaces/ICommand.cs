namespace ServerTypes
{
    public interface ICommand
    {
        object Content { get; set; }

        ICommandResult Execute();
    }
}
