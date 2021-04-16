using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace EvolutionUI.Views
{
    public class StartView : UserControl
    {
        public StartView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
