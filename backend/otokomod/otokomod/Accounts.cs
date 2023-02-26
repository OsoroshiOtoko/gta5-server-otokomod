using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace otokomod
{
    class Accounts
    {
        private const string _accountKey = "Player_Data";
        public int _id;
        public string _name;
        public long _cash;
        public Player _player;

        public Accounts()
        {
            this._name = "";
            this._cash = 1000;
        }

        public Accounts(string name, Player player, long cash = 1000)
        {
            this._name = name;
            this._player = player;
            this._cash = cash;
        }

        public static bool IsPlayerLoggedIn(Player player)
        {
            if (player != null) return player.HasData(_accountKey);
            return false;
        }

        public void Register(string name, string password)
        {
            DB.NewAccountRegister(this, password);
            Login(_player, true);
        }
          
        public void Login(Player player, bool isFirstLogin) 
        {
            DB.LoadAccount(this);

            if(isFirstLogin) 
            {
                player.SendChatMessage("You have successfully registered!");
            }

            player.SendChatMessage("You are successfully authorized!");

            player.SetData(Accounts._accountKey, this);
        }
    }
}
