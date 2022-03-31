using Avalonia.Controls;
using Lab7.ViewModels;
using Avalonia.Interactivity;

namespace Lab7.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.FindControl<MenuItem>("MenuAboutBtn").Click += async delegate
            {
                var aboutWindow = new AboutWindow();
                await aboutWindow.ShowDialog((Window)this.VisualRoot);
            };
            this.FindControl<MenuItem>("MenuExitBtn").Click += delegate
            {
                this.Close();
            };
            this.FindControl<MenuItem>("MenuLoadBtn").Click += async delegate
            {
                var filePath = new OpenFileDialog()
                {
                    Title = "Open file"
                }.ShowAsync((Window)this.VisualRoot);

                string[]? path = await filePath;

                var context = this.DataContext as MainWindowViewModel;
                if (path != null)
                {
                    context.OpenFile(string.Join(@"\", path));
                }
            };

            this.FindControl<MenuItem>("MenuSaveBtn").Click += async delegate
            {
                var filePath = new SaveFileDialog()
                {
                    Title = "Save file"
                }.ShowAsync((Window)this.VisualRoot);

                string? path = await filePath;

                var context = this.DataContext as MainWindowViewModel;
                if (path != null)
                {
                    context.SaveFile(path);
                }
            };
        }
    }
}
