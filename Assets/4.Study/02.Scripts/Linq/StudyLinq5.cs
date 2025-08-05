using UnityEngine;
using System.Linq;
using System.Collections.Generic;
public class StudyLinq5 : MonoBehaviour
{
    #region Data Class
    [System.Serializable]
    public class Student
    {
        public int studentID;
        public string studentName;

        public Student(int studentID, string studentName)
        {
            this.studentID = studentID;
            this.studentName = studentName;
        }
    }

    [System.Serializable]
    public class Grade
    {
        public int studentID;
        public int score;
        public string subject;

        public Grade(int studentID, int score, string subject)
        {
            this.studentID = studentID;
            this.score = score;
            this.subject = subject;
        }
    }
    #endregion

    public List<Student> students = new List<Student>();
    public List<Grade> grades = new List<Grade>();

    private void Start()
    {
        #region  Add Data
        students.Add(new Student(1, "Alice"));
        students.Add(new Student(2, "Bob"));
        students.Add(new Student(3, "Charlie"));
        students.Add(new Student(4, "Eve"));
        students.Add(new Student(5, "Frank"));

        grades.Add(new Grade(1, 90, "Math"));
        grades.Add(new Grade(2, 85, "Science"));
        grades.Add(new Grade(3, 92, "English"));
        grades.Add(new Grade(4, 76, "Math"));
        grades.Add(new Grade(6, 90, "History"));
        #endregion

        OuterJoin();
    }
    void OuterJoin()
    {
        var leftOuterJoin = from student in students
                            join grade in grades on student.studentID equals grade.studentID into studentGrades
                            from grade in grades.DefaultIfEmpty()
                            select new
                            {
                                StudentID = student.studentID,
                                StudentName = student.studentName,
                                Subject = grade?.subject ?? "N/A",
                                Score = grade?.score ?? 0//int타입일때: null이면 0을 반환
                            };

        var rightOuterJoin = from grade in grades
                             join student in students on grade.studentID equals student.studentID into gradeStudents
                             from student in students.DefaultIfEmpty()
                             where student == null
                             select new
                             {
                                 StudentID = grade.studentID,
                                 StudentName = "N/A",
                                 Subject = grade?.subject ?? "N/A",
                                 Score = grade?.score ?? 0
                             };
        var outerJoin = leftOuterJoin.Union(rightOuterJoin);

        foreach (var person in outerJoin)
        {
            Debug.Log($"ID : {person.StudentID} / Name : {person.StudentName} / Subject : {person.Subject} / Score : {person.Score}");
        }
    }
}
