using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students_Buisness;


namespace StudentManager_project
{
    internal class Program
    {
        private static clsStudent _clsStudent;
      
        public static async Task<bool> AddNewStudent(string Name,byte Age,float Grade)
        {
            _clsStudent = new clsStudent();

            _clsStudent.Name = Name;
            _clsStudent.Age = Age;
            _clsStudent.Grade = Grade;
            return await (_clsStudent.Save());
        }

        public static async Task<bool> DeleteStudent(int StudentID)
        {
           return await (clsStudent.DeleteStudent(StudentID));
        }

        public static async Task<bool> UpdateStudent(int StudentID, string newname, byte newage, float newgrade)
        {
            _clsStudent =  clsStudent.Find(StudentID);

            _clsStudent.Name = newname;
            _clsStudent.Age = newage;
            _clsStudent.Grade = newgrade;
            return await(_clsStudent.Save());
        }

        public static async Task PrintAllStudents()
        {
            DataTable table =await clsStudent.GetAllStudents();
            int colWidth = 15;

            Console.WriteLine("\n");

            foreach (DataColumn column in table.Columns)
            {
                Console.Write(column.ColumnName.PadRight(colWidth));
            }
            Console.WriteLine();

            
            Console.WriteLine(new string('-', table.Columns.Count * colWidth));

           
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.Write(row[column].ToString().PadRight(colWidth));
                }
                Console.WriteLine();
            }
        }
        static async Task Main(string[] args)
        {
            /* if(await AddNewStudent("Abdullah", 21, 90))
              Console.WriteLine("After Added Student Abdullah");

              if (await AddNewStudent("Ali", 20, 50))
              Console.WriteLine("After Added Student Ali");

              if (await AddNewStudent("Fadi", 18, 70))
              Console.WriteLine("After Added Student Fadi");*/

          /* await DeleteStudent(4);
          await  DeleteStudent(5);
           await DeleteStudent(6);*/

            await PrintAllStudents();
        }
    }
}
