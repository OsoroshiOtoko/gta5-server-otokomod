using System;
using RAGE;

namespace ClientSide
{
    internal class Freeze : Events.Script
    {
        public Freeze()
        {
            Events.Add("PlayerFreeze", PlayerFreeze);
        }

        private void PlayerFreeze(object[] args)
        {
            RAGE.Elements.Player.LocalPlayer.FreezePosition((bool)args[0]);
        }
    }
}
