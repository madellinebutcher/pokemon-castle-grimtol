using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
       public  string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }

        public Dictionary<string, Room> Exits { get; set; }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
            Exits = new Dictionary<string, Room>();
        }

        public void addItem(Item item)
        {
            Items.Add(item);
        }

        public void UseItem(Item item)
        {

        }

        public Room ChangeRoom(string direction)
       {
           if (Exits.ContainsKey(direction))
           {
               return Exits[direction];
           }
           System.Console.WriteLine("Invalid Direction");
           return this;
       }

    }
}