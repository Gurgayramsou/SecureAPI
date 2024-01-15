using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DbConnection.Model;

namespace DbConnection.DAL
{
    public class StudentInitializer: DropCreateDatabaseIfModelChanges<StudentContext>
    {
        protected override void Seed(StudentContext context)
        {
            var studLs = new List<Student> { new Student {id = 1,name="ram",age = 25 }, new Student { id=2, name="krishna",age=22} };

            studLs.ForEach((student) => { context.Students.Add(student); });

            context.SaveChanges();

            var gameLs = new List<Game> { new Game { id = 1, name = "FootBall", studentid = 1 }, new Game { id = 2, name = "Carum", studentid = 1 }, new Game { id = 3, name = "TableTennis", studentid = 2 } };

            gameLs.ForEach((game) => {  context.Games.Add(game); });

            context.SaveChanges();
        }
    }
}
