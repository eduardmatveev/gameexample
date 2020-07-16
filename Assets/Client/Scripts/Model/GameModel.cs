using System;
using Command;

namespace Model
{
    public class GameModel
    {
        public readonly GameNetworkBase Network;
        public readonly UserModel User = new UserModel();
        private long _nextUpdateTime = DateTime.UtcNow.Ticks;

        public GameModel(GameNetworkBase network)
        {
            Network = network;
            Network.EventReceiveCommand += OnReceiveCommand;
        }

        public void Update()
        {
            const long ticksPerSecond = 1;
            const long timePerTicks = 10000000 / ticksPerSecond;
            var currentTime = DateTime.UtcNow.Ticks;
            while (currentTime >= _nextUpdateTime)
            {
                User.Simulate();
                
                _nextUpdateTime += timePerTicks;
                currentTime = DateTime.UtcNow.Ticks;
            }
        }
        
        public void Destroy()
        {
            Network.EventReceiveCommand -= OnReceiveCommand;
        }

        private void OnReceiveCommand(CommandBase command)
        {
            command.Accept(User);
        }
    }
}