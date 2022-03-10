using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

namespace lab3visual.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string rezult = "";
        public ReactiveCommand<string, string> OnClickCommand { get; }
        public MainWindowViewModel()
        {
            OnClickCommand = ReactiveCommand.Create<string, string>((str) => Expression = str);
        }
        public string Expression 
        {
            set
            {
                if (rezult == "Error")
                {
                    rezult = "";
                }
                if (value != "=")
                {
                    this.RaiseAndSetIfChanged(ref rezult, rezult + value);
                }
                else
                {
                    try
                    {
                        if (rezult.IndexOf("+") == 0 || rezult.IndexOf("+") == rezult.Length - 1 ||
                            rezult.IndexOf("-") == 0 || rezult.IndexOf("-") == rezult.Length - 1 ||
                            rezult.IndexOf("*") == 0 || rezult.IndexOf("*") == rezult.Length - 1 ||
                            rezult.IndexOf("/") == 0 || rezult.IndexOf("/") == rezult.Length - 1)
                        {
                            throw new lab2visual.RomanNumberException("Invalid input");
                        }
                        if (rezult.IndexOf("+") != -1)
                        {
                            lab2visual.RomanNumberExtend a = new(rezult.Substring(0, rezult.IndexOf("+")));
                            lab2visual.RomanNumberExtend b = new(rezult.Substring(rezult.IndexOf("+")+1));
                            lab2visual.RomanNumber c = new(a.GetDec());
                            lab2visual.RomanNumber d = new(b.GetDec());
                            this.RaiseAndSetIfChanged(ref rezult, (c+d).ToString());
                        }
                        if (rezult.IndexOf("*") != -1)
                        {
                            lab2visual.RomanNumberExtend a = new(rezult.Substring(0, rezult.IndexOf("*")));
                            lab2visual.RomanNumberExtend b = new(rezult.Substring(rezult.IndexOf("*")+1));
                            lab2visual.RomanNumber c = new(a.GetDec());
                            lab2visual.RomanNumber d = new(b.GetDec());
                            this.RaiseAndSetIfChanged(ref rezult, (c * d).ToString());
                        }
                        if (rezult.IndexOf("-") != -1)
                        {
                            lab2visual.RomanNumberExtend a = new(rezult.Substring(0, rezult.IndexOf("-")));
                            lab2visual.RomanNumberExtend b = new(rezult.Substring(rezult.IndexOf("-")+1));
                            lab2visual.RomanNumber c = new(a.GetDec());
                            lab2visual.RomanNumber d = new(b.GetDec());
                            this.RaiseAndSetIfChanged(ref rezult, (c - d).ToString());
                        }
                        if (rezult.IndexOf("/") != -1)
                        {
                            lab2visual.RomanNumberExtend a = new(rezult.Substring(0, rezult.IndexOf("/")));
                            lab2visual.RomanNumberExtend b = new(rezult.Substring(rezult.IndexOf("/")+1));
                            lab2visual.RomanNumber c = new(a.GetDec());
                            lab2visual.RomanNumber d = new(b.GetDec());
                            this.RaiseAndSetIfChanged(ref rezult, (c / d).ToString());
                        }
                        rezult = "";
                    }
                    catch (lab2visual.RomanNumberException)
                    {
                        this.RaiseAndSetIfChanged(ref rezult, "Error");
                    }
                }
            }
            get
            {
                return rezult;
            }
        }
    }
}
