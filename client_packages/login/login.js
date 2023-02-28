let loginWindow = mp.browsers.new("package://web/login/index.html");

setTimeout(() =>
{
    mp.gui.cursor.show(true, true);
    mp.game.ui.displayHud(false);
    mp.gui.chat.show(false);
    mp.game.ui.displayRadar(false);
}, 150);

mp.events.add("authRegister", (firstName, lastName, email, password) =>
{
    mp.events.callRemote('authOnRegister', firstName, lastName, email, password);
});