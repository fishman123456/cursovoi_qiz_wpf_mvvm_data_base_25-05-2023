﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;


namespace MVVMENTITY
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private Dog selectedDog; // объект собаки, что сейчас активна
        Model model; // объект модели
        Test test = new Test(); // обьект класса тест
        public Test Test { get { return test; } }
        public ViewModel() // конструктор
        {
            this.model = new Model();
        }
        public Test TestX
        {
            get { return test; }
            set
            {
                test = value;
                OnPropertyChanged("TestX");
            }
        }
        public Dog SelectedDog
        {
            get { return selectedDog; }
            set
            {
                selectedDog = value;
                OnPropertyChanged("SelectedDog");
            }
        }
        public List<Dog> Dogs
        {
            get { return this.model.Dogs(); }
        }
        public List<Test> Tests
        {
            get { return this.Tests; }
        }

        // команда добавления нового объекта
        private Command addCommand;
        public Command AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new Command(obj =>
                  {
                      Dog NewDog = new Dog();
                      model.AddDog(NewDog);
                      selectedDog = NewDog;
                      OnPropertyChanged("Dogs");
                  }));
            }
        }

        // команда удаления
        private Command removeCommand;
        public Command RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new Command(obj =>
                  {
                      Dog oldDog = obj as Dog;
                      if (oldDog != null)
                      {
                          Debug.WriteLine("RemoveDog");
                          model.RemoveDog(oldDog);
                          OnPropertyChanged("Dogs");
                      }
                  },
                 (obj) => this.Dogs.Count > 0));
            }
        }



        // команда Синхронизации
        private Command syncDb;
        public Command SyncDb
        {
            get
            {
                return syncDb ??
                  (syncDb = new Command(obj =>
                  {
                      this.model.Dogs_sync();
                      OnPropertyChanged("Dogs");
                  }));
            }
        }
        // мои команды начало викторины
        private Command runQizComm;
        public Command RunQizComm
        { 
            get
            {
                return runQizComm ??
                    (runQizComm = new Command(obj =>
                    {

                        this.model.RunQiz();
                        OnPropertyChanged("RunQizStr");
                    }));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
