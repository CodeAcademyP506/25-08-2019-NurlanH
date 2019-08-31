using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COURSE
{
    class Program
    {
        
      
        static void Main(string[] args)
        {

            Console.WriteLine("----- WellCome -----");
           

            Course course = new Course();
            Group gruopu = new Group();
            while (true) {
                Console.WriteLine("1. Create Group");
                Console.WriteLine("2. Group List");
                Console.WriteLine("Please select action");
            int selectGroup = int.Parse(Console.ReadLine());
            if(selectGroup == 1)
            {
                    if (course.fullGroup == false)
                    {
                        CreateGroup(course);

                    }
                    else
                    {
                        Console.WriteLine("Course group is full you can't create more group");
                    }

                }
            else if(selectGroup == 2)
            {
                    if(course.haveGroup == false)
                    {
                        Console.WriteLine("Here have not a group please first create a group");
                    }
                    else
                    {
                        saveGroup(course.getGroup());
                        Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^");
                        Console.WriteLine("Select Group Please");
                        int choseGroup = int.Parse(Console.ReadLine());
                        int capasityofGroup = 0;
                        while (capasityofGroup < course.getGroup()[choseGroup-1].GroupCapacity)
                        {
                            students(course.getGroup()[choseGroup-1]);
                            saveStudent(course.GetStudent());
                            Console.WriteLine(course.GetStudent()[choseGroup - 1].Name);
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("This command has not found");
                }
            }
           
            void CreateGroup(Course groupp)
            {
                var gcount = 0;
                if (gcount < 3)
                {
                    Console.WriteLine("Group name: ");
                    string gName = Console.ReadLine();
                    Console.WriteLine("Group count: ");
                    int gCapacity = int.Parse(Console.ReadLine());
                    gcount++;
                    groupp.setGroups(gName, gCapacity);

                }
                else
                {
                    Console.WriteLine("Course group count is full");
                }
            }

            void saveGroup(Group[] gru)
            {
                for (int i = 0; i < course.groupCount ; i++)
                {
                    if (gru[i] != null)
                    {
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Group Name: "+gru[i].GroupName + "\n" + "Group Capacity: " + gru[i].GroupCapacity);
                        Console.WriteLine("-------------------");
                    }
                    else
                    {
                        break;
                    }
                }
            }

            

            void students(Group gru)
            {
                var studentCount = 0;
                

               
                    if (studentCount < gru.GroupCapacity)
                    {
                        Console.WriteLine("Student name: ");
                    string stuName = Console.ReadLine();
                    Console.WriteLine("Student LastName: ");
                    string stuLName = Console.ReadLine();
                    studentCount++;

                    course.AddStudent(stuName, stuLName);
                }
                else
                {
                    Console.WriteLine("Your group student is full");
                }
            }

            void saveStudent(Student[] stu)
            {
                for (int i = 0; i < gruopu.GroupCapacity; i++)
                {
                    if (stu[i] != null)
                    {
                        Console.WriteLine(stu[i].Name + " " + stu[i].LastName);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

    }

    public class Course
    {
        public int groupCount = 3;
        public bool haveGroup = false;
        public bool fullGroup = false;
        private Group[] groups;
        private Student[] students;
        private int stuCapacity = 0;

        private int gcount = 0;
        public Course()
        {
            groups = new Group[groupCount];
        }

        public void setGroups(string name,int capacity)
        {
            students = new Student[capacity];
            groups[gcount] = new Group() { GroupName = name,GroupCapacity = capacity};
            haveGroup = true;
            if(gcount == 2)
            {
                fullGroup = true ;
            }
            
            gcount++;
        }

        
        public Group[] getGroup()
        {
          
            return groups;
        }

        public void AddStudent(string name, string lastname)
        {
            students[stuCapacity] = new Student() { Name = name, LastName = lastname };
            stuCapacity++;
        }

        public Student[] GetStudent()
        {
            return students;
        }

    }

    public class Group
    {
        public string GroupName { get; set; }
        public int GroupCapacity { get; set; }


        
        public string GroupInfo()
        {
            return GroupName + " " + GroupCapacity;
        }

      
            
    }

    class Teacher
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    public class Student
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
