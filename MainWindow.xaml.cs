using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentMaintananceApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Records myRecords = new Records();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Main Menu

        private void PersonButton_Click(object sender, RoutedEventArgs e)
        {
            ViewRecordsStckPnl.Visibility = Visibility.Collapsed;
            NavStckPnl.Visibility = Visibility.Collapsed;
            PrsnStckPnl.Visibility = Visibility.Visible;
        }

        private void StudentButton_Click(object sender, RoutedEventArgs e)
        {
            ViewRecordsStckPnl.Visibility = Visibility.Collapsed;
            NavStckPnl.Visibility = Visibility.Collapsed;
            StdntStckPnl.Visibility = Visibility.Visible;
        }

        private void ViewAllButton_Click(object sender, RoutedEventArgs e)
        {
            ViewSpecificRecordStckPnl.Visibility = Visibility.Collapsed;
            ViewRecordsStckPnl.Visibility = Visibility.Visible;
            dataGrid.ItemsSource = myRecords.viewAllRecords();
        }

        private void ViewSpecificButton_Click(object sender, RoutedEventArgs e)
        {
            ViewRecordsStckPnl.Visibility = Visibility.Collapsed;
            ViewSpecificRecordStckPnl.Visibility = Visibility.Visible;
        }

        private void ViewStdntSNButton_Click(object sender, RoutedEventArgs e)
        {
            ViewSpecificRecordStckPnl.Visibility = Visibility.Collapsed;
            ViewRecordsStckPnl.Visibility = Visibility.Visible;
            dataGrid.ItemsSource = myRecords.viewRecordSN(viewStdntSNInpt.Text);
        }

        private void ViewStdntIDButton_Click(object sender, RoutedEventArgs e)
        {
            ViewSpecificRecordStckPnl.Visibility = Visibility.Collapsed;
            ViewRecordsStckPnl.Visibility = Visibility.Visible;
            dataGrid.ItemsSource = myRecords.viewRecordID(Convert.ToInt32(viewStdntIDInpt.Text));
        }

        private void DeleteAllButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete all Records??", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                myRecords.deleteAllRecords();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        // Person Menu

        private void AddPersonButton_Click(object sender, RoutedEventArgs e)
        {
            DeletePersonStckPnl.Visibility = Visibility.Collapsed;
            EditPersonStckPnl.Visibility = Visibility.Collapsed;
            AddPersonStckPnl.Visibility = Visibility.Visible;
        }

        private void ConfrmAddPrsn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("This Person Will Be Added To The Record. Are You Sure You Want To Add This Person?", "Confirm Add", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                myRecords.personAdd(addPrsnLstNmInpt.Text, addPrsnGvnNmInpt.Text, addPrsnMddlNmInpt.Text);
            }
        }

        private void EditPersonButton_Click(object sender, RoutedEventArgs e)
        {
            DeletePersonStckPnl.Visibility = Visibility.Collapsed;
            AddPersonStckPnl.Visibility = Visibility.Collapsed;
            EditPersonStckPnl.Visibility = Visibility.Visible;
        }

        private void ConfrmEditPrsn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("This Person's Record Will Be Edited. Are You Sure You Want To Edit This Person's Record?", "Confirm Edit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                myRecords.personEdit(Convert.ToInt32(editPrsnIdInpt.Text), editPrsnLstNmInpt.Text, editPrsnGvnNmInpt.Text, editPrsnMddlNmInpt.Text);
            }
        }

        private void DeletePersonButton_Click(object sender, RoutedEventArgs e)
        {
            AddPersonStckPnl.Visibility = Visibility.Collapsed;
            EditPersonStckPnl.Visibility = Visibility.Collapsed;
            DeletePersonStckPnl.Visibility = Visibility.Visible;
        }

        private void ConfrmDeletePrsn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("This Person's Record Will Be Deleted Includeing The Student Record. Are You Sure You Want To Delete This Person's Records?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                myRecords.personDelete(Convert.ToInt32(editPrsnIdInpt.Text));
            }
        }

        private void ExitPersonButton_Click(object sender, RoutedEventArgs e)
        {
            PrsnStckPnl.Visibility = Visibility.Collapsed;
            AddPersonStckPnl.Visibility = Visibility.Collapsed;
            EditPersonStckPnl.Visibility = Visibility.Collapsed;
            DeletePersonStckPnl.Visibility = Visibility.Collapsed;
            NavStckPnl.Visibility = Visibility.Visible;
        }

        // Student Menu

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteStudentStckPnl.Visibility = Visibility.Collapsed;
            EditStudentStckPnl.Visibility = Visibility.Collapsed;
            AddStudentStckPnl.Visibility = Visibility.Visible;
        }

        private void ConfrmAddStdnt_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("This Student Will Be Added To The Record. Are You Sure You Want To Add This Student?", "Confirm Add", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                myRecords.studentAdd(Convert.ToInt32(addStdntIdInpt.Text), addStdntSNInpt.Text, addStdntPrgrmInpt.Text, addStdntYrInpt.Text);
            }
        }

        private void EditStudentButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteStudentStckPnl.Visibility = Visibility.Collapsed;
            AddStudentStckPnl.Visibility = Visibility.Collapsed;
            EditStudentStckPnl.Visibility = Visibility.Visible;
        }

        private void ConfrmEditStdnt_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("This Student's Record Will Be Edited. Are You Sure You Want To Edit This Student's Record?", "Confirm Edit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                myRecords.studentEdit(Convert.ToInt32(editStdntIdInpt.Text), editStdntSNInpt.Text, editStdntPrgrmInpt.Text, editStdntYrInpt.Text);
            }
        }

        private void DeleteStudentButton_Click(object sender, RoutedEventArgs e)
        {
            EditStudentStckPnl.Visibility = Visibility.Collapsed;
            AddStudentStckPnl.Visibility = Visibility.Collapsed;
            DeleteStudentStckPnl.Visibility = Visibility.Visible;
        }

        private void ConfrmDeleteStdnt_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("This Student's Record Will Be Deleted. Are You Sure You Want To Delete This Student's Record?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                myRecords.studentDelete(Convert.ToInt32(deleteStdntIdInpt.Text));
            }
        }

        private void ExitStudentButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteStudentStckPnl.Visibility = Visibility.Collapsed;
            EditStudentStckPnl.Visibility = Visibility.Collapsed;
            AddStudentStckPnl.Visibility = Visibility.Collapsed;
            StdntStckPnl.Visibility = Visibility.Collapsed;
            NavStckPnl.Visibility = Visibility.Visible;
        }

        
    }
}
