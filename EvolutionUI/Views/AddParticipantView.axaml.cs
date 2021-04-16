using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace EvolutionUI.Views
{
    public class AddParticipantView : UserControl
    {
        public AddParticipantView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
