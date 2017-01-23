using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dart_Game {
    class Gameboard {
        //Areas of the dartboard defined in this array
        static int[] boardAreas = new int[20] { 20, 1, 18, 4, 13, 6, 10, 15, 2, 17, 3, 19, 7, 16, 8, 11, 14, 9, 12, 5 };
        public int genHit(Player player ,Random rng) {
            //If the current player is a Computer player, don't ask for input
            if (player.getIsCmp()) {
                
                return rng.Next(1, 20);
                }
            else {
                //ask player what they're aiming for
                Console.WriteLine("What point are you aiming for? (only values between 1 and 20 is valid");
                int playerAiming;
                try {
                    playerAiming = Convert.ToInt32(Console.ReadLine());
                    //If player input is outside of the range on the board retry
                    if(playerAiming < 1 || playerAiming > 20) {
                        Console.WriteLine("The value wasn't between 1 and 20.");
                        genHit(player, rng);
                        }
                    //Convert player input to array index
                    for (int x = 0; x < boardAreas.Length; x++) {
                        if(boardAreas[x] == playerAiming) {
                            playerAiming = x;
                            }
                        }
                    //Generate random variance to aim
                    int rngResult = rng.Next(1, 101);

                    if (rngResult < 61) {
                        Console.WriteLine("You hit " + boardAreas[playerAiming]);
                        if (player.getIsCmp() == false) {
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            }

                        return boardAreas[playerAiming];
                        }
                    //Check variance against % chances of diffrent outcomes and adjust aim
                    else if(rngResult > 60 && rngResult < 76) {
                        playerAiming = +1;
                        if(playerAiming == 20) {
                            Console.WriteLine("You hit " + boardAreas[0]);
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            return boardAreas[0];
                            }
                        else {
                            Console.WriteLine("You hit " + boardAreas[playerAiming]);
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            return boardAreas[playerAiming];
                            }
                        }

                    else if(rngResult > 75 && rngResult < 91) {
                        playerAiming = -1;
                        if(playerAiming == -1) {
                            playerAiming = boardAreas[19];
                            Console.WriteLine("You hit " + boardAreas[playerAiming]);
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            return boardAreas[playerAiming];
                            }
                        else {
                            Console.WriteLine("You hit " + boardAreas[playerAiming]);
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            return boardAreas[playerAiming];
                            }
                        }

                    else if(rngResult > 90 && rngResult < 96) {
                        playerAiming = rng.Next(0, 20);
                        Console.WriteLine("You hit " + boardAreas[playerAiming]);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        return boardAreas[playerAiming];
                        }
                    else {
                        Console.WriteLine("You missed the dart board");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        return 0;
                        }
                    }
                //If player input can't be parsed retry
                catch {Console.WriteLine("Not a valid point to aim for."); return genHit(player, rng); }
                }
            }
           }
        }

