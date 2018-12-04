/// Created by Mr. T. 
/// August 2017
/// 
/// This program is used as a template to test the draw methods that each student will
/// create and then combine into one group project. 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Media;
using System.Threading;

namespace DeathStarExhaustPort
{
    public partial class MainForm : Form
    {
        Graphics onScreen;

        Bitmap bm; //bitmap area size of whole screen
        Graphics offScreen; //Sets off-screen graphics to the bitmap

        public MainForm()
        {
            InitializeComponent();

            onScreen = this.CreateGraphics();
            bm = new Bitmap(this.Width, this.Height); //bitmap area size of whole screen
            offScreen = Graphics.FromImage(bm); //Sets off-screen graphics to the bitmap
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            SoundPlayer player;

            int shipX = 360;
            int shipY = 25;

            int torpedoX = 265;
            int torpedoY = 35;

            // ************************** X wing fly in **************************
            for (int x = 0; x < 10; x++)
            {
                shipX = shipX - 10;

                Thread.Sleep(50);
                offScreen.Clear(Color.Black);              

                DeathStar(55, 55, 400);

                ExhaustPort(245, 62, 20, 205);
                Xwing(shipX, shipY, 30, 8);

                onScreen.DrawImage(bm, 0, 0);
            }

            // ************************** X - wing fly out and torpedo fly in  **************************
            player = new SoundPlayer(Properties.Resources.torpedo);
            player.Play();

            for (int x = 0; x < 4; x++)
            {
                shipX -= 8;
                shipY -= 9;

                torpedoX -= 5;
                torpedoY += 5;

                Thread.Sleep(50);
                offScreen.Clear(Color.Black);
                
                DeathStar(55, 55, 400);
                ExhaustPort(245, 62, 20, 205);
                Xwing(shipX, shipY, 30, 10);
                Torpedo(torpedoX, torpedoY, 20);

                onScreen.DrawImage(bm, 0, 0);
            }

            // ************************** torpedo drop **************************
            for (int x = 0; x < 38; x++)
            {
                torpedoY += 5;

                Thread.Sleep(50);
                offScreen.Clear(Color.Black);
                
                DeathStar(55, 55, 400);
                ExhaustPort(245, 62, 20, 205);
                Xwing(shipX, shipY, 30, 8);
                Torpedo(torpedoX, torpedoY, 20);

                onScreen.DrawImage(bm, 0, 0);
            }

            // ************************** Explosion **************************
            player = new SoundPlayer(Properties.Resources.explosion);
            player.Play();

            for (int x = 1; x < 10; x++)
            {
                Thread.Sleep(150);
                offScreen.Clear(Color.Black);             
                
                DeathStar(55, 55, 400);
                ExhaustPort(245, 62, 20, 205);               

                if (x % 2 == 0) { Explosion(205, 205, 100); }
                else            { Explosion(155, 155, 200); }

                onScreen.DrawImage(bm, 0, 0);
            }
        }

        public void Xwing(float x, float y, float width, float height)
        {
            Pen shipPen = new Pen(Color.White);

            /// Use the rectangle below for testing purposes. 
            /// Your shape should always draw within this rectangle, reglardless of size and position.
            /// Comment it out when you are done.
            offScreen.DrawRectangle(shipPen, x, y, width, height);

        }

        public void Torpedo(float x, float y, float pixels)
        {
            Pen torpPen = new Pen(Color.White);

            /// Use the rectangle below for testing purposes. 
            /// Your shape should always draw within this rectangle, reglardless of size and position.
            /// Comment it out when you are done.
            offScreen.DrawRectangle(torpPen, x, y, pixels, pixels);
        }

        public void Explosion(float x, float y, float pixels)
        {
            Pen exPen = new Pen(Color.White);

            /// Use the rectangle below for testing purposes. 
            /// Your shape should always draw within this rectangle, reglardless of size and position.
            /// Comment it out when you are done.
            offScreen.DrawRectangle(exPen, x, y, pixels, pixels);           
        }

        /// <summary>
        /// Will draw the Death Star from Star Wars
        /// </summary>
        /// <param name="x">The X value of the Death Star</param>
        /// <param name="y">The Y value of the Death Star</param>
        /// <param name="pixels">The size of the Death Star</param>
        public void DeathStar(float x, float y, float pixels)
        {
            //Pens and Brushes
            Pen deathPen = new Pen(Color.White);
            Pen testPen = new Pen(Color.Red);
            Pen gunPen = new Pen(Color.LimeGreen,2);
            SolidBrush beamBrush = new SolidBrush(Color.LightBlue);
            Pen laserPen = new Pen(Color.LimeGreen,4);
            Pen superlaserPen = new Pen(Color.LimeGreen, 6);


            //Scale for adjusting
            float scale = pixels / 400;

            //testing rectangle, Size and Coordinates must stay inside it
            //offScreen.DrawRectangle(deathPen, x, y, pixels, pixels);

            //arc of DeathStar
            offScreen.DrawArc(deathPen, x, y, pixels, pixels, 281, 338);

            //top half rectangle of the DeathStar
            offScreen.DrawLine(deathPen, (163 * scale) + x , (4 * scale) + y, (163 * scale) + x, (30 * scale) + y);
            offScreen.DrawLine(deathPen, (238 * scale) + x, (4 * scale) + y, (238 * scale) + x, (30 * scale) + y);
            offScreen.DrawLine(deathPen, (163 * scale) + x, (30 * scale) + y, (238 * scale) + x, (30 * scale) + y);

            //Gun of DeathStar
            //Circles 
            offScreen.DrawEllipse(deathPen, (260 * scale) + x, (110 * scale) + y, 90 * scale, 120 * scale); //first
            offScreen.DrawEllipse(deathPen, (300 * scale) + x, (155 * scale) + y, 20 * scale, 30 * scale);  //third
            offScreen.DrawEllipse(deathPen, (268 * scale) + x, (118 * scale) + y, 75 * scale, 105 * scale); //second
            offScreen.FillEllipse(beamBrush, (305 * scale) + x, (160 * scale) + y, 10 * scale, 20 * scale); //fourth

            //Lasers
            offScreen.DrawLine(laserPen, (310 * scale) + x, (170 * scale) + y, (360 * scale) + x, (110 * scale) + y);
            offScreen.DrawLine(gunPen, (310 * scale) + x, (110 * scale) + y, (360 * scale) + x, (110 * scale) + y); //1
            offScreen.DrawLine(gunPen, (337 * scale) + x, (212 * scale) + y, (360 * scale) + x, (110 * scale) + y); //2
            offScreen.DrawLine(gunPen, (270 * scale) + x, (130 * scale) + y, (360 * scale) + x, (110 * scale) + y); //3
            offScreen.DrawLine(gunPen, (297 * scale) + x, (231 * scale) + y, (360 * scale) + x, (110 * scale) + y); //4
            offScreen.DrawLine(gunPen, (260 * scale) + x, (160 * scale) + y, (360 * scale) + x, (110 * scale) + y); //5
            offScreen.DrawLine(gunPen, (268 * scale) + x, (205 * scale) + y, (360 * scale) + x, (110 * scale) + y); //6
            offScreen.DrawLine(superlaserPen, (360 * scale) + x, (110 * scale) + y, (390 * scale) + x, (80 * scale) + y);

        }

        public void ExhaustPort(float x, float y, float width, float height)
        {
            Pen exPen = new Pen(Color.White);

            /// Use the rectangle below for testing purposes. 
            /// Your shape should always draw within this rectangle, reglardless of size and position.
            /// Comment it out when you are done.
            offScreen.DrawRectangle(exPen, x, y, width, height);
        }

        private void fullButton_Click(object sender, EventArgs e)
        {
            MainForm_Click(sender, e);
        }

        private void partButton_Click(object sender, EventArgs e)
        {
            offScreen.Clear(Color.Black); // do not remove

            /// Call your method here. This is where you can adjust the location and size 
            /// to make sure that it draws on the screen correctly.
            DeathStar(0, 0, 400);


            // Draws to the screen 
            onScreen.DrawImage(bm, 0, 0);
        }
    }
}
