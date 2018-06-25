using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
    public string Name { get;set; }
    public List<Item> Inventory { get;set; }
    public bool Masterball { get; internal set; }
    }
    

    

     
}