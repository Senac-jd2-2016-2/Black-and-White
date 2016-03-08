using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jogo2DExemplo
{
    class Personagem
    {
        public int x;
        public int y;
        public int vida;
        public int atk;
        public bool acerto;
        


        public Texture2D texture;

        public Personagem(int x1, int y1)
        {
            x = x1;
            y = y1;
            vida = 500;
            atk = 10;
            acerto = false;


        }

        public Vector2 getVector()
        {
            return new Vector2(x, y);
        }

        public void moverX(int qtdPassos)
        {
            x += qtdPassos;
        }

        public void pulo()
        {

        }

        public void Atk(Inimigos i)
        {
            acerto = true;
            if (acerto)
            {

            }
              
                
                
        }
        public void dano(Inimigos i)
        {
            int t = i.tipo;
            if (t == 1)
                vida -= (vida / 10);
            if (t == 2)
                vida -= (vida / 5);


        }
        public void GameOver()
        {
            if (vida == 0)
            {

            }
        }

        //public void moverY(int qtdPassos)
        //{
        //    y += qtdPassos;
        //}

    }
}
