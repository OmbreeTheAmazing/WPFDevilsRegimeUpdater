using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WMPLib;
using Squirrel;

namespace DevilsRegimeUpdater3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UpdateManager manager;
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                InitializeMediaPlayer();

                Loaded += MainWindow_Loaded;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void checkForUpdates()
        {
            try
            {
                var updateInfo = await manager.CheckForUpdate();

                if (updateInfo.ReleasesToApply.Count > 0)
                {
                    await manager.UpdateApp();

                    MessageBox.Show("Updated Successfully");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                manager = await UpdateManager
    .GitHubUpdateManager(@"https://github.com/OmbreeTheAmazing/WPFDevilsRegimeUpdater");

                version.Content = manager.CurrentlyInstalledVersion().ToString();

                checkForUpdates();
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString()); }

        }

        private void InitializeMediaPlayer()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string musicFilePath = System.IO.Path.Combine(currentDirectory, "Sony Vegas 9.x Keygen Music by Kenet & Rez (Digital Insanity).mp3");

            MediaPlayer.Source = new Uri(musicFilePath);  
            MediaPlayer.Volume = 1.0;  
            MediaPlayer.MediaEnded += MediaPlayer_MediaEnded;  
            MediaPlayer.Play();  
        }

        private void MediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Position = TimeSpan.Zero;  
            MediaPlayer.Play();  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Stop();
        }
    }
}
