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
    internal class Person
    {
        private string lastName, givenName, middleName;

        private const string personFileName = "person.txt";

        private int personIntID;



        public void addPerson(string lastName, string givenName, string middleName)
        {
            File.AppendAllText(personFileName, Environment.NewLine + lastID() + " ;-" + lastName + " ;-" + givenName + " ;-" + middleName);

            checkLines();
        }

        public void editPerson(int personID, string lastName, string givenName, string middleName)
        {
            string[] lines = File.ReadAllLines(personFileName);

            lines[findLine(personID)] = personID + " ;-" + lastName + " ;-" + givenName + " ;-" + middleName;

            File.WriteAllLines(personFileName, lines);

            checkLines();
        }

        public void deletePerson(int personID)
        {
            string[] lines = File.ReadAllLines(personFileName);
            List<string> newLines = new List<string>(lines);
            newLines.RemoveAt(findLine(personID));
            File.WriteAllLines(personFileName, newLines);

            checkLines();
        }

        private int lastID()
        {
            personIntID = 0;

            if (File.Exists(personFileName))
            {
                string[] textLines = File.ReadAllLines(personFileName);

                if (textLines != null)
                {
                    foreach (string line in File.ReadAllLines(personFileName))
                    {
                        string[] partsLine = line.Split(" ;-");
                        string strID = partsLine[0];
                        personIntID = Convert.ToInt32(strID);
                    }
                }
                else
                {
                    MessageBox.Show("The Person Record Is Empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                File.Create(personFileName).Close();
            }

            return personIntID + 1;
        }

        public bool searchPerson(int personID)
        {
            personIntID = 0;

            foreach (string line in File.ReadAllLines(personFileName))
            {
                string[] partsLine = line.Split(" ;-");
                string strID = partsLine[0];
                personIntID = Convert.ToInt32(strID);

                if (personIntID == personID)
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }

            return false;
        }

        public int findLine(int personID)
        {
            int index = 0;

            string[] lines = File.ReadAllLines(personFileName);

            while (index < lines.Length)
            {
                string line = lines[index];
                string[] partsLine = line.Split(" ;-");
                string strID = partsLine[0];
                personIntID = Convert.ToInt32(strID);

                if (personIntID == personID)
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
            // Read all lines from the file
            string[] lines = File.ReadAllLines(personFileName);

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
            File.WriteAllLines(personFileName, nonEmptyLines);
        }
    }
}
