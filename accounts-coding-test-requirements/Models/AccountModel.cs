﻿using System;

namespace accounts_coding_test_requirements.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal AmountDue { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public AccountStatuses AccountStatusId { get; set; }
    }
}
