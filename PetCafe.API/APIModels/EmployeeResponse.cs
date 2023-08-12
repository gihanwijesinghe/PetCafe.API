namespace PetCafe.API.APIModels
{
    public class EmployeeResponse : EmployeeBase
    {
        public string Id { get; set; }
        public int DaysWorked { get; set; }
        public string Cafe { get; set; }
    }
}
    