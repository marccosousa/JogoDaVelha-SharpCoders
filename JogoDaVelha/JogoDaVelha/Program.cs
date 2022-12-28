namespace JogoDaVelha
{
    class Program
    {
        static string[,] mat = new string[3, 3];
        static string simbolo = "X", posicao;

        static void Main(string[] args)
        {
            int continuar = 1;
            bool respostaJogar;
            List<Partida> partidasList = new List<Partida>();
            Console.Write("jogador 1: ");
            string nomeX = Console.ReadLine();
            Console.Write("jogador 2: ");
            string nomeO = Console.ReadLine();
            Partida p = new Partida(nomeX, nomeO);
            Console.Clear();

            do
            {
                int cont = 1;
                for (int L = 0; L < 3; L++) // Colocando posições de 1 a 9 no jogo; 
                {
                    for (int C = 0; C < 3; C++)
                    {
                        mat[L, C] = cont.ToString();
                        cont++;
                    }
                }

                Console.WriteLine("Jogador 1: " + nomeX + " - X");
                Console.WriteLine("Jogador 2: " + nomeO + " - O");
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
                    Console.WriteLine("Jogador 1: " + nomeX + " - X");
                    Console.WriteLine("Jogador 2: " + nomeO + " - O");
                    MostrarVelha();

                } while (FimDeJogo(p) != true);
                partidasList.Add(p);
                do
                {
                    Console.Write("Novo jogo?\n[1] - Sim \n[2] - Não: ");
                    continuar = int.Parse(Console.ReadLine());
                } while (continuar < 1 || continuar > 2);
                Console.Clear();
            } while (continuar == 1);
            Console.WriteLine("Fim de jogo!");
            Console.WriteLine("vitorias jogador 1: " + p.PlacarX);
            Console.WriteLine("vitorias jogador 2: " + p.PlacarO);
            Console.WriteLine("Velhas: " + p.PlacarVelha);

            int i = 1;
            foreach (Partida x in partidasList)
            {
                Console.WriteLine(x);
                i++;
            }

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

        static bool FimDeJogo(Partida atual)
        {
            bool terminou = false;
            // Se o jogo terminar em alguma linha: 
            for (int L = 0; L < 3; L++)
            {
                if (mat[L, 0] == mat[L, 1] && mat[L, 1] == mat[L, 2])
                {
                    if (mat[L, 0] == "X")
                    {
                        atual.VitoriaJogadorX();
                        Console.WriteLine("Vitória do jogador 1: " + atual.JogadorX);                        
                    }
                    else
                    {
                        atual.VitoriaJogadorO();
                        Console.WriteLine("Vitória do jogador 2: " + atual.JogadorO);                        
                    }
                    terminou = true;
                }
            }
            // Se o jogo terminar em alguma coluna: 
            for (int C = 0; C < 3; C++)
            {
                if (mat[0, C] == mat[1, C] && mat[1, C] == mat[2, C])
                {
                    if (mat[0, C] == "X")
                    {
                        atual.VitoriaJogadorX();
                        Console.WriteLine("Vitória do jogador 1: " + atual.JogadorX);
                    }
                    else
                    {
                        atual.VitoriaJogadorO();
                        Console.WriteLine("Vitória do jogador 2: " + atual.JogadorO);
                    }
                    terminou = true;
                }
            }

            // Se o jogo terminar em alguma diagonal: Diagonal principal
            if (mat[0, 0] == mat[1, 1] && mat[1, 1] == mat[2, 2])
            {
                if (mat[0, 0] == "X")
                {
                    atual.VitoriaJogadorX();
                    Console.WriteLine("Vitória do jogador 1: " + atual.JogadorX);
                }
                else
                {
                    atual.VitoriaJogadorO();
                    Console.WriteLine("Vitória do jogador 2: " + atual.JogadorO);
                }
                terminou = true;
            }
            // diagonal secundária
            if (mat[0, 2] == mat[1, 1] && mat[1, 1] == mat[2, 0])
            {
                if (mat[0, 2] == "X")
                {
                    atual.VitoriaJogadorX();
                    Console.WriteLine("Vitória do jogador 1: " + atual.JogadorX);
                }
                else
                {
                    atual.VitoriaJogadorO();
                    Console.WriteLine("Vitória do jogador 2: " + atual.JogadorO);
                }
                terminou = true;
            }

            int contVelha = 0;
            for (int L = 0; L < 3; L++)
            {
                for (int C = 0; C < 3; C++)
                {
                    if (mat[L, C] != "X" && mat[L, C] != "O")
                    {
                        contVelha++;
                    }
                }
            }

            if (contVelha == 0)
            {
                atual.Velha();
                Console.WriteLine("Deu velha! :(");
                terminou = true;
            }

            return terminou;
        }


    }
}
