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
            Room CaveEntrance = new Room("Cave Entrance", "Ash and his pokemon (Pikachu, Charmander, Bulbasuar & Squirtle) are camped out in a cave for the night. Team Rocket shows up and catches you off guard. They have captured Pikachu in a non-electrical cage. They created a smokescreen and run further into the cave. You chase after them but come across two entrances. Which do you take? [Left or Right]");
            Room CaveLeft = new Room("Cave Left", "You decide to go left and while running you trip over something. You take a look at it and it seems to be a little lump on the ground. You inspect it. It seems to be really hard and buried into the ground. You try to dig it out, but all of a sudden it pops up and a pokemon is right under it. It is a Diglett and on its head is a Master Pokeball. Diglett freaks out and starts running away with the Master Pokeball. Bulbasuar tries to block it before it gets away. You look in your backpack and you have [a berry, a Pokeball] What do you decide to do?");
            Room CaveOnyx = new Room("Cave Onyx", "Diglett happily eats the berry and you add the Master Pokeball into your backpack. You see Squirtle and Charmander rough housing and one of them gets knocked into a big rock on the side of the cave. All of a sudden the rock moves. It turns around and you are staring right into the face of Onyx. He does not look too happy. What do you want to do? [Fight Flee or Backpack].");
            Room CaveVileplum = new Room("Cave Vileplum", "Squirtle uses watergun on Onyx but that just makes him more angry and you and the rest of your pokemon hold on for dear life as Onyx boulders through the cave wall. You are all thrown off of Onyx and onto what seems like mushrooms.");
            Room CaveRight = new Room("Cave Right", "You decide to go right. It is very dark. You ask Charmander to lead the way with his tail. Charmander notices a rock glittering from the light from his tail. You go over to look what it is and you find a fire stone. [Pick up Item or Discard].");
            
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