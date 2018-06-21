using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
       public Player CurrentPlayer { get; set; }

        public bool Playing {get; set;}

        public void Setup()
        {
            Room CaveEntrance = new Room("Cave Entrance", "Ash and his pokemon (Pikachu, Charmander, Bulbasuar & Squirtle) are camped out in a cave for the night. Team Rocket shows up and catches you off guard. They have captured Pikachu in a non-electric cage and runs further into the cave. You chase after them but come across two entrances. Which do you take? [Left or Right]");
            Room CaveLeft = new Room("Cave Left", "You decide to go left and while running you trip over something. You take a look at it and it seems to be a little lump on the ground. It starts to move and it pops out. It is a Diglet! You made it very angry! Bulbasuar tries to calm it down, but Diglet is not happy. Diglet shrieks and more little lumps start popping out of the ground. More Diglets show up! The Diglets start charging at you and they used DIG. You, Bulbasuar, Charmander and Squirtle fall into hole. Something hits you on top of your head. It looks like a Master Pokeball. [Pick up Item or Discard].");
            Room CaveRight = new Room("Cave Right", "You decide to go right. It is very dark. You ask Charmander to lead the way with his tail. Charmander notices a rock glittering from the light from his tail. You go over to look what it is and you find a fire stone. [Pick up Item or Discard].");
            Room CaveBelow = new Room("Cave Below", "The ground you fell on started to move and you realize you are on top of an Onyx. [Fight or Use Master Pokeball].");
            Room CaveVileplum = new Room("Cave Vileplum", "Squirtle uses watergun on Onyx but that just makes him more angry and you and the rest of your pokemon hold on for dear life as Onyx boulders through the cave wall. You are all thrown off of Onyx and onto what seems like mushrooms.");
            //room relationships add exits 
            //build items room relationships
        

            CurrentPlayer = new Player();
            CurrentRoom = CaveEntrance;
            Playing = true;
        }

        public void Play()
        {
            //intro
            Setup();
            while (Playing)
            {
                //input
                //action /SWITCH
            }

        }
        public void Reset()
        {
            Setup();
        }

        //No need to Pass a room since Items can only be used in the CurrentRoom
        public void UseItem(string itemName)
        {

        }
    }
}