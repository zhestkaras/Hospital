using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
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
    public partial class MainWindow : Window
    {


        public class MainViewModel : INotifyPropertyChanged
        {
            private PatientDB patientDB = new PatientDB();
            private Patient editPatient = new Patient();
            public ObservableCollection<Patient> Patientss { get; set; }
            public ObservableCollection<Patient> Patients => patientDB.Patients;

            public Patient EditPatient
            {
                get => editPatient;
                set
                {
                    editPatient = value;
                    OnPropertyChanged(nameof(EditPatient));
                   
                }
            }

            public ICommand AddPatientCommand { get; }

            public MainViewModel()
            {
                AddPatientCommand = new CommandVM(AddPatient);
            }

            private void AddPatient()
            {
                if (ValidatePatient(EditPatient))
                {
                    patientDB.AddPatient(new Patient
                    {
                        FullName = EditPatient.FullName,
                        DateOfBirth = EditPatient.DateOfBirth,
                        Gender = EditPatient.Gender,
                        MedicalCardNumber = EditPatient.MedicalCardNumber,
                        Diagnosis = EditPatient.Diagnosis,
                        AdmissionDate = DateTime.Now
                    });

                   
                    EditPatient = new Patient();
                }
                else
                {
                    //  добавить обработку ошибок валидации
                }
            }

            private bool ValidatePatient(Patient patient)
            {
                // Проверка 
                return !string.IsNullOrWhiteSpace(patient.FullName) &&
                       !string.IsNullOrWhiteSpace(patient.MedicalCardNumber) &&
                       patientDB.IsMedicalCardNumberUnique(patient.MedicalCardNumber);
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (EditPatient != null)
                {
                    ///////////////////sdfgv;ozxvn;oxzihvdl;z
                    EditPatient.Patients.Add(new Patient { FullName = "Новая проблема", Gender = "Описание проблемы", MedicalCardNumber = "Заявитель", Diagnosis = "Заявитель" });
                }
            }
        }



        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();

            DataContext = this;
        }

        
    }
}




