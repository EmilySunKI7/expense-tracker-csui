using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_Expense_Tracking_App;

namespace ExpenseTrackerWinForms
{
    public class BookUpdatedEventArgs : EventArgs
    {
        public Expense expense { get; set; }

        public BookUpdatedEventArgs(Expense expense)
        {
            this.expense = expense;
        }
    }
}
