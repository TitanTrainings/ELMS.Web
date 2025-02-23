namespace ELMS.API.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int SickLeaveBalance { get; set; }
        public int VacationLeaveBalance { get; set; }
    }
}
