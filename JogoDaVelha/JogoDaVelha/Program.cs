namespace JogoDaVelha
{
    class Program
    {
        static string[,] mat = new string[3, 3];
        static int cont = 1;
        static string simbolo = "X", posicao; 

        static void Main(string[] args)
        {
            for (int L = 0; L < 3; L++) // Colocando posições de 0 a 8 no jogo; 
            {
                for (int C = 0; C < 3; C++)
                {
                    mat[L, C] = cont.ToString();
                    cont++; 
                }
            }
            MostrarVelha();
            Console.Write($"Vai jogar {simbolo} em qual posição? ");
            posicao = Console.ReadLine();
            Jogar(simbolo, posicao);
            MostrarVelha();
        }
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
            bool proximo = false;
            for (int L = 0; L < 3; L++)
            {
                for (int C = 0; C < 3; C++)
                {
                    if (mat[L, C] == posicao)
                    {
                        mat[L, C] = simbolo;
                        proximo = true; 
                    }
                }
            }
            return proximo;
        }
    }
}
