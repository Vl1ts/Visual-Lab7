using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Lab7.Views
{
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("CloseBtn").Click += delegate
            {
                Close();
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
