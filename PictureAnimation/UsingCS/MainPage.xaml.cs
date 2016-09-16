using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UsingCS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Storyboard m_storyBoard = null;
        
        List<Uri> list = new List<Uri>();
        public MainPage()
        {
            
            
            this.InitializeComponent();
            //初始化

           
            for (int i = 1; i < 9; i++)
            {
                Uri uri= new Uri(string.Format("ms-appx:///Resources/teemo_{0}.png", i));
                list.Add(uri);
            }

           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Initiaz();
            m_storyBoard.Begin();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Task.Delay(1000).Wait();
        }


        public  void Initiaz()
        {
           
        }
    }
}
