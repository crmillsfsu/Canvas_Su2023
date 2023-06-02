using Canvas.CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.Library.Services
{
    public class StudentService
    {
        private static StudentService? instance;
        private static object _lock = new object();
        public static StudentService Current {
            get
            {
                lock(_lock)
                {
                    if (instance == null)
                    {
                        instance = new StudentService();
                    }
                }

                return instance;
            }
        }

        private List<Student> enrollments;
        private StudentService()
        {
            enrollments = new List<Student>
            {
                new Student{Id = 1, Name = "John Smith"},
                new Student{Id = 2, Name = "Bob Smith"},
                new Student{Id = 3, Name = "Sue Smith"}
            };
        }

        public List<Student> Enrollments
        {
            get { return enrollments; }
        }

        public Student? Get(int id)
        {
            return enrollments.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Student? student)
        {
            if (student != null) {
                enrollments.Add(student);
            }
        }

        public void Delete(int id)
        {
            var enrollmentToRemove = Get(id);
            if (enrollmentToRemove != null)
            {
                enrollments.Remove(enrollmentToRemove);
            }
        }

        public void Delete(Student s)
        {
            Delete(s.Id);
        }

        public void Read()
        {
            enrollments.ForEach(Console.WriteLine);
        }
    }
}
