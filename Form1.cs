﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOLStartUpTemplate
{
    public partial class Form1 : Form
    {
        // The universe array
        bool[,] universe = new bool[15, 15];
        bool[,] scratch = new bool[15, 15];
        private void Swap()
        {
            bool[,] temp = new bool[universe.GetLength(0), universe.GetLength(1)];
            temp = scratch;
            scratch = universe;
            universe = temp;
            graphicsPanel1.Invalidate();
        }
        private void Replace()
        {
            bool[,] temp = new bool[universe.GetLength(0), universe.GetLength(1)];
            universe = scratch;
            scratch = temp;
            graphicsPanel1.Invalidate();
        }

        // Drawing colors
        Color gridColor = Color.Black;
        Color cellColor = Color.FromArgb(0xdb, 0x7f, 0x8e);

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;
        int alive = 0;

        public Form1()
        {
            InitializeComponent();
            this.Text = Properties.Resources.AppName;

            //Read Settings
            graphicsPanel1.BackColor = Properties.Settings.Default.PanelColor;


            // Setup the timer
            timer.Interval = 100; // milliseconds
            timer.Tick += Timer_Tick;
            //timer.Enabled = true; // start timer running
        }

        private int CountNeighborsFinite(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);

            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;

                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }

                    if (xCheck < 0)
                    {
                        continue;
                    }
                    if (yCheck < 0)
                    {
                        continue;
                    }
                    if (xCheck >= xLen)
                    {
                        continue;
                    }
                    if (yCheck >= yLen)
                    {
                        continue;
                    }

                    if (universe[xCheck, yCheck] == true) count++;
                }
            }
            return count;
        }

        // Calculate the next generation of cells
        private void NextGeneration()
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    int count = CountNeighborsFinite(x, y);

                    if (universe[x, y] == true)
                    {
                        alive++;
                    }

                    if (universe[x, y] == true && count < 2)
                    {
                        scratch[x, y] = false;
                    }
                    else if (universe[x, y] == true && count > 3)
                    {
                        scratch[x, y] = false;
                    }
                    else if (universe[x, y] == true && count == 2 || count == 3)
                    {
                        scratch[x, y] = true;
                    }
                    else if (universe[x, y] == false && count == 3)
                    {
                        scratch[x, y] = true;
                    }
                }
            }
            Replace();

            // Increment generation count
            generations++;

            // Update status strip generations
            toolStripStatusAlive.Text = "Cells Alive = " + alive.ToString();
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            float cellWidth = (float)graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            float cellHeight = (float)graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    Font font = new Font("Arial", 15f);
                    StringFormat sformat = new StringFormat();
                    sformat.Alignment = StringAlignment.Center;
                    sformat.LineAlignment = StringAlignment.Center;

                    // A rectangle to represent each cell in pixels
                    Rectangle cellRect = Rectangle.Empty;
                    cellRect.X = (int)(x * cellWidth);
                    cellRect.Y = (int)(y * cellHeight);
                    cellRect.Width = (int)cellWidth;
                    cellRect.Height = (int)cellHeight;

                    int count = CountNeighborsFinite(x, y);


                    // Fill the cell with a brush if alive
                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                    }

                    // Outline the cell with a pen
                    e.Graphics.DrawString(count.ToString(), font, Brushes.DarkSlateGray, cellRect, sformat);

                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the width and height of each cell in pixels
                int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
                int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = e.X / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = e.Y / cellHeight;

                // Toggle the cell's state
                universe[x, y] = !universe[x, y];

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = false;
                }
            }
            graphicsPanel1.Invalidate();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            NextGeneration();
            graphicsPanel1.Invalidate();
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            timer.Stop();
            graphicsPanel1.Invalidate();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            timer.Start();
            NextGeneration();
            graphicsPanel1.Invalidate();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = false;
                }
            }
            graphicsPanel1.Invalidate();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Random rng = new Random();
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    int num = rng.Next(0, 2);
                    if (num == 0)
                    {
                        scratch[x, y] = true;
                    }
                }
            }
            Replace();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        #region Settings

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = graphicsPanel1.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                graphicsPanel1.BackColor = dlg.Color;
            }
        }

        private void gridSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();

            graphicsPanel1.BackColor = Properties.Settings.Default.PanelColor;

        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();

            graphicsPanel1.BackColor = Properties.Settings.Default.PanelColor;

        }


        #endregion

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.PanelColor = graphicsPanel1.BackColor;

            Properties.Settings.Default.Save();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);

                int mWidth = 0;
                int mHeight = 0;

                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();

                    if (row[0] == '!')
                    {

                    }
                    else
                    {
                        mHeight++;
                    }

                    mWidth = row.Length;
                }

                bool[,] hold = new bool[mWidth, mHeight];
                universe = hold;
                scratch = hold;

                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    if (row[0] == '!')
                    {

                    }
                    else
                    {
                        for (int xPos = 0; xPos < row.Length; xPos++)
                        {
                            for (int y = 0; y < universe.GetLength(1); y++)
                            {
                                for (int x = 0; x < universe.GetLength(0); x++)
                                {
                                    if (row[xPos] == 'O')
                                    {
                                        universe[x, y] = true;
                                    }
                                    else if (row[xPos] == '.')
                                    {
                                        universe[x, y] = false;
                                    }
                                }
                            }
                        }
                    }
                }
                reader.Close();
                
            }
            graphicsPanel1.Invalidate();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2; dlg.DefaultExt = "cells";

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);

                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    string currentRow = string.Empty;

                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        if (universe[x, y] == true)
                        {
                            currentRow = currentRow + "O";
                        }
                        else if (universe[x, y] == false)
                        {
                            currentRow = currentRow + ".";
                        }
                    }
                    writer.WriteLine(currentRow);
                }
                writer.Close();

            }
        }
    }
}