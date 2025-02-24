namespace ELMS.API.DTO
{
    public class UserLeaveBalanceDTO
    {
        public int TotalVacationLeave { get; set; } = 15;
        public int TotalSickLeave { get; set; } = 15;
        public int TotalAnnualLeave { get; set; } = 30;
        public int UsedVacationLeave { get; set; }
        public int UsedSickLeave { get; set; }
        public int RemainingVacationLeave { get; set; }
        public int RemainingSickLeave { get; set; }
        public int BalanceAnnualLeave { get; set; }
    }
}
