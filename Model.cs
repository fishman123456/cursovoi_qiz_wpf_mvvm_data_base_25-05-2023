using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Windows;

namespace MVVMENTITY
{
    

    public class ApplicationContext : DbContext// выполняет функцию соединения с бд
    {
        public DbSet<Dog> Dogs => Set<Dog>();// непосредственно коллекция объектов. Именно она будет храниться в базе данных
       
        public ApplicationContext() => Database.EnsureCreated();// при создании этого объекта удостоверяяемся, что база данных существует и создаем, если нет
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)// говорим чем и куда сохранять наши данные
        {
            optionsBuilder.UseSqlite("Data Source=Dogs.db");
        }
    }
    // делаем для теста передачи списка в listbox
    public class Test: Dog, INotifyPropertyChanged 
    {
        public  string TestStringsQiz { get; set; } = "первый";
        public Test() { }
        public Test(string one) 
        {
            TestStringsQiz = one;
        }   
        // событие, которое уведомляет  viewModel и view о изменении
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propT = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propT));
        }
    }
    public class Dog : INotifyPropertyChanged // собак храним в бд и отображаем пользователю
    {
        
        public int Id { get; set; } //  Id необходим для соханения его в бд
        public string ansver { get; set; } = "Ответ - на вопрос"; // ответ
        public  string question { get; set; } = "Вопрос - на который надо отвечать"; // вопрос

        public string dogName = "Unnamed";//  Свойство - значение будет занимать ячейку в столбике dogName
        public string DogName 
        {
            get { return dogName; }
            set
            {
                dogName = value;
                OnPropertyChanged("DogName");// триггеим событие - вызываем обновление во всех view событие
            }
        }
       
        // событие, которое уведомляет  viewModel и view о изменении
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
      
    }

    class Model : INotifyPropertyChanged
    {
        private ApplicationContext db;// контекст для работы с бд. Коллекция собак в нем

        public void AssembleNewDogs() // стандартный набор собак
        {
            //AddDog(new Dog { DogName = "Золотистый ретривер" });
            //AddDog(new Dog { DogName = "Волчья собака Сарлоса" });
            //AddDog(new Dog { DogName = "Шиба-ину" });
            //AddDog(new Dog { DogName = "Сибирский хаски" });
        }
       
        public List<Dog> Dogs() // метод возвращает текущее, коллекции собак
        {
            return this.db.Dogs.ToList<Dog>();
        }

        public void AddDog(Dog dog) // добавить
        {
            this.db.Dogs.Add(dog);
            Dogs_sync();
        }
        
        public void RemoveDog(Dog dog) // Удалить
        {
            this.db.Dogs.Remove(dog);
            Dogs_sync();
        }

        public void Dogs_sync() // Сохраняем изменения в бд
        {
            this.db.SaveChanges();
           //MessageBox.Show("Объекты сохранены");
            OnPropertyChanged("Dogs");// уведомляем отображение о изменении 
        }
       

        public Model()
        {   
            this.db = new ApplicationContext();// создаем контекст (сессию для работы с бд)
            this.AssembleNewDogs();
            Debug.WriteLine("Объектов в базе данных: "+this.db.Dogs.ToList<Dog>().Count.ToString());
        }
        // собираем список для вывода в ListBox
        public void RunQiz()
        {
            string s = "самый первый";
            Test test = new Test(s);
           
            OnPropertyChanged("RunQizTest");
        }


        public event PropertyChangedEventHandler PropertyChanged;// событие для уведомления вида пользователя
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
