using Canvas.CLI.Models;
using Canvas.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.MAUI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public List<Student> Students { 
            get
            {
                return StudentService.Current.Enrollments;
            }
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
