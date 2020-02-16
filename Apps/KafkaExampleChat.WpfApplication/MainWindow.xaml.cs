using System.Windows;

namespace KafkaExampleChat.WpfApplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnEnviar_Click(object sender, RoutedEventArgs e)
        {
            LblStatus.Text = "Enviando...";
        }
    }
}