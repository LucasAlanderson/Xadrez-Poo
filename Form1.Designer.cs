using System.Diagnostics;

namespace Xadrez;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private const int TamanhoDaMatriz = 8;
    private Button[,] matriz = new Button[TamanhoDaMatriz, TamanhoDaMatriz];
    private Tabuleiro tb = new Tabuleiro();

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Xadrez";


        PictureBox cavalo = new PictureBox();
        cavalo.Location = new Point(50, 50);
        cavalo.Size = new Size(50, 50);
        cavalo.SizeMode = PictureBoxSizeMode.StretchImage;
        PictureBox torre = new PictureBox();

        torre.Location = new Point(50, 50);
        torre.Size = new Size(50, 50);
        torre.SizeMode = PictureBoxSizeMode.StretchImage;
    
        try
        {
            string path = Path.Combine(@"D:\Users\20231170150049\Xadrez-Poo", "bin", "Debug", "imagens", "cavalo_branco.png");
            MessageBox.Show("Tentando carregar: " + path);
            cavalo.Image = Image.FromFile(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
        }
        this.Controls.Add(cavalo);


        for (int linha = 0; linha < TamanhoDaMatriz; linha++)
        {
            for (int coluna = 0; coluna < TamanhoDaMatriz; coluna++)
            {
                Button b = new Button();
                if ((coluna + linha) % 2 == 0)
                {
                    b.Size = new Size(50, 50);
                    b.Location = new Point(50 * linha, 50 * coluna);
                    b.BackColor = Color.White;
                    matriz[linha, coluna] = b;
                    this.Controls.Add(b);
                }
                else
                {
                    b.Size = new Size(50, 50);
                    b.Location = new Point(50 * linha, 50 * coluna);
                    b.BackColor = Color.Black;
                    matriz[linha, coluna] = b;
                }
                this.Controls.Add(b);
            }
            tb.InicializarTabuleiro();
        }

        #endregion
    }
}
