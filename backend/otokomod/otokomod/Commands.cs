using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace otokomod
{
    internal class Commands : Script
    {
        [Command("veh", "/Spawn auto", Alias = "vechicle")]
        private void cmd_veh(Player player, string vehname, int color1, int color2) 
        {
            uint vhash = NAPI.Util.GetHashKey(vehname);
            if(vhash <= 0 ) 
            {
                player.SendChatMessage("~r~non-existent model");
            }
            Vehicle veh = NAPI.Vehicle.CreateVehicle(vhash, player.Position, player.Heading, color1, color2);
            player.SetIntoVehicle(veh, (int)VehicleSeat.Driver);
        }
    }
}
