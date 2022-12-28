namespace JogoDaVelha
{
    class Partida
    {
        public string JogadorX { get; set; }
        public int PlacarX{ get; private set; }
        public string JogadorO { get; set; }
        public int PlacarO { get; private set; }
        public int PlacarVelha { get; private set; }

        public string VitoriaDaRodada { get; set; }

        public Partida()
        {
        }

        public Partida(string jogadorX, string jogadorO)
        {
            JogadorX = jogadorX;
            JogadorO = jogadorO;
        }

        public void VitoriaJogadorX()
        {
            PlacarX += 1; 
        }

        public void VitoriaJogadorO()
        {
            PlacarO += 1;
        }

        public void Velha()
        {
            PlacarVelha += 1;
        }

        public override string ToString()
        {
            return $"Vitória da rodada: "; 
        }
    }
}
