using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
using ReactiveUI;
using System.Reactive;

namespace Lab7.Models
{
    public class Student : ReactiveObject
    {
        private int MarksAmount = 5;
        public Student()
        {
            StudentData = "Undefined";
            StudentMarks = new List<Mark>();
            for (int i = 0; i < MarksAmount; ++i)
            {
                StudentMarks.Add(new Mark());
            }
            for (int i = 0; i < StudentMarks.Count; ++i)
            {
                StudentMarks[i].Changed.Subscribe((x) => FindAverage());
            }
            FindAverage();
        }

        string studentData;
        public string StudentData
        {
            get { return studentData; }
            set { studentData = value; }
        }

        public List<Mark> StudentMarks
        {
            get;
            set;
        }

        string studentAverageMark;
        public string StudentAverageMark
        {
            get { return studentAverageMark; }
            set { this.RaiseAndSetIfChanged(ref studentAverageMark, value); }
        }
        
        public bool IsStudentMarked { get; set; }

        //Average
        ISolidColorBrush cellBrushColor;
        public ISolidColorBrush CellBrushColor
        {
            get
            {
                return (ISolidColorBrush)cellBrushColor;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref cellBrushColor, value);
            }
        }

        void FindAverage()
        {
            int sum = 0;
            try
            {
                foreach(Mark mark in StudentMarks)
                {
                    sum += int.Parse(mark.MarkValue);
                }
                
                double average = (double)sum / (double)StudentMarks.Count;

                if(average < 1)
                {
                    CellBrushColor = Brushes.Red;
                }
                else if(average < 1.5)
                {
                    CellBrushColor = Brushes.Yellow;
                }
                else
                {
                    CellBrushColor = Brushes.Green;
                }

                StudentAverageMark = average.ToString();
            }
            catch (Exception ex)
            {
                StudentAverageMark = "#ERROR";
                CellBrushColor = Brushes.White;
            }
        }
    }
}
