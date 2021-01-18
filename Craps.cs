
//Author: Jordan Moss

using static System.Console;
namespace Craps
{
    class Craps
    {
        static void Main()
        {
            //declare variables
            int point = 0;              //holds the point once it is set. 
            int wager = 0;              //the amount that the player wants to wager.
            int sumOfDice = 0;          //the sum of the dice roll.
            int chips = 100;            //integer to hold the number of chips. Player starts out with 100.
            bool exit = false;          //when set to true, the game will end. Initialized to false.

            System.Random rng = new System.Random();        //Creates a Random object so random numbers can be generated.

            //Gives the user a chance to have the game instructions printed to the screen.
            WriteLine("Welcome to Craps! Would you like to learn how to play? [y/n]");
            char instructions = char.Parse(ReadLine());     //Reads the user's input as a string and parses it to a character.
            if (instructions == 'y')
                DisplayInstructions();                      //If the user enters 'y', the DisplayInstructions method will be called.

            //A do-while loop to make the game continue until the user runs out of chips or chooses to exit.
            do
            {
                WriteLine("Chips: {0}", chips);

                //A do-while loop to ensure the user inputs a valid amount to wager. Must be greater than or equal to one.
                do
                {
                    WriteLine("Please make a wager. Enter a number greater than zero.");
                    wager = int.Parse(ReadLine()); //Reads the user's input as a string and parses it to an integer.
                } while(wager < 1);

                //Generates and displays a random number between 2 and 12 to simulate rolling 2 six-sided dice.
                sumOfDice = rng.Next(2, 12);
                WriteLine("You rolled: {0}", sumOfDice);

                if (sumOfDice == 7 || sumOfDice == 11) //If the sum is 7 or 11, the player wins the round.
                {
                    chips += (wager * 2);   //the player's wager is doubled and added to their chip total.
                    WriteLine("You win! \n\tChips: {0}", chips);
                }
                else if (sumOfDice == 2 || sumOfDice == 3 || sumOfDice == 12) //if the sum is 2, 3, or 12, the player loses the round.
                {
                    chips -= wager; //the player's wager is removed from their chip total.
                    WriteLine("Sorry, you lose! \n\tChips: {0}", chips);
                }
                else //the dice sum becomes the point, and the player must roll the point again. They lose if they roll 7.
                {
                    point = sumOfDice;
                    WriteLine("This value has become the point. Roll until you make your point!");
                    ReadKey();

                    //A do-while loop to make the player keep rolling until they roll the point or 7.
                    do
                    {
                        sumOfDice = rng.Next(2, 12); //Rolls the dice again.
                        WriteLine("You rolled: {0}", sumOfDice);
                        
                        if (sumOfDice == point)     //If the player makes their point, they win the round.
                        {
                            chips += (wager * 2);   //the player's wager is doubled and added to their chip total.
                            WriteLine("You win! \n\tChips: {0}", chips);
                        }

                        if (sumOfDice == 7)         //If the player rolls 7, they lose the round.
                        {
                            chips -= wager;         //the player's wager is removed from their chip total.
                            WriteLine("Sorry, you lose! \n\tChips: {0}", chips);
                        }

                        ReadKey();
                    } while(sumOfDice != point && sumOfDice != 7);
                    
                }

                //If the player runs out of chips, it's game over. If they don't, they can choose to quit or keep playing.
                if (chips <= 0)
                    WriteLine("Sorry, you ran out of chips! Game over!");
                else
                {
                    WriteLine("Would you like to play another round? [y/n]");
                    char playAgain = char.Parse(ReadLine());    //Reads the user's input as a string and parses it to a character.
                    exit = (playAgain == 'y') ? false : true;   //If they don't enter 'y', exit is set to true and the game ends.
                }
                
            } while(!exit && chips > 0);

            WriteLine("Thank you for playing!");
        }

        static void DisplayInstructions()   //When called, the game instructions are printed to the screen.
        {
            WriteLine("HOW TO PLAY:"
                + "\n\tThe player rolls a pair of dice. If the sum is 7 or 11,"
                + "\n\tthey win. If the sum is 2, 3, or 12, they lose. If the "
                + "\n\tsum is another number, then it becomes the 'point'. The"
                + "\n\tplayer has to roll the dice until they make the point"
                + "\n\tagain. But if they roll 7, they lose!\n"

                + "\n\tThe player starts out with 100 chips. At the start of"
                + "\n\teach round, the player makes a wager.If they win the"
                + "\n\tround, they win double their wager. But if they lose,"
                + "\n\tthey lose their wager. The game ends when the player"
                + "\n\truns out of chips or chooses to stop playing.\n");
        }

    }
}
