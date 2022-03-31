using System;
using System.Collections.Generic;
using System.Text;
using Lab7.Models;
using System.Reactive;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.IO;

namespace Lab7.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Student>();
            StudentsSummary = new ObservableCollection<Student>();
            StudentsSummary.Add(new Student());
            StudentsSummary.Add(new Student());
            StudentsSummary.Add(new Student());
            StudentsSummary.Add(new Student());
            StudentsSummary.Add(new Student());
        }
        ObservableCollection<Student> items;
        public ObservableCollection<Student> Items
        {
            get
            {
                return items;
            }
            set
            {
                FindStudentsSummary();
                this.RaiseAndSetIfChanged(ref items, value);
            }
        }

        public void AddNewStudent()
        {
            Items.Add(new Student());
            FindStudentsSummary();
        }

        public void DeleteMarkedStudents()
        {
            var updatedList = new ObservableCollection<Student>();

            foreach (var currentStudent in Items)
            {
                if (currentStudent.IsStudentMarked == false)
                {
                    updatedList.Add(currentStudent);
                }
            }

            Items = updatedList;
            FindStudentsSummary();
        }

        ObservableCollection<Student> studentsSummary;
        public ObservableCollection<Student> StudentsSummary
        {
            get => studentsSummary;
            set => this.RaiseAndSetIfChanged(ref studentsSummary, value);
        }

        public void FindStudentsSummary()
        {
            if(Items != null)
            {
                var summaryList = new List<double>();
                for (int i = 0; i < 5; ++i)
                {
                    summaryList.Add(0);
                }

                foreach (Student currentStudent in Items)
                {
                    for (int i = 0; i < currentStudent.StudentMarks.Count; ++i)
                    {
                        try
                        {
                            summaryList[i] += int.Parse(currentStudent.StudentMarks[i].MarkValue);
                        }
                        catch (Exception ex)
                        {
                            StudentsSummary[0].StudentMarks[i].MarkValue = "#ERROR";
                        }
                    }
                }
                for (int i = 0; i < 5; ++i)
                {
                    StudentsSummary[0].StudentMarks[i].MarkValue = (summaryList[i] / Items.Count).ToString();
                }
            }

        }

        public void OpenFile(string path)
        {
            if (File.Exists(path))
            {
                Items.Clear();

                using (StreamReader sr = File.OpenText(path))
                {
                    var currentString = "";
                    
                    while ((currentString = sr.ReadLine()) != null)
                    {
                        int firstDotIndex = 0;
                        int secondDotIndex = currentString.IndexOf('"', 1);

                        Student newStudent = new Student();
                        newStudent.StudentData = currentString.Substring(firstDotIndex + 1, secondDotIndex - 1);

                        var currentMarks = currentString.Substring(secondDotIndex + 2).Split(' ');
                        for (int i = 0; i < newStudent.StudentMarks.Count; ++i)
                        {
                            newStudent.StudentMarks[i].MarkValue = currentMarks[i];
                        }

                        Items.Add(newStudent);
                    }
                }

                FindStudentsSummary();
            }
        }
        public void SaveFile(string path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (var currentStudent in Items)
                {
                    sw.Write($"\"{currentStudent.StudentData}\" ");
                    
                    foreach (Mark currentMark in currentStudent.StudentMarks)
                    {
                        sw.Write($"{currentMark.MarkValue} ");
                    }

                    sw.Write('\n');
                }
            }
        }

        
    }
}
