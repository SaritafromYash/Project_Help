//using ADO_Layered_App_Demo.Models;
//using ADO_Layered_App_Demo.Repository;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ADO_Layered_App_Demo
//{
//    internal class Program2
//    {

//        public static void Main()
//        {

//            Console.WriteLine("Menu for the Courses");


//            int choice;
//            DataSet result;

//            Console.WriteLine("Select  Operation for the Courses");
//            Console.WriteLine("----------------------------");
//            Console.WriteLine("1.Get All Courses");
//            Console.WriteLine("2.Get CourseBy Id");
//            Console.WriteLine("3.Get Courses By User");
//            Console.WriteLine("4.Add Course");
//            Console.WriteLine("5.Update Course");
//            Console.WriteLine("6.Exit");


//            //course repo object
//            CourseRepository courseRepo = new CourseRepository();

//            choice = Convert.ToInt32(Console.ReadLine());

                
//                switch (choice)
//                {
//                    case 1:
//                    Console.WriteLine("All Course : \n");
//                     result = courseRepo.GetAllCourses();

//                    foreach (DataRow row in result.Tables[0].Rows)
//                    {
//                        Console.WriteLine($"{row[0]} - {row[1]} - {row[2]} - {row[3]} - {row[4]} -{row[5]} ");
//                    }
//                    break;

//                case 2:
//                    Console.WriteLine("Enter Id for the Course");
//                    int id = Convert.ToInt32(Console.ReadLine());
//                    Course course = courseRepo.GetCourseById(id);
//                    Console.WriteLine(course);
//                    break;

//                case 3:
//                    Console.WriteLine("All Course For User : \n");
//                    Console.WriteLine("Enter the UserId ");
//                    int userId = Convert.ToInt32(Console.ReadLine());
//                    result = courseRepo.GetCoursesByUser(userId);

//                    foreach (DataRow row in result.Tables[0].Rows)
//                    {
//                        Console.WriteLine($"{row[0]} - {row[1]} - {row[2]} - {row[3]} - {row[4]} -{row[5]} ");
//                    }
//                    break;

//                case 4:
//                    //Add course
//                    Console.WriteLine("Enter the Course Details");
//                    Course newCourse = new Course();
//                    newCourse.CourseId = Convert.ToInt32(Console.ReadLine());
//                    newCourse.Title = Console.ReadLine();
//                    newCourse.Description = Console.ReadLine();
//                    newCourse.StartDate = Convert.ToDateTime(Console.ReadLine());
//                    newCourse.EndDate = Convert.ToDateTime(Console.ReadLine());
//                    newCourse.Category = Console.ReadLine();    
//                    newCourse.Level = Console.ReadLine();
//                    int addResult = courseRepo.AddCourse(newCourse);
//                    if(addResult > 0)
//                    {
//                        Console.WriteLine("Course Added Successfully ");
//                    }
//                    else
//                    {
//                        Console.WriteLine("Failed to Add Course ! ");
//                    }

//                    break;

//                case 5:
//                    //update course
//                    //Add course
//                    Console.WriteLine("Enter the New Course Details");
                 
//                    Course modfiedCourse = new Course();
//                    Console.WriteLine("Enter The Course Id to Update");
//                    modfiedCourse.CourseId = Convert.ToInt32(Console.ReadLine());
//                    Console.WriteLine("Enter Title");
//                    modfiedCourse.Title = Console.ReadLine();
//                    Console.WriteLine("Enter Description");
//                    modfiedCourse.Description = Console.ReadLine();
//                    Console.WriteLine("Enter Start Date");
//                    modfiedCourse.StartDate = Convert.ToDateTime(Console.ReadLine());
//                    Console.WriteLine("Enter End Date");
//                    modfiedCourse.EndDate = Convert.ToDateTime(Console.ReadLine());
//                    Console.WriteLine("Enter Category");
//                    modfiedCourse.Category = Console.ReadLine();
//                    Console.WriteLine("Enter Level");
//                    modfiedCourse.Level = Console.ReadLine();

//                    int modifiedResult = courseRepo.UpdateCourse(modfiedCourse);
//                    if (modifiedResult > 0)
//                    {
//                        Console.WriteLine("Course Updated Successfully ");
//                    }
//                    else
//                    {
//                        Console.WriteLine("Failed to Update Course ! ");
//                    }

//                    break;

//                case 6:
//                    Console.WriteLine("Thank You !");
//                    Environment.Exit(0);
//                    break;


//            }




//        }



//    }
//}
