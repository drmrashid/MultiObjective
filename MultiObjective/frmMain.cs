using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiObjective
{
    public partial class frmMain : Form
    {
        List<Particle> nonDominated;
        List<Particle> dominated;
        List<Particle> toRemove;
        List<Particle> selected;
        List<Particle> gridParticles;
        int w;
        int h;
        double ngh;
        //Bitmap bluePixel;
        //Bitmap redPixel;
        //Bitmap blackPixel;
        Bitmap graph;
        //Bitmap graphKitaGuess;
        double scale;

        double[,] pretoOptimalSet;
        Graphics g;
        Function f;

        public frmMain()
        {
            nonDominated = new List<Particle>();
            dominated = new List<Particle>();
            selected = new List<Particle>();
            gridParticles = new List<Particle>();
            InitializeComponent();
            scale = 10;
            //ngh = 0.01;
            graph = new Bitmap(1000, 1000);
            w = graph.Width / 2;
            h = graph.Height / 2;
            //graphKitaGuess = new Bitmap(1000, 1000);
            f = new Function(Function.Type.Kita);
            //foreach (string s in cboScale.Items)
            //{
            //    scale = Double.Parse(s);
            //    Bitmap b = new Bitmap(1000, 1000);
            //    DrawParetoOptimalGuess(Function.Type.Kita, b);
            //    //pretoOptimalSet = f.PretoOptimalSet;
            //    //for (int i = 0; i <= pretoOptimalSet.GetUpperBound(0); i++)
            //    //{
            //    //    //g.DrawImage(blackPixel, (float)(pretoOptimalSet[i, 0] * scale + w), (float)(h - pretoOptimalSet[i, 1] * scale));
            //    //    if (Math.Abs(pretoOptimalSet[i, 0] * scale) < w && Math.Abs(pretoOptimalSet[i, 1] * scale) < h)
            //    //        b.SetPixel((int)(pretoOptimalSet[i, 0] * scale + w), (int)(h - pretoOptimalSet[i, 1] * scale), Color.Black);
            //    //}
            //    b.Save("g" + s + ".bmp");
            //}
            g = Graphics.FromImage(graph);
            picGraph.Image = graph;
            picGraph.Height = graph.Height;
            picGraph.Width = graph.Width;
            //picGraph.AutoScrollOffset = new Point(0, 0);
            //bluePixel = new Bitmap(2, 2);
            //bluePixel.SetPixel(0, 0, Color.Blue);
            //bluePixel.SetPixel(0, 1, Color.Blue);
            //bluePixel.SetPixel(1, 0, Color.Blue);
            //bluePixel.SetPixel(1, 1, Color.Blue);
            //blackPixel = new Bitmap(2, 2);
            //blackPixel.SetPixel(0, 0, Color.Black);
            //blackPixel.SetPixel(0, 1, Color.Black);
            //blackPixel.SetPixel(1, 0, Color.Black);
            //blackPixel.SetPixel(1, 1, Color.Black);
            //redPixel = new Bitmap(2, 2);
            //redPixel.SetPixel(0, 0, Color.Red);
            //redPixel.SetPixel(0, 1, Color.Red);
            //redPixel.SetPixel(1, 0, Color.Red);
            //redPixel.SetPixel(1, 1, Color.Red);
            foreach (string fType in Enum.GetNames(typeof(Function.Type)))
            {
                cboFunction.Items.Add(fType);
            }
            cboZoom.SelectedIndex = 4;
            cboFunction.SelectedIndex = 0;
            cboScale.SelectedIndex = 1;


        }
        private void ClearGraph()
        {
            GraphicsUnit gu = GraphicsUnit.Pixel;
            g.FillRectangle(Brushes.White, graph.GetBounds(ref gu));
            g.DrawLine(Pens.Black, new PointF(w, 0), new PointF(w, graph.Height));
            g.DrawLine(Pens.Black, new PointF(0, h), new PointF(graph.Width, h));
        }
        private void DrawParetoOptimalGuess()
        {
            switch (f.FunctionType)
            {
                case Function.Type.Kita:
                    g.DrawImage((Bitmap)Kita.ResourceManager.GetObject("g" + scale.ToString()), new Point(0, 0));
                    break;
                case Function.Type.Kursawe:
                    g.DrawImage((Bitmap)Kursawe.ResourceManager.GetObject("g" + scale.ToString()), new Point(0, 0));
                    break;
                case Function.Type.DebBimodal:
                    g.DrawImage((Bitmap)DebBimodal.ResourceManager.GetObject("g" + scale.ToString()), new Point(0, 0));
                    break;
                case Function.Type.DTLZ1:
                    //g.DrawImage((Bitmap)DTLZ1.ResourceManager.GetObject("_" + scale.ToString()), new Point(0, 0));
                    break;
                case Function.Type.DTLZ7:
                    //g.DrawImage((Bitmap)DTLZ7.ResourceManager.GetObject("_" + scale.ToString()), new Point(0, 0));
                    break;
            }
        }
        private void DrawSearchSpace()
        {
            switch (f.FunctionType)
            {
                case Function.Type.Kita:
                    g.DrawImage((Bitmap)Kita.ResourceManager.GetObject("s" + scale.ToString()), new Point(0, 0));
                    break;
                case Function.Type.Kursawe:
                    g.DrawImage((Bitmap)Kursawe.ResourceManager.GetObject("s" + scale.ToString()), new Point(0, 0));
                    break;
                case Function.Type.DebBimodal:
                    g.DrawImage((Bitmap)DebBimodal.ResourceManager.GetObject("s" + scale.ToString()), new Point(0, 0));
                    break;
                case Function.Type.DTLZ1:
                    //g.DrawImage((Bitmap)DTLZ1.ResourceManager.GetObject("_" + scale.ToString()), new Point(0, 0));
                    break;
                case Function.Type.DTLZ7:
                    //g.DrawImage((Bitmap)DTLZ7.ResourceManager.GetObject("_" + scale.ToString()), new Point(0, 0));
                    break;
            }
        }
        private void DrawParetoOptimalGuess(Function.Type fType, Bitmap b)
        {
            //if(f == null)
            //    return;
            Particle p;
            double[] x;
            switch (fType)
            {
                case Function.Type.Kita:
                    x = new double[2];
                    for (x[0] = 0.22, x[1] = 6.47; x[0] < 5.81; x[0] += 0.005, x[1] -= 0.001)
                        //for (x[1] = 6.46; x[1] < 4.61; x[1] -= 0.01)
                        {
                            p = new Particle(f, x);
                            if (Math.Abs(p.F[0] * scale) < w && Math.Abs(p.F[1] * scale) < h)
                                b.SetPixel((int)(p.F[0] * scale + w), (int)(h - p.F[1] * scale), Color.LightGreen);
                        }
                    break;
                case Function.Type.Kursawe:
                 
                    x = new double[3];
                    for (x[0] = -1.15; x[0] < 0.45; x[0] += 0.01)
                        for (x[1] = -1.15; x[1] < -0.06; x[1] += 0.01)
                            for (x[2] = -0.20; x[2] < 0.01; x[2] += 0.01)
                            {
                            p = new Particle(f, x);
                            if (Math.Abs(p.F[0] * scale) < w && Math.Abs(p.F[1] * scale) < h)
                                b.SetPixel((int)(p.F[0] * scale + w), (int)(h - p.F[1] * scale), Color.LightGreen);
                        }
                    break;
                case Function.Type.DebBimodal:
                    x = new double[2];
                    for (x[0] = 0.1; x[0] < 0.1001; x[0] += 0.0001)
                        for (x[1] = 0.10; x[1] < 0.81; x[1] += 0.01)
                        {
                            p = new Particle(f, x);
                            if (Math.Abs(p.F[0] * scale) < w && Math.Abs(p.F[1] * scale) < h)
                                b.SetPixel((int)(p.F[0] * scale + w), (int)(h - p.F[1] * scale), Color.LightGreen);
                        }
                    break;
            }
        }
        private void DrawSearchSpace(Function.Type fType, Bitmap b)
        {
            //if(f == null)
            //    return;
            Particle p;
            double[] x;
            switch (fType)
            {
                case Function.Type.Kita:
                    x = new double[2];
                    for (x[0] = 0.0; x[0] < 7.1; x[0] += 0.1)
                        for (x[1] = 0.0; x[1] < 7.1; x[1] += 0.1)
                        {
                            p = new Particle(f, x);
                            if (Math.Abs(p.F[0] * scale) < w && Math.Abs(p.F[1] * scale) < h)
                                b.SetPixel((int)(p.F[0] * scale + w), (int)(h - p.F[1] * scale), Color.LightSlateGray);
                        }
                    break;
                case Function.Type.Kursawe:

                    x = new double[3];
                    for (x[0] = -5.0; x[0] < 5.1; x[0] += 0.1)
                        for (x[1] = -5.0; x[1] < 5.1; x[1] += 0.1)
                            for (x[2] = -5.0; x[2] < 5.1; x[2] += 0.1)
                            {
                                p = new Particle(f, x);
                                if (Math.Abs(p.F[0] * scale) < w && Math.Abs(p.F[1] * scale) < h)
                                    b.SetPixel((int)(p.F[0] * scale + w), (int)(h - p.F[1] * scale), Color.LightSlateGray);
                            }
                    break;
                case Function.Type.DebBimodal:
                    x = new double[2];
                    for (x[0] = 0.1; x[0] < 1.01; x[0] += 0.01)
                        for (x[1] = 0.1; x[1] < 1.01; x[1] += 0.01)
                        {
                            p = new Particle(f, x);
                            if (Math.Abs(p.F[0] * scale) < w && Math.Abs(p.F[1] * scale) < h)
                                b.SetPixel((int)(p.F[0] * scale + w), (int)(h - p.F[1] * scale), Color.LightSlateGray);
                        }
                    break;
            }
        }
        private void DrawParetoOptimalFront()
        {
            switch (f.FunctionType)
            {
                case Function.Type.Kita:
                    g.DrawImage((Bitmap)Kita.ResourceManager.GetObject("_" + scale.ToString()), new Point(0, 0));
                    break;
                case Function.Type.Kursawe:
                    g.DrawImage((Bitmap)Kursawe.ResourceManager.GetObject("_" + scale.ToString()), new Point(0, 0));
                    break;
                case Function.Type.DebBimodal:
                    g.DrawImage((Bitmap)DebBimodal.ResourceManager.GetObject("_" + scale.ToString()), new Point(0, 0));
                    break;
                case Function.Type.DTLZ1:
                    g.DrawImage((Bitmap)DTLZ1.ResourceManager.GetObject("_" + scale.ToString()), new Point(0, 0));
                    break;
                case Function.Type.DTLZ7:
                    g.DrawImage((Bitmap)DTLZ7.ResourceManager.GetObject("_" + scale.ToString()), new Point(0, 0));
                    break;
            }
            //for (int i = 0; i <= pretoOptimalSet.GetUpperBound(0); i++)
            //{
            //    //g.DrawImage(blackPixel, (float)(pretoOptimalSet[i, 0] * scale + w), (float)(h - pretoOptimalSet[i, 1] * scale));
            //    if (Math.Abs(pretoOptimalSet[i, 0] * scale) < w && Math.Abs(pretoOptimalSet[i, 1] * scale) < h) 
            //        graph.SetPixel((int)(pretoOptimalSet[i, 0] * scale + w), (int)(h - pretoOptimalSet[i, 1] * scale), Color.Black);
            //}
        }
        private void DrawNonDominated()
        {
            for (int i = 0; i < nonDominated.Count; i++)
            {
                if (Math.Abs(nonDominated[i].F[0] * scale) < w && Math.Abs(nonDominated[i].F[1] * scale) < h)
                {
                    graph.SetPixel((int)(nonDominated[i].F[0] * scale + w), (int)(h - nonDominated[i].F[1] * scale), Color.Red);
                    graph.SetPixel((int)(nonDominated[i].F[0] * scale + w + 1), (int)(h - nonDominated[i].F[1] * scale), Color.Red);
                    graph.SetPixel((int)(nonDominated[i].F[0] * scale + w - 1), (int)(h - nonDominated[i].F[1] * scale), Color.Red);
                    graph.SetPixel((int)(nonDominated[i].F[0] * scale + w), (int)(h + 1 - nonDominated[i].F[1] * scale), Color.Red);
                    graph.SetPixel((int)(nonDominated[i].F[0] * scale + w), (int)(h - 1 - nonDominated[i].F[1] * scale), Color.Red);
                }
            }
        }
        private void DrawDominated()
        {
            for (int i = 0; i < dominated.Count; i++)
            {
                if (Math.Abs(dominated[i].F[0] * scale) < w && Math.Abs(dominated[i].F[1] * scale) < h) 
                    graph.SetPixel((int)(dominated[i].F[0] * scale + w), (int)(h - dominated[i].F[1] * scale), Color.Blue);
            }
        }
        private void DrawGridParticles()
        {
            for (int i = 0; i < gridParticles.Count; i++)
            {
                if (Math.Abs(gridParticles[i].F[0] * scale) < w && Math.Abs(gridParticles[i].F[1] * scale) < h)
                    graph.SetPixel((int)(gridParticles[i].F[0] * scale + w), (int)(h - gridParticles[i].F[1] * scale), Color.LightGreen);
            }
        }
        private void DrawSelected()
        {
            for (int i = 0; i < selected.Count; i++)
            {
                if (Math.Abs(selected[i].F[0] * scale) < w && Math.Abs(selected[i].F[1] * scale) < h)
                {
                    graph.SetPixel((int)(selected[i].F[0] * scale + w), (int)(h - selected[i].F[1] * scale), Color.Orange);
                    graph.SetPixel((int)(selected[i].F[0] * scale + w + 1), (int)(h - selected[i].F[1] * scale), Color.Orange);
                    graph.SetPixel((int)(selected[i].F[0] * scale + w - 1), (int)(h - selected[i].F[1] * scale), Color.Orange);
                    graph.SetPixel((int)(selected[i].F[0] * scale + w), (int)(h + 1 - selected[i].F[1] * scale), Color.Orange);
                    graph.SetPixel((int)(selected[i].F[0] * scale + w), (int)(h - 1 - selected[i].F[1] * scale), Color.Orange);
                }
            }
        }
        private void UpdateGraph()
        {
            ClearGraph();
            if (chkDrawDominated.Checked)
                DrawDominated();
            if (chkGridSearch.Checked)
                DrawGridParticles();
            if (chkDisplaySearchSpace.Checked)
                DrawSearchSpace();
            if(chkDisplayGuess.Checked)
                DrawParetoOptimalGuess();
            if (pretoOptimalSet != null)
                DrawParetoOptimalFront();
            DrawNonDominated();
            DrawSelected();
            if (chkDisplayGuess.Checked)
                DrawParetoOptimalGuess(f.FunctionType, graph);
            //g.DrawImage(graphKitaGuess, new Point(0,0));
            picGraph.Refresh();
        }
        private void AddSelected(Particle p)
        {
            for (int i = 0; i < selected.Count; i++)
            {
                if (selected[i].GetDistance(p.X) < ngh/2)
                    return;
            }
            selected.Add(p);
        }
        private void Run(int maxParticle, int maxIteration)
        {
            lblNonDominatedCount.Text = "Non Dominated Solutions : ";
            lblGenerationalDistance.Text = "Generational Distance : ";
            lblSpacing.Text = "Spacing : ";
            lblErrorRatio.Text = "Error Ratio : ";
            ngh = Double.Parse(txtNghRadius.Text);
            nonDominated = new List<Particle>();
            dominated = new List<Particle>();
            selected = new List<Particle>();
            gridParticles = new List<Particle>();
            Random r = new Random();
            //Function f = new Function(Function.Type.DTLZ7);
            f = new Function((Function.Type)Enum.Parse(typeof(Function.Type), cboFunction.Text));
            pretoOptimalSet = f.PretoOptimalSet;
            //double[,] range = new double[f.SolutionSpaceDimensions,2];
            //for (int i = 0; i < f.SolutionSpaceDimensions; i++)
            //{
            //    range[i, 0] = -5;
            //    range[i, 1] = 5;
            //}
            //range[1,0] = 0;
            //range[1,1] = 7;
            double[,] range = f.Range;
            double[,] tempRange = new double[f.SolutionSpaceDimensions,2];
            Particle[] particles = new Particle[maxParticle];
            for (int iter = 0; iter < maxIteration; iter++)
            {
                for (int p = 0; p < maxParticle; p++)
                {
                    if (!chkRandomPlacement.Checked &&  p < maxParticle * 0.75 && selected.Count > 0)
                    {
                        //int tempNonDominatedIndex = (int)(r.NextDouble() * nonDominated.Count);
                        int tempNonDominatedIndex = (int)(r.NextDouble() * selected.Count);
                        for (int i = 0; i < f.SolutionSpaceDimensions; i++)
                        {
                            tempRange[i, 0] = selected[tempNonDominatedIndex].X[0] - ngh;
                            tempRange[i, 1] = tempRange[0, 0] + ngh * 2;
                        }
                        //tempRange[1, 0] = selected[tempNonDominatedIndex].X[1] - ngh;
                        //tempRange[1, 1] = tempRange[1, 0] + ngh * 2;
                        particles[p] = new Particle(f, r, tempRange);
                    }
                    else
                    {
                        particles[p] = new Particle(f, r, range);
                    }
                    //AddSelected(particles[p]);
                    nonDominated.Add(particles[p]);
                    dominated.Add(particles[p]);
//                    Rectangle rect = new Rectangle(new Point((int)(particles[p].F[0] * scale + w), (int)(h - particles[p].F[1] * scale)), new Size(3, 3));
                    //graph.SetPixel((int)(particles[p].F[0]*scale + w), (int)(h - particles[p].F[1]*scale), Color.Red);
//                    Invalidate(rect);
                }
                toRemove = new List<Particle>();
                selected = new List<Particle>();
                for( int p=0; p < nonDominated.Count; p++)
                {
                    if (!nonDominated[p].IsNonDominated(nonDominated))
                    {
                        //dominated.Add(nonDominated[p]);
                        toRemove.Add(nonDominated[p]);
                        //Rectangle rect = new Rectangle(new Point((int)(nonDominated[p].F[0] * scale + w), (int)(h - nonDominated[p].F[1] * scale)), new Size(3, 3));
                        //graph.SetPixel((int)(nonDominated[p].F[0]*scale + w), (int)(h - nonDominated[p].F[1]*scale), Color.White); 
                        //Invalidate(rect);
                    }
                    else
                        AddSelected(nonDominated[p]);
                }
                for (int p = 0; p < toRemove.Count; p++)
                {
                    nonDominated.Remove(toRemove[p]);
                }
                //Invalidate(
                lblNonDominatedCount.Text = "Non Dominated Solutions : " + nonDominated.Count.ToString();
                UpdateGraph();
                //Invalidate();
                Application.DoEvents();
                if (chkGridSearch.Checked)
                    DoGridSearch();
                pbrIterations.Increment(1);
            }
            //int minIndex;
            double minDistance;
            double objDistSum = 0;
            double[] x2 = new double[f.ObjectiveSpaceDimensions];
            for (int i = 0; i < nonDominated.Count; i++)
            {
                //minIndex = 0;
                minDistance = Double.MaxValue;
                //double[] x2;
                for (int j = 0; j <= pretoOptimalSet.GetUpperBound(0); j++)
                {
                    for(int k = 0; k < f.ObjectiveSpaceDimensions; k++)
                        x2[k] = pretoOptimalSet[j, k];
                    //x2[1] = pretoOptimalSet[j, 1];
                    if (nonDominated[i].GetObjectiveSpaceDistance(x2) < minDistance)
                    {
                        minDistance = nonDominated[i].GetObjectiveSpaceDistance(x2);
                        //minIndex = j;
                    }
                }
                //objDistSum += nonDominated[i].GetObjectiveSpaceDistance(new Particle(x2)) * nonDominated[i].GetObjectiveSpaceDistance(new Particle(x2));
                objDistSum += minDistance * minDistance;
            }
            objDistSum = Math.Sqrt(objDistSum);
            objDistSum /= nonDominated.Count;
            lblGenerationalDistance.Text = "Generational Distance : " + objDistSum.ToString();
            double[] d = new double[nonDominated.Count];
            double dAvg = 0;
            double dSum = 0;
            for (int i = 0; i < nonDominated.Count; i++)
            {
                d[i] = Double.MaxValue;
                for (int j = 0; j < nonDominated.Count; j++)
                {
                    if(i != j)
                    {
                        double temp = Math.Abs(nonDominated[i].F[0] - nonDominated[j].F[0]) + Math.Abs(nonDominated[i].F[1] - nonDominated[j].F[1]);
                        if (temp < d[i])
                            d[i] = temp;
                    }
                }
                dAvg += d[i];
            }
            dAvg /= d.Length;
            for (int i = 0; i < d.Length; i++)
            {
                dSum += (dAvg - d[i]) * (dAvg - d[i]);
            }
            dSum /= d.Length - 1;
            lblSpacing.Text = "Spacing : " + dSum.ToString();
            double c = 0;
            bool found;
            double acceptedDev = 0.01;
            for (int i = 0; i < nonDominated.Count; i++)
            {
                found = false;
                for (int j = 0; j <= pretoOptimalSet.GetUpperBound(0); j++)
                {
                    if (Math.Sqrt((nonDominated[i].F[0] - pretoOptimalSet[j, 0])*(nonDominated[i].F[0] - pretoOptimalSet[j, 0]) + (nonDominated[i].F[1] - pretoOptimalSet[j, 1])*(nonDominated[i].F[1] - pretoOptimalSet[j, 1])) < acceptedDev)
                    {
                        found = true;
                        break;
                    }

                }
                if (!found)
                    c++;
            }
            c /= nonDominated.Count;
            lblErrorRatio.Text = "Error Ratio : " + c.ToString();
            return;
        }

        private void DoGridSearch()
        {
            int depth = int.Parse(txtGridDepth.Text);
            Particle p;// = new Particle[depth * 8];
            //int p = 0;
            double[] x = new double[2];
            List<Particle> tempNonDominated = new List<Particle>(nonDominated);
            for (int d = 0; d < nonDominated.Count; d++)
            {
                for (int i = -depth; i <= depth; i++)
                    for (int j = -depth; j <= depth; j++)
                    {
                        if (i != 0 || j != 0)
                        {
                            x[0] = nonDominated[d].X[0] + i * ngh;
                            x[1] = nonDominated[d].X[1] + j + ngh;
                            p = new Particle(f, x);
                            if (p.F[0] != Double.PositiveInfinity && p.F[1] != Double.PositiveInfinity)
                            {
                                tempNonDominated.Add(p);
                                gridParticles.Add(p);
                            }
                            //p++;
                        }
                    }
                List<Particle> toRemove = new List<Particle>();
                for (int i = 0; i < tempNonDominated.Count; i++)
                {
                    if (!tempNonDominated[i].IsNonDominated(tempNonDominated))
                        toRemove.Add(tempNonDominated[i]);
                }
                for (int i = 0; i < toRemove.Count; i++)
                {
                    tempNonDominated.Remove(toRemove[i]);
                }
            }
            nonDominated = new List<Particle>(tempNonDominated);
            //throw new Exception("The method or operation is not implemented.");
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    Graphics g = e.Graphics;
        //    //Font font = new Font("Times New Roman", 8);
        //    //Brush brush = new SolidBrush(Color.Red);
        //    //Brush brush2 = new SolidBrush(Color.Blue);
        //    //Brush brush3 = new SolidBrush(Color.Black);
        //    //Pen pen = new Pen(brush);
        //    //Pen pen2 = new Pen(brush2);
        //    //Pen pen3 = new Pen(brush3);
            
        //    //w = Size.Width / 2;
        //    //h = Size.Height / 2;
        //    if (chkDrawDominated.Checked)
        //    {
        //        for (int i = 0; i < dominated.Count; i++)
        //        {
        //            //g.DrawString(".", font, brush2, new PointF((float)dominated[i].F1()*10+w, h -(float)dominated[i].F2()*20));
        //            //g.DrawEllipse(pen2, new Rectangle(new Point((int)(dominated[i].F[0] * 10 + w), (int)(h - dominated[i].F[1] * 10)), new Size(1, 1)));
        //            g.DrawImage(bluePixel, (float)(dominated[i].F[0] * scale + w), (float)(h - dominated[i].F[1] * scale));
        //        }
        //    }
        //    if (pretoOptimalSet != null)
        //        for (int i = 0; i <= pretoOptimalSet.GetUpperBound(0); i++)
        //        {
        //            //Particle p = new Particle(new double[2] { pretoOptimalSet[i, 0], pretoOptimalSet[i, 1] });
        //            //                if(p.F[0] != Double.PositiveInfinity && p.F[1] != Double.PositiveInfinity)
        //            //                    g.DrawEllipse(pen3, new Rectangle(new Point((int)(p.F1() * 10 + w), (int)(h - p.F2() * 30)), new Size(1, 1)));
        //            //if (p.F[0] != Double.PositiveInfinity && p.F[1] != Double.PositiveInfinity)
        //            //g.DrawEllipse(pen3, new Rectangle(new Point((int)(pretoOptimalSet[i, 0] * 10 + w), (int)(h - pretoOptimalSet[i, 1] * 10)), new Size(1, 1)));
        //            //g.DrawLine(pen3, new Point((int)(pretoOptimalSet[i, 0] * 10 + w), (int)(h - pretoOptimalSet[i, 1] * 10)), new Point((int)(pretoOptimalSet[i, 0] * 10 + w)+1, (int)(h - pretoOptimalSet[i, 1] * 10)+1));
        //            g.DrawImage(blackPixel, (float)(pretoOptimalSet[i, 0] * scale + w), (float)(h - pretoOptimalSet[i, 1] * scale));
        //        }

        //    for (int i = 0; i < nonDominated.Count; i++)
        //    {
        //        //g.DrawString("*", font, brush, new PointF((float)nonDominated[i].F1()*10+w, h -(float)nonDominated[i].F2()*20));
        //        //g.DrawEllipse(pen, new Rectangle(new Point((int)(nonDominated[i].F[0] * 10 + w), (int)(h - nonDominated[i].F[1] * 10)), new Size(2, 2)));
        //        //e.Graphics.DrawImageUnscaled(bm,<xPosition>,<yPosition>);

        //        g.DrawImage(redPixel, (float)(nonDominated[i].F[0] * scale + w), (float)(h - nonDominated[i].F[1] * scale));
        //    }
        //    //Pen pen = new Pen(brush);
        //    //g.DrawEllipse(pen, new Rectangle(new Point(100, 100), new Size(1, 1)));
        //    //g.DrawString("*", font, brush, new PointF(50, 50));
        //    //g.DrawRectangle(pen, new Rectangle(new Point(100,100),new Size(2,2)));
        //    g.DrawLine(Pens.Red, new PointF(w, 0), new PointF(w, Size.Height));
        //    g.DrawLine(Pens.Red,new PointF(0,h), new PointF(Size.Width,h));
        //}



        private void btnRun_Click(object sender, EventArgs e)
        {
            int maxParticles = Int32.Parse(txtMaxParticles.Text);
            int maxIterations = Int32.Parse(txtMaxIterations.Text);
            Invalidate();
            btnRun.Enabled = false;
            pbrIterations.Minimum = 0;
            pbrIterations.Maximum = maxIterations;
            pbrIterations.Value = 0;
            Run(maxParticles, maxIterations);
            pbrIterations.Value = 0;
            btnRun.Enabled = true;
            return;
        }

        private void chkDrawDominated_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void cboScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            double zoom = Double.Parse(cboZoom.Text) * .01;
            picGraph.Height = (int)(graph.Height * zoom);
            picGraph.Width = (int)(graph.Width * zoom);
            //picGraph.AutoScrollOffset.X = (int)(picGraph.AutoScrollOffset.X * zoom);
            //picGraph.AutoScrollOffset.Y = (int)(picGraph.AutoScrollOffset.Y * zoom);
            picGraph.AutoScrollOffset = new Point((int)(picGraph.AutoScrollOffset.X * zoom),(int)(picGraph.AutoScrollOffset.Y * zoom));
            Invalidate();
        }

        private void cboScale_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            scale = Double.Parse(cboScale.Text);
            UpdateGraph();
        }

        private void chkDisplayGuess_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        private void cboFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            f = new Function((Function.Type)Enum.Parse(typeof(Function.Type), cboFunction.Text));
            pretoOptimalSet = f.PretoOptimalSet;
            UpdateGraph();
        }

        private void chkDisplaySearchSpace_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        private void chkDrawDominated_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateGraph();
        }
    }
}