using Maze.Library;
using System;
using System.Collections.Generic;

namespace Maze.Solver
{
   
    /// <summary>
    /// 
    /// </summary>
    
    public class RobotController
    {
        private IRobot robot;

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotController"/> class
        /// </summary>
        /// <param name="robot">Robot that is controlled</param>
        public RobotController(IRobot robot)
        {
            // Store robot for later use
            this.robot = robot;
        }

        /// <summary>
        /// Moves the robot to the exit
        /// </summary>
        /// <remarks>
        /// This function uses methods of the robot that was passed into this class'
        /// constructor. It has to move the robot until the robot's event
        /// <see cref="IRobot.ReachedExit"/> is fired. If the algorithm finds out that
        /// the exit is not reachable, it has to call <see cref="IRobot.HaltAndCatchFire"/>
        /// and exit.
        /// </remarks>
        public void MoveRobotToExit()
        {
            // Tip: It is generally considered bad coding style to use multiple empty
            // lines to structure code. Try to avoid that.


            backtracker(true);



            // Tip: Remove "dead" code before checking it in.
            /*

            // Trivial sample algorithm that can just move right
            var reachedEnd = false;
            robot.ReachedExit += (_, __) => reachedEnd = true;

            while (!reachedEnd)
            {
                robot.Move(Direction.Right);
            }

            */
        }



        // Tip: In C#, members should start with capital letters.
        private void backtracker(bool firstMove)
        {

            var reachedEnd = false;
            robot.ReachedExit += (_, __) => reachedEnd = true;

            var lastMove = Direction.Right;
          

           
            if(!reachedEnd)
            {
                if (robot.TryMove(Direction.Right) && (lastMove != Direction.Left ||firstMove))
                {

                    lastMove = Direction.Right;
                    backtracker(false);
                    
                }
                else if (robot.TryMove(Direction.Up) && (lastMove != Direction.Down || firstMove))
                {
                    lastMove = Direction.Up;
                    backtracker(false);
                    
                }
                else if (robot.TryMove(Direction.Left) && (lastMove != Direction.Right || firstMove))
                {
                    lastMove = Direction.Left;
                    backtracker(false);
                    
                }
                else if (robot.TryMove(Direction.Down) && (lastMove != Direction.Up || firstMove))
                {
                    lastMove = Direction.Down;
                    backtracker(false);
                    
                }

            }
            
        }
    }
}
