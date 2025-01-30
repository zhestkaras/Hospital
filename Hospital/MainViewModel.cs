using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
namespace Hospital
{
    public partial class MainWindow
    {
        public class MainViewModel : INotifyPropertyChanged
        {
            private PatientDB patientDB = new PatientDB();
            private Patient editPatient = new Patient();
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
                    MessageBox.Show("Error");
                }
            }

            private bool ValidatePatient(Patient patient)
            {

                return !string.IsNullOrWhiteSpace(patient.FullName) &&
                       !string.IsNullOrWhiteSpace(patient.MedicalCardNumber) &&
                       patientDB.IsMedicalCardNumberUnique(patient.MedicalCardNumber);
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

           
            }

        }

    }






