using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace EvolutionUI.Views
{
    public class PointSystemView : UserControl
    {
        public PointSystemView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
