using SQLite;
using System;
using System.Collections.ObjectModel;
using WPFNotes.Commands;
using WPFNotes.Helpers;
using WPFNotes.Models;

namespace WPFNotes.ViewModels
{
    public class NotesViewModel
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }

        public bool isEditing { get; set; }

        private Notebook selectedNotebook;

        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set
            {
                selectedNotebook = value;
                ReadNotes();
            }
        }

        public ObservableCollection<Note> Notes { get; set; }
        public NewNotebookCommand NewNotebookCommand { get; set; }

        public NewNoteCommand NewNoteCommand { get; set; }

        public NotesViewModel()
        {
            isEditing = false;
            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);

            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();

            ReadNotebooks();
            ReadNotes();
        }

        public void CreateNotebook()
        {
            Notebook newNotebook = new Notebook
            {
                Name = "New Notebook",
                UserId = int.Parse(App.UserId)
                
            };

            DatabaseHelper.Insert(newNotebook);

            ReadNotebooks();
        }

        public void CreateNote(int notebookId)
        {
            Note newNote = new Note
            {
                NotebookId = notebookId,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                Title = "New Note"
            };

            DatabaseHelper.Insert(newNote);
            ReadNotes();
        }

        public void ReadNotebooks()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseHelper.dbFile))
            {
                var notebooks = connection.Table<Notebook>().ToList();

                Notebooks.Clear();

                foreach (var notebook in notebooks)
                {
                    Notebooks.Add(notebook);
                }
            }
        }

        public void ReadNotes()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseHelper.dbFile))
            {
                if (SelectedNotebook != null)
                {
                    var notes = connection.Table<Note>().Where(n => n.NotebookId == selectedNotebook.Id).ToList();
                    Notes.Clear();

                    foreach (var note in notes)
                    {
                        Notes.Add(note);
                    }
                }
            }
        }
    }
}