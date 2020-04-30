using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFNotes.ViewModels;

namespace WPFNotes.Commands
{
    public class NewNoteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public NotesViewModel NotesViewModel { get; set; }

        public NewNoteCommand(NotesViewModel notesViewModel)
        {
            NotesViewModel = notesViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
        }
    }
}