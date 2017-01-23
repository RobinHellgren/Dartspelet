using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart_Game {
    class Player {
        //Variable properties
        private string name;
        private bool isCmp;
        //List of all turns taken by player
        private List<Turn> plyrTurns = new List<Turn>();
        //player's personal gameboard (gameboard could be treated as a static class and make this unecesarry)
        private Gameboard gameBoard;
        //Getters
        public string getName() {
            return name;
            }
        public bool getIsCmp() {
            return isCmp;
            }
        public List<Turn> getPlayerList() {
            return plyrTurns;
            }
        public Gameboard getGameboard() {
            return gameBoard;
            }
        //Method for showing all turns seperatly
        public void displayTurns() {
            Console.WriteLine("Printing turns for " + name);
            int turnCounter = 0;
            foreach(Turn turn in plyrTurns) {
                turnCounter++;
                Console.WriteLine("========================================");
                Console.WriteLine("TURN " + turnCounter);
                for(int pointIndex = 0; pointIndex < 3; pointIndex++) {
                    Console.WriteLine(turn.getPoint(pointIndex));
                    }
                Console.WriteLine("=========================================");
                }
            Console.WriteLine("Point total: " + calcPoints());
            }
        //Method for calculating total points for player
        public int calcPoints() {
            int sum = 0;
            foreach(Turn turn in plyrTurns) {
                sum = (sum + turn.getScore());
                }
            return sum;
            }
        public void addTurn(Game game) {
 
            Console.WriteLine(name + " will now throw 3 arrows. The program will ask you for what point you're aiming for.");
            //Determine first arrow
            int arrow1 = gameBoard.genHit(this , game.getRng());
            //If this puts player over 301 points discard turn
            if((arrow1 + calcPoints()) > 301) {
                Console.WriteLine(name + " went over 301, passing your turn");
                if (getIsCmp() == false) {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    }
                plyrTurns.Add(new Turn(0, 0, 0));
                return;
                }
            //Tell player what point total they're at and determine second arrow
            Console.WriteLine(name + " point total is currently at " + (arrow1 + calcPoints()));
            int arrow2 = gameBoard.genHit(this, game.getRng());
            //If this puts player over 301 points discard turn
            if ((arrow1 + arrow2 + calcPoints()) > 301) {
                Console.WriteLine(name + " went over 301 points, passing your turn");
                if (getIsCmp() == false) {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    }
                plyrTurns.Add(new Turn(0, 0, 0));
                return;
                }
            //Tell player what point total they're at and determine third arrow
            Console.WriteLine(name + " point total is currently at " + (arrow1 + arrow2 + calcPoints()));
            int arrow3 = gameBoard.genHit(this, game.getRng());
            //If this puts player over 301 points discard turn
            if ((arrow1 + arrow2 + arrow3 + calcPoints()) > 301) {
                Console.WriteLine(name + " went over 301, passing your turn");
                if (getIsCmp() == false) {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    }
                plyrTurns.Add(new Turn(0, 0, 0));
                return;
                }
            //Add new turn
            plyrTurns.Add(new Turn(arrow1, arrow2, arrow3));
            //Tell player point total for this turn
            Console.WriteLine(name + " got " + (arrow1 + arrow2 + arrow3) + " points this turn");
            //Show player all turns aswell as total amount of points
            displayTurns();
            }
        //Constructor
        public Player(string name, bool isCmp) {
            this.name = name;
            this.isCmp = isCmp;
            this.gameBoard = new Gameboard();
            }

        }
    }
