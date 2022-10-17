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

        public bool LearningNeuron(int X1, int X2,  int D)
        {
            this.X1 = X1;
            this.X2 = X2;
            bool out_is_correct = true;
            Net();
            output = ActivateFunction();
            if (output != D)
            {
                W1 += this.X1 * D;
                W2 += this.X2 * D;
                T -= D;
                Console.WriteLine($"Изменение весов:\n W1 = {W1}\n W2 = {W2}\n T = {T}");
                out_is_correct = false;
            }
            else
                Console.WriteLine("Выход совпал с эталонным значением");

            Console.WriteLine($"Выход = {output}\nЭталонное значение = {D}\n");

            return out_is_correct;
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
            bool exit;
            int j = 0;
            do
            {
                j++;
                Console.WriteLine($"Прогон {j}");
                exit = true;
                for (int i = 0; i < D.Length; i++)
                {
                    if (firstNeuron.LearningNeuron(input1[i], input2[i], D[i]) == false)
                    {
                        exit = false;
                    }
                }
            } while (!exit);
        }
    }
}