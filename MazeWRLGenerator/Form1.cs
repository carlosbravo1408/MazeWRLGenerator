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
using System.Diagnostics;

namespace MazeWRLGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
//take from https://www.mathworks.com/matlabcentral/cody/groups/33/problems/283
        Graphics area;
        string ubicacion = Directory.GetCurrentDirectory();
        Color[] colores = new Color[] { Color.White, Color.GhostWhite, Color.Red, Color.Black };
        Pen lapiz = new Pen(Color.GhostWhite, 1);
        private void Form1_Load(object sender, EventArgs e)
        {
            area = pictureBox1.CreateGraphics();
            rdb_intxt_CheckedChanged(sender, e);
            rdb_outtxt.Checked = true;
            rdb_outtxt_CheckedChanged(sender, e);
            nudx_ValueChanged(sender, e);
            Form1_SizeChanged(sender, e);
            //Text = ":v";
        }

        private void rdb_intxt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_intxt.Checked == true)
            {
                richTextBox1.Text = "";
                richTextBox1.ReadOnly = false;
                nudx.Enabled = false;
                nudy.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = true;
                rdb_0.Enabled = false;
                rdb_1.Enabled = false;
                rdb_2.Enabled = false;
                rdb_3.Enabled = false;
                contextMenuStrip1.Visible = false;
                contextMenuStrip1.Enabled = false;
            }
        }

        private void rdb_outtxt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_outtxt.Checked == true)
            {
                richTextBox1.Text = "";
                richTextBox1.ReadOnly = true;
                nudx.Enabled = true;
                nudy.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = false;
                rdb_0.Enabled = true;
                rdb_1.Enabled = true;
                rdb_2.Enabled = true;
                rdb_3.Enabled = true;
                contextMenuStrip1.Visible = true;
                contextMenuStrip1.Enabled = true;
                nudx_ValueChanged(sender, e);
                //panel1_DoubleClick(sender, e);
                //Form3 gen = new Form3();
                //gen.MdiParent = this;
                //gen.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char sepx = '\t';
            char sepy = '\n';
            richTextBox1.Text = "";
            if (rdb_spacdot.Checked == true)
            {
                sepx = ' ';
                sepy = ';';
            }
            if (rdb_tabn.Checked == true)
            {
                sepx = '\t';
                sepy = '\n';
            }
            for (int i = 0; i < funcion.GetLength(0); i++)
            {
                for (int j = 0; j < funcion.GetLength(1); j++)
                {
                    richTextBox1.Text = richTextBox1.Text + Convert.ToString(funcion[i, j]);
                    if (j < funcion.GetLength(1) - 1)
                        richTextBox1.Text = richTextBox1.Text + sepx;
                }
                if (i < funcion.GetLength(0) - 1)
                    richTextBox1.Text = richTextBox1.Text + sepy;
            }
            //Process.Start("C:\\Users\\Ark\\Desktop\\vrml1.wrl");
        }
        int i = 0, lineas = 0;
        int[,] funcion;
        string[] linea = null;
        int columnas = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            i = 0;
            lineas = 0;
            string aux = richTextBox1.Text;
            if (richTextBox1.TextLength != 0)
            {
                /*
                 * por cada caracter existente, detectará si existe salto de línea, 
                 * para determinar el número de líneas totales
                 */
                if (aux.Split('\n').Length >= 5)
                {
                    linea = aux.Split('\n');
                    if (aux[richTextBox1.TextLength - 1] == '\n')
                    {
                        lineas = linea.Length - 1;
                    }
                    else
                    {
                        lineas = linea.Length;
                    }
                    columnas = linea[0].Split(' ').Length;
                    funcion = new int[lineas, columnas];
                    for (i = 0; i <= lineas - 1; i++)
                    {
                        string[] cadenas = linea[i].Split('\t');
                        for (int j = 0; j <= columnas - 1; j++)
                        {
                            funcion[i, j] = Convert.ToInt16(cadenas[j]);
                        }
                    }
                }
                else
                {
                    aux = RemoveChar(aux, '[');
                    aux = RemoveChar(aux, ']');
                    linea = aux.Split(';');
                    lineas = linea.Length;
                    columnas = linea[0].Split(' ').Length;
                    funcion = new int[lineas, columnas];
                    for (i = 0; i <= lineas - 1; i++)
                    {
                        string[] cadenas = linea[i].Split(' ');
                        for (int j = 0; j <= columnas - 1; j++)
                        {
                            funcion[i, j] = Convert.ToInt16(cadenas[j]);
                        }
                    }
                }
                DrawMaze(funcion);
            }
        }
        //string lol = null;
        void DrawMaze(int[,] Matrix)
        {
            area = pictureBox1.CreateGraphics();
            area.Clear(Color.White);
            bool[,] matrix = new bool[Matrix.GetLength(0) * 4 + 1, Matrix.GetLength(1) * 4 + 1];
            /*
             *  %                                            +   +
                %     value = 0 -> 00 -> no walls         ->
                %                  NW                        +   +
                %
                %                                            +   +
                %     value = 1 -> 01 -> wall to W        -> |
                %                  NW                        +   +
                %
                %                                            +---+
                %     value = 2 -> 10 -> wall to N        ->
                %                  NW                        +   +
                %
                %                                            +---+
                %     value = 3 -> 11 -> walls to N and W -> |
                %                  NW                        +   +
             */
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if (Matrix[i, j] == 0)
                        {
                            matrix[4 * i + k, 4 * j] = false;
                            matrix[4 * i, 4 * j + k] = false;
                            //matrix[4 * i + 3, 4 * j] = true;
                            matrix[4 * i, 4 * j] = true;
                        }
                        if (Matrix[i, j] == 1)
                        {
                            matrix[4 * i, 4 * j + k] = false;
                            matrix[4 * i + k, 4 * j] = true;
                        }
                        if (Matrix[i, j] == 2)
                        {
                            matrix[4 * i + k, 4 * j] = false;
                            matrix[4 * i, 4 * j + k] = true;
                        }
                        if (Matrix[i, j] == 3)
                        {
                            matrix[4 * i, 4 * j + k] = true;
                            matrix[4 * i + k, 4 * j] = true;
                        }
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[matrix.GetLength(0) - 1, i] = true;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, matrix.GetLength(1) - 1] = true;
            }
            x = matrix.GetLength(1);
            y = matrix.GetLength(0);
            int dx = (w - 2 * tol) / x, dy = (h - 2 * tol) / y;
            tamañoNodo = min<int>(ref dx, ref dy);
            desfaseX = (w - tamañoNodo * x) / 2;
            desfaseY = (h - tamañoNodo * y) / 2;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == false)
                        graficar_nodo(0, 1, desfaseX + j * tamañoNodo, desfaseY + i * tamañoNodo, tamañoNodo);
                    else
                        graficar_nodo(2, 1, desfaseX + j * tamañoNodo, desfaseY + i * tamañoNodo, tamañoNodo);
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i % 4 == 0 && j % 4 == 0 && i < y - 1 && j < x - 1)
                        graficar_borde(3, desfaseX + j * tamañoNodo, desfaseY + i * tamañoNodo, tamañoNodo * 4);
                }
            }
        }
        int tamañoNodo, desfaseX, desfaseY;
        int x, y;
        int tol = 15;
        int w, h;

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            w = pictureBox1.Size.Width; h = pictureBox1.Size.Height;
            int m = min<int>(ref w, ref h);
            //lbl_1.Text = Convert.ToString(w) + "w - " + Convert.ToString(h) + "h - " + Convert.ToString(m) + "m";
            if (rdb_intxt.Checked == true)
                button2_Click(sender, e);
            if (rdb_outtxt.Checked == true)
                //nudx_ValueChanged(sender, e);
                try
                {
                    DrawMaze(funcion);
                    //area.Restore();
                }
                catch
                {
                    nudx_ValueChanged(sender, e);
                }
        }

        private void graficar_nodo(int colorFill, int colorBoard, int posicionX, int posicionY, int dimension)
        {
            area.FillRectangle(new SolidBrush(colores[colorFill]), posicionX, posicionY, dimension, dimension);
            Pen pen = new Pen(colores[colorBoard], 1);
            area.DrawRectangle(pen, posicionX, posicionY, dimension, dimension);
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            Form3 gen = new Form3();
            //gen.MdiParent = this;
            //gen.ShowDialog();
            gen.Show();
            gen.BringToFront();
            //((RichTextBox)frm.Controls["rtb_1"]).Text = lol;
        }
        int posX, posY, cx, cy, dx, dy;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_portapapeles_Click(object sender, EventArgs e)
        {
            Form1_SizeChanged(sender, e);
            try
            {
                System.Windows.Forms.Clipboard.SetText(richTextBox1.Text);
            }
            catch
            {

            }
        }
        StreamWriter fichero;
        private void btn_vp_Click(object sender, EventArgs e)
        {
            try
            {
                //string cadena = "#VRML V2.0 utf8\n#Created with V-Realm Builder v2.0\n#Integrated Data Systems Inc.\n#www.ids-net.com";
                fichero = new StreamWriter(ubicacion + "\\TempFiles\\test.wrl");
                //fichero.WriteLine("test"+cadena);
                //fichero.Close();
                decimal[] dimensiones = 
                {
                    (nud_esp.Value * (funcion.GetLength(1) + 3) + nud_d.Value * (funcion.GetLength(1))),
                    nud_esp.Value,
                    (nud_esp.Value * (funcion.GetLength(0) + 3) + nud_d.Value * (funcion.GetLength(0)))
                };
                string[] Comentarios = 
                {
                    "#VRML V2.0 utf8",
                    "#Creado por mi :v",
                    "#puto el que lo lea :V"
                };
                for(int i=0;i<Comentarios.Length;i++)
                {
                    fichero.WriteLine(Comentarios[i]);
                }
                string maze = "#" + richTextBox1.Text;
                maze = RemoveChar(maze, '\n');
                maze = RemoveChar(maze, '\r');
                fichero.WriteLine(maze);
                string[] evnDescription = 
                {
                    "DirectionalLight {",
                    "   color	1 1 1",
	                "   direction	-0.57735 -0.57735 -0.57735",
	                "   intensity	1",
                    "}",
                    "DirectionalLight {",
                    "	direction	0 0 1",
                    "}",
                    "DirectionalLight {",
                    "	direction	0.57735 0.57735 -0.57735",
                    "}",
                    "WorldInfo {",
                    "    info    \"By MazeGenerator v:\"",
                    "    title   \"Maze" + "Test" + "\"",
                    "}"
                };
                for (int i = 0; i < evnDescription.Length; i++)
                {
                    fichero.WriteLine(evnDescription[i]);
                }
                double despx = -(double)nud_esp.Value * 2 - (double)nud_d.Value / 2 + (double)dimensiones[0] * (0.5);
                double despz = -(double)nud_esp.Value * 2 - (double)nud_d.Value / 2 + (double)dimensiones[2] * (0.5);
                double despy = (double)nud_esp.Value / 2 + (double)nud_h.Value / 2;
                string[] piso =
                {
                    "DEF Env Transform {",
                    "    translation " + despx.ToString().Replace(',','.') +" " + despz.ToString().Replace(',','.') + " 0.38",
                    "	rotation	1 0 0  1.5708",
                    "    scale   1 1 1",
                    "    children [",
                    "        Shape {",
                    "            appearance  Appearance {",
                    "                material    Material {",
                    "                    ambientIntensity    0.1",
                    "                    diffuseColor    0.8 0.8 0.8",
                    "                   emissiveColor   0 0 0",
                    "                    shininess   0.2",
                    "                    specularColor   1 1 1",
                    "                   transparency    0",
                    "                }",
                    "                texture NULL",
                    "            }",
                    "            geometry    Box {",
                    "                size    "+Convert.ToString(dimensiones[0]).Replace(',','.')+" "+Convert.ToString(dimensiones[1]).Replace(',','.')+" "+Convert.ToString(dimensiones[2]).Replace(',','.'),
                    "		    }",
                    "	    }"
                };
                for (int i = 0; i < piso.Length; i++)
                {
                    fichero.WriteLine(piso[i]);
                }
                #region Columnas
                for(int i=0;i<funcion.GetLength(0)+1;i++)
                {
                    for(int j=0;j<funcion.GetLength(1)+1;j++)
                    {
                        despx = (double)nud_esp.Value * (1.5+j) + (double)nud_d.Value * j - (double)dimensiones[0] * (0.5);
                        despz = (double)nud_esp.Value * (1.5+i) + (double)nud_d.Value * i - (double)dimensiones[2] * (0.5);
                        string[] columna =
                        {
                            "	    DEF col"+Convert.ToString(i)+Convert.ToString(j)+" Transform {",
                            "		    translation	"+Convert.ToString(despx).Replace(',','.') + " "+Convert.ToString(despy).Replace(',','.') + " "+Convert.ToString(despz).Replace(',','.'),
                            "		    children Shape {",
                            "			    appearance	Appearance {",
                            "				    material	Material {",
                            "					    ambientIntensity	0.1",
                            "					    diffuseColor	1 0 0",
                            "					    emissiveColor	0 0 0",
                            "					    shininess	0.2",
                            "					    specularColor	1 1 1",
                            "					    transparency	0",
                            "				    }",
                            "			    }",
                            "			    geometry	Box {",
                            "				    size	"+Convert.ToString(nud_esp.Value).Replace(',','.')+" "+Convert.ToString(nud_h.Value).Replace(',','.')+" "+Convert.ToString(nud_esp.Value).Replace(',','.'),//0.012 0.1 0.012",
                            "			    }",
                            "		    }",
                            "	    }"
                        };
                        for(int k=0;k<columna.Length;k++)
                        {
                            fichero.WriteLine(columna[k]);
                        }
                    }
                }
                #endregion
                #region paredes horizontales
                for (int i = 0; i < funcion.GetLength(0)+1; i++)
                {
                    for (int j = 0; j < funcion.GetLength(1); j++)
                    {
                        despx = (double)nud_esp.Value *(2+j) + (double)nud_d.Value * j + (double)nud_d.Value/2 + (double)dimensiones[0] * (-0.5);
                        despz = (double)nud_esp.Value * (1.5+i) + (double)nud_d.Value * i + (double)dimensiones[2] * (-0.5);
                        if (i < funcion.GetLength(0))
                        {
                            if (funcion[i, j] == 2 || funcion[i, j] == 3)
                            {
                                string[] hwall =
                                {
                                "	    DEF hwall"+Convert.ToString(i)+Convert.ToString(j)+" Transform {",
                                "		    translation	"+Convert.ToString(despx).Replace(',','.') + " "+Convert.ToString(despy).Replace(',','.') + " "+Convert.ToString(despz).Replace(',','.'),
                                "		    children Shape {",
                                "			    appearance	Appearance {",
                                "				    material	Material {",
                                "					    ambientIntensity	0.1",
                                "					    diffuseColor	0.9 0.767329 0.619635",
                                "					    emissiveColor	0 0 0",
                                "					    shininess	0.2",
                                "					    specularColor	0 0 0",
                                "					    transparency	0",
                                "				    }",
                                "			    }",
                                "			    geometry	Box {",
                                "				    size	"+Convert.ToString(nud_d.Value).Replace(',','.')+" "+Convert.ToString(nud_h.Value).Replace(',','.')+" "+Convert.ToString(nud_esp.Value).Replace(',','.'),//0.012 0.1 0.012",
                                "			    }",
                                "		    }",
                                "	    }"
                                };
                                for (int k = 0; k < hwall.Length; k++)
                                {
                                    fichero.WriteLine(hwall[k]);
                                }
                            }
                        } else if(i== funcion.GetLength(0))
                        {
                            string[] hwall =
                                {
                                "	    DEF hwall"+Convert.ToString(i)+Convert.ToString(j)+" Transform {",
                                "		    translation	"+Convert.ToString(despx).Replace(',','.') + " "+Convert.ToString(despy).Replace(',','.') + " "+Convert.ToString(despz).Replace(',','.'),
                                "		    children Shape {",
                                "			    appearance	Appearance {",
                                "				    material	Material {",
                                "					    ambientIntensity	0.1",
                                "					    diffuseColor	0.9 0.767329 0.619635",
                                "					    emissiveColor	0 0 0",
                                "					    shininess	0.2",
                                "					    specularColor	0 0 0",
                                "					    transparency	0",
                                "				    }",
                                "			    }",
                                "			    geometry	Box {",
                                "				    size	"+Convert.ToString(nud_d.Value).Replace(',','.')+" "+Convert.ToString(nud_h.Value).Replace(',','.')+" "+Convert.ToString(nud_esp.Value).Replace(',','.'),//0.012 0.1 0.012",
                                "			    }",
                                "		    }",
                                "	    }"
                                };
                            for (int k = 0; k < hwall.Length; k++)
                            {
                                fichero.WriteLine(hwall[k]);
                            }
                        }
                    }
                }
                #endregion
                #region paredes verticales
                for (int i = 0; i < funcion.GetLength(0); i++)
                {
                    for (int j = 0; j < funcion.GetLength(1)+1; j++)
                    {
                        despz = (double)nud_esp.Value * (2+i) + (double)nud_d.Value * i + (double)nud_d.Value / 2 + (double)dimensiones[2] * (-0.5);
                        despx = (double)nud_esp.Value * (1.5+j) + (double)nud_d.Value * j + (double)dimensiones[0] * (-0.5);
                        if (j < funcion.GetLength(1))
                        {
                            if (funcion[i, j] == 1 || funcion[i, j] == 3)
                            {
                                string[] vwall =
                                {
                                "	    DEF vwall"+Convert.ToString(i)+Convert.ToString(j)+" Transform {",
                                "		    translation	"+Convert.ToString(despx).Replace(',','.') + " "+Convert.ToString(despy).Replace(',','.') + " "+Convert.ToString(despz).Replace(',','.'),
                                "		    children Shape {",
                                "			    appearance	Appearance {",
                                "				    material	Material {",
                                "					    ambientIntensity	0.1",
                                "					    diffuseColor	0.9 0.767329 0.619635",
                                "					    emissiveColor	0 0 0",
                                "					    shininess	0.2",
                                "					    specularColor	0 0 0",
                                "					    transparency	0",
                                "				    }",
                                "			    }",
                                "			    geometry	Box {",
                                "				    size	"+Convert.ToString(nud_esp.Value).Replace(',','.')+" "+Convert.ToString(nud_h.Value).Replace(',','.')+" "+Convert.ToString(nud_d.Value).Replace(',','.'),//0.012 0.1 0.012",
                                "			    }",
                                "		    }",
                                "	    }"
                                };
                                for (int k = 0; k < vwall.Length; k++)
                                {
                                    fichero.WriteLine(vwall[k]);
                                }
                            }
                        }
                        else if(j == funcion.GetLength(1))
                        {
                            string[] vwall =
                                {
                                "	    DEF vwall"+Convert.ToString(i)+Convert.ToString(j)+" Transform {",
                                "		    translation	"+Convert.ToString(despx).Replace(',','.') + " "+Convert.ToString(despy).Replace(',','.') + " "+Convert.ToString(despz).Replace(',','.'),
                                "		    children Shape {",
                                "			    appearance	Appearance {",
                                "				    material	Material {",
                                "					    ambientIntensity	0.1",
                                "					    diffuseColor	0.9 0.767329 0.619635",
                                "					    emissiveColor	0 0 0",
                                "					    shininess	0.2",
                                "					    specularColor	0 0 0",
                                "					    transparency	0",
                                "				    }",
                                "			    }",
                                "			    geometry	Box {",
                                "				    size	"+Convert.ToString(nud_esp.Value).Replace(',','.')+" "+Convert.ToString(nud_h.Value).Replace(',','.')+" "+Convert.ToString(nud_d.Value).Replace(',','.'),//0.012 0.1 0.012",
                                "			    }",
                                "		    }",
                                "	    }"
                                };
                            for (int k = 0; k < vwall.Length; k++)
                            {
                                fichero.WriteLine(vwall[k]);
                            }
                        }
                    }
                }
                #endregion
                fichero.WriteLine("	]");
                fichero.WriteLine("}");
                despx = -(double)nud_esp.Value * 2 - (double)nud_d.Value / 2 + (double)dimensiones[0] * (0.5);
                despz = -(double)nud_esp.Value * 2 - (double)nud_d.Value / 2 + (double)dimensiones[2] * (0.5);
                string[] viewpoint =
                    {
                        "DEF SuperiorEntorno Viewpoint {",
                        "	fieldOfView	1",
                        "	jump	TRUE",
                        "	position " + despx.ToString().Replace(',','.') +" " + despz.ToString().Replace(',','.') + " "+Convert.ToString(((double)max<decimal>(ref dimensiones[0],ref dimensiones[2]))/2*Math.Tan(67.5*Math.PI/180)).Replace(',','.'),
                        "	description	\"Vista Superior Laberinto\"",
                        "}",
"                         DEF Body Transform {",
"	                        translation	0 0 0",
"	                        children Transform {",
"		                        translation	0 0 0.40985",
"		                        children [ ",
"		                            DEF Base Inline {",
"			                            url	\"Cuerpo.wrl\"",
"		                            }",
"		                            DEF RuedaIzquierda Transform {",
"			                            translation	-0.04875 0 -0.0065",
"			                            children Inline {",
"				                            url	\"RuedaIzquierda.wrl\"",
"			                            }",
"		                            }",
"		                            DEF RuedaDerecha Transform {",
"			                            translation	0.04275 0 -0.0065",
"			                            children Inline {",
"				                            url	\"RuedaDerecha.wrl\"",
"			                            }",
"		                            }",
"		                            DEF VistaFrontal Transform {",
"			                            rotation	1 0 0  1.5708",
"			                            children DEF FPView1 Viewpoint {",
"				                            position	0 0.07 0.1",
"				                            description	\"Vista Frontal\"",
"			                            }",
"		                            }",
"		                            DEF VistaTrasera Transform {",
"			                            rotation	1 0 0  1.5708",
"			                            children DEF Rot Transform {",
"				                            rotation	0 1 0  3.14116",
"				                            children DEF FPView2 Viewpoint {",
"					                            position	0 0.07 0.1",
"					                            description	\"Vista Trasera\"",
"				                            }",
"			                            }",
"		                            }",
"		                            DEF VistaAlzado Viewpoint {",
"			                            position	0 0 0.5",
"			                            description	\"Vista Superior\"",
"		                            }",
"		                        ]",
"	                        }",
"                       }"
                    };
                for (int k = 0; k < viewpoint.Length; k++)
                {
                    fichero.WriteLine(viewpoint[k]);
                }
                fichero.Close();
                Process.Start(ubicacion + "\\TempFiles\\test.wrl");
            }
            catch
            {
                MessageBox.Show("¿qué has hecho culero :V\nNo sirve la cosa esta :v");
            }
        }

        private void btn_genArc_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ruta = saveFileDialog1.FileName;
                fichero = new StreamWriter(ruta);
                try
                {
                    //fichero = new StreamWriter("C:\\Users\\Ark\\Desktop" + "\\test.wrl");
                    //fichero.WriteLine("test"+cadena);
                    //fichero.Close();
                    decimal[] dimensiones =
                    {
                    (nud_esp.Value * (3 + funcion.GetLength(1)) + nud_d.Value * (funcion.GetLength(1))),
                    nud_esp.Value,
                    (nud_esp.Value * (3 + funcion.GetLength(0)) + nud_d.Value * (funcion.GetLength(0)))
                    };
                    string[] Comentarios =
                    {
                    "#VRML V2.0 utf8",
                    "#Creado por mi :v",
                    "#puto el que lo lea :V"
                    };
                    for (int i = 0; i < Comentarios.Length; i++)
                    {
                        fichero.WriteLine(Comentarios[i]);
                    }
                    string maze = "#" + richTextBox1.Text;
                    maze = RemoveChar(maze, '\n');
                    maze = RemoveChar(maze, '\r');
                    fichero.WriteLine(maze);
                    string[] name = saveFileDialog1.FileName.Split('\\');
                    string[] evnDescription =
                    {
                        "WorldInfo {",
                        "    info    \"By MazeGenerator v:\"",
                        "    title   \"Maze " + name[name.Length-1] + "\"",
                        "}"
                    };
                    for (int i = 0; i < evnDescription.Length; i++)
                    {
                        fichero.WriteLine(evnDescription[i]);
                    }
                    double despx = -(double)nud_esp.Value * 2 - (double)nud_d.Value / 2 + (double)dimensiones[0] * (0.5);
                    double despz = -(double)nud_esp.Value * 2 - (double)nud_d.Value / 2 + (double)dimensiones[2] * (0.5);
                    double despy = (double)nud_esp.Value / 2 + (double)nud_h.Value / 2;
                    string[] piso =
                    {
                        "DEF Env Transform {",
                        "    translation " + despx.ToString().Replace(',','.') +" " + despz.ToString().Replace(',','.') + " 0.38",
                        "	rotation	1 0 0  1.5708",
                        "    scale   1 1 1",
                        "    children [",
                        "        Shape {",
                        "            appearance  Appearance {",
                        "                material    Material {",
                        "                    ambientIntensity    0.1",
                        "                    diffuseColor    0.8 0.8 0.8",
                        "                   emissiveColor   0 0 0",
                        "                    shininess   0.2",
                        "                    specularColor   1 1 1",
                        "                   transparency    0",
                        "                }",
                        "                texture NULL",
                        "            }",
                        "            geometry    Box {",
                        "                size    "+Convert.ToString(dimensiones[0]).Replace(',','.')+" "+Convert.ToString(dimensiones[1]).Replace(',','.')+" "+Convert.ToString(dimensiones[2]).Replace(',','.'),
                        "		    }",
                        "	    }"
                    };
                    for (int i = 0; i < piso.Length; i++)
                    {
                        fichero.WriteLine(piso[i]);
                    }
                    #region Columnas
                    for (int i = 0; i < funcion.GetLength(0) + 1; i++)
                    {
                        for (int j = 0; j < funcion.GetLength(1) + 1; j++)
                        {
                            despx = (double)nud_esp.Value * (1.5+j) + (double)nud_d.Value * j + (double)dimensiones[0] * (-0.5);
                            despz = (double)nud_esp.Value * (1.5+i) + (double)nud_d.Value * i + (double)dimensiones[2] * (-0.5);
                            string[] columna =
                            {
                                "	    DEF col"+Convert.ToString(i)+Convert.ToString(j)+" Transform {",
                                "		    translation	"+Convert.ToString(despx).Replace(',','.') + " "+Convert.ToString(despy).Replace(',','.') + " "+Convert.ToString(despz).Replace(',','.'),
                                "		    children Shape {",
                                "			    appearance	Appearance {",
                                "				    material	Material {",
                                "					    ambientIntensity	0.1",
                                "					    diffuseColor	1 0 0",
                                "					    emissiveColor	0 0 0",
                                "					    shininess	0.2",
                                "					    specularColor	1 1 1",
                                "					    transparency	0",
                                "				    }",
                                "			    }",
                                "			    geometry	Box {",
                                "				    size	"+Convert.ToString(nud_esp.Value).Replace(',','.')+" "+Convert.ToString(nud_h.Value).Replace(',','.')+" "+Convert.ToString(nud_esp.Value).Replace(',','.'),//0.012 0.1 0.012",
                                "			    }",
                                "		    }",
                                "	    }"
                            };
                            for (int k = 0; k < columna.Length; k++)
                            {
                                fichero.WriteLine(columna[k]);
                            }
                        }
                    }
                    #endregion
                    #region paredes horizontales
                    for (int i = 0; i < funcion.GetLength(0) + 1; i++)
                    {
                        for (int j = 0; j < funcion.GetLength(1); j++)
                        {
                            despx = (double)nud_esp.Value * (2+j) + (double)nud_d.Value * j + (double)nud_d.Value / 2 + (double)dimensiones[0] * (-0.5);
                            despz = (double)nud_esp.Value * (1.5+i) + (double)nud_d.Value * i + (double)dimensiones[2] * (-0.5);
                            if (i < funcion.GetLength(0))
                            {
                                if (funcion[i, j] == 2 || funcion[i, j] == 3)
                                {
                                    string[] hwall =
                                    {
                                    "	    DEF hwall"+Convert.ToString(i)+Convert.ToString(j)+" Transform {",
                                    "		    translation	"+Convert.ToString(despx).Replace(',','.') + " "+Convert.ToString(despy).Replace(',','.') + " "+Convert.ToString(despz).Replace(',','.'),
                                    "		    children Shape {",
                                    "			    appearance	Appearance {",
                                    "				    material	Material {",
                                    "					    ambientIntensity	0.1",
                                    "					    diffuseColor	0.9 0.767329 0.619635",
                                    "					    emissiveColor	0 0 0",
                                    "					    shininess	0.2",
                                    "					    specularColor	0 0 0",
                                    "					    transparency	0",
                                    "				    }",
                                    "			    }",
                                    "			    geometry	Box {",
                                    "				    size	"+Convert.ToString(nud_d.Value).Replace(',','.')+" "+Convert.ToString(nud_h.Value).Replace(',','.')+" "+Convert.ToString(nud_esp.Value).Replace(',','.'),//0.012 0.1 0.012",
                                    "			    }",
                                    "		    }",
                                    "	    }"
                                    };
                                    for (int k = 0; k < hwall.Length; k++)
                                    {
                                        fichero.WriteLine(hwall[k]);
                                    }
                                }
                            }
                            else if (i == funcion.GetLength(0))
                            {
                                string[] hwall =
                                    {
                                    "	    DEF hwall"+Convert.ToString(i)+Convert.ToString(j)+" Transform {",
                                    "		    translation	"+Convert.ToString(despx).Replace(',','.') + " "+Convert.ToString(despy).Replace(',','.') + " "+Convert.ToString(despz).Replace(',','.'),
                                    "		    children Shape {",
                                    "			    appearance	Appearance {",
                                    "				    material	Material {",
                                    "					    ambientIntensity	0.1",
                                    "					    diffuseColor	0.9 0.767329 0.619635",
                                    "					    emissiveColor	0 0 0",
                                    "					    shininess	0.2",
                                    "					    specularColor	0 0 0",
                                    "					    transparency	0",
                                    "				    }",
                                    "			    }",
                                    "			    geometry	Box {",
                                    "				    size	"+Convert.ToString(nud_d.Value).Replace(',','.')+" "+Convert.ToString(nud_h.Value).Replace(',','.')+" "+Convert.ToString(nud_esp.Value).Replace(',','.'),//0.012 0.1 0.012",
                                    "			    }",
                                    "		    }",
                                    "	    }"
                                    };
                                for (int k = 0; k < hwall.Length; k++)
                                {
                                    fichero.WriteLine(hwall[k]);
                                }
                            }
                        }
                    }
                    #endregion
                    #region paredes verticales
                    for (int i = 0; i < funcion.GetLength(0); i++)
                    {
                        for (int j = 0; j < funcion.GetLength(1) + 1; j++)
                        {
                            despz = (double)nud_esp.Value * (2+i) + (double)nud_d.Value * i + (double)nud_d.Value / 2 + (double)dimensiones[2] * (-0.5);
                            despx = (double)nud_esp.Value * (1.5+j) + (double)nud_d.Value * j + (double)dimensiones[0] * (-0.5);
                            if (j < funcion.GetLength(1))
                            {
                                if (funcion[i, j] == 1 || funcion[i, j] == 3)
                                {
                                    string[] vwall =
                                    {
                                    "	    DEF vwall"+Convert.ToString(i)+Convert.ToString(j)+" Transform {",
                                    "		    translation	"+Convert.ToString(despx).Replace(',','.') + " "+Convert.ToString(despy).Replace(',','.') + " "+Convert.ToString(despz).Replace(',','.'),
                                    "		    children Shape {",
                                    "			    appearance	Appearance {",
                                    "				    material	Material {",
                                    "					    ambientIntensity	0.1",
                                    "					    diffuseColor	0.9 0.767329 0.619635",
                                    "					    emissiveColor	0 0 0",
                                    "					    shininess	0.2",
                                    "					    specularColor	0 0 0",
                                    "					    transparency	0",
                                    "				    }",
                                    "			    }",
                                    "			    geometry	Box {",
                                    "				    size	"+Convert.ToString(nud_esp.Value).Replace(',','.')+" "+Convert.ToString(nud_h.Value).Replace(',','.')+" "+Convert.ToString(nud_d.Value).Replace(',','.'),//0.012 0.1 0.012",
                                    "			    }",
                                    "		    }",
                                    "	    }"
                                    };
                                    for (int k = 0; k < vwall.Length; k++)
                                    {
                                        fichero.WriteLine(vwall[k]);
                                    }
                                }
                            }
                            else if (j == funcion.GetLength(1))
                            {
                                string[] vwall =
                                    {
                                    "	    DEF vwall"+Convert.ToString(i)+Convert.ToString(j)+" Transform {",
                                    "		    translation	"+Convert.ToString(despx).Replace(',','.') + " "+Convert.ToString(despy).Replace(',','.') + " "+Convert.ToString(despz).Replace(',','.'),
                                    "		    children Shape {",
                                    "			    appearance	Appearance {",
                                    "				    material	Material {",
                                    "					    ambientIntensity	0.1",
                                    "					    diffuseColor	0.9 0.767329 0.619635",
                                    "					    emissiveColor	0 0 0",
                                    "					    shininess	0.2",
                                    "					    specularColor	0 0 0",
                                    "					    transparency	0",
                                    "				    }",
                                    "			    }",
                                    "			    geometry	Box {",
                                    "				    size	"+Convert.ToString(nud_esp.Value).Replace(',','.')+" "+Convert.ToString(nud_h.Value).Replace(',','.')+" "+Convert.ToString(nud_d.Value).Replace(',','.'),//0.012 0.1 0.012",
                                    "			    }",
                                    "		    }",
                                    "	    }"
                                    };
                                for (int k = 0; k < vwall.Length; k++)
                                {
                                    fichero.WriteLine(vwall[k]);
                                }
                            }
                        }
                    }
                    #endregion
                    fichero.WriteLine("	]");
                    fichero.WriteLine("}");
                    despx = -(double)nud_esp.Value * 2 - (double)nud_d.Value / 2 + (double)dimensiones[0] * (0.5);
                    despz = -(double)nud_esp.Value * 2 - (double)nud_d.Value / 2 + (double)dimensiones[2] * (0.5);
                    string[] viewpoint =
                    {
                        "DEF SuperiorEntorno Viewpoint {",
                        "	fieldOfView	1",
                        "	jump	TRUE",
                        "	position " + despx.ToString().Replace(',','.') +" " + despz.ToString().Replace(',','.') + " "+Convert.ToString(((double)max<decimal>(ref dimensiones[0],ref dimensiones[2]))/2*Math.Tan(67.5*Math.PI/180)).Replace(',','.'),
                        "	description	\"Vista Superior Laberinto\"",
                        "}",
"                         DEF Body Transform {",
"	                        translation	0 0 0",
"	                        children Transform {",
"		                        translation	0 0 0.40985",
"		                        children [ ",
"		                            DEF Base Inline {",
"			                            url	\"Cuerpo.wrl\"",
"		                            }",
"		                            DEF RuedaIzquierda Transform {",
"			                            translation	-0.04875 0 -0.0065",
"			                            children Inline {",
"				                            url	\"RuedaIzquierda.wrl\"",
"			                            }",
"		                            }",
"		                            DEF RuedaDerecha Transform {",
"			                            translation	0.04275 0 -0.0065",
"			                            children Inline {",
"				                            url	\"RuedaDerecha.wrl\"",
"			                            }",
"		                            }",
"		                            DEF VistaFrontal Transform {",
"			                            rotation	1 0 0  1.5708",
"			                            children DEF FPView1 Viewpoint {",
"				                            position	0 0.07 0.1",
"				                            description	\"Vista Frontal\"",
"			                            }",
"		                            }",
"		                            DEF VistaTrasera Transform {",
"			                            rotation	1 0 0  1.5708",
"			                            children DEF Rot Transform {",
"				                            rotation	0 1 0  3.14116",
"				                            children DEF FPView2 Viewpoint {",
"					                            position	0 0.07 0.1",
"					                            description	\"Vista Trasera\"",
"				                            }",
"			                            }",
"		                            }",
"		                            DEF VistaAlzado Viewpoint {",
"			                            position	0 0 0.5",
"			                            description	\"Vista Superior\"",
"		                            }",
"		                        ]",
"	                        }",
"                       }"
                    };
                    for (int k = 0; k < viewpoint.Length; k++)
                    {
                        fichero.WriteLine(viewpoint[k]);
                    }
                    fichero.Close();
                    DialogResult result = MessageBox.Show(this, ("Se guardo el archivo: " + saveFileDialog1.FileName + "\n¿Desea visualizar su archivo?"), "Archivo guardado exitosamente ;)", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        Process.Start(saveFileDialog1.FileName);
                    }
                }
                catch
                {
                    MessageBox.Show("¿qué has hecho culero :V\nNo sirve la cosa esta :v");
                }
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar== 113)
            {
                rdb_0.Checked = true;
            }
            if ((int)e.KeyChar == 119)
            {
                rdb_1.Checked = true;
            }
            if ((int)e.KeyChar == 101)
            {
                rdb_2.Checked = true;
            }
            if ((int)e.KeyChar == 114)
            {
                rdb_3.Checked = true;
            }
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rdb_0.Checked = true;
        }

        private void westWallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rdb_1.Checked = true;
        }

        private void northWallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rdb_2.Checked = true;
        }

        private void northAndWestWallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rdb_3.Checked = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                posX = e.X;
                posY = e.Y;
                if (e.X > desfaseX && w - desfaseX - tamañoNodo > e.X)
                {
                    cx = (posX - desfaseX) / (tamañoNodo * 4);
                    dx = (posX - desfaseX) / tamañoNodo;
                }
                if (e.Y > desfaseY && h - desfaseY - tamañoNodo > e.Y)
                {
                    cy = (posY - desfaseY) / (tamañoNodo * 4);
                    dy = (posY - desfaseY) / tamañoNodo;
                }
                lbl_pos.Text = "X:" + Convert.ToString(cx) + " Y:" + Convert.ToString(cy);
                lbl_1.Text = "x:" + Convert.ToString(dx) + "y:" + Convert.ToString(dy);
            }
            catch
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdb_0.Checked == true)
                {
                    funcion[cy, cx] = 0;
                    graficar_nodo(2, 1, desfaseX + (4 * cx + 0) * tamañoNodo, desfaseY + 4 * cy * tamañoNodo, tamañoNodo);
                    graficar_nodo(0, 1, desfaseX + (4 * cx + 1) * tamañoNodo, desfaseY + 4 * cy * tamañoNodo, tamañoNodo);
                    graficar_nodo(0, 1, desfaseX + (4 * cx + 2) * tamañoNodo, desfaseY + 4 * cy * tamañoNodo, tamañoNodo);
                    graficar_nodo(0, 1, desfaseX + (4 * cx + 3) * tamañoNodo, desfaseY + 4 * cy * tamañoNodo, tamañoNodo);
                    graficar_nodo(0, 1, desfaseX + 4 * cx * tamañoNodo, desfaseY + (4 * cy + 1) * tamañoNodo, tamañoNodo);
                    graficar_nodo(0, 1, desfaseX + 4 * cx * tamañoNodo, desfaseY + (4 * cy + 2) * tamañoNodo, tamañoNodo);
                    graficar_nodo(0, 1, desfaseX + 4 * cx * tamañoNodo, desfaseY + (4 * cy + 3) * tamañoNodo, tamañoNodo);
                    graficar_borde(3, desfaseX + (4 * cx * tamañoNodo), desfaseY + (4 * cy * tamañoNodo), tamañoNodo * 4);

                }
                if (rdb_1.Checked == true)
                {
                    funcion[cy, cx] = 1;
                    graficar_nodo(2, 1, desfaseX + (4 * cx + 0) * tamañoNodo, desfaseY + 4 * cy * tamañoNodo, tamañoNodo);
                    graficar_nodo(0, 1, desfaseX + (4 * cx + 1) * tamañoNodo, desfaseY + 4 * cy * tamañoNodo, tamañoNodo);
                    graficar_nodo(0, 1, desfaseX + (4 * cx + 2) * tamañoNodo, desfaseY + 4 * cy * tamañoNodo, tamañoNodo);
                    graficar_nodo(0, 1, desfaseX + (4 * cx + 3) * tamañoNodo, desfaseY + 4 * cy * tamañoNodo, tamañoNodo);
                    graficar_nodo(2, 1, desfaseX + 4 * cx * tamañoNodo, desfaseY + (4 * cy + 1) * tamañoNodo, tamañoNodo);
                    graficar_nodo(2, 1, desfaseX + 4 * cx * tamañoNodo, desfaseY + (4 * cy + 2) * tamañoNodo, tamañoNodo);
                    graficar_nodo(2, 1, desfaseX + 4 * cx * tamañoNodo, desfaseY + (4 * cy + 3) * tamañoNodo, tamañoNodo);
                    graficar_borde(3, desfaseX + (4 * cx * tamañoNodo), desfaseY + (4 * cy * tamañoNodo), tamañoNodo * 4);
                }
                if (rdb_2.Checked == true)
                {
                    funcion[cy, cx] = 2;
                    graficar_nodo(2, 1, desfaseX + (4 * cx + 0) * tamañoNodo, desfaseY + 4 * cy * tamañoNodo, tamañoNodo);
                    graficar_nodo(2, 1, desfaseX + (4 * cx + 1) * tamañoNodo, desfaseY + 4 * cy * tamañoNodo, tamañoNodo);
                    graficar_nodo(2, 1, desfaseX + (4 * cx + 2) * tamañoNodo, desfaseY + 4 * cy * tamañoNodo, tamañoNodo);
                    graficar_nodo(2, 1, desfaseX + (4 * cx + 3) * tamañoNodo, desfaseY + 4 * cy * tamañoNodo, tamañoNodo);
                    graficar_nodo(0, 1, desfaseX + 4 * cx * tamañoNodo, desfaseY + (4 * cy + 1) * tamañoNodo, tamañoNodo);
                    graficar_nodo(0, 1, desfaseX + 4 * cx * tamañoNodo, desfaseY + (4 * cy + 2) * tamañoNodo, tamañoNodo);
                    graficar_nodo(0, 1, desfaseX + 4 * cx * tamañoNodo, desfaseY + (4 * cy + 3) * tamañoNodo, tamañoNodo);
                    graficar_borde(3, desfaseX + (4 * cx * tamañoNodo), desfaseY + (4 * cy * tamañoNodo), tamañoNodo * 4);
                }
                if (rdb_3.Checked == true)
                {
                    funcion[cy, cx] = 3;
                    graficar_nodo(2, 1, desfaseX + (4 * cx + 0) * tamañoNodo, desfaseY + 4 * cy * tamañoNodo, tamañoNodo);
                    graficar_nodo(2, 1, desfaseX + (4 * cx + 1) * tamañoNodo, desfaseY + 4 * cy * tamañoNodo, tamañoNodo);
                    graficar_nodo(2, 1, desfaseX + (4 * cx + 2) * tamañoNodo, desfaseY + 4 * cy * tamañoNodo, tamañoNodo);
                    graficar_nodo(2, 1, desfaseX + (4 * cx + 3) * tamañoNodo, desfaseY + 4 * cy * tamañoNodo, tamañoNodo);
                    graficar_nodo(2, 1, desfaseX + 4 * cx * tamañoNodo, desfaseY + (4 * cy + 1) * tamañoNodo, tamañoNodo);
                    graficar_nodo(2, 1, desfaseX + 4 * cx * tamañoNodo, desfaseY + (4 * cy + 2) * tamañoNodo, tamañoNodo);
                    graficar_nodo(2, 1, desfaseX + 4 * cx * tamañoNodo, desfaseY + (4 * cy + 3) * tamañoNodo, tamañoNodo);
                    graficar_borde(3, desfaseX + (4 * cx * tamañoNodo), desfaseY + (4 * cy * tamañoNodo), tamañoNodo * 4);
                }
            }
            catch
            {

            }
        }

        private void graficar_borde(int colorBoard, int posicionX, int posicionY, int dimension)
        {
            Pen pen = new Pen(colores[colorBoard], 1);
            area.DrawRectangle(pen, posicionX, posicionY, dimension, dimension);
        }
        static string RemoveChar(string s, char r)
        {
            string res = null;
            foreach (char c in s)
            {
                if (c != r)
                {
                    res += c;
                }
            }
            return (res);
        }
        private void nudx_ValueChanged(object sender, EventArgs e)
        {
            area.Clear(Color.White);
            funcion = new int[(int)nudy.Value, (int)nudx.Value];
            DrawMaze(funcion);
        }
        private void nudy_ValueChanged(object sender, EventArgs e)
        {
            nudx_ValueChanged(sender, e);
        }
        T max<T>(ref T a, ref T b)
        {
            try
            {
                if (Convert.ToDouble(a) > Convert.ToDouble(b))
                    return (a);
                else
                    return (b);
            }
            catch
            {
                return (default(T));
            }
        }
        T max<T>(ref T[] array)
        {
            double m = Convert.ToDouble(array[0]);
            int ind = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (m < Convert.ToDouble(array[i]))
                {
                    m = Convert.ToDouble(array[i]);
                    ind = i;
                }
            }
            return (array[ind]);
        }
        T min<T>(ref T a, ref T b)
        {
            try
            {
                if (Convert.ToDouble(a) < Convert.ToDouble(b))
                    return (a);
                else
                    return (b);
            }
            catch
            {
                return (default(T));
            }
        }
        T min<T>(ref T[] array)
        {
            double m = Convert.ToDouble(array[0]);
            int ind = 0;
            for (int i = 0; i > array.Length; i++)
            {
                if (m < Convert.ToDouble(array[i]))
                {
                    m = Convert.ToDouble(array[i]);
                    ind = i;
                }
            }
            return (array[ind]);
        }

    }
}
