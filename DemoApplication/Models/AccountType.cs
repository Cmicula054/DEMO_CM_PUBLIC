using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApplication.Models
{
    public class AccountType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static AccountType[] ValidAccountTypes
        {
            get
            {
                return new[]
            {
                new AccountType
                {
                    Id = 1,
                    Name = "Vendor"
                },
                new AccountType
                {
                    Id = 2,
                    Name = "Customer"
                },
                new AccountType
                {
                    Id = 3,
                    Name = "Demo"
                },
            };
            }
        }
    }
}