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
        private const int N = 1;
        private double NetRes;
        private int output;

        public void Net() 
        {
            NetRes = W1 * X1 + W2 * X2 + T * X0;
        }

        public int ActivateFunction() 
        {
            if (NetRes > 0)
                return 1;
            else if (NetRes <= 0)
                return -1;
            else 
                return 0;
        }

        public int LearningNeuron(int X1, int X2,  int D)
        {
            this.X1 = X1;
            this.X2 = X2;
            bool changeW = false;
            Net();
            output = ActivateFunction();
            if (output != D)
            {
                W1 += this.X1 * D;
                W2 += this.X2 * D;
                T -= D;
                Console.WriteLine($"Изменение весов:\n W1 = {W1}\n W2 = {W2}\n T = {T}");
            }
            else
                Console.WriteLine("Выход совпал с эталонным значением");

            Console.WriteLine($"Выход = {output}\nЭталонное значение = {D}\n");

            return output;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = new int[] { -1, 1, -1, 1 };
            int[] input2 = new int[] { -1, -1, 1, 1 };
            int[] output = new int[4];
            int[] D = new int[] { -1, -1, -1, 1};
            neuron firstNeuron = new neuron();
            bool exit = false;
            int j = 0;
            do
            {
                    j++;
                    Console.WriteLine($"Прогон {j}");
                for (int i = 0; i < D.Length; i++)
                {
                    output[i] = firstNeuron.LearningNeuron(input1[i], input2[i], D[i]);
                }
                for (int i = 0; i < D.Length; i++)
                {
                    if (output[i] != D[i]) 
                    {
                        exit = false;
                        break;
                    }
                    else
                        exit = true;
                }
            } while (!exit);
        }
    }
}