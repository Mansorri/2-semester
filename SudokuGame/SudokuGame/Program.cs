
//Лабораторна 10
//Варіант 8

//    Судоку.Зробити три різні види складності. Додати конструктор судоку. 
//    В конструкторі обов’язково перевіряти валідність створеного судоку.

//using System;

//class SudokuGame
//{
//    private const int SideLength = 9;
//    private static Random random = new Random();

//    public static int[,] GenerateSudoku(int emptyCells)
//    {
//        int[,] grid = new int[SideLength, SideLength];
//        FillGrid(grid);
//        RemoveNumbers(grid, emptyCells);
//        return grid;
//    }

//    private static bool FillGrid(int[,] grid)
//    {
//        for (int row = 0; row < SideLength; row++)
//        {
//            for (int col = 0; col < SideLength; col++)
//            {
//                if (grid[row, col] == 0)
//                {
//                    for (int num = 1; num <= SideLength; num++)
//                    {
//                        if (IsSafe(grid, row, col, num))
//                        {
//                            grid[row, col] = num;

//                            if (FillGrid(grid))
//                            {
//                                return true;
//                            }
//                            grid[row, col] = 0;
//                        }
//                    }
//                    return false;
//                }
//            }
//        }
//        return true;
//    }

//    private static bool IsSafe(int[,] grid, int row, int col, int num)
//    {
//        for (int x = 0; x < SideLength; x++)
//        {
//            if (grid[row, x] == num || grid[x, col] == num)
//            {
//                return false;
//            }
//        }

//        int startRow = row / 3 * 3, startCol = col / 3 * 3;
//        for (int i = 0; i < 3; i++)
//        {
//            for (int j = 0; j < 3; j++)
//            {
//                if (grid[startRow + i, startCol + j] == num)
//                {
//                    return false;
//                }
//            }
//        }
//        return true;
//    }

//    //Матриця з індексами елементів
//    //(0,0)(0,1)(0,2) (0,3)(0,4)(0,5) (0,6)(0,7)(0,8)
//    //(1,0)(1,1)(1,2) (1,3)(1,4)(1,5) (1,6)(1,7)(1,8)
//    //(2,0)(2,1)(2,2) (2,3)(2,4)(2,5) (2,6)(2,7)(2,8)

//    //(3,0)(3,1)(3,2) (3,3)(3,4)(3,5) (3,6)(3,7)(3,8)
//    //(4,0)(4,1)(4,2) (4,3)(4,4)(4,5) (4,6)(4,7)(4,8)
//    //(5,0)(5,1)(5,2) (5,3)(5,4)(5,5) (5,6)(5,7)(5,8)

//    //(6,0)(6,1)(6,2) (6,3)(6,4)(6,5) (6,6)(6,7)(6,8)
//    //(7,0)(7,1)(7,2) (7,3)(7,4)(7,5) (7,6)(7,7)(7,8)
//    //(8,0)(8,1)(8,2) (8,3)(8,4)(8,5) (8,6)(8,7)(8,8)
//    private static void RemoveNumbers(int[,] grid, int emptyCells)
//    {
//        int count = emptyCells;
//        while (count > 0)
//        {
//            int row = random.Next(0, SideLength);
//            int col = random.Next(0, SideLength);
//            if (grid[row, col] != 0)
//            {
//                grid[row, col] = 0;
//                count--;
//            }
//        }
//    }

//    private static void PrintInteractiveGrid(int[,] grid, int cursorRow, int cursorCol, bool[,] incorrectCells = null)
//    {
//        Console.Clear();
//        Console.WriteLine("Використовуйте стрілки для переміщення та цифри для заповнення клітинок.");
//        Console.WriteLine("Натисніть Enter, щоб перевірити розв'язок, або Esc для виходу.");
//        for (int row = 0; row < SideLength; row++)
//        {
//            for (int col = 0; col < SideLength; col++)
//            {

//                if (row == cursorRow && col == cursorCol)
//                {
//                    Console.BackgroundColor = ConsoleColor.DarkCyan;
//                }
//                if (incorrectCells != null && incorrectCells[row, col])
//                {
//                    Console.BackgroundColor = ConsoleColor.Red;
//                }
//                Console.Write(grid[row, col] == 0 ? ". " : $"{grid[row, col]} ");
//                Console.ResetColor();
//            }
//            Console.WriteLine();
//        }
//    }

//    public static void PlayGame(int[,] grid)
//    {
//        int cursorRow = 0, cursorCol = 0;
//        bool[,] incorrectCells = new bool[SideLength, SideLength];

//        Console.Clear();
//        PrintInteractiveGrid(grid, cursorRow, cursorCol, incorrectCells);

//        while (true)
//        {
//            Console.SetCursorPosition(0, SideLength + 2); 
//            Console.WriteLine("Керування:");
//            Console.WriteLine("Стрілки - переміщення, Enter - перевірка, Esc - вихід, 1-9 - заповнити клітинку.");

//            Console.SetCursorPosition(cursorCol * 2, cursorRow);

//            var key = Console.ReadKey(true);

//            if (key.Key == ConsoleKey.Escape)
//            {
//                Console.SetCursorPosition(0, SideLength + 5);
//                Console.WriteLine("Гру завершено.");
//                break;
//            }

//            if (key.Key == ConsoleKey.Enter)
//            {
//                if (CheckSolution(grid, incorrectCells) && !HasEmptyCells(grid))
//                {
//                    Console.SetCursorPosition(0, SideLength + 5);
//                    Console.WriteLine("\nВітаємо! Ви правильно розв'язали судоку.");
//                    break;
//                }
//                else
//                {
//                    Console.SetCursorPosition(0, SideLength + 5);
//                    Console.WriteLine("\nДеякі числа неправильні. Перевірте підсвічені клітинки.");
//                    Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
//                    Console.ReadKey(true);
//                }
//            }

//            switch (key.Key)
//            {
//                case ConsoleKey.UpArrow:
//                    cursorRow = Math.Max(0, cursorRow - 1);
//                    break;
//                case ConsoleKey.DownArrow:
//                    cursorRow = Math.Min(SideLength - 1, cursorRow + 1);
//                    break;
//                case ConsoleKey.LeftArrow:
//                    cursorCol = Math.Max(0, cursorCol - 1);
//                    break;
//                case ConsoleKey.RightArrow:
//                    cursorCol = Math.Min(SideLength - 1, cursorCol + 1);
//                    break;
//                default:
//                    if (char.IsDigit(key.KeyChar))
//                    {
//                        int num = int.Parse(key.KeyChar.ToString());
//                        if (num >= 1 && num <= SideLength)
//                        {
//                            if (grid[cursorRow, cursorCol] == 0)
//                            {
//                                grid[cursorRow, cursorCol] = num;
//                                Console.SetCursorPosition(cursorCol * 2, cursorRow);
//                                Console.Write(num);
//                            }
//                            else
//                            {
//                                Console.SetCursorPosition(0, SideLength + 5);
//                                Console.WriteLine("\nЦя клітинка вже заповнена. Натисніть будь-яку клавішу для продовження...");
//                                Console.ReadKey(true);
//                            }
//                        }
//                    }
//                    break;
//            }
//        }
//    }

//    private static bool HasEmptyCells(int[,] grid)
//    {
//        for (int row = 0; row < SideLength; row++)
//        {
//            for (int col = 0; col < SideLength; col++)
//            {
//                if (grid[row, col] == 0)
//                {
//                    Console.WriteLine("Матриця повністю не заповнена");
//                    return true;
//                }
//            }
//        }
//        return false;
//    }

//    private static bool CheckSolution(int[,] grid, bool[,] incorrectCells)
//    {
//        bool isValid = true;

//        for (int row = 0; row < SideLength; row++)
//        {
//            for (int col = 0; col < SideLength; col++)
//            {
//                incorrectCells[row, col] = false;
//                int num = grid[row, col];
//                if (num != 0)
//                {
//                    grid[row, col] = 0;
//                    if (!IsSafe(grid, row, col, num))
//                    {
//                        incorrectCells[row, col] = true;
//                        isValid = false;
//                    }
//                    grid[row, col] = num;
//                }
//            }
//        }
//        return isValid;
//    }

//    public static void Main()
//    {
//        Console.WriteLine("Оберіть рівень складності:");
//        Console.WriteLine("1. Легкий (20-30 порожніх клітинок)");
//        Console.WriteLine("2. Середній (31-45 порожніх клітинок)");
//        Console.WriteLine("3. Складний (46-64 порожніх клітинок)");
//        int emptyCells = 0;

//        switch (Console.ReadKey(true).Key)
//        {
//            case ConsoleKey.D1:
//                emptyCells = random.Next(20, 31);
//                break;
//            case ConsoleKey.D2:
//                emptyCells = random.Next(31, 46);
//                break;
//            case ConsoleKey.D3:
//                emptyCells = random.Next(46, 65);
//                break;
//            default:
//                Console.WriteLine("Некоректний вибір. Гру завершено.");
//                return;
//        }

//        int[,] sudoku = GenerateSudoku(emptyCells);
//        PlayGame(sudoku);
//    }
//}