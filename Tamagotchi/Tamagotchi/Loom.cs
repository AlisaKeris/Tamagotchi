using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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
        
        int Kullastus = 100;
        int Room = 100;
        int Tervis = 100;
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
            Random random = new Random();
            if (random.Next(0, 2) == 0)
            {

                Tervis -= 10;


            }
            if (random.Next(0, 2) == 1)
            {
                Kullastus -= 10;
            }
            if (random.Next(0, 2) == 2)
            {
                Room -= 10;
            }
            if (Kullastus == 0 ||  Tervis == 0)
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
