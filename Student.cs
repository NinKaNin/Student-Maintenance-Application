using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows;

namespace StudentMaintananceApplication
{
    internal class Student
    {
        Person person = new Person();

        private string studentNumber, studentProgram, studentYear;

        private const string studentFileName = "student.txt";

        private int studentIntID;



        public void addStudent(int studentID, string studentNumber, string studentProgram, string studentYear)
        {
            File.AppendAllText(studentFileName, Environment.NewLine + studentID + " ;-" + studentNumber + " ;-" + studentProgram + " ;-" + studentYear);

            checkLines();
        }

        public void editStudent(int studentID, string studentNumber, string studentProgram, string studentYear)
        {
            string[] lines = File.ReadAllLines(studentFileName);

            lines[findLine(studentID)] = studentID + " ;-" + studentNumber + " ;-" + studentProgram + " ;-" + studentYear;

            File.WriteAllLines(studentFileName, lines);

            checkLines();
        }

        public void deleteStudent(int studentID)
        {
            string[] lines = File.ReadAllLines(studentFileName);
            List<string> newLines = new List<string>(lines);
            newLines.RemoveAt(findLine(studentID));
            File.WriteAllLines(studentFileName, newLines);

            checkLines();
        }

        public bool searchStudent(int studentID)
        {
            studentIntID = 0;

            if (File.Exists(studentFileName))
            {
                string[] textLines = File.ReadAllLines(studentFileName);

                if (textLines != null)
                {
                    foreach (string line in File.ReadAllLines(studentFileName))
                    {
                        string[] partsLine = line.Split(" ;-");
                        string strID = partsLine[0];
                        studentIntID = Convert.ToInt32(strID);

                        if (studentIntID == studentID)
                        {
                            return true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("The Student Record Is Empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                File.Create(studentFileName).Close();
            }

            return false;
        }

        public int findLine(int studentID)
        {
            int index = 0;

            string[] lines = File.ReadAllLines(studentFileName);

            while (index < lines.Length)
            {
                string line = lines[index];
                string[] partsLine = line.Split(" ;-");
                string strID = partsLine[0];
                studentIntID = Convert.ToInt32(strID);

                if (studentIntID == studentID)
                {
                    break;
                }
                else
                {
                    index++;
                }
            }

            return index;
        }

        private void checkLines()
        {
            string[] lines = File.ReadAllLines(studentFileName);

            // Remove empty or whitespace-only lines
            List<string> nonEmptyLines = new List<string>();
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    nonEmptyLines.Add(line);
                }
            }

            // Write the updated lines back to the file
            File.WriteAllLines(studentFileName, nonEmptyLines);
        }

        public bool searchSN(string SN)
        {
            string sn;

            if (File.Exists(studentFileName))
            {
                string[] textLines = File.ReadAllLines(studentFileName);

                if (textLines != null)
                {
                    foreach (string line in File.ReadAllLines(studentFileName))
                    {
                        string[] partsLine = line.Split(" ;-");
                        sn = partsLine[1];

                        if (sn == SN)
                        {
                            return true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("The Student Record Is Empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                File.Create(studentFileName).Close();
            }

            return false;
        }

        public int findLine(string SN)
        {
            int index = 0;

            string sn;

            string[] lines = File.ReadAllLines(studentFileName);

            while (index < lines.Length)
            {
                string line = lines[index];
                string[] partsLine = line.Split(" ;-");
                sn = partsLine[1];

                if (sn == SN)
                {
                    break;
                }
                else
                {
                    index++;
                }
            }

            return index;
        }
    }
}
