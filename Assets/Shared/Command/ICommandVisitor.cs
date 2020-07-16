namespace Command
{
    public interface ICommandVisitor
    {
        void Visit(CommandUpdateResource cmd);
        void Visit(CommandUpdateResources cmd);
    }
}