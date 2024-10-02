using System;
using System.Linq;
using System.Text.RegularExpressions;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Vgr2DesktopPoczta;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CheckPrice(object? sender, RoutedEventArgs e)
    {
        var path = "avares://Vgr2DesktopPoczta/Images/";
        if (PostCardRadio.IsChecked == true)
        {
            PriceTextBlock.Text = "Cena: 1zł";
            using var stream = AssetLoader.Open(new Uri(path + "postcard.png"));
            ImageFN.Source = new Bitmap(stream);
        }
        else if (LetterRadio.IsChecked == true)
        {
            PriceTextBlock.Text = "Cena: 1.5zł";
            using var stream = AssetLoader.Open(new Uri(path + "letter.png"));
            ImageFN.Source = new Bitmap(stream);
        }
        else if (PackRadio.IsChecked == true)
        {
            PriceTextBlock.Text = "Cena: 10zł";
            using var stream = AssetLoader.Open(new Uri(path + "package.png"));
            ImageFN.Source = new Bitmap(stream);
        }
    }

    private void ShowPopupInfo(string message)
    {
        var window = new InfoPopUp();
        window.InfoTextBlock.Text = message;
        window.ShowDialog(this);
    }
    
    private void OnConfirm(object? sender, RoutedEventArgs e)
    {
        if (ZipTextBox.Text?.Length != 5)
        {
            ShowPopupInfo("ZŁA DŁUGOŚĆ KODU POCZTOWEGO!");
            return;
        }
        
        string zipCode =  new string(ZipTextBox?.Text?.Where(c => char.IsDigit(c)).ToArray());
        
        if (zipCode.Length != 5)
            ShowPopupInfo("WPROWADŹ POPRAWNY KOD POCZTOWY");
    }
}