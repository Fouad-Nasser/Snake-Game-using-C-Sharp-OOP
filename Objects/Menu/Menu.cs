using System;
using System.Collections.Generic;


namespace Objects.Menu
{
    
    class Menu
    {
        public event EventHandler<MenuEvenrArgs> PressEnter;
        MenuEvenrArgs menu;
        int curr;
        List<string> menuItems;
        ConsoleColor hBackColor;
        ConsoleColor hForeColor;
        ConsoleColor backColor;
        ConsoleColor foreColor;
        int x;
        int y;
        public int Curr
        {
            get { return curr; }
        }

        public Menu(List<string> _menuItems,ConsoleColor _hBackColor,ConsoleColor _hForeColor,ConsoleColor _backColor,ConsoleColor _foreColor,int _x,int _y)
        {
            PressEnter = OnPressEnter;
            menuItems = _menuItems;
            hBackColor = _hBackColor;
            hForeColor = _hForeColor;
            backColor = _backColor;
            foreColor = _foreColor;
            x = _x;
            y = _y;
            curr = 0;
             menu = new MenuEvenrArgs(curr);
        }

        
        public Menu(List<string> _menuItems, ConsoleColor _hBackColor, ConsoleColor _hForeColor, int _x, int _y)
            : this(_menuItems, _hBackColor, _hForeColor,ConsoleColor.Black,ConsoleColor.White,_x,_y)
        {
            
        }

        private void Draw()
        {
            for(int i=0; i < menuItems.Count;i++)
            {
                Console.SetCursorPosition(x, y+i);
                if(i==menu.Current)
                {
                    Console.BackgroundColor = hBackColor;
                    Console.ForegroundColor = hForeColor;
                }
                else
                {
                    Console.BackgroundColor = backColor;
                    Console.ForegroundColor = foreColor;
                }
                Console.Write(menuItems[i]);
            }
        }

        public void show()
        {
            ConsoleKeyInfo cki;
            
            do
            {
                Draw();
                cki = Console.ReadKey();
                switch(cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        menu.Current--;
                        if (menu.Current < 0)
                        {
                            menu.Current = menuItems.Count - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                       menu.Current++;
                       if (menu.Current == menuItems.Count)
                        {
                            menu.Current = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        PressEnter(this,menu);
                        break;
                    case ConsoleKey.Escape:
                        menu.IsChoice = true;
                        break;
                    case ConsoleKey.Home:
                        menu.Current = 0;
                        break;
                    case ConsoleKey.End:
                        menu.Current = menuItems.Count - 1;
                        break;
                }
            } while (!menu.IsChoice);
        }

        private void OnPressEnter(object sender, MenuEvenrArgs e)
        {
            
        }

    }
}
