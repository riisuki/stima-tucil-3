using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas_Kecil_3_Stima
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void eNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iDToolStripMenuItem.Checked = false;
            eNToolStripMenuItem.Checked = true;
            fileToolStripMenuItem.Text = "File";
            exitToolStripMenuItem.Text = "Exit";
            languageToolStripMenuItem.Text = "Language";
            helpToolStripMenuItem.Text = "Help";
            guideToolStripMenuItem.Text = "Guide";
            aboutToolStripMenuItem.Text = "About";
            browseButton.Text = "Browse";
            fromText.Text = "From:";
            toText.Text = "To:";
        }

        private void iDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eNToolStripMenuItem.Checked = false;
            iDToolStripMenuItem.Checked = true;
            fileToolStripMenuItem.Text = "Berkas";
            exitToolStripMenuItem.Text = "Keluar";
            languageToolStripMenuItem.Text = "Bahasa";
            helpToolStripMenuItem.Text = "Bantuan";
            guideToolStripMenuItem.Text = "Panduan";
            aboutToolStripMenuItem.Text = "Tentang";
            browseButton.Text = "Telusuri";
            fromText.Text = "Dari:";
            toText.Text = "Ke:";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            //create a form 
           // System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            //create a viewer object 
            //Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 
            graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            //bind the graph to the viewer 
            gViewer1.Graph = graph;

            //associate the viewer with the form 
            //form.SuspendLayout();
            //viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            //form.Controls.Add(viewer);
            //form.ResumeLayout();
            //show the form 
            //form.ShowDialog();
        }
    }
}
