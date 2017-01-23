using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart_Game {
    class Turn {
        //array to store each individual arrow
       private int[] storedPoints;
        //constructor
        public Turn(int arrow1, int arrow2, int arrow3) {
            this.storedPoints = new int[3] { arrow1, arrow2, arrow3 };            
                }
        //getter method to fetch each individual arrow
        public int getPoint(int index) {
            return this.storedPoints[index];
            }
        //Sum all points from 1 turn
        public int getScore() {
            int sum = (storedPoints[0] + storedPoints[1] + storedPoints[2]);
            return sum;
            }
        }
    }
