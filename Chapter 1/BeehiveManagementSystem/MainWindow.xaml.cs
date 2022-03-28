using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


// head first 403

namespace BeehiveManagementSystem
{
    public abstract class Bee : IWorker
    {
        public string Job { get; private set; }
        public abstract float CostPerShift { get; }

        public Bee(string job)
        {
            Job = job;
        }

        public void WorkTheNextShift() 
        {
            if (HoneyVault.ConsumeHoney(CostPerShift))
                DoJob();

        }

        protected abstract void DoJob();
        

    }
                         
    class NectarCollector : Bee
    {

        public const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;
        public override float CostPerShift => 1.95f;
        public NectarCollector() : base("Nectar Collector") { }

        protected override void DoJob()
        {
            HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
        }
    }
    class HoneyManufacturer : Bee
    {
        public const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;
        public override float CostPerShift => 1.7f;
        public HoneyManufacturer() : base("Honey Manufacturer") { }
        
        protected override void DoJob()
        {
            HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
            //Debug.WriteLine($"Test");
        }
    }

    class Queen : Bee, INotifyPropertyChanged
    {
        public const float EGGS_PER_SHIFT = 0.45f;
        public const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

        private IWorker[] workers = new IWorker[0];
        private float eggs = 0;
        private float unassignedWorkers = 3;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string StatusReport { get; private set; }
        public override float CostPerShift => 2.15f;
        public Queen() : base("Queen")
        {
            AssignBee("Nectar Collector");
            AssignBee("Honey Manufacturer");
            AssignBee("Egg Care");
        }

        private void AddWorker(IWorker worker)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }

        private void UpdateStatusReport()
        {
            StatusReport = $"Vault report:\n{HoneyVault.StatusReports}\n";
            StatusReport += $"\nEgg count: {eggs:0.0}\n";
            StatusReport += $"Unassigned workers: {unassignedWorkers:0.0}\n";
            StatusReport += $"{WorkerStatus("Nectar Collector")}\n";
            StatusReport += $"{WorkerStatus("Honey Manufacturer")}";
            StatusReport += $"\n{WorkerStatus("Egg Care")}\n";
            StatusReport += $"TOTAL WORKERS: {workers.Length}";
            OnPropertyChanged("StatusReport");
        }

        public void CareForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }

        private string WorkerStatus(string job)
        {
            int count = 0;
            foreach (IWorker worker in workers)
                if (worker.Job == job) count++;
            string s = "(s)";
            if (count == 1) s = "";
            return $"{count} {job} bee{s}";
        }

        public void AssignBee(string job)
        {
            switch (job)
            {
                case "Nectar Collector": AddWorker(new NectarCollector()); break;
                case "Honey Manufacturer": AddWorker(new HoneyManufacturer()); break;
                case "Egg Care": AddWorker(new EggCare(this)); break;
            }
            UpdateStatusReport();
        }

        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            foreach (IWorker worker in workers)
                worker.WorkTheNextShift();
            HoneyVault.ConsumeHoney(unassignedWorkers * HONEY_PER_UNASSIGNED_WORKER);
            UpdateStatusReport();
        }

    }
       
    class EggCare : Bee
    {
        public const float CARE_PROGRESS_PER_SHIFT = 0.15f;
        public override float CostPerShift => 1.35f;

        private readonly Queen queen;
        public EggCare(Queen queen) : base("Egg Care")
        {
            this.queen = queen;
        }

        protected override void DoJob()
        {
            queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }
    }
    public static class HoneyVault
    {
        public const float NECTAR_CONVERSION_RATIO = .19f;
        public const float LOW_LEVEL_WARNING = 10f;

        private static float honey = 25f;
        private static float nectar = 100f;
        
        public static void CollectNectar(float amount)
        {
            nectar = (amount > 0f) ? nectar + amount : nectar;
        }

        public static void ConvertNectarToHoney(float amount)
        {
            float nectarToConvert = amount;
            if (nectarToConvert > nectar) nectarToConvert = nectar;
            nectar -= nectarToConvert;
            honey += nectarToConvert * NECTAR_CONVERSION_RATIO;
        }

        public static bool ConsumeHoney(float amount)
        {
            if (amount <= honey)
            {
                honey -= amount;
                return true;
            }
            else
                return false;
        }
        public static string StatusReports 
        {
            get 
            {
                string report = $"{honey:0.0} units of honey\n{nectar:0.0} units of nectar";

                string warnings = "\n";
                warnings += (honey < LOW_LEVEL_WARNING) ? "LOW HONEY - ADD A HONEY MANUFACTUR\n" : ""; 
                warnings += (nectar < LOW_LEVEL_WARNING) ? "LOW NECTAR - ADD A NECTAR BEE\n" : "";
                
                return report + warnings;
            }
        }



    }
    public partial class MainWindow : Window
    {
        //private Queen queen = new Queen();
        private readonly Queen queen;
        private DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            queen = Resources["queen"] as Queen;
            //statusReport.Text = queen.StatusReport;
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1.5);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            WorkShift_Click(this, new RoutedEventArgs());
        }

        private void WorkShift_Click(object sender, RoutedEventArgs e)
        {
            queen.WorkTheNextShift();
            //statusReport.Text = queen.StatusReport;
        }


        private void AssignJob_Click(object sender, RoutedEventArgs e) 
        { 
            queen.AssignBee(jobSelector.Text);
            //statusReport.Text = queen.StatusReport;
        }
    }
}
