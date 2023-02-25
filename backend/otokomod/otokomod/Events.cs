using System;
using GTANetworkAPI;

namespace otokomod
{
    class Events : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStarted()
        {
            DB.InitConnection();
        }

        [ServerEvent(Event.PlayerConnected)]
        private void OnPlayerConnected(Player player)
        {
            player.SendChatMessage("Hello " + player.Name);
            if (DB.IsAccountExist(player.Name))
            {
                player.SendChatMessage("You are already registered. Use /login");
            }
            else
            {
                player.SendChatMessage("Use the command to register /register");
            }
        }

        [ServerEvent(Event.PlayerSpawn)]
        private void OnPlayerSpawn(Player player)
        {
            player.Health = 50;
            player.Armor = 50;
        }

    }
}
