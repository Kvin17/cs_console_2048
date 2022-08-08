namespace cs_console_2048
{
     class Picture
    {
        public static int WIDTH = 24;
        public static int HEIGHT = 12;
        public ConsoleColor _pictureColor { get; set; } = ConsoleColor.Black;
        public string[] _picture { get; set; } = {
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
           "########################" };
        public Picture(string[] image, ConsoleColor color)
        {
            _pictureColor = color;
            _picture = image;
        }
        public Picture() { }
        public void PaintPicture(int x, int y)
        {
                    for (int i = 0; i < _picture.Length; i++)
                    {
                        Console.SetCursorPosition(x, y + i);
                        for (int j = 0; j < Picture.WIDTH; j++)
                        {
                            if (_picture[i][j] == '#')
                            {
                                Console.BackgroundColor = _pictureColor;
                                Console.ForegroundColor = _pictureColor;
                            }
                            Console.Write(_picture[i][j]);
                            Console.BackgroundColor = default;
                            Console.ForegroundColor = default;
                        }
                    }
        }

    }
}
