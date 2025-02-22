
namespace Xadrez;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        tb.InicializarTabuleiro(this);
    }

    public void ClickAqui(Pecas peca)
    {
        if (peca == null) {
            MessageBox.Show("Faça as coisas direito!");
            return;
        }

        MessageBox.Show($"x={peca.linha}    y={peca.coluna}");
    }
}
