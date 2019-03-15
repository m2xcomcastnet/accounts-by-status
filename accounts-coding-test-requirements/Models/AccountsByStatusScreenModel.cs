using System.Collections.Generic;

namespace accounts_coding_test_requirements.Models
{
    /// <summary>
    /// A model containing data used by the accounts grouped by status screen
    /// </summary>
    public class AccountsByStatusScreenModel
    {
        public List<AccountModel> ActiveAccounts { get; set; }
        public List<AccountModel> InactiveAccounts { get; set; }
        public List<AccountModel> OverdueAccounts { get; set; }
    }
}
