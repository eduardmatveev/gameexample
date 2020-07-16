using Data;

namespace Command
{
    public class CommandUpdateResource : CommandBase
    {
        public ResourceData Data;
        public uint Amount;
        
        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}