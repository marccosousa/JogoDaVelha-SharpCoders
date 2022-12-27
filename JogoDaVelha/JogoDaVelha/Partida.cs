namespace JogoDaVelha
{
    class Partida
    {
        public string JogadorX { get; set; }
        public string JogadorO { get; set; }
        public int NumPartida { get; set; }

        public Partida()
        {
        }

        public Partida(string jogadorX, string jogadorO, int numPartida)
        {
            this.JogadorX = jogadorX;
            this.JogadorO = jogadorO;
            this.NumPartida = numPartida;
        }

        public override string ToString()
        {
            return $"jog1{JogadorX}, jog2{JogadorO}, numpartida:{NumPartida}"; 
        }
    }
}
