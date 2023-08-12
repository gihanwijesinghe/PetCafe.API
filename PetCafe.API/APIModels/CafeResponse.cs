namespace PetCafe.API.APIModels
{
    public class CafeResponse : CafePost
    {
        public Guid Id { get; set; }
        public int EmployeesCount { get; set; }
    }
}
