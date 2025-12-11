using System.Windows.Controls;
using FluxorWpfApp.Store.MyLab;

namespace FluxorWpfApp.Views
{
    public partial class MyLabView : UserControl
    {
        public MyLabView(MyLabViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
