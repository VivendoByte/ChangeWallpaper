using ChangeWallpaper.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace ChangeWallpaper
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (System.Environment.UserName == "igord")
            {
                this.txtImagePath.Text = @"Z:\MyData\Immagini\File di Flight Simulator X\2020-8-31_15-44-42-785.jpg";
            }
        }

        private void btnChangeWallpaper_Click(object sender, RoutedEventArgs e)
        {
            string image = this.txtImagePath.Text;

            if (string.IsNullOrEmpty(image) == false && File.Exists(image))
            {
                Type pluginInterfaceType = typeof(IPlugin);
                var ass = Assembly.Load("ChangeWallpaper.Plugin");
                var types = ass.GetTypes().Where(t => pluginInterfaceType.IsAssignableFrom(t) && t.IsClass).ToList();

                if (types != null && types.Count > 0)
                {
                    IPlugin plugin = Activator.CreateInstance(types[0]) as IPlugin;
                    plugin.Execute(image);
                }
            }
        }
    }
}