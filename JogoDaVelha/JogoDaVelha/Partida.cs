namespace JogoDaVelha
{
    class Partida
    {
        public string jogadorX { get; set; }
        public string jogadorO { get; set; }
        public int numPartida { get; set; }

        public Partida(string jogadorX, string jogadorO, int numPartida)
        {
            this.jogadorX = jogadorX;
            this.jogadorO = jogadorO;
            this.numPartida = numPartida;
        }

        public override string ToString()
        {
            return $"jog1{jogadorX}, jog2{jogadorO}, numpartida:{numPartida}"; 
        }
    }
}
