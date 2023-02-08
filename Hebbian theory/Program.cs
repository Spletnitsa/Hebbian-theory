namespace Hebbian_theory
{
    class Neuron 
    {
        private int _x1;
        private int _x2;
        private const int _x0 = -1;
        private double _w1 = 0;
        private double _w2 = 0;
        private double _t = 0;
        private int _output;

        private double Net() 
        {
            return _w1 * _x1 + _w2 * _x2 + _t * _x0;
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
                    this._x1 = X1[i];
                    this._x2 = X2[i];

                    _output = ActivateFunction(Net());

                    if (_output != D[i])
                    {
                        exit = false;

                        _w1 += this._x1 * D[i];
                        _w2 += this._x2 * D[i];
                        _t -= D[i];
                        Console.WriteLine($"Изменение весов:\n W1 = {_w1}\n W2 = {_w2}\n T = {_t}");
                    }
                    else
                        Console.WriteLine("Выход совпал с эталонным значением");

                    Console.WriteLine($"Выход = {_output}\nЭталонное значение = {D[i]}\n");
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
            Neuron firstNeuron = new Neuron();
            firstNeuron.LearningNeuron(input1, input2, D);
        }
    }
}