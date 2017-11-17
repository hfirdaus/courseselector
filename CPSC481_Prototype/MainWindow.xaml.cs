﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPSC481_Prototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Course_Selector_Items.ItemsSource = CourseSelectorCourses.instance.visable;
        }

        private void Requirement_Popup_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Requirement_Popup.Visibility == Visibility.Visible)
            {
                Requirement_Popup.Visibility = Visibility.Hidden;
            }
        }
        private void Show_Complete_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Show_Completed_Stack_Panel.Visibility = Visibility.Visible;
        }

        private void Show_Complete_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Show_Completed_Stack_Panel.Visibility = Visibility.Collapsed;
        }

        private void Add_to_Cart_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Added to Cart"); 
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            Requirement_Popup.Visibility = Visibility.Visible;
            Course_Search_Panel.Visibility = Visibility.Visible;
            Degree_Search_Panel.Visibility = Visibility.Hidden;
        }

        private void Add_Degree_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Requirement_Popup.Visibility = Visibility.Visible;
            Course_Search_Panel.Visibility = Visibility.Hidden;
            Degree_Search_Panel.Visibility = Visibility.Visible;
        }

        //private void Course_ACCT_Click(object sender, MouseButtonEventArgs e)
        //{
        //    Main_Faculty_Menu.Header = "ACCT - Accounting";
        //}

        private void Remove_From_Cart(object sender, RoutedEventArgs e)
        {
        }

        private void Enroll(object sender, RoutedEventArgs e)
        {
        }

        int num = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(Semester semester in Semester.ALL_SEMESTERS)
            {
                // Make a course
                Course newCourse = new Course("CPSC", "217", "Course Title " + num, "Course Description " + num, semester, 2017);

                for (int lec = 1; lec <= 2; lec++)
                {
                    Offering offering = new Offering();
                    Section s = new Section()
                    {
                        Name = "Lecture " + lec
                    };
                    s.Select_Command = new LectureCommand(newCourse, s);
                    offering.Lecture = s;
                    for (int i = 0; i < 2; i++)
                    {
                        s = new Section()
                        {
                            Name = "Tutorial " + i
                        };
                        offering.Tutorials.Add(s);
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        s = new Section()
                        {
                            Name = "Lab " + i
                        };
                        if (num % 2 == 0)
                        {
                            offering.Labs.Add(s);
                        }
                    }

                    newCourse.AddOffering(offering);
                }

                CourseSelectorCourses.AddCourse(newCourse);
                num++;
            }

        }

        private void DeleteCourse(object sender, RoutedEventArgs e)
        {

        }

        private void Semester_Checked(object sender, RoutedEventArgs e)
        {
            Semester s = Semester.SearchSemester(((CheckBox)sender).Tag.ToString());
            if (s == null)
                return;
            if (((CheckBox) sender).IsChecked == true)
            {
                CourseSelectorCourses.AddVisibleSemester(s);
            } else
            {
                CourseSelectorCourses.RemoveVisibleSemester(s);
            }
        }
    }
}
