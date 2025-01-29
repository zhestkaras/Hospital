using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Patient selectedCategory;
       

        public ObservableCollection<Patient> Patients { get; set; }
        public Patient SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                Signal();
            }
        }
       

       
        public MainWindow()
        {
            InitializeComponent();

           
            
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCategory != null)
            {
                SelectedCategory.Patients.Add(new Patient { FullName = "Новая проблема", Gender = "Описание проблемы", MedicalCardNumber = "Заявитель", Diagnosis = "Заявитель" });
            }
        }
    }


}

