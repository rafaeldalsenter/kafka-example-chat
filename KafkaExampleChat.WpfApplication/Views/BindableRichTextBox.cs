using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace KafkaExampleChat.WpfApplication.Views
{
    public sealed class BindableRichTextBox : RichTextBox
    {
        public static readonly DependencyProperty DocumentProperty =
            DependencyProperty.Register("Document", typeof(FlowDocument), typeof(BindableRichTextBox),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnDocumentChanged)));

        public new FlowDocument Document
        {
            get => this.GetValue(DocumentProperty) as FlowDocument;
            set => this.SetValue(DocumentProperty, value);
        }

        public static void OnDocumentChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var rtb = obj as RichTextBox;
            rtb.Document = args.NewValue as FlowDocument;
        }
    }
}