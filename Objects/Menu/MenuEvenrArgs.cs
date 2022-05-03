using System;

namespace Objects.Menu
{
    class MenuEvenrArgs:EventArgs
    {
        int current;
        bool isChoice;

        public int Current
        {
            get { return current; }
            set { current = value; }
        }

        public bool IsChoice
        {
            get { return isChoice; }
            set { isChoice = value; }
        }

        public MenuEvenrArgs(int current)
        {
            this.current = current;
            isChoice = false;
        }
    }


}