using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Bispo : Pecas
    {
         public override bool MovimentoValido(int LinhaDestino, int ColunaDestino)
    {
        if (LinhaDestino < 1 || LinhaDestino > 8 || ColunaDestino < 1 || ColunaDestino > 8)
        {
            return false;
        }
        int difLinha = Math.Abs(linha - LinhaDestino);
        int difColuna = Math.Abs(coluna - ColunaDestino);

        return difLinha == difColuna;
    }
    }
