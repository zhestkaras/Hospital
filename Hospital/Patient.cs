public class Patient
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } // "Мужской" или "Женский"
    public string MedicalCardNumber { get; set; }
    public string Diagnosis { get; set; }
    public DateTime AdmissionDate { get; set; } = DateTime.Now;
}
