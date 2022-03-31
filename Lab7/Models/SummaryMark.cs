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
    public class SummaryMark : ReactiveObject
    {
        public SummaryMark()
        {
            SummaryMarkValue = "0";
        }

        string summaryMarkValue;
        public string SummaryMarkValue
        {
            get
            {
                return summaryMarkValue;
            }
            set
            {
                try
                {
                    double doubleValue = double.Parse(value);
                    SumCellBrushColor = Brushes.White;

                    if (doubleValue >= 0 || doubleValue <= 2)
                    {
                        value = doubleValue.ToString();
                        if (doubleValue < 1)
                        {
                            SumCellBrushColor = Brushes.Red;
                        }
                        else if (doubleValue < 1.5)
                        {
                            SumCellBrushColor = Brushes.Yellow;
                        }
                        else if (doubleValue <= 2)
                        {
                            SumCellBrushColor = Brushes.Green;
                        }
                    }
                    else
                    {
                        value = "#ERROR";
                    }
                }
                catch (Exception ex)
                {
                    SumCellBrushColor = Brushes.White;
                    value = "#ERROR";
                    //value = doubleValue.ToString();
                }
                this.RaiseAndSetIfChanged(ref summaryMarkValue, value);
            }
        }

        ISolidColorBrush cellBrushColor;
        public ISolidColorBrush SumCellBrushColor
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
    }
}
