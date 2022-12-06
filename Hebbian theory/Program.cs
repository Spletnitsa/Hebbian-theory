namespace Hebbian_theory
{
    class neuron 
    {
        private int X1;
        private int X2;
        private const int X0 = -1;
        private double W1 = 0;
        private double W2 = 0;
        private double T = 0;
        private int output;

        private double Net() 
        {
            return W1 * X1 + W2 * X2 + T * X0;
        }

        private int ActivateFunction(double NetRes) 
        {
            if (NetRes > 0)
                return 1;
            else if (NetRes <= 0)
                return -1;
            else 
                return 0;
        }

        public void LearningNeuron(int[] X1, int[] X2,  int[] D)
        {
            bool exit;
            int j = 0;
            do
            {
                j++;
                Console.WriteLine($"Прогон {j}");
                exit = true;
                for (int i = 0; i < D.Length; i++)
                {
                    this.X1 = X1[i];
                    this.X2 = X2[i];

                    output = ActivateFunction(Net());

                    if (output != D[i])
                    {
                        exit = false;

                        W1 += this.X1 * D[i];
                        W2 += this.X2 * D[i];
                        T -= D[i];
                        Console.WriteLine($"Изменение весов:\n W1 = {W1}\n W2 = {W2}\n T = {T}");
                    }
                    else
                        Console.WriteLine("Выход совпал с эталонным значением");

                    Console.WriteLine($"Выход = {output}\nЭталонное значение = {D[i]}\n");
                }
            } while (!exit);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = new int[] { -1, 1, -1, 1 };
            int[] input2 = new int[] { -1, -1, 1, 1 };
            int[] D = new int[] { -1, -1, -1, 1};
            neuron firstNeuron = new neuron();
            firstNeuron.LearningNeuron(input1, input2, D);
        }
    }
}