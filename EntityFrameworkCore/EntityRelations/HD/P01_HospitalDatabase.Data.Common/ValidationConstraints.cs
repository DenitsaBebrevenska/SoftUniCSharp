namespace P01_HospitalDatabase.Data.Common;
public static class ValidationConstraints
{
    //Patient
    public const int PatientFirstNameLength = 50;
    public const int PatientLastNameLength = 50;
    public const int PatientAddressLength = 250;
    public const int PatientEmailLength = 80;

    //Visitation
    public const int VisitationCommentsLength = 250;

    //Diagnose
    public const int DiagnoseNameLength = 50;
    public const int DiagnoseCommentsLength = 250;

    //Medicament    
    public const int MedicamentNameLength = 50;

    //Doctor second task
    public const int DoctorNameLength = 100;
    public const int DoctorSpecialtyLength = 100;

}
