using System;

//HeadFirst - 264
// A paramter with the same name as a field masks that field. Use the this keyword to access the field
          
namespace PaintballGunGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int numberOfBalls = ReadInt(20, "Number of Balls");
            int magazinSize = ReadInt(16, "Magazine size");
            Console.Write($"Loaded [false]: ");
            bool.TryParse(Console.ReadLine(), out bool isLoaded);

            PaintballGun gun = new PaintballGun(numberOfBalls, magazinSize, isLoaded);
            while (true)
            {
                // Console.WriteLine($"{gun.getBalls()} balls, {gun.GetBallsLoaded()} loaded");
                Console.WriteLine($"{gun.Balls} balls, {gun.BallsLoaded} loaded");
                if (gun.IsEmpty()) Console.WriteLine("WARNING: You're out of ammo");
                Console.WriteLine("Space to Shoot, r to reload, + to add ammo, q to quit");
                char key = Console.ReadKey(true).KeyChar;
                if (key == ' ') Console.WriteLine($"Shooting returned {gun.Shoot()}");
                else if (key == 'r') gun.Reload();
                else if (key == '+') gun.Balls += gun.MagazineSize;
                else if (key == 'q') return;

                               
            }
        }
        static int ReadInt(int lastUsedValues, string prompt)
        {
            Console.Write($"{prompt} [{lastUsedValues}]: ");
            string line = Console.ReadLine();
            if (int.TryParse(line, out int value))
            {
                Console.WriteLine($"  using value {value}");
                return value;
            }
            else
            {  
                Console.WriteLine($"   using default value " + lastUsedValues);
                return lastUsedValues;
            }
        }
    }

    internal class PaintballGun
    {
        public PaintballGun(int balls, int magazinSize, bool loaded)
        {
            this.balls = balls;
            MagazineSize = magazinSize;
            if (!loaded) Reload();
        }
        // internal const int MAGAZINE_SIZE = 16;
        public int MagazineSize { get; private set; } = 16;

        private int balls = 0;
        //private int ballsLoaded = 0;
        //public int BallsLoaded
        //{
        //    get { return ballsLoaded; }
        //    set { ballsLoaded = value; }
        //}

        public int BallsLoaded { get; private set; }
        public int GetBallsLoaded() {  return BallsLoaded; }
        public bool IsEmpty() { return BallsLoaded == 0; }
        // public int GetBalls() { return balls; }

        public void Reload()
        {
            if (balls > MagazineSize) BallsLoaded = MagazineSize;
            else BallsLoaded = balls;
        }

        public bool Shoot()
        {
            if (BallsLoaded == 0) return false;
            BallsLoaded--;
            balls--;
            return true;
        }

        //internal object GetBalls()
        //{
        //    throw new NotImplementedException();
        //}

        //internal void SetBalls(object p)
        //{
        //    throw new NotImplementedException();
        //}
        // gets replaced with

        public int Balls
        {
            get { return balls; }
            set
            {
                if (value > 0)
                    balls = value;
                Reload();
            }
        }


    }
}
