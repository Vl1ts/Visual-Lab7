using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using Avalonia.Media;

namespace Lab7.Models
{
    public class Mark : ReactiveObject
    {
        public Mark()
        {
            MarkValue = "0";
        }

        string markValue;
        public string MarkValue
        {
            get
            {
                return markValue;
            }
            set
            {
                //SetMarkValue(value);
                try
                {
                    int intValue = int.Parse(value);
                    CellBrushColor = Brushes.White;

                    if (intValue == 0 || intValue == 1 || intValue == 2)
                    {
                        value = intValue.ToString();
                        if (intValue == 0)
                        {
                            CellBrushColor = Brushes.Red;
                        }
                        else if (intValue == 1)
                        {
                            CellBrushColor = Brushes.Yellow;
                        }
                        else if (intValue == 2)
                        {
                            CellBrushColor = Brushes.Green;
                        }
                    }
                    else
                    {
                        value = "#ERROR";
                    }
                }
                catch (Exception ex)
                {
                    CellBrushColor = Brushes.White;
                    value = "#ERROR";
                }
                this.RaiseAndSetIfChanged(ref markValue, value);
            }
        }

        //Current
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

        //public void SetMarkValue(string newValue)
        //{
        //    try
        //    {
        //        int intValue = int.Parse(newValue);
        //        CellBrushColor = Brushes.White;

        //        if (intValue == 0 || intValue == 1 || intValue == 2)
        //        {
        //            MarkValue = newValue;
        //            if (intValue == 0)
        //            {
        //                CellBrushColor = Brushes.Red;
                        
        //            }
        //            else if(intValue == 1)
        //            {
        //                CellBrushColor = Brushes.Yellow;
        //                return;
        //            }
        //            else if(intValue == 2)
        //            {
        //                CellBrushColor = Brushes.Green;
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            MarkValue = "#ERROR";
        //        }                
        //    }
        //    catch (Exception ex)
        //    {
        //        CellBrushColor = Brushes.White;
        //        MarkValue = "#ERROR";
        //    }
        //}
    }
}
