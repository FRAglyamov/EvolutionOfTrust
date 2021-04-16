using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AvaloniaUI
{
    public class MainWindow : Window
    {
        private Button hellloButton;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            hellloButton = this.FindControl<Button>("HelloButton");
        }

        public void Hello_Click(object sender, RoutedEventArgs e)
        {
            if (hellloButton.Opacity < 100)
            {
                hellloButton.Opacity = 100;
            } else
            {
                hellloButton.Opacity = 0;
            }
        }
    }
}
