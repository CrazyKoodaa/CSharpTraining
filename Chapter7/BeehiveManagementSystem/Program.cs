using System;

namespace BeehiveManagementSystem
{
    public static void HoneyVault()
    {
        public string StatusReport { get; }
    private float honey = 25f;


}
    public class Bee : IWorker
    {
        public virtual float CostPerShift { get; }

        public string Job { get; private set; }
        public Bee(string job)
        {
            Job = job;
        }

        void WorkTheNextShift()
        {
            if HoneyVault.ConsumeHoney(CostPerShift))
            {
                DoJob();
            }
        }
        protected virtual DoJob();
    }
    class Queen : Bee
    {
        private Bee[] workers;
        private IWorker[] workers = new IWorker[0];
        private void AddWorker(IWorker worker)
        {
            if (unassignedWorkers >= 1)
            {
                usassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
                
            }
        }
        private string WorkerStatus(string job)
        {
            int count = 0;
            foreach (IWorker worker in workers)
                if (worker.Job == job) count++;
            string s = "s";
            if (count == 1) s = "";
            return $"{count} {job} bee(s)";
        }
        public string StatusReport { get; }
        public override float CostPerShift => base.CostPerShift;
        public abstract void AssignBee();
        public void CareForEggs();
        protected override DoJob();


    }
    class NectarCollector : Bee
    {
        public override float CostPerShift => base.CostPerShift;
        protected override DoJob();
    }

    class HoneyManufacturer : Bee
    {
        public override float CostPerShift => base.CostPerShift;
        protected override DoJob();
    }

    class EggCare : Bee
    {
        public override float CostPerShift => base.CostPerShift;
        protected override DoJob();

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
