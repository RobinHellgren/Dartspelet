using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart_Game {
    class Game {
        //List to contain players
        private List<Player> playerList;
        //Instance of Random to generate random numbers
        private Random rng;
        //Bool for main gameplay loop
        private bool gameRunning;
        //Getters
        public List<Player> getPlayerList() {
            return playerList;
            }
        public Random getRng() {
            return rng;
            }
        //Constructor
        public Game() {
            this.playerList = new List<Player>();
            this.rng = new Random();
            }
        public void addPLayer() {
            //Define variables
            string userInputName;
            ConsoleKey userInputIsCmp;
            bool isCmp = false;
            //Ask player for name
            Console.WriteLine("What is the new players name?");
            userInputName = Console.ReadLine();
            //Ask if player is controlled by the computer
            Console.WriteLine("Is the new player human or controlled by the computer? Press C or P for you answer.");
            userInputIsCmp = Console.ReadKey().Key;

            if (userInputIsCmp == ConsoleKey.C) {
                isCmp = true;
                }
            else if (userInputIsCmp == ConsoleKey.P) {
                isCmp = false;
                }
            //If answer is outside of expected input retry
            else {
                Console.WriteLine("The answer is not valid, answer with only 'y' or 'n'");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                addPLayer();
                }

            playerList.Add(new Player(userInputName, isCmp));
            }
        public void playGame() {
            gameRunning = true;
            Console.WriteLine("Explanation of game");
            ConsoleKey playerInput;
            do {
                //Ask if player wants to add more players
                Console.WriteLine("Do you want to add another player? Answer by pressing y or n.");
                playerInput = Console.ReadKey().Key;

                if (playerInput == ConsoleKey.Y) {
                    addPLayer();
                    }
                else if(playerInput == ConsoleKey.N) {

                    }
                else {
                    Console.WriteLine("Invalid input, try again");
                    playerInput = ConsoleKey.Y;
                    }
                } while (playerInput == ConsoleKey.Y);
            //Main play loop
            do {
                //Have all players take turns
                    foreach(Player player in playerList) {
                        player.addTurn(this);
                        //If player end up with exactly 301 points immedietly end the game and announce winner
                        if (player.calcPoints() == 301) {
                            Console.WriteLine(player.getName() + " have won!");
                            gameRunning = false;
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        //Break to stop players taking turns 
                        break;
                            }
                        }
                } while (gameRunning);
            }
        }
    }
