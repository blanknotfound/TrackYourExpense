﻿namespace DataModel.Model
{
    public class User
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public int BalanceAmt { get; set; } 

        public Currency SCurrency { get; set; }
    }
}
