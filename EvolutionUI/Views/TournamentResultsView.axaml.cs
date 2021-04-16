using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace EvolutionUI.Views
{
    public class TournamentResultsView : UserControl
    {
        public TournamentResultsView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
