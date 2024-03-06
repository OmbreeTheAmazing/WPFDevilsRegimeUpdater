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

namespace DevilsRegimeUpdater3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeMediaPlayer();
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
