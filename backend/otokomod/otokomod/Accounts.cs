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
        public string _firstName;
        public string _lastName;
        public long _cash;
        public Player _player;

        public Accounts()
        {
            this._firstName = "";
            this._lastName = "";
            this._cash = 1000;
        }

        public Accounts(string firstName, string lastName, Player player, long cash = 1000)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._player = player;
            this._cash = cash;
        }

        public static bool IsPlayerLoggedIn(Player player)
        {
            if (player != null) return player.HasData(_accountKey);
            return false;
        }

        public void Register(string firstName, string lastName, string email, string password)
        {
            DB.NewAccountRegister(this, firstName, lastName, email, password);
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
