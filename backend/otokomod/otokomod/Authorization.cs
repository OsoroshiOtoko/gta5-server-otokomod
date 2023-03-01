using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GTANetworkAPI;

namespace otokomod
{
    internal class Authorization : Script
    {
        [RemoteEvent("authOnRegister")]
        private void OnRegister(Player player, string firstName, string lastName, string email, string password)
        {
            if(DB.IsAccountExist(player.Name))
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "showTextError", "An account with this nickname already exists.");
                return;
            }

            Accounts account = new Accounts(firstName, lastName, player);
            account.Register(firstName, lastName, email, password);
            NAPI.ClientEvent.TriggerClientEvent(player, "closeAuthWindow");
            NAPI.ClientEvent.TriggerClientEvent(player, "PlayerFreeze", false);

        }
    }
}
