namespace Command
{
    public abstract class CommandBase
    {
        public abstract void Accept(ICommandVisitor visitor);
    }
}