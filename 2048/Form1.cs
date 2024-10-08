namespace _2048
{
    public partial class Form1 : Form
    {
        private Button[,] cells; private int[,] number = new int[4, 4];
        private Random random = new Random(); public Form1()
        {
            InitializeComponent();
            cells = new Button[,]{
                {button1 ,button2 ,button3 ,button4 } ,
                { button5 ,button6 ,button7 ,button8 } ,
                {button9 ,button10 ,button11 ,button12} ,
                { button13 ,button14 ,button15 ,button16}
            }; for (int i = 0; i < number.GetLength(0); i++)
            {
                for (int j = 0; j < number.GetLength(1); j++)
                {
                    number[i, j] = 0;
                }
            }
        }
        private void StartNewGame()
        {
            number = new int[4, 4]; NewPlit();
        }
        private void NewPlit()
        {
            int x, y; do
            {
                x = random.Next(0, 4);
                y = random.Next(0, 4);
            } while (number[x, y] != 0);
            number[x, y] = random.Next(1, 3) * 2;
        }
        private void Show()
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j].Text = number[i, j].ToString(); if (cells[i, j].Text == "0")
                    {
                        cells[i, j].Text = "";
                    }
                }
            }
        }
        private void ButtonUp()
        {
            Show();
        }
        private void newNumbew(int n = 0)
        {
        }
        private void move(int x, int y)
        {
            bool moved = false;

            if (x == -1) // Up
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        if (number[i, j] != 0)
                        {
                            int target = i;
                            while (target > 0 && (number[target - 1, j] == 0 || number[target - 1, j] == number[i, j]))
                            {
                                if (number[target - 1, j] == number[i, j])
                                {
                                    number[target - 1, j] *= 2;
                                    number[i, j] = 0;
                                    moved = true;
                                    break; 
                                }
                                else
                                {
                                    number[target - 1, j] = number[target, j];
                                    number[target, j] = 0;
                                    moved = true;
                                }
                                target--;
                            }
                        }
                    }
                }
            }
            else if (x == 1) // Down
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 2; i >= 0; i--)
                    {
                        if (number[i, j] != 0)
                        {
                            int target = i;
                            while (target < 3 && (number[target + 1, j] == 0 || number[target + 1, j] == number[i, j]))
                            {
                                if (number[target + 1, j] == number[i, j])
                                {
                                    number[target + 1, j] *= 2;
                                    number[i, j] = 0;
                                    moved = true;
                                    break;
                                }
                                else
                                {
                                    number[target + 1, j] = number[target, j];
                                    number[target, j] = 0;
                                    moved = true;
                                }
                                target++;
                            }
                        }
                    }
                }
            }
            else if (y == -1) // Left
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 1; j < 4; j++)
                    {
                        if (number[i, j] != 0)
                        {
                            int target = j;
                            while (target > 0 && (number[i, target - 1] == 0 || number[i, target - 1] == number[i, j]))
                            {
                                if (number[i, target - 1] == number[i, j])
                                {
                                    number[i, target - 1] *= 2;
                                    number[i, j] = 0;
                                    moved = true;
                                    break; 
                                }
                                else
                                {
                                    number[i, target - 1] = number[i, target];
                                    number[i, target] = 0;
                                    moved = true;
                                }
                                target--;
                            }
                        }
                    }
                }
            }
            else if (y == 1) // Right
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 2; j >= 0; j--)
                    {
                        if (number[i, j] != 0)
                        {
                            int target = j;
                            while (target < 3 && (number[i, target + 1] == 0 || number[i, target + 1] == number[i, j]))
                            {
                                if (number[i, target + 1] == number[i, j])
                                {
                                    number[i, target + 1] *= 2;
                                    number[i, j] = 0;
                                    moved = true;
                                    break; 
                                }
                                else
                                {
                                    number[i, target + 1] = number[i, target];
                                    number[i, target] = 0;
                                    moved = true;
                                }
                                target++;
                            }
                        }
                    }
                }
            }

            if (moved)
            {
                newNumber(); 
                Show(); 
            }
        }
        private void newNumber(int n = 0)
        {
            int x = new Random().Next(4); int y = new Random().Next(4);
            if (number[x, y] == 0)
            {
                number[x, y] = 2; return;
            }
            if (n > 100)
            {
                MessageBox.Show("Game over");
                return;
            }
            newNumber(n + 1);
        }
       

        private void button20_Click_1(object sender, EventArgs e)
        {
            

            move(0, -1);
            newNumber();
            Show();
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            move(0, 1);
            newNumber();
            Show();
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            move(0, -1);
            newNumber();
            Show();

        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            move(1, 0);
            newNumber();
            Show();
        }
    }

}



