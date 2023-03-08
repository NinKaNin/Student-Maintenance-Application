using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows;
using Microsoft.VisualBasic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace StudentMaintananceApplication
{
    internal class Records
    {
        //initialize class
        Person myPerson = new Person();
        Student myStudent = new Student();

        //declare variables
        private const string personFileName = "person.txt";
        private const string studentFileName = "student.txt";
        private const string recordFileName = "record.txt";
        private string lastName, givenName, middleName, studentNumber, program, year;
        int ID;
        private string[] lines;
        private string Line;

        //methods
        public void personAdd(string lastName, string givenName, string middleName)
        {
            myPerson.addPerson(lastName.Trim(), givenName.Trim(), middleName.Trim());
        }

        public void personEdit(int id, string lastName, string givenName, string middleName)
        {
            if (myPerson.searchPerson(id))
            {
                myPerson.editPerson(id, lastName.Trim(), givenName.Trim(), middleName.Trim());
            }
            else{
                MessageBox.Show("The Person Is Not In The Record.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void personDelete(int id)
        {
            if (myPerson.searchPerson(id))
            {
                myPerson.deletePerson(id);
                if (myStudent.searchStudent(id))
                {
                    myStudent.deleteStudent(id);
                }
            }
            else
            {
                MessageBox.Show("The Person Is Not In The Record.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void studentAdd(int id, string studentNumber, string program, string year)
        {
            if (myPerson.searchPerson(id))
            {
                if (myStudent.searchStudent(id))
                {
                    MessageBox.Show("The Student Is Already In The Record.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    myStudent.addStudent(id, studentNumber.Trim(), program.Trim(), year.Trim());
                }
            }
            else
            {
                MessageBox.Show("The Person Is Not In The Record.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void studentEdit(int id, string studentNumber, string program, string year)
        {
            if (myStudent.searchStudent(id))
            {
                myStudent.editStudent(id, studentNumber.Trim(), program.Trim(), year.Trim());
            }
            else
            {
                MessageBox.Show("The Student Is Not In The Record.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void studentDelete(int id)
        {
            if (myStudent.searchStudent(id))
            {
                myStudent.deleteStudent(id);
            }
            else
            {
                MessageBox.Show("The Student Is Not In The Record.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<string[]> viewAllRecords()
        {

            List<string[]> data = new List<string[]>();
            if (File.Exists(personFileName))
            {
                string[] textLines = File.ReadAllLines(personFileName);
                File.Delete(recordFileName);

                if (textLines != null)
                {
                    foreach (string line in textLines)
                    {
                        string[] splitPerson = line.Split(" ;-");
                        ID = Convert.ToInt32(splitPerson[0]);

                        if (myStudent.searchStudent(ID))
                        {
                            lines = File.ReadAllLines(studentFileName);
                            string[] splitStudent = lines[myStudent.findLine(ID)].Split(" ;-");
                            File.AppendAllText(recordFileName, Environment.NewLine + splitPerson[0] + " ;-" + splitPerson[1] + " ;-" + splitPerson[2] + " ;-" + splitPerson[3] + " ;-" + splitStudent[1] + " ;-" + splitStudent[2] + " ;-" + splitStudent[3]);
                            // Read all lines from the file
                            string[] nullLines = File.ReadAllLines(recordFileName);

                            // Remove empty or whitespace-only lines
                            List<string> nonEmptyLines = new List<string>();
                            foreach (string Line in nullLines)
                            {
                                if (!string.IsNullOrWhiteSpace(Line))
                                {
                                    nonEmptyLines.Add(Line);
                                }
                            }

                            // Write the updated lines back to the file
                            File.WriteAllLines(recordFileName, nonEmptyLines);
                        }
                        else
                        {
                            File.AppendAllText(recordFileName, Environment.NewLine + splitPerson[0] + " ;-" + splitPerson[1] + " ;-" + splitPerson[2] + " ;-" + splitPerson[3] + " ;-" + " " + " ;-" + " " + " ;-" + " ");
                            // Read all lines from the file
                            string[] nullLines = File.ReadAllLines(recordFileName);

                            // Remove empty or whitespace-only lines
                            List<string> nonEmptyLines = new List<string>();
                            foreach (string Line in nullLines)
                            {
                                if (!string.IsNullOrWhiteSpace(Line))
                                {
                                    nonEmptyLines.Add(Line);
                                }
                            }

                            // Write the updated lines back to the file
                            File.WriteAllLines(recordFileName, nonEmptyLines);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("The Person Record Is Empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                string[] Lines = File.ReadAllLines(recordFileName);
                foreach (string line in Lines)
                {
                    data.Add(line.Split(" ;-"));
                }
            }
            else
            {
                File.Create(studentFileName).Close();
            }

            return data;
        }

        public List<string[]> viewRecordID(int id)
        {
            string[] textLines = File.ReadAllLines(personFileName);
            File.Delete(recordFileName);
            List<string[]> data = new List<string[]>();

            if (myPerson.searchPerson(id))
            {
                lines = File.ReadAllLines(personFileName);
                string[] splitPerson = lines[myPerson.findLine(id)].Split(" ;-");

                if (myStudent.searchStudent(id))
                {
                    lines = File.ReadAllLines(studentFileName);
                    string[] splitStudent = lines[myStudent.findLine(id)].Split(" ;-");

                    File.AppendAllText(recordFileName, Environment.NewLine + splitPerson[0] + " ;-" + splitPerson[1] + " ;-" + splitPerson[2] + " ;-" + splitPerson[3] + " ;-" + splitStudent[1] + " ;-" + splitStudent[2] + " ;-" + splitStudent[3]);
                    // Read all lines from the file
                    string[] nullLines = File.ReadAllLines(recordFileName);

                    // Remove empty or whitespace-only lines
                    List<string> nonEmptyLines = new List<string>();
                    foreach (string Line in nullLines)
                    {
                        if (!string.IsNullOrWhiteSpace(Line))
                        {
                            nonEmptyLines.Add(Line);
                        }
                    }

                    // Write the updated lines back to the file
                    File.WriteAllLines(recordFileName, nonEmptyLines);
                }
                else
                {
                    File.AppendAllText(recordFileName, Environment.NewLine + splitPerson[0] + " ;-" + splitPerson[1] + " ;-" + splitPerson[2] + " ;-" + splitPerson[3] + " ;-" + " " + " ;-" + " " + " ;-" + " ");
                    // Read all lines from the file
                    string[] nullLines = File.ReadAllLines(recordFileName);

                    // Remove empty or whitespace-only lines
                    List<string> nonEmptyLines = new List<string>();
                    foreach (string Line in nullLines)
                    {
                        if (!string.IsNullOrWhiteSpace(Line))
                        {
                            nonEmptyLines.Add(Line);
                        }
                    }

                    // Write the updated lines back to the file
                    File.WriteAllLines(recordFileName, nonEmptyLines);
                }
                string[] Lines = File.ReadAllLines(recordFileName);
                foreach (string line in Lines)
                {
                    data.Add(line.Split(" ;-"));
                }
            }
            else
            {
                MessageBox.Show("The Person Is Not In The Record.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return data;
        }

        public List<string[]> viewRecordSN(string sn)
        {
            string[] textLines = File.ReadAllLines(personFileName);
            File.Delete(recordFileName);
            List<string[]> data = new List<string[]>();

            if (myStudent.searchSN(sn))
            {
                lines = File.ReadAllLines(studentFileName);
                string[] splitStudent = lines[myStudent.findLine(sn)].Split(" ;-");
                string strID = splitStudent[0];
                ID = Convert.ToInt32(strID);

                lines = File.ReadAllLines(personFileName);
                string[] splitPerson = lines[myPerson.findLine(ID)].Split(" ;-");

                File.AppendAllText(recordFileName, Environment.NewLine + splitPerson[0] + " ;-" + splitPerson[1] + " ;-" + splitPerson[2] + " ;-" + splitPerson[3] + " ;-" + splitStudent[1] + " ;-" + splitStudent[2] + " ;-" + splitStudent[3]);
                // Read all lines from the file
                string[] nullLines = File.ReadAllLines(recordFileName);

                // Remove empty or whitespace-only lines
                List<string> nonEmptyLines = new List<string>();
                foreach (string Line in nullLines)
                {
                    if (!string.IsNullOrWhiteSpace(Line))
                    {
                        nonEmptyLines.Add(Line);
                    }
                }

                // Write the updated lines back to the file
                File.WriteAllLines(recordFileName, nonEmptyLines);
            }
            else
            {
                MessageBox.Show("The Student Is Not In The Record.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            string[] Lines = File.ReadAllLines(recordFileName);
            foreach (string line in Lines)
            {
                data.Add(line.Split(" ;-"));
            }

            return data;
        }

        public void deleteAllRecords()
        {
            File.Delete(personFileName);
            File.Delete(studentFileName);
            File.Create(personFileName);
            File.Create(studentFileName);
        }
    }
}
