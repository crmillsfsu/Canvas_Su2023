using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.CLI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Student()
        {
            Name = string.Empty;
        }

        public override string ToString()
        {
            return $"{Id}. {Name}";
        }
    }

    public enum Classifications
    {
        None
        , Freshman
        , Sophomore
        , Junior
        , Senior
        , NonDegree
    }
}
