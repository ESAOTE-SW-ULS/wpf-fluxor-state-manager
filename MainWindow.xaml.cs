using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FluxorWpfApp.Views;
using Microsoft.Extensions.DependencyInjection;

namespace FluxorWpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        // Load MyLab page by default
        LoadMyLabPage();
    }

    private void MyLabButton_Click(object sender, RoutedEventArgs e)
    {
        LoadMyLabPage();
    }

    private void CounterButton_Click(object sender, RoutedEventArgs e)
    {
        LoadCounterPage();
    }

    private void ImageButton_Click(object sender, RoutedEventArgs e)
    {
        LoadImagePage();
    }

    private void EventsButton_Click(object sender, RoutedEventArgs e)
    {
        LoadEventsPage();
    }

    private void LoadMyLabPage()
    {
        ContentArea.Children.Clear();
        var myLabView = App.Services?.GetRequiredService<Views.MyLabView>();
        if (myLabView != null)
        {
            ContentArea.Children.Add(myLabView);
        }
    }

    private void LoadCounterPage()
    {
        ContentArea.Children.Clear();
        var counterView = App.Services?.GetRequiredService<Views.CounterView>();
        if (counterView != null)
        {
            ContentArea.Children.Add(counterView);
        }
    }

    private void LoadImagePage()
    {
        ContentArea.Children.Clear();
        var imageView = App.Services?.GetRequiredService<Views.ImageView>();
        if (imageView != null)
        {
            ContentArea.Children.Add(imageView);
        }
    }

    private void LoadEventsPage()
    {
        ContentArea.Children.Clear();
        var eventsView = App.Services?.GetRequiredService<Views.EventsView>();
        if (eventsView != null)
        {
            ContentArea.Children.Add(eventsView);
        }
    }
}