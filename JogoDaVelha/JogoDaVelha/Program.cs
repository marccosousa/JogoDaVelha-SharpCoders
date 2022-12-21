namespace JogoDaVelha
{
    class Program
    {
        static string[,] mat = new string[3, 3];
        static int cont = 1, test = 1;
        static string simbolo = "X", posicao;
        static bool respostaJogar; 

        static void Main(string[] args)
        {
            for (int L = 0; L < 3; L++) // Colocando posições de 1 a 9 no jogo; 
            {
                for (int C = 0; C < 3; C++)
                {
                    mat[L, C] = cont.ToString();
                    cont++; 
                }
            }
            MostrarVelha();
            do
            {
                do
                {
                    Console.Write($"Vai jogar {simbolo} em qual posição? ");
                    posicao = Console.ReadLine();
                    respostaJogar = Jogar(simbolo, posicao);

                    if (respostaJogar == false)
                    {
                        Console.WriteLine("Joga inválida, digite novamente: ");
                    }
                } while (respostaJogar != true);
                MudarJogador();
                Console.Clear();
                MostrarVelha();

            } while (FimDeJogo() != true); 

        }

        // Funções do jogo.
        static void MostrarVelha()
        {
            Console.WriteLine("+---+---+---+");
            for (int L = 0; L < 3; L++)
            {
                for (int C = 0; C < 3; C++)
                {
                    Console.Write("|  " + mat[L, C]);
                }
                Console.Write("|");
                Console.WriteLine();
                Console.WriteLine("+---+---+---+");
            }
        }
        
        static bool Jogar(string simbolo, string posicao)
        {
            bool mudouDeNumParaSimbolo = false;
            for (int L = 0; L < 3; L++)
            {
                for (int C = 0; C < 3; C++)
                {
                    if (mat[L, C] == posicao)
                    {
                        mat[L, C] = simbolo;
                        mudouDeNumParaSimbolo = true; 
                    }
                }
            }
            return mudouDeNumParaSimbolo;
        }
        
        static void MudarJogador()
        {
            if (simbolo == "X")
            {
                simbolo = "O";
            }
            else
            {
                simbolo = "X";
            }

        }

        static bool FimDeJogo()
        {
            bool terminou = false;
            // Se o jogo terminar em alguma linha: 
            for (int L = 0; L < 3; L++)
            {
                if (mat[L, 0] == mat[L, 1] && mat[L, 1] == mat[L, 2])
                {
                    terminou = true;
                }
            }
            // Se o jogo terminar em alguma coluna: 
            for (int C = 0; C < 3; C++)
            {
                if (mat[0, C] == mat[1, C] && mat[1, C] == mat[2, C])
                {
                    terminou = true;
                }
            }

            // Se o jogo terminar em alguma diagonal: Diagonal principal, diagonal secundária
            if (mat[1, 1] == mat[2, 2] && mat[2, 2] == mat[3, 3])
            {
                terminou = true;
            }

            if (mat[1, 3] == mat[2, 2] && mat[2, 2] == mat[3,1])
            {
                terminou = true;
            }


            return terminou;
        }
    }
}
