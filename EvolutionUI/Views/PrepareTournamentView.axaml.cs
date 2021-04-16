using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace EvolutionUI.Views
{
    public class PrepareTournamentView : UserControl
    {
        public PrepareTournamentView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
