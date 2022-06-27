using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkAmnestyCriminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Prison prison = new Prison();
            Console.WriteLine("Список преступников до амнистии.");
            prison.ShowAllCriminals();
            Console.WriteLine("\nВ нашей великой стране Арстоцка произошла амнистия!");
            prison.HoldAmnesty();
            Console.WriteLine("\nСписок преступников после амнистии.");
            prison.ShowAllCriminals();
            Console.ReadLine();
        }
    }

    class Prison
    {
        private List<Criminal> _criminals = new List<Criminal>();

        public Prison()
        {
            CreateList();
        }

        public void HoldAmnesty()
        {
            _criminals = _criminals.Where(people => people.Crime != "Антиправительственное").ToList();
        }

        public void ShowAllCriminals()
        {
            foreach (Criminal criminal in _criminals)
            {
                criminal.ShowInfo();
            }
        }

        private void CreateList()
        {
            _criminals.Add(new Criminal("Евгений", "Рыкавец", "Анатольевичь", "Убийсвто"));
            _criminals.Add(new Criminal("Кирилл", "Фидотов", "Андреевичь", "Взятничество"));
            _criminals.Add(new Criminal("Игорь", "Зайцев", "Петровичь", "Антиправительственное"));
            _criminals.Add(new Criminal("Евгений", "Мухавец", "Дмитриевичь", "Воровство"));
            _criminals.Add(new Criminal("Дмитрий", "Бухавец", "Дмитриевичь", "Воровство"));
        }
    }

    class Criminal
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public string  Crime { get; private set; }

        public Criminal(string name, string surname, string patronymic, string crime)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Crime = crime;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ФИО : {Name} {Surname} {Patronymic} | Преступление -  {Crime}|");
        }
    }
}
