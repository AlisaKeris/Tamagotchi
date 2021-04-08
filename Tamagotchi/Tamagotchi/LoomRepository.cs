using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Tamagotchi
{
    class LoomRepository
    {
        SQLiteConnection database;
        public LoomRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Loom>();
        }
        public IEnumerable<Loom> GetItems()
        {
            return database.Table<Loom>().ToList();
        }
        public Loom GetItem(int id)
        {
            return database.Get<Loom>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Loom>(id);
        }
        /*public int SaveItem(Loom item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }*/
    }
}
