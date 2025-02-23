﻿using ELMS.API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ELMS.API.Services
{
    public interface IUserService
    {
        public UserLeaveBalanceDTO GetLeaveBalance(string user);
    }
}
