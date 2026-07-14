using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main(String[] args)
    {
        List<Student_Managment> std=new List<Student_Managment>();
        List<Course_Managment>course_Managments =new List<Course_Managment>();
        List<Course_Registration>course_Registrations=new List<Course_Registration>();

        while (true)
        {
            Console.WriteLine("Welcome to Student Management System......");
            Console.WriteLine("1.Student Management");
            Console.WriteLine("2.Course Management");
            Console.WriteLine("3.Course Registration");
            Console.WriteLine("4.Fees Calculation");
            Console.WriteLine("5.Display Student Details");
            Console.WriteLine("6.Exit");
            Console.WriteLine("Please Enter number between 1-6");


            try
            {
                int choice=Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        
                        bool exitSubMenu1 = false;
                        while (!exitSubMenu1)
                        {
                            Console.WriteLine("1.Register Student");
                            Console.WriteLine("2.View Registered Student");
                            Console.WriteLine("3.Search Student by Id");
                            Console.WriteLine("4.Exit");
                            Console.WriteLine("Enter a Number 1-4");

                            try
                            {
                                int choice1=Convert.ToInt32(Console.ReadLine());

                                switch (choice1)
                                {
                                    case 1:
                                    Console.WriteLine("Enter Student Id:");
                                    int id=Convert.ToInt32(Console.ReadLine());
                                  
                                    bool exist = false;
                                    foreach(Student_Managment stid in std)
                                        {
                                            if (stid.Id == id)
                                            {
                                                 exist = true;
                                                 break;
                                            }
                                            if (exist)
                                            {
                                                Console.WriteLine("Entered Student Id already exist. ");
                                                break;
                                            }
                                        }
                                            Console.WriteLine("Enter Student Name:");
                                            string stdname=Console.ReadLine();
                                            Console.WriteLine("Enter Student Department:");
                                            string stdept=Console.ReadLine();
                                            Console.WriteLine("Enter Student Type (1-Regular, 2-Scholarship, 3-PartTime):");
                                            int typeChoice = Convert.ToInt32(Console.ReadLine());
                                            StudentType sType = StudentType.Regular;
                                            if (typeChoice == 2) sType = StudentType.Scholarship;
                                            else if (typeChoice == 3) sType = StudentType.parttime;

                                            Student_Managment student = new Student_Managment(id, stdname, stdept, sType);

                                            
                                            std.Add(student);
                                            Console.WriteLine("Student Added Successufully...............");
                                            break;


                                    case 2:
                                        if (std.Count == 0)
                                        {
                                            Console.WriteLine("There is no Student Registerd");
                                        }
                                        else
                                        {
                                            foreach(Student_Managment student1 in std)
                                            {
                                                student1.Display();
                                            }
                                        }
                                    break;

                                    case 3:
                                    Console.WriteLine("Enter Student Id:");
                                    int id1=Convert.ToInt32(Console.ReadLine());
                                    bool found =false;
                                    foreach(Student_Managment stid1 in std)
                                        {
                                            if (stid1.Id == id1)
                                            {
                                                 exist = true;
                                                 stid1.Display();
                                                 break;
                                            }
                                            if (!found)
                                            {
                                                Console.WriteLine("Student not found");
                                            }
                                        }
                                        break;

                                    case 4:
                                     exitSubMenu1 = true;
                                     break;
                        

                                    default:
                                    Console.WriteLine("Invalid Choice");
                                    break;

                                    
                                }


                                

                            }
                            catch(FormatException)
                            {
                                Console.WriteLine("please enter numbers only.");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }break;
                         
                    case 2:

                        bool exitSubMenu2 = false;
                        while (!exitSubMenu2)
                        {
                            Console.WriteLine("Welcome to Course Management.");
                            Console.WriteLine("1.Add Course");
                            Console.WriteLine("2.Display All Courses");
                            Console.WriteLine("3.Exit");
                            Console.WriteLine("Enter 1 - 3");

                            try
                            {
                                int choice2 =Convert.ToInt32(Console.ReadLine());
                                switch (choice2)
                                {
                                    case 1:
                                    Console.WriteLine("Enter Course Id:");
                                    int cid =Convert.ToInt32(Console.ReadLine());
                                    bool exist =false;
                                    foreach(Course_Managment course_Managment in course_Managments)
                                        {
                                            if (course_Managment.cId == cid)
                                            {
                                                exist=true;
                                                break;
                                            }
                                            if (exist)
                                            {
                                                Console.WriteLine("Course Id already exist.");
                                            }
                                        }
                                        Console.WriteLine("Enter Course Name:");
                                        string cName=Console.ReadLine();
                                        Console.WriteLine("Enter Course Credit:");
                                        int Ccredit=Convert.ToInt32(Console.ReadLine());
                                        Course_Managment course_Managment1=new Course_Managment(cid,cName,Ccredit);
                                        course_Managments.Add(course_Managment1) ;
                                        Console.WriteLine("Course Added Successfully.......");


                                    break;

                                    case 2:
                                    if (course_Managments.Count == 0)
                                        {
                                            Console.WriteLine("There is no Course Available");
                                        }
                                        else
                                        {
                                            foreach(Course_Managment cm in course_Managments)
                                            {
                                                cm.show();
                                            }
                                        }

                                    break;

                                    case 3:
                                     exitSubMenu2= true;
                       
                                    break;

                                    default:
                                    Console.WriteLine("Invalid Choice");
                                    break;


                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Please Enter numbers only");
                            }catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }

                    break;

                    case 3:
                        try
                        {
                            Console.WriteLine("Enter Student Id:");
                            int regStudentId = Convert.ToInt32(Console.ReadLine());
                            Student_Managment regStudent = FindStudent(std, regStudentId);
 
                            if (regStudent == null)
                            {
                                Console.WriteLine("Student not found. Register the student first.");
                                break;
                            }
 
                            if (regStudent.EnrolledCourses.Count >= 3)
                            {
                                Console.WriteLine("This student already has the maximum number of courses (" + 3+ ").");
                                break;
                            }
 
                            Console.WriteLine("Enter Course Id to enroll in:");
                            int regCourseId = Convert.ToInt32(Console.ReadLine());
                            Course_Managment regCourse = FindCourse(course_Managments, regCourseId);
 
                            if (regCourse == null)
                            {
                                Console.WriteLine("Course not found. Add the course first.");
                                break;
                            }
 
                            bool alreadyEnrolled = false;
                            foreach (Course_Managment c in regStudent.EnrolledCourses)
                            {
                                if (c.cId == regCourseId)
                                {
                                    alreadyEnrolled = true;
                                    break;
                                }
                            }
 
                            if (alreadyEnrolled)
                            {
                                Console.WriteLine("Student is already registered for this course.");
                                break;
                            }
 
                            regStudent.EnrolledCourses.Add(regCourse);
                            course_Registrations.Add(new Course_Registration(regStudentId, regCourseId));
                            Console.WriteLine("Course Registration Successful...............");
                               
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("please enter numbers only.");
                        }catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                  

                    
                    
                    
                       
                    

                    break;

                   
                
                case 4:

                        try
                        {
                            Console.WriteLine("Enter Student Id:");
                            int feeStudentId = Convert.ToInt32(Console.ReadLine());
                            Student_Managment feeStudent = FindStudent(std, feeStudentId);

                            if (feeStudent == null)
                            {
                                Console.WriteLine("Student not found.");
                                break;
                            }

                            Console.WriteLine("Student Id:" + feeStudent.Id);
                            Console.WriteLine("Total Credits:" + feeStudent.TotalCredits());
                            Console.WriteLine("Student Type:" + feeStudent.type);
                            Console.WriteLine("Total Fee:" + feeStudent.CalculateFee());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("please enter numbers only.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 5:

                        try
                        {
                            Console.WriteLine("Enter Student Id:");
                            int viewId = Convert.ToInt32(Console.ReadLine());
                            Student_Managment viewStudent = FindStudent(std, viewId);

                            if (viewStudent == null)
                            {
                                Console.WriteLine("Student not found.");
                                break;
                            }

                            viewStudent.FullDetails();
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("please enter numbers only.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 6:
                        Console.WriteLine("Thank you for using Student Management System. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;


            }
            }catch(FormatException)
            {
                Console.WriteLine("please enter numbers only.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }

 static Student_Managment FindStudent(List<Student_Managment> list, int id)
    {
        foreach (Student_Managment s in list)
        {
            if (s.Id == id)
            {
                return s;
            }
        }
        return null;
    }
 
    static Course_Managment FindCourse(List<Course_Managment> list, int id)
    {
        foreach (Course_Managment c in list)
        {
            if (c.cId == id)
            {
                return c;
            }
        }
        return null;
    }
}
