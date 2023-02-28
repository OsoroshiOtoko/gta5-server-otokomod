using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using RAGE.Ui;

namespace ClientSide
{
    public class RegistrationMenu : Events.Script
    {
        private HtmlWindow registrationWindow;

        public RegistrationMenu()
        {
            // Підписуємось на подію "playerConnected", яка викликається при підключенні гравця до сервера
            Events.Add("playerConnected", ShowRegistrationMenu);
        }

        private void ShowRegistrationMenu(object[] args)
        {
            // Створюємо вікно реєстрації
            registrationWindow = new HtmlWindow("registration.html");
        }

        private void OnRegistrationWindowClosed(object sender, System.EventArgs e)
        {
            // Закриваємо вікно реєстрації
            registrationWindow.Destroy();
        }
    }
}
