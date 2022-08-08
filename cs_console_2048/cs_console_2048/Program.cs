namespace cs_console_2048
{
    class Program
    {
        static int WIN_SIZE = 4;
        public static Dictionary<int, Picture> pictures = new Dictionary<int, Picture>();
        public static bool InGame = true;
        static void Main()
        { 
            Console.SetWindowSize(WIN_SIZE*Picture.WIDTH+6,WIN_SIZE*Picture.HEIGHT+3);
            Console.BufferWidth = WIN_SIZE*Picture.WIDTH+7;
            Console.BufferHeight = WIN_SIZE*Picture.HEIGHT+4;
            Console.CursorVisible = false;
            Program app = new Program();
            while (true)
            {
                app.InitGame();
                //new Picture().PaintPicture(0,0);
                //Console.ReadLine();
                Tile[,] arr = new Tile[WIN_SIZE, WIN_SIZE];
                Tile[,] _oldMap = new Tile[WIN_SIZE, WIN_SIZE];
                for (int i = 0; i < WIN_SIZE; i++)
                {
                    for (int j = 0; j < WIN_SIZE; j++)
                    {
                        arr[i, j] = new Tile(true);
                        _oldMap[i, j] = new Tile(true);
                    }
                }

                arr[2, 3] = new Tile(2);
                arr[1, 3] = new Tile(2);
                _oldMap[2, 3] = new Tile(2);
                _oldMap[1, 3] = new Tile(2);

                while (!IsEnd(arr,_oldMap))
                {
                    app.DrawMap(arr);
                    app.MoveTile(arr);
                    app.Spawn(arr, _oldMap);
                    app.CopyMap(arr, _oldMap);
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(5, 5);
                Console.WriteLine("ploho");
                Console.ReadLine();
            }
        }
        void MoveTile(Tile[,] arrayMap)
        {
            Console.SetCursorPosition(1 * Picture.WIDTH + 1, 0);
            Console.ForegroundColor = ConsoleColor.Black;
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.W:
                    for (int y = 0; y < 4; y++)
                    { for (int j = 0; j < 4; j++)
                        {
                            for (int i = 1; i < 4; i++)
                            {
                                if (arrayMap[j, i]._nominal != 0 && arrayMap[j , i-1]._nominal == 0)
                                {
                                    arrayMap[j , i-1] = new Tile( arrayMap[j, i]._nominal);
                                    arrayMap[j, i] = new Tile(true);
                                }
                                else if (arrayMap[j, i]._nominal == arrayMap[j , i-1]._nominal)
                                {
                                    arrayMap[j, i - 1] = new Tile((arrayMap[j, i-1]._nominal * 2));
                                    arrayMap[j, i] = new Tile(true);                                  
                                }
                            }
                        }}
                    break;                   
                case ConsoleKey.S:
                    for (int y = 0; y < 4; y++)
                    {
                        for (int j = 0; j <4; j++)
                        {
                            for (int i = 2; i >=0; i--)
                            {
                                if (arrayMap[j,i]._nominal != 0 && arrayMap[j,i+1]._nominal == 0)
                                {
                                    arrayMap[j,i+1] = new Tile(arrayMap[j,i]._nominal);
                                    arrayMap[j ,i] = new Tile(true);
                                }
                                else if (arrayMap[j,i]._nominal == arrayMap[j,i+1]._nominal)
                                {                                  
                                    arrayMap[j,i+1] = new Tile((arrayMap[j,i]._nominal * 2));
                                    arrayMap[j, i] = new Tile(true);
                                }
                            }
                        }
                    }
                    break;
                case ConsoleKey.D:
                    for (int y = 0; y < 4; y++)
                    {
                        for (int j = 2; j >=0; j--)
                        {
                            for (int i = 0; i <4; i++)
                            {
                                if (arrayMap[j, i]._nominal != 0 && arrayMap[j+1, i]._nominal == 0)
                                {
                                    arrayMap[j+1, i] = new Tile(arrayMap[j, i]._nominal);
                                    arrayMap[j, i] = new Tile(true);
                                }
                                else if (arrayMap[j, i]._nominal == arrayMap[j+1, i ]._nominal)
                                {
                                    arrayMap[j+1, i] = new Tile((arrayMap[j, i]._nominal * 2));
                                    arrayMap[j, i] = new Tile(true);
                                }
                            }
                        }
                    }
                    break;
                case ConsoleKey.A:
                    for (int y = 0; y < 4; y++)
                    {
                        for (int j = 1; j < 4; j++)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                if (arrayMap[j, i]._nominal != 0 && arrayMap[j - 1, i]._nominal == 0)
                                {
                                    arrayMap[j - 1, i] = new Tile(arrayMap[j, i]._nominal);
                                    arrayMap[j, i] = new Tile(true);
                                }
                                else if (arrayMap[j, i]._nominal == arrayMap[j - 1, i]._nominal)
                                {
                                    arrayMap[j - 1, i] = new Tile((arrayMap[j - 1, i]._nominal * 2));
                                    arrayMap[j, i] = new Tile(true);
                                }
                            }
                        }
                    }
                    break;
            }
        }
        void DrawMap(Tile[,] arrayMap)
        { 
            Console.Clear();
            for (int i = 0; i < WIN_SIZE; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (arrayMap[i, j]._nominal != 0 )
                        arrayMap[i, j]._picture.PaintPicture(i * (Picture.WIDTH + 2), j * (Picture.HEIGHT + 1));
                    //Thread.Sleep(10);
                }
            }
        }
        void Spawn(Tile[,] map, Tile[,] oldMap)
        {
            int random;
            int x, y, value;
            int zerovalue = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (map[i,j]._nominal == 0)
                        zerovalue++;
            if (zerovalue != 0 && IsMoving(map, oldMap))
            {
                Random rand = new Random();
                while (true)
                {
                    x = rand.Next(0, 4);
                    y = rand.Next(0, 4);
                    if (map[x, y]._nominal == 0)
                    {
                        map[x, y] = new Tile(false);

                        break;
                    }
                }

            }
            else if (zerovalue == 0)
                InGame = false;
        }
        static bool IsMoving(Tile[,] map, Tile[,] OldMap)
        {
            int c = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (map[i,j]._nominal != OldMap[i,j]._nominal)
                        c++;
            return c > 0 ? true : false;
        }
        static bool IsEnd(Tile[,] map, Tile[,] oldMap)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((map[i,j]._nominal == map[i + 1,j]._nominal || map[i,j]._nominal == map[i,j + 1]._nominal) && !IsMoving(map,oldMap))
                        return false;

                }
                if (map[i,3]._nominal == map[i + 1,3]._nominal)
                    return false;
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (map[i,j]._nominal== 0)
                        return false;
                }
            }
            return true;
        }
        void CopyMap(Tile[,] map, Tile[,] oldMap)
        {
            for(int i = 0; i < WIN_SIZE; i++)
            {
                for(int j=0;j<WIN_SIZE;j++)
                {
                    oldMap[i, j] = new Tile(map[i, j]._nominal); 
                }
            }
        }
        void InitGame()
        {
            string[] pict = new string[] {
           "########################",
           "########################",
           "########################",
           "########################",
           "########################",
           "########################",
           "########################",
           "########################",
           "########################",
           "########################",
           "########################",
           "########################"};
            pictures.Add(0, new Picture(pict, ConsoleColor.Black));
            pict = new string[] {
           "########################",
           "##                    ##",
           "##       #########    ##",
           "##     ##        ##   ##",
           "##    ##         ##   ##",
           "##            ###     ##",
           "##         ###        ##",
           "##      ###           ##",
           "##    ##          #   ##",
           "##   ##############   ##",
           "##                    ##",
           "########################"};
            pictures.Add(2, new Picture(pict,ConsoleColor.Red));
            pict =new string[] { "########################",
           "##                    ##",
           "##             ##     ##",
           "##           #  #     ##",
           "##         #    #     ##",
           "##       #      #     ##",
           "##     #        #     ##",
           "##    #############   ##",
           "##              #     ##",
           "##              #     ##",
           "##                    ##",
           "########################"};
            pictures.Add(4, new Picture(pict,ConsoleColor.Magenta));
            pict = new string[] {
        "########################",
           "##                    ##",
           "##    ############    ##",
           "##  ##            ##  ##",
           "##  ##            ##  ##",
           "##    #####  #####    ##",
           "##    #####  #####    ##",
           "##  ##            ##  ##",
           "##  ##            ##  ##",
           "##    ############    ##",
           "##                    ##",
           "########################"};
            pictures.Add(8, new Picture(pict,ConsoleColor.White));
            pict = new string[] {
            "########################",
           "##                    ##",
           "##  ##    ##########  ##",
           "##  ##    ##          ##",
           "##  ##    ##          ##",
           "##  ##    ##########  ##",
           "##  ##    ##      ##  ##",
           "##  ##    ##      ##  ##",
           "##  ##    ##      ##  ##",
           "##  ##    ##########  ##",
           "##                    ##",
           "########################"};
            pictures.Add(16, new Picture(pict,ConsoleColor.Yellow));
            pict = new string[] {
           "########################",
           "##                    ##",
           "##   #####    #####   ##",
           "##  #    ##  #     #  ##",
           "##       ##       #   ##",
           "##     ###       #    ##",
           "##     ###      #     ##",
           "##       ##    #      ##",
           "##  #    ##   #    #  ##",
           "##   #####   ######   ##",
           "##                    ##",
           "########################"};
            pictures.Add(32, new Picture(pict, ConsoleColor.Blue));
            pict = new string[] {
           "########################",
           "##                    ##",
           "## ########      ###  ##",
           "## ##          ##  #  ##",
           "## ##         #    #  ##",
           "## ########  #     #  ##",
           "## ##    ## ######### ##",
           "## ##    ##       ##  ##",
           "## ##    ##       ##  ##",
           "## ########       ##  ##",
           "##                    ##",
           "########################"};
            pictures.Add(64, new Picture(pict, ConsoleColor.Cyan));
            pict = new string[] {
           "########################",
           "##                    ##",
           "##  #  #####   #####  ##",
           "## ## #     # #     # ##",
           "## ## #    #  #     # ##",
           "## ##     #     ###   ##",
           "## ##    #     #   #  ##",
           "## ##   #     #     # ##",
           "## ##  #    # #     # ##",
           "## ## ######   #####  ##",
           "##                    ##",
           "########################"};
            pictures.Add(128, new Picture(pict, ConsoleColor.DarkBlue));
            pict = new string[] {
           "########################",
           "##                    ##",
           "##  ####  ##### ##### ##",
           "## #    # ##    ##    ##",
           "##      # ##    ##    ##",
           "##     #  ##### ##### ##",
           "##    #      ## ## ## ##",
           "##   #       ## ## ## ##",
           "##  #   #    ## ## ## ##",
           "## #####  ##### ##### ##",
           "##                    ##",
           "########################"};
            pictures.Add(256, new Picture(pict, ConsoleColor.DarkCyan));
            pict = new string[] {
           "########################",
           "##                    ##",
           "## ######  #  ######  ##",
           "## ##     ## #      # ##",
           "## ##     ## #     #  ##",
           "## ###### ##      #   ##",
           "##     ## ##     #    ##",
           "##     ## ##    #     ##",
           "##     ## ##  ##    # ##",
           "## ###### ## #######  ##",
           "##                    ##",
           "########################"};
            pictures.Add(512, new Picture(pict, ConsoleColor.DarkGray));
            pict = new string[] {
           "########################",
           "##                    ##",
           "##  #  ###  ### #   # ##",
           "## ## #   # # # #   # ##",
           "## ## #   # # # #   # ##",
           "## ##     # # # #   # ##",
           "## ##    #  # # ##### ##",
           "## ##   #   # #     # ##",
           "## ##  #  # # #     # ##",
           "## ## ####  ###     # ##",
           "##                    ##",
           "########################"};
            pictures.Add(1024, new Picture(pict, ConsoleColor.DarkGreen));
            pict = new string[] {
           "########################",
           "##                    ##",
           "##  ##  ### # #  ###  ##",
           "## #  # # # # # #   # ##",
           "## #  # # # # # #   # ##",
           "##    # # # # #  ###  ##",
           "##   #  # # ### #   # ##",
           "##  #   # #   # #   # ##",
           "## #  # # #   # #   # ##",
           "## ###  ###   #  ###  ##",
           "##                    ##",
           "########################"};
            pictures.Add(2048, new Picture(pict, ConsoleColor.DarkMagenta));
            pict = new string[] {
           "########################",
           "##                    ##",
           "## # # ### #### ##### ##",
           "## # # # # #  # #     ##",
           "## # # # # #  # #     ##",
           "## # # # # #  # ##### ##",
           "## ### # # #### #   # ##",
           "##   # # #    # #   # ##",
           "##   # # #    # #   # ##",
           "##   # ### #### ##### ##",
           "##                    ##",
           "########################"};
            pictures.Add(4096, new Picture(pict, ConsoleColor.DarkRed));
        }
    }
}