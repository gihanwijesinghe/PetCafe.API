namespace PetCafe.API.APIModels
{
    public class EmployeeResponse : EmployeePost
    {
        public string Id { get; set; }
        public int DaysWorked { get; set; }
        public string Cafe { get; set; }
    }
}
    