using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Tamagotchi
{
    [Table("Loomad")]
    public class Loom
    {
        
        /*[PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        
        public int Kullastus { get; set; }
        public int Room { get; set; }
        public int Tervis { get; set; }*/
        Random random = new Random();
        int Kullastus = 50;
        int Room = 50;
        int Tervis = 50;
        //повышаем значения
        public int Nakormit()
        {
            return Kullastus += 10;
        }
        public int Poigrat()
        {
            return Room += 10;
        }
        public int Vulechit()
        {
            return Tervis += 10;
        }
        //godmode
        public void Voskresit()
        {
            Tervis = 100;
            Kullastus = 100;
            Room = 100;
        }

        public string Checkstate()
        {
            switch (random.Next(0, 3))
            {
                case (1):
                    Tervis -= 10;
                    break;
                case (2):
                    Kullastus -= 10;
                    break;
                case (3):
                    Room -= 10;
                    break;
            }
            if (Kullastus == 0 || Room == 0 || Tervis == 0)
            {
                return "Мертв";
            }
            if (Kullastus < 20)
            {
                return "Голоден";
            }
            if (Tervis < 20)
            {
                return "Приболел";
            }
            if (Room < 20)
            {
                return "Грустный";
            }
            return "Здоров";
        }
        //получить значение
        public int Ztervis()
        {
            return Tervis;
        }
        public int Zkullastus()
        {
            return Kullastus;
        }
        public int Zroom()
        {
            return Room;
        }
    }
}
