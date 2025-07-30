using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Home_Expense_Tracking_App;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace ExpenseTrackerWinForms
{
    public partial class FormMonthlySatement : Form
    {

        static ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        static ILogger logger = factory.CreateLogger("FormMonthlyStatementClass");
        static HttpClient client = new HttpClient();

        private List<Expense> expenseList;
        private double total;
        private string month;
        private int year;

        public FormMonthlySatement()
        {
            InitializeComponent();
        }

        private void FormMonthlySatement_Load(object sender, EventArgs e)
        {
            loadComboBoxMonth();

            this.dataGridViewExpenses.Columns.Add("ID", "ID");
            this.dataGridViewExpenses.Columns.Add("Date", "Date");
            this.dataGridViewExpenses.Columns.Add("Item", "Item");
            this.dataGridViewExpenses.Columns.Add("Type", "Type");
            this.dataGridViewExpenses.Columns.Add("Spender", "Spender");
            this.dataGridViewExpenses.Columns.Add("Price", "Price");

            this.textBoxTotal.ReadOnly = true;
            this.buttonOk.Enabled = false;
        }


        private void loadComboBoxMonth()
        {
            comboBoxMonths.Items.Add("January");
            comboBoxMonths.Items.Add("February");
            comboBoxMonths.Items.Add("March");
            comboBoxMonths.Items.Add("April");
            comboBoxMonths.Items.Add("May");
            comboBoxMonths.Items.Add("June");
            comboBoxMonths.Items.Add("July");
            comboBoxMonths.Items.Add("August");
            comboBoxMonths.Items.Add("September");
            comboBoxMonths.Items.Add("October");
            comboBoxMonths.Items.Add("November");
            comboBoxMonths.Items.Add("December");
        }


        private void comboBoxMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.month = comboBoxMonths.Text;
            if (!string.IsNullOrEmpty(textBoxYear.Text))
            {
                buttonOk.Enabled = true;
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxYear.Text, out this.year))
            {
                System.Windows.Forms.MessageBox.Show("Please enter a valid year!");
            }
            if (!string.IsNullOrEmpty(textBoxYear.Text) && this.month != null)
            {
                buttonOk.Enabled = true;
            }
        }
        

        private void buttonOk_Click(object sender, EventArgs e)
        {
            getMonthlies();
            displayExpenses(this.expenseList);
            textBoxTotal.Text = total.ToString();
        }

        public void displayExpenses(List<Expense> expenseList)
        {
            this.dataGridViewExpenses.Rows.Clear();
            foreach (var entry in expenseList)
            {
                this.dataGridViewExpenses.Rows.Add(entry.id,
                entry.date,
                entry.item,
                entry.type,
                entry.spender,
                entry.price);
            }
        }


        private void getMonthlies()
        {
            var monthlyStatement = Task.Run(async () => await getMonthlyStatement(this.year, this.month));
            var monthlyStatementResult = monthlyStatement.GetAwaiter().GetResult();

            var monthlyTotal = Task.Run(async () => await getMonthlyTotal(this.year, this.month));
            var monthlyTotalResult = monthlyTotal.GetAwaiter().GetResult();
        }


        private async Task<List<Expense>> getMonthlyStatement(int year, string month)
        {
            string url = "http://localhost:8080/expenses/monthlystatement/" + year + "/" + month;

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(new Uri(url)))
                {
                    logger.LogInformation("getMonthlyStatement service call finished");
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string resultString = await content.ReadAsStringAsync();
                        string reasonPhrase = response.ReasonPhrase;
                        HttpResponseHeaders headers = response.Headers;
                        //HttpStatusCode code = response.StatusCode;


                        var data = JsonConvert.DeserializeObject<List<Expense>>(resultString);
                        this.expenseList = data;
                        return expenseList;
                    }
                }
            }
            catch (Exception ex)
            {
                // need to return ex.message for display.
                logger.LogInformation(ex.Message);
                return null;
            }
        }


        private async Task<double> getMonthlyTotal(int year, string month)
        {
            string url = "http://localhost:8080/expenses/monthlytotal/" + year + "/" + month;

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(new Uri(url)))
                {
                    logger.LogInformation("getMonthlyTotal service call finished");
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string resultString = await content.ReadAsStringAsync();
                        string reasonPhrase = response.ReasonPhrase;
                        HttpResponseHeaders headers = response.Headers;
                        //HttpStatusCode code = response.StatusCode;


                        var data = JsonConvert.DeserializeObject<double>(resultString);
                        this.total = data;
                        return this.total;
                    }
                }
            }
            catch (Exception ex)
            {
                // need to return ex.message for display.
                logger.LogInformation(ex.Message);
                return 0.00;
            }
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
