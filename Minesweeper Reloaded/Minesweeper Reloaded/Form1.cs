using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace Minesweeper_Reloaded
{
    public partial class Form1 : Form
    {

        Form f;
        Object[] container = new Object[25];

        Label tmrLabel;
        Label mineLabel;

        Timer tmr = new Timer();
        Random random = new Random();
        static int kante = 0;
        string[] arr_leicht = new string[101];
        string[] arr_mittel = new string[226];
        string[] arr_schwer = new string[626];
        static int active_array = 0;

        bool labelIsSet = false;
        static int seconds = 0;
        int minesLeft = 0;

        static string[] arr = new string[626];




        public Form1()
        {
            InitializeComponent(); 
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            tmr.Tick += new System.EventHandler(tmr_Tick);
            tmr.Interval = 1000;
            tmr.Enabled = false;




        }

        private void tmr_Tick(object sender, EventArgs e) // Erstellt und justiert Labels für Timer und Minenzähler
        {
            if ((!labelIsSet) && (f != null))
            {
                try
                {
                    tmrLabel = new Label();

                    tmrLabel.Location = new Point(1, kante * 25);
                    tmrLabel.BackColor = Color.FromArgb(0, 0, 0);
                    tmrLabel.ForeColor = Color.Red;

                    tmrLabel.Name = "tmrLabel";
                    tmrLabel.Font = new Font("Courier", 11, FontStyle.Bold);
                    tmrLabel.Text = "";
                    tmrLabel.Width = 50;

                    f.Controls.Add(tmrLabel);


                    mineLabel = new Label();

                    mineLabel.Location = new Point(100, kante * 25);
                    mineLabel.BackColor = Color.FromArgb(0, 0, 0);
                    mineLabel.ForeColor = Color.Red;
                    mineLabel.Name = "mineLabel";
                    mineLabel.Font = new Font("Courier", 11, FontStyle.Bold);
                    mineLabel.Text = "";
                    mineLabel.Width = 50;

                    f.Controls.Add(mineLabel);


                    labelIsSet = true;

                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    seconds++;
                    tmrLabel.Text = seconds.ToString();
                }
                catch
                {
                }
            }

        }

        Form2 f2;
        private void leichtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeWindows();
            kante = 10;
            int mines = 10;
            active_array = 2;
            create_field_leicht(mines);
            create_world_leicht(kante, kante);
            f2.Width = 250;
            f2.Height = 320;

            minesLeft = mines;

        }


        Form3 f3;
        private void mittelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeWindows();
            kante = 15;
            int mines = 25;
            active_array = 3;
            create_field_mittel(mines);
            create_world_mittel(kante, kante);
            f3.Width = 375;
            f3.Height = 445;

            minesLeft = mines;
        }

        Form4 f4;
        private void schwerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeWindows();
            kante = 25;
            int mines = 100;
            active_array = 4;
            create_field_schwer(mines);
            create_world_schwer(kante, kante);
            f4.Width = 625;
            f4.Height = 695;

            minesLeft = mines;
        }

        private void Highscore_Popup(object sender, EventArgs e)
        {
            Highscore h1 = new Highscore(seconds, active_array);

            try
            {
                h1.Show();
            }
            catch { }

        }

        private void Highscore2_Popup(object sender, EventArgs e)
        {

        }


        public void closeWindows()
        {

            if (f2 != null)
            {
                f2.Close();
                f2 = null;
            }
            if (f3 != null)
            {
                f3.Close();
                f3 = null;
            }
            if (f4 != null)
            {
                f4.Close();
                f4 = null;
            }
            f = null;
            labelIsSet = false;
            seconds = 0;
            tmr.Enabled = false;
        }


        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }


        public void create_world_leicht(int x, int y)
        {

            f2 = new Form2();
            f2.MdiParent = this;

            for (int i = 0; i < x; ++i)
            {
                for (int j = 0; j < y; ++j)
                {
                    add_button_leicht(i, j, f2);
                }
            }


            f2.Show();
        }
        public void create_world_mittel(int x, int y)
        {

            f3 = new Form3();
            f3.MdiParent = this;

            for (int i = 0; i < x; ++i)
            {
                for (int j = 0; j < y; ++j)
                {
                    add_button_mittel(i, j, f3);
                }
            }


            f3.Show();
        }
        public void create_world_schwer(int x, int y)
        {

            f4 = new Form4();
            f4.MdiParent = this;

            for (int i = 0; i < x; ++i)
            {
                for (int j = 0; j < y; ++j)
                {
                    add_button_schwer(i, j, f4);
                }
            }


            f4.Show();
        }

       

        public void add_button_leicht(int x, int y, Form2 parent)
        {
            int width = 24;
            int height = 24;
            int padding = 1;
            Button test = new Button();
            test.Location = new Point(width * x + padding, height * y + padding);
            test.Height = height;
            test.Width = width;
            test.BackColor = Color.FromArgb(150, 150, 150);
            test.ForeColor = Color.Blue;

            test.Name = "button_" + x + "_" + y;
            test.Font = new Font("Arial", 11, FontStyle.Bold);
            test.Text = "";
            test.Click += test_Click;
            test.MouseDown += right_click;



            //counter++;
            //if (arr_leicht[counter] == "X")
            //{
            //    test.Text = "X";
            //}
            
            parent.Controls.Add(test);
        }
        public void add_button_mittel(int x, int y, Form3 parent)
        {
            int width = 24;
            int height = 24;
            int padding = 1;
            Button test = new Button();
            test.Location = new Point(width * x + padding, height * y + padding);
            test.Height = height;
            test.Width = width;
            test.BackColor = Color.FromArgb(150, 150, 150);
            test.ForeColor = Color.Blue;

            test.Name = "button_" + x + "_" + y;
            test.Font = new Font("Arial", 11, FontStyle.Bold);
            test.Text = "";
            test.Click += test_Click;
            test.MouseDown += right_click;
            parent.Controls.Add(test);
        }
        public void add_button_schwer(int x, int y, Form4 parent)
        {




            int width = 24;
            int height = 24;
            int padding = 1;
            Button test = new Button();






            test.Location = new Point(width * x + padding, height * y + padding);
            test.Height = height;
            test.Width = width;
            test.BackColor = Color.FromArgb(150, 150, 150);
            test.ForeColor = Color.Blue;

            test.Name = "button_" + x + "_" + y;
            test.Font = new Font("Arial", 11, FontStyle.Bold);
            test.Text = "";
            test.Click += test_Click;
            test.MouseDown += right_click;





            parent.Controls.Add(test);
        }

        public void right_click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var Button = (Button)sender;
                //MessageBox.Show("WTF!!!");
                //////int w = Button.Location.X;
                //////int h = Button.Location.Y;

                //////int W = 1;
                //////int H = 1;

                //////int zahl = 0;


                //////while (w > 1)
                //////{
                //////    W++;
                //////    w -= 25;
                //////}
                //////while (h > 1)
                //////{
                //////    H++;
                //////    h -= 25;
                //////}
                //////int position = W + (10 * H) - 10;
                if (Button.Text == "X")
                {
                    minesLeft++;
                    Button.Text = "";
                    Button.BackColor = Color.FromArgb(150, 150, 150);
                }
                else
                {
                    minesLeft--;
                    Button.Text = "X";
                    Button.ForeColor = Color.FromArgb(0, 0, 0);
                    Button.BackColor = Color.FromArgb(50, 50, 50);
                }
            }
            updateMineLabel();
        }

        public void updateMineLabel()
        {
            if (mineLabel != null)
            {
                mineLabel.Text = minesLeft.ToString();
                if (minesLeft == 0)
                {
                    if (winTest())
                    {
                        MessageBox.Show("DU HAST GEWONNEN!!!!!");
                        tmr.Enabled = false;
                        Highscore_Popup(this, null);
                        closeWindows();
                    }

                }
            }

        }

        public bool winTest()
        {
            foreach (String value in arr)
            {
                if (value.Length <= 0)
                {
                    return false;
                }
                else
                {
                    //Dieses Feld ist fertig
                }
                
            }
            return true;

        }

        private void test_Click(object sender, EventArgs  e)
        {
            var Button = (Button)sender;



            if (!tmr.Enabled)
            {
                tmr.Enabled = true;
            }

            if (Button.Text != "X")
            {
                checkButton(Button);
            }


            updateMineLabel();

            debugPrint();
        }

        public void debugPrint()
        {
            foreach (String value in arr)
            {
                if (value == "")
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(value);
                }
            }

        }

        public void checkButton(Button Button)
        {

            int zahl = countNeighbours(Button);

            changeColorForButtonText(Button, zahl);
            setButtonText(Button, zahl.ToString());


            Button.Text = zahl.ToString();
            if (zahl == 0)
            {

                setButtonText(Button, " ");

                int W = getCoordinateW(Button);
                int H = getCoordinateH(Button);

                //int pos = W + (kante * H);
                //arr[pos] = zahl.ToString();

                check_neighbours(W, H);
            }
        }

        public int getCoordinateW(Button Button)
        {
            int w = Button.Location.X;
            int W = 1;
            while (w > 1)
            {
                W++;
                w -= 25;
            }
            return W;
        }

        public int getCoordinateH(Button Button)
        {
            int h = Button.Location.Y;
            int H = 1;
            while (h > 1)
            {
                H++;
                h -= 25;
            }
            return H;
        }

        public int countNeighbours(Button Button)
        {
            int W = getCoordinateW(Button);
            int H = getCoordinateH(Button);



            int zahl = 0;


            if (active_array == 2)
            {
                arr = arr_leicht;
                f = f2;
            }
            else if (active_array == 3)
            {
                arr = arr_mittel;
                f = f3;
            }
            else if (active_array == 4)
            {
                arr = arr_schwer;
                f = f4;
            }
            arr[0] = "#";


            int position = W + (kante * H) - kante;


            //MessageBox.Show(position.ToString());



            if (arr[position] == "X")
            {
                MessageBox.Show("Hier war eine Mine, du hast verloren!");
                Button.ForeColor = Color.FromArgb(255, 0, 0);
                closeWindows();

            }
            else
            {
                if (position == 1)
                {
                    //MessageBox.Show("o. l!");
                    //oben links
                    if (arr[position + 1] == "X")
                        zahl++;
                    if (arr[position + kante] == "X")
                        zahl++;
                    if (arr[position + 1 + kante] == "X")
                        zahl++;
                }
                else if ((position > 1) && (position < kante))
                {
                    //MessageBox.Show("o!");
                    //oben
                    if (arr[position - 1] == "X")
                        zahl++;
                    if (arr[position + 1] == "X")
                        zahl++;
                    if (arr[position + kante - 1] == "X")
                        zahl++;
                    if (arr[position + kante] == "X")
                        zahl++;
                    if (arr[position + kante + 1] == "X")
                        zahl++;
                }
                else if (position == kante)
                {
                    //MessageBox.Show("o. r!");
                    //oben rechts
                    if (arr[position + kante - 1] == "X")
                        zahl++;
                    if (arr[position + kante] == "X")
                        zahl++;
                    if (arr[position - 1] == "X")
                        zahl++;
                }
                else if (position == ((kante * kante) - kante + 1))
                {
                    //MessageBox.Show("u. l!");
                    //unten links
                    if (arr[position - kante] == "X")
                        zahl++;
                    if (arr[position - kante + 1] == "X")
                        zahl++;
                    if (arr[position + 1] == "X")
                        zahl++;
                }
                else if ((position > ((kante * kante) - kante + 1)) && (position < (kante * kante)))
                {
                    //MessageBox.Show("u!");
                    //unten
                    if (arr[position - kante - 1] == "X")
                        zahl++;
                    if (arr[position - kante] == "X")
                        zahl++;
                    if (arr[position - kante + 1] == "X")
                        zahl++;
                    if (arr[position - 1] == "X")
                        zahl++;
                    if (arr[position + 1] == "X")
                        zahl++;
                }
                else if (position == (kante * kante))
                {
                    //MessageBox.Show("u. r!");
                    //unten rechts
                    if (arr[position - kante - 1] == "X")
                        zahl++;
                    if (arr[position - kante] == "X")
                        zahl++;
                    if (arr[position - 1] == "X")
                        zahl++;
                }
                else
                {
                    int target = position;
                    while (target > kante)
                    {
                        target -= kante;
                    }
                    if (target == 1)
                    {

                        //MessageBox.Show("l!");
                        //links
                        if (arr[position - kante] == "X")
                            zahl++;
                        if (arr[position - kante + 1] == "X")
                            zahl++;
                        if (arr[position + 1] == "X")
                            zahl++;
                        if (arr[position + kante] == "X")
                            zahl++;
                        if (arr[position + kante + 1] == "X")
                            zahl++;
                    }
                    else if (target == kante)
                    {
                        //MessageBox.Show("r!");
                        //rechts
                        if (arr[position - kante - 1] == "X")
                            zahl++;
                        if (arr[position - kante] == "X")
                            zahl++;
                        if (arr[position - 1] == "X")
                            zahl++;
                        if (arr[position + kante - 1] == "X")
                            zahl++;
                        if (arr[position + kante] == "X")
                            zahl++;
                    }
                    else
                    {
                        //MessageBox.Show("F!");
                        //im Feld
                        if (arr[position - kante - 1] == "X")
                            zahl++;
                        if (arr[position - kante] == "X")
                            zahl++;
                        if (arr[position - kante + 1] == "X")
                            zahl++;
                        if (arr[position - 1] == "X")
                            zahl++;
                        if (arr[position + 1] == "X")
                            zahl++;
                        if (arr[position + kante - 1] == "X")
                            zahl++;
                        if (arr[position + kante] == "X")
                            zahl++;
                        if (arr[position + kante + 1] == "X")
                            zahl++;
                    }
                }
                arr[position] = zahl.ToString();    //Befülle das Array an der derzeitigen Buttonstelle mit der Zahl, damit es aus dem WinTest fällt


            }

            return zahl;
        }


        public void setButtonText(Button Button, String txt)
        {
            Button.Text = txt;
        }

        public void changeColorForButtonText(Button Button, int zahl)
        {
            
            if (zahl == 1)
            {
                Button.ForeColor = Color.FromArgb(0, 0, 255);
                Button.BackColor = Color.FromArgb(210, 210, 210);
            }
            if (zahl == 2)
            {
                Button.ForeColor = Color.FromArgb(0, 128, 0);
                Button.BackColor = Color.FromArgb(210, 210, 210);
            }
            if (zahl == 3)
            {
                Button.ForeColor = Color.FromArgb(255, 0, 0);
                Button.BackColor = Color.FromArgb(210, 210, 210);
            }
            if (zahl == 4)
            {
                Button.ForeColor = Color.FromArgb(0, 128, 128);
                Button.BackColor = Color.FromArgb(210, 210, 210);
            }
            if (zahl == 5)
            {
                Button.ForeColor = Color.FromArgb(255, 255, 0);
                Button.BackColor = Color.FromArgb(210, 210, 210);
            }
            if (zahl == 6)
            {
                Button.ForeColor = Color.FromArgb(255, 0, 255);
                Button.BackColor = Color.FromArgb(210, 210, 210);
            }
            if (zahl == 7)
            {
                Button.ForeColor = Color.FromArgb(128, 255, 0);
                Button.BackColor = Color.FromArgb(210, 210, 210);
            }
            if (zahl == 8)
            {
                Button.ForeColor = Color.FromArgb(0, 0, 0);
                Button.BackColor = Color.FromArgb(210, 210, 210);
            }
            if (zahl == 0)
            {
                Button.BackColor = Color.FromArgb(240, 240, 240);
            }
        }

        public void check_neighbours(int width, int height)
        {
            // du bekommst die coords vom derzeitigen button als x und y. Diese kannst du wiederum in position umrechnen und damit das jeweilige Field_array ansprechen. so lässt sich berechnen, ob anbei noch buttons frei sind, die so einfach mit der performclick-methode aktiviert werden knnen. Wunderbarer Strike!!!
            string name = "";
            //field
            name = "button_" + (width + 1) + "_" + height;
            //button2.Name = name;
            //int count = 0;
            if (f != null)
            {
                foreach (Control c in f.Controls)
                {
                    if (c.GetType().ToString() == "System.Windows.Forms.Button")
                    {
                        Button test2 = (Button)c;
                        //if (test2.Name == name) MessageBox.Show("FOUND!! | " + name + " | " + test2.Name);
                        //if (++count < 2) MessageBox.Show(c.ToString());
                        try
                        {
                            String[] coords = test2.Name.Split('_');
                            int x = width - 1;
                            int y = height - 1;
                            //bool result = Int32.TryParse(coords[1], out x);
                            for (int i = x - 1; i <= x + 1; ++i)
                            {
                                for (int j = y - 1; j <= y + 1; ++j)
                                {
                                    if ((i != x || y != j) && test2.Name == "button_" + i + "_" + j)
                                    {
                                        //check
                                        //MessageBox.Show(test2.Name + " |" + test2.Text + "|");
                                        if (test2.Text.Length == 0)
                                        {
                                            test2.Text = " ";
                                            checkButton(test2);
                                        }
                                    }
                                }

                            }
                            //checkButton(test2);
                            //test2.PerformClick();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                }
            }
            //button2.PerformClick();

        }


        //public static IEnumerable<Control> check_stack(Control root)
        //{
        //    MessageBox.Show("Check_Neighbours activated!");
        //    var stack = new Stack<Control>();
        //    stack.Push(root);

        //    while (stack.Any())
        //    {
        //        var next = stack.Pop();
        //        foreach (Control child in next.Controls)
        //            stack.Push(child);

        //        if (next.GetType().ToString() == "Button")
        //        {
        //            MessageBox.Show("Button named: " + next.Name);
        //        }
        //        yield return next;
        //    }
        //}


        public void create_field_leicht(int mines)
        {
            int randomNumber = 1;
            for (int i = 0; i <= (kante * kante); i++)
            {
                arr_leicht[i] = "";
            }
            randomNumber = random.Next(0, (kante * kante));
            while (mines > 0)
            {
                randomNumber = random.Next(0, (kante * kante)) + 1;
                if (arr_leicht[randomNumber] != "X")
                {
                    mines--;
                    arr_leicht[randomNumber] = "X";
                }
            }
        }
        public void create_field_mittel(int mines)
        {
            int randomNumber = 1;
            for (int i = 0; i <= (kante * kante); i++)
            {
                arr_mittel[i] = "";
            }
            randomNumber = random.Next(0, (kante * kante));
            while (mines > 0)
            {
                randomNumber = random.Next(0, (kante * kante)) + 1;
                if (arr_mittel[randomNumber] != "X")
                {
                    mines--;
                    arr_mittel[randomNumber] = "X";
                }
            }
        }
        public void create_field_schwer(int mines)
        {
            int randomNumber = 1;
            for (int i = 0; i <= (kante * kante); i++)
            {
                arr_schwer[i] = "";
            }
            randomNumber = random.Next(0, (kante * kante));
            while (mines > 0)
            {
                randomNumber = random.Next(0, (kante * kante)) + 1;
                if (arr_schwer[randomNumber] != "X")
                {
                    mines--;
                    arr_schwer[randomNumber] = "X";
                }
            }
        }



    }
}
