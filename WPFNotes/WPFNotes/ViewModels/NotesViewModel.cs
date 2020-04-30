using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFNotes.Commands;
using WPFNotes.Models;

namespace WPFNotes.ViewModels
{
    public class NotesViewModel
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }

		private Notebook selectedNotebook;

		public Notebook SelectedNotebook
		{
			get { return selectedNotebook; }
			set { 
				selectedNotebook = value; 
				//TODO: Get Notes
			}
		}
		public	ObservableCollection<Note> Notes { get; set; }
		public  NewNotebookCommand NewNotebookCommand { get; set; }

		public NewNoteCommand NewNoteCommand { get; set; }

		public NotesViewModel()
		{
			NewNotebookCommand = new NewNotebookCommand(this);
			NewNoteCommand = new NewNoteCommand(this);
		}
	}
}