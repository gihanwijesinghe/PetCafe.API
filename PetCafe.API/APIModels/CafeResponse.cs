namespace PetCafe.API.APIModels
{
    public class CafeResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int EmployeesCount { get; set; }
    }
}
