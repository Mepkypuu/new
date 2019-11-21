using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace РГР
{
    public struct Data
    {
        public string name;
        public int c;
        public string date1;
       // public string time1;
    }
    public partial class Form1 : Form
    {
        

        Form2 form2;
        Form3 form3;

        Point[] snake;
        Point apple;
        int count;
        int length; // for snake
        int direction; // 1 up, 2 down, 3 left, 4 right

        Random random = new Random(DateTime.Now.Millisecond);

        Queue<int> inputKeys = new Queue<int>();

        public Form1()
        {
            InitializeComponent();
        }
        public static Data ReadOneStruct(StreamReader reader)
        {
            Data s = new Data();
           
                s.name = reader.ReadLine();
                s.c = int.Parse(reader.ReadLine());
                s.date1 = reader.ReadLine();
              //  s.time1 = reader.ReadLine();
                
            return s;
        }
        public static List<Data> ReadAllFile(StreamReader reader)
        {
            List<Data> list = new List<Data>();
            while (!reader.EndOfStream)
            {
                list.Add(ReadOneStruct(reader));
            }
            return list;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Setup();
        }

        //игровый цикл
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Input();
            _Update();
            Draw();
        }

        //начальная установка
        void Setup()
        {
            label1.Text = "0";
            length = 5;
            count = 0;
            timer1.Interval = 200;
            snake = new Point[200];
            for (int i = 0; i < length; i++)
            {
                snake[i].X = 100;
                snake[i].Y = 100 + i * 10;
            }

            direction = 1;
            apple.X = 10;
            apple.Y = 10;
           // label4.Visible = false;
           // label3.Visible = false;
        }
        
        //обработка ввода
        void Input()
        {
            //пока есть необработанные клавиши
            while (inputKeys.Count > 0)
            {
                int key = inputKeys.Dequeue();//получить одну клавишу и обработать
                if (key == 1 && direction == 2) //движемся вверх, но смотрим вниз
                {
                    continue;
                }
                else if (key == 2 && direction == 1) //движемся вниз, но смотрим вверх
                {
                    continue;
                }
                else if (key == 3 && direction == 4) //движемся вверх, но смотрим вниз
                {
                    continue;
                }
                else if (key == 4 && direction == 3) //движемся вверх, но смотрим вниз
                {
                    continue;
                }

                direction = key;
            }
        }

        //обработка данных
        void _Update()
        {
            //Shift Snake
            for (int i = 198; i >= 0; i--)
            {
                snake[i + 1].X = snake[i].X;
                snake[i + 1].Y = snake[i].Y;
            }

            if (direction == 1)
            {
                snake[0].X = snake[1].X;
                snake[0].Y = snake[1].Y - 10; // 10 - one step
                if (snake[0].Y == 0)
                {
                    timer1.Enabled = false; // changes
                    MessageBox.Show("Game Over!");

                    if (form2 == null || form2.IsDisposed)
                    {
                        form2 = new Form2(label1);
                        form2.Show();
                    }
                   

                   // label4.Visible = true;
                   // label3.Visible = true;

                  //  complete.Enabled = false;
                   // stop.Enabled = false;

                }
            }

            if (direction == 2)
            {
                snake[0].X = snake[1].X;
                snake[0].Y = snake[1].Y + 10; // 10 - one step
                if (snake[0].Y >= panel1.Height)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Game Over!");
                    if (form2 == null || form2.IsDisposed)
                    {
                        form2 = new Form2(label1);
                        form2.Show();
                    }
                   /* StreamReader reader = new StreamReader("file.txt");
                    List<Data> list = ReadAllFile(reader);
                    reader.Close();

                    list = list.OrderBy(s => s.c).ToList();
                    label4.Text = list[index: list.Count - 1].c.ToString();*/

                   // label4.Visible = true;
                   // label3.Visible = true;
                   // complete.Enabled = false;
                   // stop.Enabled = false;
                }
            }

            if (direction == 3)
            {
                snake[0].X = snake[1].X - 10;
                snake[0].Y = snake[1].Y;
                if (snake[0].X == 0)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Game Over!");
                    if (form2 == null || form2.IsDisposed)
                    {
                        form2 = new Form2(label1);
                        form2.Show();
                    }
                   /* StreamReader reader = new StreamReader("file.txt");
                    List<Data> list = ReadAllFile(reader);
                    reader.Close();

                    list = list.OrderBy(s => s.c).ToList();
                    label4.Text = list[index: list.Count - 1].c.ToString();*/

                  //  label4.Visible = true;
                   // label3.Visible = true;
                  //  complete.Enabled = false;
                   // stop.Enabled = false;
                }
            }

            if (direction == 4)
            {
                snake[0].X = snake[1].X + 10;
                snake[0].Y = snake[1].Y;
                if (snake[0].X >= panel1.Width)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Game Over!");
                    if (form2 == null || form2.IsDisposed)
                    {
                        form2 = new Form2(label1);
                        form2.Show();
                    }
                   /* StreamReader reader = new StreamReader("file.txt");
                    List<Data> list = ReadAllFile(reader);
                    reader.Close();

                    list = list.OrderBy(s => s.c).ToList();
                    label4.Text = list[index: list.Count - 1].c.ToString();*/

                   // label4.Visible = true;
                   // label3.Visible = true;
                   // complete.Enabled = false;
                    //stop.Enabled = false;
                }
            }

            //наступили на яблоко
            if (snake[0].X == apple.X && snake[0].Y == apple.Y)
            {

                length++;
                if (length == 8)
                    timer1.Interval = 150;
                if (length == 11)
                    timer1.Interval = 120;
                if (length == 15)
                    timer1.Interval = 100;
                if (length == 18)
                    timer1.Interval = 80;
                count++;
                label1.Text = count.ToString();
                do
                {
                    apple.X = random.Next(1, panel1.Width / 10) * 10;
                    apple.Y = random.Next(1, panel1.Height / 10) * 10;
                } while (snake.Contains(apple));
            }
            for(int i=1; i<length; i++)
            {
                if(snake[0] == snake[i])
                {
                    timer1.Stop();
                    MessageBox.Show("Game Over!");
                    if (form2 == null || form2.IsDisposed)
                    {
                        form2 = new Form2(label1);
                        form2.Show();
                    }
                    
                  /*  StreamReader reader = new StreamReader("file.txt");
                    List<Data> list = ReadAllFile(reader);
                    reader.Close();

                    list = list.OrderBy(s => s.c).ToList();
                    label4.Text = list[index: list.Count - 1].c.ToString();*/

                    //label4.Visible = true;
                    //label3.Visible = true;
                   // complete.Enabled = false;
                   // stop.Enabled = false;
                    break;
                }
            }
        }

        //вывод
        void Draw()
        {
            panel1.Refresh();
        }
        void CheckGame(bool GameOver)
        {
            if(GameOver == true)
            {
               
            }
        }

        SolidBrush brushRed = new SolidBrush(Color.Red);

        SolidBrush brushYellow = new SolidBrush(Color.Yellow);

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.LightGreen;
            for (int i = 0; i < length; i++)
            {
                e.Graphics.FillEllipse(brushRed, snake[i].X, snake[i].Y, 10, 10);
            }

            e.Graphics.FillEllipse(brushYellow, apple.X, apple.Y, 10, 10);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W)
            {
                inputKeys.Enqueue(1);
            }

            if (e.KeyData == Keys.S)
            {
                inputKeys.Enqueue(2);
            }

            if (e.KeyData == Keys.A)
            {
                inputKeys.Enqueue(3);
            }

            if (e.KeyData == Keys.D)
            {
                inputKeys.Enqueue(4);
            }
        }

        private void Begin_Click(object sender, EventArgs e)
        {
            Setup();
            timer1.Enabled = true;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            StreamReader reader = new StreamReader("file.txt");
            List<Data> list = ReadAllFile(reader);
            reader.Close();

            list = list.OrderByDescending(s => s.c).ToList();
           // label4.Text = list[index: list.Count - 1].c.ToString();
            form3 = new Form3(list);
            form3.Show();
            
        }

        private void Complete_Click(object sender, EventArgs e)
        {
            timer1.Start();
            complete.Enabled = false;
            stop.Enabled = true;
        }
    }
}