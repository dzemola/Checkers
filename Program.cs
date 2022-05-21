Console.Clear();

//Variables
int turnCount       = 0;
int blackCheckCount = 12;
int blueCheckCount  = 12;
ConsoleColor origForeColor = Console.ForegroundColor;
CheckerType[,] board = new CheckerType[8, 8];
ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.White, ConsoleColor.Black, ConsoleColor.DarkBlue };


//Change text color
Console.ForegroundColor = ConsoleColor.DarkMagenta;

Console.WriteLine("Welcome");
Console.WriteLine("\tto the");    
Console.WriteLine("\t\tMagical Game of");
Console.WriteLine("\t\t\t\tCheckers!");

//change text color
Console.ForegroundColor = origForeColor;

Console.WriteLine("\n\n\n\n\nPlayer 1 is the Black checker and will move first. \nPlayer 2 will be the Blue checker. \nPlease press any key to start the game.");
Console.ReadKey();

//Change background and text color
Console.BackgroundColor = ConsoleColor.DarkGray;
Console.ForegroundColor = ConsoleColor.Black;
Console.Clear();

//Set up board and start game
SetBoard();
PlayGame();

Console.ReadKey();


static string Prompt(string text)
{
    Console.Write(text);
    return Console.ReadLine();
}//end function

static int ConvertInt(string userInput)
{
    bool parsedSucessfully = false;
    int parsedValue        = 0;

    while (parsedSucessfully == false)
    {     
        parsedSucessfully = int.TryParse(userInput, out parsedValue);
    }//end while

    return parsedValue;
}//end function

void SetBoard()
{
    //Identify checker start locations
    StartCheckers(CheckerType.Black);
    StartCheckers(CheckerType.Blue);
    
    //Draw board with checker pieces
    DrawBoard();  
}

void DrawBoard()
{
    //Set grid
    Console.SetCursorPosition(0, 25);

    Console.WriteLine("   0      1      2      3      4      5      6      7  (x)");

    Console.SetCursorPosition(58, 1);
    Console.WriteLine(" 0");
    Console.SetCursorPosition(58, 4);
    Console.WriteLine(" 1");
    Console.SetCursorPosition(58, 7);
    Console.WriteLine(" 2");
    Console.SetCursorPosition(58, 10);
    Console.WriteLine(" 3");
    Console.SetCursorPosition(58, 13);
    Console.WriteLine(" 4");
    Console.SetCursorPosition(58, 16);
    Console.WriteLine(" 5");
    Console.SetCursorPosition(58, 19);
    Console.WriteLine(" 6");
    Console.SetCursorPosition(58, 22);
    Console.WriteLine(" 7");
    Console.SetCursorPosition(57, 24);
    Console.WriteLine(" (y)");

    //Variables
    int w    = 7;
    int h    = 3;
    bool Red = true;

    for (int col = 0; col < 8; col++)
    {
        for (int row = 0; row < 8; row++)
        {
            if (Red != false)
            {
                DrawRectangle(col * w, row * h, w, h, colors[0]);
                board[col,row] = CheckerType.Red;
                Red = false;
            }
            else if (Red != true)
            {
                DrawRectangle(col * w, row * h, w, h, colors[1]);
                Red = true;
            }

            if(board[col,row] == CheckerType.Black)
            {
                DrawChecker(col * w, row * h, ConsoleColor.Black, CheckerType.Black);
            }

            if (board[col, row] == CheckerType.BlackKing)
            {
                DrawChecker(col * w, row * h, ConsoleColor.Black, CheckerType.BlackKing);
            }
            if (board[col, row] == CheckerType.Blue)
            {
                DrawChecker(col * w, row * h, ConsoleColor.Blue, CheckerType.Blue);
            }
            if (board[col, row] == CheckerType.BlueKing)
            {
                DrawChecker(col * w, row * h, ConsoleColor.Blue, CheckerType.BlueKing);
            }
        }

        Red = !Red;
    }
    

}
void DrawRectangle(int xStart, int yStart, int width, int height, ConsoleColor color)
{
    //Store current  console color
    ConsoleColor origBackColor = Console.BackgroundColor;
    
    //Change color
    Console.BackgroundColor = color;
   
    //Variables
    int xend = xStart + width;
    int yend = yStart + height;

    for (int row = yStart; row < yend; row += 1)
    {
        for (int col = xStart; col < xend; col += 1)
        {
            Console.SetCursorPosition(col, row);
            Console.Write(" ");
        }
    }

    
    Console.BackgroundColor = origBackColor;
   
}

void StartCheckers(CheckerType checkerValue)
{
    //Variables
    int rowStart = 0;
    int rowEnd   = 0;
    int square   = 0;

    if (checkerValue == CheckerType.Black)
    {
        rowStart = 0;
        rowEnd   = 3;

        for (int row = rowStart; row < rowEnd; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                if (square % 2 == 1)
                {
                    board[col, row] = checkerValue;

                }
                square++;
            }

            square++;
        }
    }
    if (checkerValue == CheckerType.Blue)
    {
        rowStart = 5;
        rowEnd   = 8;

        for (int row = rowStart; row < rowEnd; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                if (square % 2 == 0)
                {
                    board[col, row] = checkerValue;

                }
                square++;
            }

            square++;
        }
    }
 

}

void DrawChecker(int xStart, int yStart, ConsoleColor color, CheckerType type)
{

    ConsoleColor origBackColor = Console.BackgroundColor;
    ConsoleColor origForeColor = Console.ForegroundColor;

    
    Console.BackgroundColor = color;

    if (type == CheckerType.Blue || type == CheckerType.Black)
    {
        for (int i = 1; i < board.GetLength(0); i++)
        {
            for (int j = 1; j < board.GetLength(1); j++)
            {

                Console.SetCursorPosition(xStart + 2, yStart + 1);
                Console.Write("   ");

            }

        }
    }
    if (type == CheckerType.BlueKing || type == CheckerType.BlackKing)
    {
        for (int i = 1; i < board.GetLength(0); i++)
        {
            for (int j = 1; j < board.GetLength(1); j++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(xStart + 2, yStart + 1);
                Console.Write(" ** ");

            }

        }
    }
    Console.ForegroundColor = origForeColor;
    Console.BackgroundColor = origBackColor;

}
void InputMove()
{
    int startX = 0;
    int startY = 0;
    int   endX = 0;
    int   endY = 0;
    bool validate = false;

    string move = Prompt("Player, input your move.   ");

    startX = ConvertInt("" + move[0]);
    startY = ConvertInt("" + move[1]);
    endX   = ConvertInt("" + move[3]);
    endY   = ConvertInt("" + move[4]);

    

    validate = MoveValidate(startX, startY, endX, endY);
   

    while (validate == false)
    {
        
        Console.Clear();
        DrawBoard();
        Console.SetCursorPosition(0, 27);
        move = Prompt("Illegal move! Player try agin. Please input your move.   ");

        startX = ConvertInt("" + move[0]);
        startY = ConvertInt("" + move[1]);
        endX = ConvertInt("" + move[3]);
        endY = ConvertInt("" + move[4]);

        validate = MoveValidate(startX, startY, endX, endY);

        
    }

    if (validate == true)
    {
        MovePiece(startX, startY, endX, endY);
        KingMe(endX, endY);
        Console.Clear();
        DrawBoard();
    }

}
void KingMe(int endX, int endY)
{
    int w = 7;
    int h = 3;

    if (turnCount % 2 == 1)
    {
        if(endY == 7)
        {
            board[endX, endY] = CheckerType.Empty;
            board[endX, endY] = CheckerType.BlackKing;
            DrawChecker(endX, endY, ConsoleColor.Black, CheckerType.BlackKing);
        }
    }
    if (turnCount % 2 == 0)
    {
        if (endY == 0)
        {
            board[endX, endY] = CheckerType.Empty;
            board[endX, endY] = CheckerType.BlueKing;
            DrawChecker(endX * w, endY * h, ConsoleColor.Blue, CheckerType.BlueKing);
        }
    }


}
void MovePiece(int startCol, int startRow, int endCol, int endRow)
{
    //Store piece at current location.
    CheckerType currentpiece = board[startCol, startRow];

    //Clear piece at start location
    board[startCol, startRow] = CheckerType.Empty;

    //Place piece at new location.
    board[endCol, endRow] = currentpiece;

    JumpCheck(startCol, startRow, endCol, endRow);
}
bool MoveValidate(int startX, int startY, int endX, int endY)
{
   //Variable
    bool valid = false;
    
    //Verify Player 1 move
    if(turnCount % 2 == 1)
    {
        //Validate black checker
        if (board[startX,startY] == CheckerType.Black && board[endX,endY] == CheckerType.Empty && endY > startY)
        {       
                valid = true;           
        }

        //Validate black king checker
        if (board[startX, startY] == CheckerType.BlackKing && board[endX, endY] == CheckerType.Empty)
        {
            valid = true;
        }
    }

    //Verify Player 2 move
    else if (turnCount % 2 == 0)
    {
        //Validate blue checker
        if (board[startX, startY] == CheckerType.Blue && board[endX, endY] == CheckerType.Empty && endY < startY)
        {
            valid = true;
        }
        //Validate blue king checker
        if (board[startX, startY] == CheckerType.BlueKing && board[endX, endY] == CheckerType.Empty)
        {
            valid = true;
        }
    }
    return valid;
}
void JumpCheck(int startX, int startY, int endX, int endY)
{
    int jumpX = (startX + endX) / 2;
    int jumpY = (startY + endY) / 2;
    
    if(turnCount % 2 == 1)
    {
        if (board[jumpX, jumpY] == CheckerType.Blue)
        {
            board[jumpX, jumpY] = CheckerType.Empty;
            blueCheckCount--;
        }
    }
    else if (turnCount % 2 == 0)
    {
        if (board[jumpX, jumpY] == CheckerType.Black)
        {
            board[jumpX, jumpY] = CheckerType.Empty;
            blackCheckCount--;
        }
    }


}
void PlayGame()
{
    //Variable   
    bool GameOver = false;
    
    while (!GameOver)
    {      
        Console.SetCursorPosition(0, 27);
        
        Console.WriteLine("Use the following format to move your piece. From colum row - To colum row (Ex. 12-03).");
        Console.WriteLine("Pieces can only move in a diagonal.");
        turnCount++;

        if (turnCount % 2 == 1)
        {
            Console.WriteLine("Player 1 it is your move.");
            InputMove();
            
        } 
        else if(turnCount % 2 == 0)
        {
            Console.WriteLine("Player 2 it is your move.");
            InputMove();
            
        }

        if(blackCheckCount == 0)
        {
            GameOver = true;
            Console.Clear();
            DrawBoard();
            Console.SetCursorPosition(0, 27);
            Console.WriteLine("Player 2 wins!!");
        }
        if (blueCheckCount == 0)
        {
            GameOver = true;
            Console.Clear();
            DrawBoard();
            Console.SetCursorPosition(0, 27);
            Console.WriteLine("Player 1 wins!!");
        }

    }
}
enum CheckerType
{
    Empty     = 0,
    Black     = 1,
    Blue      = 2,
    BlackKing = 3,
    BlueKing  = 4,
    Red       = 5,
}
