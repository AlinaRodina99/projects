﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;

namespace Test7
{
    /// <summary>
    /// Class that binds model and view.
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private static readonly Calculator calculator;
        private string boxForFirstNumber;
        private string boxForSecondNumber;
        private string answer;
        private string currentOperand;
        private RelayCommand gettingAdd;
        private RelayCommand gettingSubtraction;
        private RelayCommand gettingMultiplication;
        private RelayCommand gettingDivision;   


        static ViewModel()
        {
            calculator = new Calculator();
        }

        /// <summary>
        /// If user changed first number answer must be changed too.
        /// </summary>
        public void ChangedFirstNumber()
        {
            if (boxForFirstNumber != null && boxForSecondNumber != null && currentOperand != null)
            {
                Answer = calculator.Calculate(currentOperand, Convert.ToDouble(boxForSecondNumber), Convert.ToDouble(boxForFirstNumber)).ToString();
            }
        }

        /// <summary>
        /// If user changed second number answer must be changed too.
        /// </summary>
        public void ChangedSecondNumber()
        {
            if (boxForFirstNumber != null && boxForSecondNumber != null && currentOperand != null)
            {
                Answer = calculator.Calculate(currentOperand, Convert.ToDouble(boxForSecondNumber), Convert.ToDouble(boxForFirstNumber)).ToString();
            }
        }

        /// <summary>
        /// Property for the first number.
        /// </summary>
        public string BoxForFirstNumber
        {
            get => boxForFirstNumber;
            set
            {
                if (!Double.TryParse(boxForFirstNumber, out double result))
                {
                    MessageBox.Show("Неверный формат числа.");
                    return;
                }

                boxForFirstNumber = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Property for the second number.
        /// </summary>
        public string BoxForSecondNumber
        {
            get => boxForSecondNumber;
            set
            {
                if (!Double.TryParse(boxForFirstNumber, out double result))
                {
                    MessageBox.Show("Неверный формат числа.");
                    return;
                }

                boxForSecondNumber = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Property for the answer of expression
        /// </summary 
        public string Answer
        {
            get => answer;
            set
            {
                answer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Command to make addition.
        /// </summary>
        public RelayCommand GetAdd
        {
            get
            {
                return gettingAdd ?? (gettingAdd = new RelayCommand(obj =>
                {
                    if (boxForFirstNumber == null || boxForSecondNumber == null)
                    {
                        MessageBox.Show("Введите оба числа для выражения.");
                        return;
                    }

                    currentOperand = "+";
                    Answer = calculator.Calculate(currentOperand, Convert.ToDouble(boxForSecondNumber), Convert.ToDouble(boxForFirstNumber)).ToString();
                }));
            }
        }

        /// <summary>
        /// Command to make subtraction.
        /// </summary>
        public RelayCommand GetSubtraction
        {
            get
            {
                return gettingSubtraction ?? (gettingSubtraction = new RelayCommand(obj =>
                {
                    if (boxForFirstNumber == null || boxForSecondNumber == null)
                    {
                        MessageBox.Show("Введите оба числа для выражения.");
                        return;
                    }

                    currentOperand = "-";
                    Answer = calculator.Calculate(currentOperand, Convert.ToDouble(boxForSecondNumber), Convert.ToDouble(boxForFirstNumber)).ToString();
                }));
            }
        }

        /// <summary>
        /// Command to make multiplication.
        /// </summary>
        public RelayCommand GetMultiplication
        {
            get
            {
                return gettingMultiplication ?? (gettingMultiplication = new RelayCommand(obj =>
                {
                    if (boxForFirstNumber == null || boxForSecondNumber == null)
                    {
                        MessageBox.Show("Введите оба числа для выражения.");
                        return;
                    }

                    currentOperand = "*";
                    Answer = calculator.Calculate(currentOperand, Convert.ToDouble(boxForSecondNumber), Convert.ToDouble(boxForFirstNumber)).ToString();
                }));
            }
        }

        /// <summary>
        /// Command to make division.
        /// </summary>
        public RelayCommand GetDivision
        {
            get
            {
                return gettingDivision ?? (gettingDivision = new RelayCommand(obj =>
                {
                    if (boxForFirstNumber == null || boxForSecondNumber == null)
                    {
                        MessageBox.Show("Введите оба числа для выражения.");
                        return;
                    }

                    currentOperand = "/";
                    Answer = calculator.Calculate(currentOperand, Convert.ToDouble(boxForSecondNumber), Convert.ToDouble(boxForFirstNumber)).ToString();
                }));
            }
        }
    


       public void OnPropertyChanged([CallerMemberName] string prop = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    }
}
