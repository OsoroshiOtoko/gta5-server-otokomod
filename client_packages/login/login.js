let authWindow;

authWindow = mp.browsers.new("package://web/login/index.html");
    setTimeout(() =>
{
    mp.gui.cursor.show(true, true);
    mp.game.ui.displayHud(false);
    mp.gui.chat.show(false);
    mp.game.ui.displayRadar(false);
}, 150);

/*mp.events.add('showAuthWindow', () =>
{
    authWindow = mp.browsers.new("package://web/login/index.html");
    setTimeout(() =>
{
    mp.gui.cursor.show(true, true);
    mp.game.ui.displayHud(false);
    mp.gui.chat.show(false);
    mp.game.ui.displayRadar(false);
}, 150);
}); */

mp.events.add('closeAuthWindow', () =>
{
    mp.gui.cursor.show(false, false);
    mp.game.ui.displayHud(true);
    mp.gui.chat.show(true);
    mp.game.ui.displayRadar(true);

    if(authWindow)
    {
        authWindow.destroy();
        authWindow = null;
    }
});

mp.events.add("authRegister", (firstName, lastName, email, password) =>
{
    mp.events.callRemote('authOnRegister', firstName, lastName, email, password);
});


mp.events.add('showTextError', (text) =>
{
    authWindow.execute(`sendError("${text})`);
});