using Canvas.CLI.Models;
using Canvas.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.MAUI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Student> Students { 
            get
            {
                if(string.IsNullOrEmpty(Query))
                {
                    return new ObservableCollection<Student>(StudentService.Current.Enrollments);
                }
                return new ObservableCollection<Student>(StudentService.Current.Search(Query));
            }
        }

        public string Query { get; set; }

        public void Search() {
            NotifyPropertyChanged("Students");
        }

        public void Delete()
        {
            if(SelectedStudent == null)
            {
                return;
            }
            StudentService.Current.Delete(SelectedStudent);
            NotifyPropertyChanged("Students");
        }

        public Student SelectedStudent { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
