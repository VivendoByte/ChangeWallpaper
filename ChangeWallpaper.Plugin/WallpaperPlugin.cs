using ChangeWallpaper.Interfaces;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ChangeWallpaper.Plugin
{
    public class Plugin : IPlugin
    {
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 1;
        const int SPIF_SENDCHANGE = 2;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public void Execute(string parameter)
        {
            // bool isUwp = new DesktopBridge.Helpers().IsRunningAsUwp();

            if (File.Exists(parameter))
            {
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, parameter, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            }
        }
    }
}