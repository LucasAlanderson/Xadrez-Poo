using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xadrez;

public class Peao : Pecas
{
    // public PictureBox peaoImagem { get; private set; }
    bool primeiroMovimento = true;
    Peao peaoAdversario;
    public override bool MovimentoValido(int LinhaDestino, int ColunaDestino)
    {
        MessageBox.Show($" linha destino {LinhaDestino}         coluna destino {ColunaDestino}");
        if (LinhaDestino < 0 || LinhaDestino > 7 || ColunaDestino < 0 || ColunaDestino > 7)
        {
            MessageBox.Show("É aqui animal");
            return false;
        }

        int difLinha = LinhaDestino - linha;  // Diferença na linha
        int difColuna = Math.Abs(ColunaDestino - coluna); // Diferença na coluna

        // Verifica se o movimento é para frente sem capturar
        if (difColuna == 0)
        {
            // Peão branco move para frente (+1) e preto para trás (-1)
            int direcao = (cor == "branco") ? 1 : -1;

            // Movimento normal de 1 casa
            if (difLinha == direcao)
            {
                return true;
            }

            // Movimento de 2 casas no primeiro movimento
            if (difLinha == 2 * direcao && primeiroMovimento)
            {
                return true;
            }
        }

        // Verifica se o movimento é uma captura diagonal
        if (difLinha == ((cor == "branco") ? 1 : -1) && difColuna == 1)
        {
            if (peaoAdversario != null && peaoAdversario.cor != cor)
            {
                return true; // Captura normal
            }
        }
        MessageBox.Show("Na ultima linha");
        return false; // Movimento inválido
    }
    public Peao(string Cor, int Linha, int Coluna) : base(Cor, Linha, Coluna)
    {
        pictureBox = new PictureBox
        {
            Location = new Point(coluna * 50, linha * 50),
            Size = new Size(48, 48),
            SizeMode = PictureBoxSizeMode.StretchImage,
            Parent = this,
        };

        pictureBox.BackColor = (linha + coluna) % 2 == 0 ? Color.White : Color.Black;

        try
        {
            string path = Path.Combine($@"{disk}:\Users\", Environment.UserName, "Xadrez-Poo", "bin", "Debug", "imagens", $"peao_{cor}.png"); // Se estiver dando erro, edite o valor da variável 'disk' para "D"
            // MessageBox.Show("Tentando carregar: " + path);
            pictureBox.Image = Image.FromFile(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
        }

    }
    public Peao() : base() { }

}
