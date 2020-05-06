using System.Windows;
using System.Windows.Controls;
using WPFNotes.Models;

namespace WPFNotes.Controls
{
    /// <summary>
    /// Interaction logic for Notebook.xaml
    /// </summary>
    public partial class NotebookControl : UserControl
    {
        public Notebook DisplayNotebook
        {
            get { return (Notebook)GetValue(notebookProperty); }
            set { SetValue(notebookProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty notebookProperty =
            DependencyProperty.Register("DisplayNotebook", typeof(Notebook), typeof(NotebookControl), new PropertyMetadata(null, SetValues));

        private static void SetValues(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NotebookControl notebook = d as NotebookControl;

            if (notebook != null)
            {
                notebook.notebookNameTextBlock.Text = (e.NewValue as Notebook).Name;
            }
        }

        public NotebookControl()
        {
            InitializeComponent();
        }
    }
}