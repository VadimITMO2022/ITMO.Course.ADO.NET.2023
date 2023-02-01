using System.Linq;

namespace Linq_Student
{
    public class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public List<int> Scores;

        static List<Student> students = new List<Student>
       {
       new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
       new Student {First="Claire", Last="O’Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
       new Student {First="John", Last="Smith", ID=113, Scores= new List<int> {92, 63, 71, 89}},
       new Student {First="Tom", Last="Ford", ID=114, Scores= new List<int> {96, 83, 81, 62}}
       };
    
      
            static void Main()
            {

                IEnumerable<Student> studentQuery = from student in students
                                                    where student.Scores[0] > 90
                                                    select student;
                foreach (Student student in studentQuery)
                {
                    Console.WriteLine("{0}, {1}", student.Last, student.First);
                }
            }

    }

    
}



   