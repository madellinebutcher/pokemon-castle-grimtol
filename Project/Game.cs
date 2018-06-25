using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }



        public bool Playing { get; set; }

        public void Setup()
        {
            Room CaveEntrance = new Room("Cave Entrance", "They created a smokescreen and disappears. You think they ran further into the cave and chase after them, but come across two entrances. Which do you take? [Left or Right]");
            Room CaveLeft = new Room("Cave Left", "You decide to go left and you trip over something. You take a look at it and it seems to be a little lump on the ground. You inspect it. It seems to be really hard and buried into the ground. You try to dig it out, but all of a sudden it pops up and a pokemon is right under it. It is a Diglett and on its head is a Master Pokeball. Diglett freaks out and starts running away with the Master Pokeball. Bulbasuar tries to block it before it gets away. You happen to have a berry and give it to Diglett. Do you want to follow it? [Forward or Back].");
            Room CaveOnyx = new Room("Cave Onyx", "Diglett happily eats the berry. You [Take Masterball] from the top of his head. Squirtle is teasing Charmander and makes him angry. Charmander uses flamethrower at Squirtle who dodges before being hit and Charmander's flamerthrower hit this huge rock instead. All of a sudden the rock moves. It turns around and you are staring right into the face of Onyx. He does not look too happy. All your pokemon are scared.[In your backpack you have Masterball or Forward(run) or Back(go)]. [Forward, Back]");
            Room CaveVileplum = new Room("Cave Vileplum", "Squirtle gets some spunk in him and he uses watergun on Onyx but that just makes him more angry. Onyx charges you and your pokemon. You all run away from Onyx and jump out of the way as Onyx boulders his way through the cave wall. You look into the new passage way and see all these mushrooms. Do you go [Forward or Back]");
            Room CaveJigglypuff = new Room("Cave Jigglypuff", "You walk through all the mushrooms slowly and notice that they are Vileplums. Bulbasaur touches one and a puff of sleeping powder was sprayed onto his face. You pick him up and notice a Jigglypuff standing on a rock. It smiles at you and starts to sing its song. You get groggy and everything turns black. When you come to all your pokemon are asleep around you and has marker drawings on their face. You seem to have some on your face too! Seems like Jigglypuff did not like you sleeping during her performance. You notice that there is a little Chesto Berry tree blooming next to the spring. You feed your pokemon the Chesto Berry and they start to wake up. You notice that there is another entrance to the spring, but there are two entrances [Left or Right]");
            Room TeamRocket = new Room("Team Rocket", "You took the left entrance and you see Team Rocket! You told Charmande to do flamethrower, Squirtle to do watergun and Bulbasaur to do razor leaf. The attacks hit Team Rocket and it dazes them for a bit. You run over and release Pikachu from its cage. You tell Pikachu to do Thunderbolt at Team Rocket. It was a direct hit and they go flying off! 'Looks like we are blasting off again'. Suddenly a little pokemon floats right on top of you and giggles. 'Mew' it says! What did you want to do? [Master Pokeball]");
            Room Nothing = new Room("Nothing", "You took the right entrance but there is no one there. You see lots of eyes appear above you! It seems like a whole collection of Noibats! Your pokemon can't see all the Noibats. What do you want to do? There doesn't seem to be an exit. [Go Back].");

            Room CaveRight = new Room("Cave Right", "You decide to go right. It is very dark. You ask Charmander to lead the way with his tail. The pokemon start to smell something. They lead you to a entrance to the left and there seems to be a stack of yummy berries behind a boulder. You let them eat some. Go [Left or Back].");

            //CaveEntrance
            CaveEntrance.Exits.Add("right", CaveRight);
            CaveEntrance.Exits.Add("left", CaveLeft);

            //CaveRight
            CaveRight.Exits.Add("left", CaveLeft);
            CaveRight.Exits.Add("back", CaveEntrance);

            //CaveLeft
            CaveLeft.Exits.Add("forward", CaveOnyx);
            CaveLeft.Exits.Add("back", CaveEntrance);

            //CaveOnyx
            CaveOnyx.Exits.Add("forward", CaveVileplum);
            CaveOnyx.Exits.Add("back", CaveLeft);

            //CaveVileplum
            CaveVileplum.Exits.Add("forward", CaveJigglypuff);
            CaveVileplum.Exits.Add("back", CaveOnyx);

            //CaveJigglypuff
            CaveJigglypuff.Exits.Add("left", TeamRocket);
            CaveJigglypuff.Exits.Add("right", Nothing);

            //Nothing
            Nothing.Exits.Add("back", CaveJigglypuff);

            //----------This section is for Items and what Room they are found in----------\\

            //CaveLeft
            Item Masterball = new Item("Masterball", "Can catch any pokemon. Save it for a rare one.");



            //Adding Items to rooms

            //CaveLeft
            CaveOnyx.Items.Add(Masterball);






            //room relationships add exits 
            //build items room relationships


            CurrentPlayer = new Player();
            CurrentRoom = CaveEntrance;
            Playing = true;
        }

        public void Guide()
        {
            Console.WriteLine("Type 'Help' to acces the game guide");
            Console.WriteLine("Type 'Left' to go Left");
            Console.WriteLine("Type 'Right' to go Right");
            Console.WriteLine("Type 'Forward' to go Forward");
            Console.WriteLine("Type 'Back' to go Back to the previous room you were in");
            Console.WriteLine("Type 'Take <ItemName>' to put item in your backpack");
            Console.WriteLine("Type 'Use <ItemName>' to go use items you have in your backpack");
        }

        //Player Command Inputs
        public void UserCommand()
        {
            string input = Console.ReadLine().ToLower();
            string input1 = input.Split(" ")[0];
            string input2 = "";
            if (input.Split(" ").Length > 1)
            {
                input2 = input.Split(" ")[1];
            }

            switch (input1.ToLower())
            {
                case "help":
                case "h":
                    Guide();
                    break;
                case "left":
                case "l":
                    Console.Clear();
                    CurrentRoom = CurrentRoom.ChangeRoom("left");
                    Look();
                    break;
                case "right":
                case "r":
                    Console.Clear();
                    CurrentRoom = CurrentRoom.ChangeRoom("right");
                    Look();
                    break;
                case "forward":
                case "f":
                    Console.Clear();
                    CurrentRoom = CurrentRoom.ChangeRoom("forward");
                    Look();
                    break;
                case "back":
                case "b":
                    Console.Clear();
                    CurrentRoom = CurrentRoom.ChangeRoom("back");
                    Look();
                    break;
                case "take":
                case "t":
                    TakeItem(input2);
                    break;
                case "use":
                case "u":
                    UseItem(input2);
                    break;
                case "reset":
                    Reset();
                    break;
            }

        }

        public void Play()
        {
            Guide();
            Console.Clear();
            Setup();
            //intro
            Console.WriteLine("Ash and his pokemon (Pikachu, Charmander, Bulbasuar & Squirtle) are camped out in a cave for the night.\n");
            Console.WriteLine("All of a sudden you hear the phrase that pricks your hairs up. 'Prepare for Trouble! And make it Double!'...\n");
            Console.WriteLine("You drown out the rest of what they say because you heard it enough in your lifetime or traveling to be a Pokemon Master. Team Rocket babbles on as they try to capture Pikachu!\n");
            Console.WriteLine("You did not see Meowth anywhere with Jesse and James. Out of nowhere Meowth grabs Pikachu with a device that looks to be a huge rubberhand. He carries Pikachu into a non-electrical cage.\n");

            Console.WriteLine(CurrentRoom.Description);

            while (Playing)
            {

                UserCommand();
                //input
                //action /SWITCH
            }

        }

        //----------This sets up how a player can pick up an item and add to inventory----------\\

        public void TakeItem(string itemName)
        {
            Item item = CurrentRoom.Items.Find(i => i.Name.ToLower().Contains(itemName));

            if (CurrentRoom.Items.Contains(item))
            {
                Console.WriteLine($"You picked up {item.Name}. You put it in your backpack. Throughout the game I will let you know what is in your backpack.");
                CurrentPlayer.Inventory.Add(item);
                CurrentRoom.Items.Remove(item);
            }
            else
            {
                Console.WriteLine("There is nothing to take in this room.");
            }
        }

        //----------This is for how a player uses and item from their inventory----------\\

        public void UseItem(string itemName)
        {
            Item item = CurrentPlayer.Inventory.Find(i => i.Name.ToLower().Contains(itemName));
            if (item != null)
            {
                if (itemName == "Masterball") NewMethod();
                {
                    CurrentPlayer.Masterball = !CurrentPlayer.Masterball;
                    CurrentPlayer.Inventory.Remove(item);
                }

                Console.WriteLine("You throw the master ball.\n");
                Console.WriteLine("CONGRATULATIONS YOU CAUGHT MEW!\n");
            }


            else
            {
                System.Console.WriteLine("You don't have that item in your inventory.\n");
            }

        }
        private static void NewMethod()
        {
            ;
        }

        public void Look()
        {

            Console.WriteLine(CurrentRoom.Description);

        }

        //Quit Game
        public void Quit()
        {

        }

        //Reset Game
        public void Reset()
        {
            Play();
        }

        //No need to Pass a room since Items can only be used in the CurrentRoom

    }
}