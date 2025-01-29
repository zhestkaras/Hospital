using System.Collections.ObjectModel;

public class PatientDB
{
    private ObservableCollection<Patient> patients = new ObservableCollection<Patient>();

    public ObservableCollection<Patient> Patients => patients;

    public bool IsMedicalCardNumberUnique(string medicalCardNumber)
    {
        foreach (var patient in patients)
        {
            if (patient.MedicalCardNumber == medicalCardNumber)
                return false;
        }
        return true;
    }

    public void AddPatient(Patient patient)
    {
        patients.Add(patient);
    }
}
