﻿using System.Linq;

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
       new Student {First="Tom", Last="Ford", ID=114, Scores= new List<int> {96, 83, 81, 62}},
       new Student {First="Marina", Last="Ivanova", ID=115, Scores= new List<int> {93, 64, 91, 79}},
       new Student {First="Peter", Last="Monson", ID=116, Scores= new List<int> {98, 93, 51, 82}},
       new Student {First="Donald", Last="Hamperson", ID=117, Scores= new List<int> {73, 44, 91, 94}}
       };


        static void Main()
        {

            var studentQuery3 =from student in students group student by student.Last[0];

            foreach (var groupOfStudents in studentQuery3)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    Console.WriteLine("   {0}, {1}",
                        student.Last, student.First);
                }
            }

        
        }


    }

}

    




   