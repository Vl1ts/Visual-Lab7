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
    public class Summary
    {
        private int MarksAmount = 5;
        public Summary()
        {
            ListSummaryMarks = new List<SummaryMark>();
            for (int i = 0; i < MarksAmount; ++i)
            {
                ListSummaryMarks.Add(new SummaryMark());
            }
        }
        public List<SummaryMark> ListSummaryMarks
        {
            get;
            set;
        }
    }
}
