using System;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace App2
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {

            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Globalization.DateTimeFormatting.DateTimeFormatter formatter =
                new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("longtime");

            StorageFile sampleFile = await localFolder.CreateFileAsync("dataFile.txt",
                CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, formatter.Format(DateTime.Now));
        }

        private async void test()
        {
            Uri filePath = new Uri("ms-appx:///問題/問題1.txt");
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(filePath);
            string readText = await FileIO.ReadTextAsync(file);
            textBox.Text = readText;
        }
    }
}
