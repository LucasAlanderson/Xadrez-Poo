using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Rainha : Pecas
    {
        public override bool MovimentoValido(int LinhaDestino, int ColunaDestino){
            if(LinhaDestino < 1 || LinhaDestino > 8 || ColunaDestino < 1 || ColunaDestino > 8)
        {
            return false; 
        }
    }

    public Rainha(string cor, int linha, int coluna): base(cor, linha, coluna){}
    }