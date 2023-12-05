using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Master_3_
{
    internal class Program
    {
        static char[,] playField =
        {
            {'1','2','3' },
            {'4','5','6' },
            {'7','8','9' }
        };
       


        static int roundCounter = 0;

        static void Main(string[] args)
        {
            int player = 2; //Player1 starts
            int input = 0;
            bool inputCorrect = true;

            

            

            do
            {
                


                if (player == 2)
                {
                    player = 1;
                    CheckXorO(player, input);
                    
                }
                else if (player == 1)
                {
                    player = 2;
                    CheckXorO(player, input);
                    
                }
                SetField();

                #region
                //Winning condition
                char[] playerChars = { 'X', 'O' };
                foreach (char playerchar in playerChars)
                {
                    if (((playField[0, 0] == playerchar) && (playField[0, 1] == playerchar) && (playField[0, 2] == playerchar))
                        || ((playField[1, 0] == playerchar) && (playField[1, 1] == playerchar) && (playField[1, 2] == playerchar))
                        || ((playField[2, 0] == playerchar) && (playField[2, 1] == playerchar) && (playField[2, 2] == playerchar))
                        || ((playField[0, 0] == playerchar) && (playField[1, 0] == playerchar) && (playField[2, 0] == playerchar))
                        || ((playField[0, 1] == playerchar) && (playField[1, 1] == playerchar) && (playField[2, 1] == playerchar))
                        || ((playField[0, 2] == playerchar) && (playField[1, 2] == playerchar) && (playField[2, 2] == playerchar))
                        || ((playField[0, 0] == playerchar) && (playField[1, 1] == playerchar) && (playField[2, 2] == playerchar))
                        || ((playField[0, 2] == playerchar) && (playField[1, 1] == playerchar) && (playField[2, 0] == playerchar)))
                    {
                        if (playerchar == 'X')
                        {
                            Console.WriteLine("Player 2 WON the game!");
                            
                        }
                        else if (playerchar == 'O')
                        {
                            Console.WriteLine("Player 1 WON the game!");
                            
                        }
                       
                        Console.WriteLine("Press any Key to reset the game");
                        Console.ReadKey();
                        ResetField();
                        break;

                       

                    }
                    else if (roundCounter == 10)
                    {
                        Console.WriteLine("There is no winner , Its a Draw!");
                        Console.WriteLine("Press any Key to reset the game");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }




                }
                #endregion
                #region
                //Check if the field is already taken
                do
                {
                    
                    Console.Write("\nPlayer {0}: Choose your field!" , player);
                    try
                    {
                        input = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid input!");
                    }
                    if ((input == 1) && (playField[0, 0] == '1'))
                        inputCorrect = true;
                    else if (input == 2 && playField[0, 1] == '2')
                        inputCorrect = true;
                    else if (input == 3 && playField[0, 2] == '3')
                        inputCorrect = true;
                    else if (input == 4 && playField[1, 0] == '4')
                        inputCorrect = true;
                    else if (input == 5 && playField[1, 1] == '5')
                        inputCorrect = true;
                    else if (input == 6 && playField[1, 2] == '6')
                        inputCorrect = true;
                    else if (input == 7 && playField[2, 0] == '7')
                        inputCorrect = true;
                    else if (input == 8 && playField[2, 1] == '8')
                        inputCorrect = true;
                    else if (input == 9 && playField[2, 2] == '9')
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("Incorrect input! Please use another field!");
                        inputCorrect = false;
                    }
                    
                } while (!inputCorrect);
                #endregion

               

            } while (true);
            
            


        }
        public static void SetField()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", playField[0, 0], playField[0, 1], playField[0,2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |    ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", playField[1,0], playField[1,1], playField[1,2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", playField[2,0], playField[2,1], playField[2,2]);
            Console.WriteLine("     |     |     ");
            roundCounter++;

        }
        public static void CheckXorO(int player, int input)
        {
            char PlayerSign = ' ';
            if (player == 1)
                PlayerSign = 'X';
            else if (player == 2)
                PlayerSign = 'O';

            switch(input)
            {
                case 1: playField[0, 0] = PlayerSign; break;
                case 2: playField[0, 1] = PlayerSign; break;
                case 3: playField[0, 2] = PlayerSign; break;
                case 4: playField[1, 0] = PlayerSign; break;
                case 5: playField[1, 1] = PlayerSign; break;
                case 6: playField[1, 2] = PlayerSign; break;
                case 7: playField[2, 0] = PlayerSign; break;
                case 8: playField[2, 1] = PlayerSign; break;
                case 9: playField[2, 2] = PlayerSign; break;

            }
        }
        public static void ResetField()
        {
            char[,] resetedPlayField =
            {
             {'1','2','3' },
             {'4','5','6' },
             {'7','8','9' }
            };
            playField = resetedPlayField;
            SetField();
            roundCounter = 0;
            
        }
    }
}
