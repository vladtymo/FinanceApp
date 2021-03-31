namespace ServerTypes
{
    public interface ICommand
    {
        CommandResult Execute(object parameters);
    }
}
