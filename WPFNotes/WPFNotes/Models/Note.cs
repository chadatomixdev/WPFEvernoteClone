using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFNotes.Models
{
    public class Note : INotifyPropertyChanged
    {
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnProperyChanged("Id");
            }
        }

        private int notebookId;

        public int NotebookId
        {
            get { return notebookId; }
            set
            {
                notebookId = value;
                OnProperyChanged("NotebookId");
            }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnProperyChanged("Title");
            }
        }

        private DateTime createdTime;

        public DateTime CreatedTime
        {
            get { return createdTime; }
            set
            {
                createdTime = value;
                OnProperyChanged("CreatedTime");
            }
        }

        private DateTime updatedTime;

        public DateTime UpdatedTime
        {
            get { return createdTime; }
            set
            {
                createdTime = value;
                OnProperyChanged("UpdatedTime");
            }
        }

        private string filelocation;

        public string FileLocation
        {
            get { return filelocation; }
            set
            {
                filelocation = value;
                OnProperyChanged("FileLocation");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnProperyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}