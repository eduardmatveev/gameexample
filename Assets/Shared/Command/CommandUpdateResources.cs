using Data;

namespace Command
{
    public class CommandUpdateResources : CommandBase
    {
        public DataRefDictionary<ResourceData, uint> Resources;
        
        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}