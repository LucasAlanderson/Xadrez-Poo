using System.CodeDom;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;

namespace Xadrez;

public partial class Form1 : Form
{
    private PictureBox? pecaSelecionada = null; // Armazena a peça selecionada
    private int origemX = -1, origemY = -1; // Armazena a posição da peça
    public Tabuleiro tb = new Tabuleiro();
    
    public Form1()
    {
        InitializeComponent();
    }

    public void ClickNoTabuleiro(Pecas peca)
    {
        Pecas[,] tabuleiro = tb.Matriz;
        if (origemX == -1 && origemY == -1) // Primeiro clique: seleciona a peça
        {
            if (peca is not CasaVazia)
            {
                pecaSelecionada = peca.pictureBox;
                origemX = peca.linha;
                origemY = peca.coluna;
                MessageBox.Show($"Peça selecionada em ({peca.linha}, {peca.coluna})");
            }
        }
        else // Segundo clique: tenta mover a peça
        {
            try
            {
                Pecas pecaOrigem = tabuleiro[origemX, origemY];
                Pecas pecaDestino = tabuleiro[peca.linha, peca.coluna];

                // MessageBox.Show("Tudo certo");
                // Verifica se o movimento é válido

                MessageBox.Show(pecaOrigem.GetType().ToString());
                // MessageBox.Show(pecaDestino.GetType().ToString());

                if (origemX < 0 || origemX >= TamanhoDaMatriz || origemY < 0 || origemY >= TamanhoDaMatriz)
                {
                    MessageBox.Show("Erro: Coordenadas fora do tabuleiro!");
                    return;
                }

                if (pecaOrigem == null)
                {
                    MessageBox.Show("Erro: Nenhuma peça encontrada na posição de origem!");
                    return;
                }

                if (pecaOrigem.MovimentoValido(origemX, origemY))
                {
                    MessageBox.Show("Movimento Inválido!");
                    pecaSelecionada = null;
                    origemX = -1;
                    origemY = -1;
                    return;
                }

                if (pecaDestino is CasaVazia) // Se o destino estiver vazio, apenas move a peça
                {
                    tabuleiro[origemX, origemY] = new CasaVazia("casavazia", origemX, origemY);
                    tabuleiro[peca.linha, peca.coluna] = pecaOrigem;

                    pecaOrigem.linha = peca.linha;
                    pecaOrigem.coluna = peca.coluna;
                    pecaOrigem.pictureBox.Location = new Point(peca.linha * 50, peca.coluna * 50);
                    this.Controls.Add(pecaOrigem.pictureBox);  // Garantir que a imagem da peça apareça no novo local
                }
                else
                {
                    this.Controls.Remove(pecaDestino.pictureBox);  // Remover a peça capturada
                    tabuleiro[peca.linha, peca.coluna] = pecaOrigem;
                    tabuleiro[origemX, origemY] = new CasaVazia("casavazia", origemX * 50, origemY * 50);

                    pecaOrigem.linha = peca.linha;
                    pecaOrigem.coluna = peca.coluna;
                    pecaOrigem.pictureBox.Location = new Point(peca.linha * 50, peca.coluna * 50);
                    this.Controls.Add(pecaOrigem.pictureBox);  // Coloca a nova posição no tabuleiro
                }

                // Atualiza a interface
                this.Refresh();

                // Reseta os valores para a próxima jogada
                pecaSelecionada = null;
                origemX = -1;
                origemY = -1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Excessão: " + e.Message + "\n\nLocalizados em: " + e.StackTrace);
            }
        }
    }
}
