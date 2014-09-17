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
    public partial class Highscore : Form
    {

        string eingabe = "";
        int myTime;

        int mode = 0;

        string[] pair1 = new string[2];
        string[] pair2 = new string[2];
        string[] pair3 = new string[2];
        string[] str = new string[]{"", "", "", "", "", ""};

        int newPlace = 0;


        public Highscore(int seconds, int mode2)
        {
            mode = mode2 - 1;
            InitializeComponent();
            myTime = seconds;
            label3.Text = myTime.ToString();
            loadScore();

        }

      





        public void loadScore()
        {
            int counter = 0;
            string line;
            System.IO.StreamReader file;
            
            System.IO.StreamReader fileLeicht = new System.IO.StreamReader("Highscore_leicht.txt");
            System.IO.StreamReader fileMittel = new System.IO.StreamReader("Highscore_mittel.txt");
            System.IO.StreamReader fileSchwer = new System.IO.StreamReader("Highscore_schwer.txt");

            //MessageBox.Show("Mode: " + mode.ToString());
            switch (mode)
            {
                case 1:
                    file = fileLeicht;
                    break;
                case 2:
                    file = fileMittel;
                    break;
                default:
                    file = fileSchwer;
                    break;
            }



            while ((line = file.ReadLine()) != null)
            {
                str[counter] = line;
                counter++;
            }

            file.Close();
            fileLeicht.Close();
            fileMittel.Close();
            fileSchwer.Close();

            pair1[0] = str[0];
            pair1[1] = str[1];
            pair2[0] = str[2];
            pair2[1] = str[3];
            pair3[0] = str[4];
            pair3[1] = str[5];

            int score1 = 9999;
            int score2 = 9999;
            int score3 = 9999;

            try{score1 = Convert.ToInt32(pair1[1]);}
            catch{}
            try{score2 = Convert.ToInt32(pair2[1]);}
            catch{}
            try{score3 = Convert.ToInt32(pair3[1]);}
            catch{}

            int place = 4;

            //MessageBox.Show(pair1[0]);
            //MessageBox.Show(pair1[1]);
            //MessageBox.Show(pair2[0]);
            //MessageBox.Show(pair2[1]);
            //MessageBox.Show(pair3[0]);
            //MessageBox.Show(pair3[1]);


            if ((myTime >= score1) && (myTime >= score2) && (myTime >= score3))
            {
                //bist du zu schlecht, um einen Mitspieler zu überbieten...
                //so beende diesen Bildschirm und lasse keine Eingabe zu. Wechsle sofort zur Highscore-Ansicht.
                Highscore2 h2 = new Highscore2(pair1[0], pair2[0], pair3[0], pair1[1], pair2[1], pair3[1], mode);
                h2.Show();

                this.Close();
                //return;
            }
            else
            {
                if (myTime < score3)
                {
                    place--;
                }
                if (myTime < score2)
                {
                    place--;
                }
                if (myTime < score1)
                {
                    place--;
                }
                newPlace = place;
                MessageBox.Show("Platz: " + newPlace.ToString());
            }


        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            eingabe = textBox1.Text;
            //MessageBox.Show("Du hast " + eingabe + " eingegeben!");
            System.IO.StreamWriter file;
            if (newPlace == 3)
            {
                pair3[0] = eingabe;
                pair3[1] = myTime.ToString();
            }
            else if (newPlace == 2)
            {
                pair3[0] = pair2[0];
                pair3[1] = pair2[1];
                pair2[0] = eingabe;
                pair2[1] = myTime.ToString();
            }
            else
            {
                pair3[0] = pair2[0];
                pair3[1] = pair2[1];
                pair2[0] = pair1[0];
                pair2[1] = pair1[1];
                pair1[0] = eingabe;
                pair1[1] = myTime.ToString();
            }
            //MessageBox.Show("Neuer Platz: " + newPlace.ToString());
            switch (mode)
            {
                case 2:
                    file = new System.IO.StreamWriter("Highscore_mittel.txt", false);
                    break;
                case 3:
                    file = new System.IO.StreamWriter("Highscore_schwer.txt", false);
                    break;


                default:
                    file = new System.IO.StreamWriter("Highscore_leicht.txt", false);
                    break;
            }




            file.WriteLine(pair1[0]);
            file.WriteLine(pair1[1]);
            file.WriteLine(pair2[0]);
            file.WriteLine(pair2[1]);
            file.WriteLine(pair3[0]);
            file.WriteLine(pair3[1]);

            file.Close();

            //Hier in die Datei schreiben
            //Dieses Fenster schließen
            Highscore2 h2 = new Highscore2(pair1[0], pair2[0], pair3[0], pair1[1], pair2[1], pair3[1], mode);
            h2.Show();

            this.Close();

            //Und Highscore-Fenster anzeigen
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Highscore_Load(object sender, EventArgs e)
        {

        }


    }
}
