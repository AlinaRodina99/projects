using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Test7
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Calculator calculator;
        private string boxForFirstNumber;
        private string boxForSecondNumber;
        private string answer;
        private string currentOperand;
        private RelayCommand gettingAdd;
        private RelayCommand gettingSubtraction;
        private RelayCommand gettingMultiplication;
        private RelayCommand gettingDivision;


        public ViewModel()
        {
            calculator = new Calculator();
        }

        public string BoxForFirstNumber
        {
            get => boxForFirstNumber;
            set
            {

                if (boxForFirstNumber != null && boxForSecondNumber != null && currentOperand != null)
                {
                    answer = calculator.Calculate(currentOperand, Convert.ToDouble(value), Convert.ToDouble(boxForSecondNumber)).ToString();
                }

                boxForFirstNumber = value;
                OnPropertyChanged();
            }
        }

        public string BoxForSecondNumber
        {
            get => boxForSecondNumber;
            set
            {
                if (boxForFirstNumber != null && boxForSecondNumber != null && currentOperand != null)
                {
                    answer = calculator.Calculate(currentOperand, Convert.ToDouble(boxForFirstNumber), Convert.ToDouble(value)).ToString();
                }

                boxForSecondNumber = value;
                OnPropertyChanged();
            }
        }

        public string Answer
        {
            get => answer;
            set
            {
                answer = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand GetAdd
        {
            get
            {
                return gettingAdd ??
                    (gettingAdd = new RelayCommand(obj =>
                    {
                        currentOperand = "+";

                        if (boxForFirstNumber == null || boxForSecondNumber == null)
                        {
                            MessageBox.Show("Введите числа для выражения.");
                            return;
                        }

                        Answer = (calculator.Calculate(currentOperand, Convert.ToDouble(boxForFirstNumber), Convert.ToDouble(boxForSecondNumber))).ToString();
                    }));
            }
        }

        public RelayCommand GetSubtraction
        {
            get
            {
                return gettingSubtraction ??
                    (gettingSubtraction = new RelayCommand(obj =>
                    { 
                        currentOperand = "-";

                        if (boxForFirstNumber == null || boxForSecondNumber == null)
                        {
                            MessageBox.Show("Введите числа для выражения.");
                            return;
                        }

                        Answer = (calculator.Calculate(currentOperand, Convert.ToDouble(boxForFirstNumber), Convert.ToDouble(boxForSecondNumber))).ToString();
                    }));
            }
        }

        public RelayCommand GetMultiplication
        {
            get
            {
                return gettingMultiplication ??
                    (gettingMultiplication = new RelayCommand(obj =>
                    {
                        currentOperand = "*";

                        if (boxForFirstNumber == null || boxForSecondNumber == null)
                        {
                            MessageBox.Show("Введите числа для выражения.");
                            return;
                        }

                        Answer = (calculator.Calculate(currentOperand, Convert.ToDouble(boxForFirstNumber), Convert.ToDouble(boxForSecondNumber))).ToString();
                    }));
            }
        }

        public RelayCommand GetDivision
        {
            get
            {
                return gettingDivision ??
                    (gettingDivision = new RelayCommand(obj =>
                    {
                        currentOperand = "/";

                        if (boxForFirstNumber == null || boxForSecondNumber == null)
                        {
                            MessageBox.Show("Введите числа для выражения.");
                            return;
                        }

                        Answer = (calculator.Calculate(currentOperand, Convert.ToDouble(boxForFirstNumber), Convert.ToDouble(boxForSecondNumber))).ToString();
                    }));
            }
        }


        public void OnPropertyChanged([CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
