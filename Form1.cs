using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Home_Expense_Tracking_App;
using Home_Expense_Tracking_App.ManageBook;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ExpenseTrackerWinForms
{
    public partial class Form1 : Form
    {
        static ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        static ILogger logger = factory.CreateLogger("Form1Class");
        static HttpClient client = new HttpClient();


        public Book myBook;
        private string filePath = string.Empty;
        private Expense expenseSelected;
        private bool openedFromWeb = false;
        private SSEClient sseClient = new SSEClient();

        public Form1()
        {
            InitializeComponent();
            client.Timeout = TimeSpan.FromSeconds(10);
            client.BaseAddress = new Uri("http://localhost:8080/");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("ID");
            listBox1.Items.Add("Date");
            listBox1.Items.Add("Item");
            listBox1.Items.Add("Type");
            listBox1.Items.Add("Spender");
            listBox1.Items.Add("Price");

            initDataGridView();
            listBox1.Enabled = false;
            buttonAddExpense.Enabled = false;
            buttonSave.Enabled = false;
            buttonEdit.Enabled = false;
            buttonClearSearch.Enabled = false;
            buttonEditCats.Enabled = false;

            listenToBroadcast();
        }

        private void initDataGridView()
        {
            this.dataGridView1.Columns.Add("ID", "ID");
            this.dataGridView1.Columns.Add("Date", "Date");
            this.dataGridView1.Columns.Add("Item", "Item");
            this.dataGridView1.Columns.Add("Type", "Type");
            this.dataGridView1.Columns.Add("Spender", "Spender");
            this.dataGridView1.Columns.Add("Price", "Price");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkAndSaveOpenedBook();
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void filesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.filePath = openFileDialog1.FileName;
            this.myBook = Book.LoadBookFromFile(this.filePath);
            displayExpenses(myBook.expenses.Values.ToList());
            listBox1.Enabled = true;
            buttonAddExpense.Enabled = true;
            buttonSave.Enabled = true;
            buttonEdit.Enabled = true;
            buttonEditCats.Enabled = true;
        }

        private async Task<Book> callDataService()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //var response = await client.GetStringAsync("expenses/getall"); //what does this do???
            logger.LogInformation("I am going to call expense/getall web service");
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(new Uri("http://localhost:8080/expenses/getall")))
                {
                    logger.LogInformation("expense/getall service call finished");
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string resultString = await content.ReadAsStringAsync();
                        string reasonPhrase = response.ReasonPhrase;
                        HttpResponseHeaders headers = response.Headers;
                        //HttpStatusCode code = response.StatusCode;


                        var data = JsonConvert.DeserializeObject<Book>(resultString);
                        this.myBook = data;
                        return myBook;
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

        private async Task<Book> callDataServiceWrapper()
        {
            logger.LogInformation("I am going to call DataService");

            Book task = await callDataService();
            logger.LogInformation("finished call DataService");

            return task;
        }

        private void webAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var result = AsyncContext.Run(callDataService);

            var task = Task.Run(async () => await callDataServiceWrapper());
            //var task = callDataService();
            // run something else........
            logger.LogInformation("I am doing something else");
            //now I want to see if async task finished, if not wait for task finish
            var result = task.GetAwaiter().GetResult();
            logger.LogInformation("Got load from webAPI result");

            displayExpenses(myBook.expenses.Values.ToList());
            listBox1.Enabled = true;
            buttonAddExpense.Enabled = true;
            buttonSave.Enabled = true;
            buttonEdit.Enabled = true;
            buttonEditCats.Enabled = true;

            openedFromWeb = true;
        }

        private async void webAPIToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            //var result = AsyncContext.Run(callDataService);

            myBook = await callDataServiceWrapper();
            logger.LogInformation("Got load from webAPI result");

            displayExpenses(myBook.expenses.Values.ToList());
            listBox1.Enabled = true;
            buttonAddExpense.Enabled = true;
            buttonSave.Enabled = true;
            buttonEdit.Enabled = true;
            buttonEditCats.Enabled = true;

            openedFromWeb = true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkAndSaveOpenedBook();

            this.myBook = new Book();
            this.filePath = string.Empty;
            listBox1.Enabled = true;
            buttonAddExpense.Enabled = true;
            buttonSave.Enabled = true;
            buttonEdit.Enabled = true;
            buttonEditCats.Enabled = true;
            displayExpenses(myBook.expenses.Values.ToList());
        }

        private void checkAndSaveOpenedBook()
        {
            if (this.myBook != null)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save file before closing?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    saveOpenedBook();
                }
            }
        }

        private async Task<string> saveToWebAPI(Book book)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //var response = await client.GetStringAsync("expenses/getall"); //what does this do???

            JsonContent jsonContent = JsonContent.Create(book);

            try
            {
                using (HttpResponseMessage response = await client.PostAsync("http://localhost:8080/expenses/save", jsonContent))
                {
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string resultString = await content.ReadAsStringAsync();
                        string reasonPhrase = response.ReasonPhrase;
                        HttpResponseHeaders headers = response.Headers;
                        //HttpStatusCode code = response.StatusCode;
                        logger.LogInformation("Book saved to webAPI");
                        return resultString;
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

        private void saveOpenedBook()
        {
            if (this.filePath != null && this.filePath != string.Empty && !openedFromWeb)
            {
                Book.saveBook(this.myBook, this.filePath);
                buttonSave.Enabled = false;
            }

            else if (openedFromWeb)
            {
                //save to web api
                Console.WriteLine(myBook.expenses.Count);
                var task = Task.Run(async () => await saveToWebAPI(this.myBook));
                //var task = callDataService();
                // run something else........
                logger.LogInformation("I am saving to web service");
                //now I want to see if async task finished, if not wait for task finish
                string searchList = task.GetAwaiter().GetResult();
                logger.LogInformation(searchList);
            }

            else
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.ShowDialog();
                this.filePath = saveFileDialog1.FileName;
                if (this.filePath != "")
                {
                    Book.saveBook(this.myBook, this.filePath);
                    buttonSave.Enabled = false;
                }
            }

            Console.WriteLine("Form1 Thread is: " + Thread.CurrentThread.ManagedThreadId);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numRow = e.RowIndex;
            int idSelected = int.Parse(dataGridView1.Rows[numRow].Cells[0].Value.ToString());
            this.expenseSelected = this.myBook.getExpenseByID(idSelected);

            System.Windows.Forms.MessageBox.Show(this.expenseSelected.ToString());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string criteria = listBox1.SelectedItem.ToString();
            if (criteria == null || criteria.Length == 0)
            {
                return;
            }

            SortBook something = new SortBook();
            logger.LogInformation("current expenses count {Description}.",
                this.myBook.expenses.Count);
            List<Expense> sortedList = something.SortExpenses(this.myBook.expenses.Values.ToList(), criteria);
            displayExpenses(sortedList);
        }

        public void displayExpenses(List<Expense> expenseList)
        {
            if (dataGridView1.InvokeRequired)
            {
                
                this.Invoke(new Action(dataGridView1.Rows.Clear));
                foreach (var entry in expenseList)
                {
                    this.Invoke(() => dataGridView1.Rows.Add(entry.id,
                    entry.date,
                    entry.item,
                    entry.type,
                    entry.spender,
                    entry.price)
                    );
                    
                }
            }
            else
            {
                this.dataGridView1.Rows.Clear();
                foreach (var entry in expenseList)
                {
                    this.dataGridView1.Rows.Add(entry.id,
                    entry.date,
                    entry.item,
                    entry.type,
                    entry.spender,
                    entry.price);
                }
            }
            
        }

        public void updateBook(object sender, Expense e)
        {
            myBook.addNewExpense(e);
            displayExpenses(this.myBook.expenses.Values.ToList());
            System.Windows.Forms.MessageBox.Show("Book Updated!");
            buttonSave.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myForm = new FormExpense();
            //myForm.bookUpdated += new FormExpense.BookUpdatedHandler(updateBook);
            var handler = new FormExpense.BookUpdatedHandler(this.updateBook);
            myForm.bookUpdated += handler;
            myForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveOpenedBook();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var myForm = new FormExpense(this.expenseSelected);
            //myForm.bookUpdated += new FormExpense.BookUpdatedHandler(updateBook);
            var handler = new FormExpense.BookUpdatedHandler(updateBook);
            myForm.bookUpdated += handler;
            myForm.Show();
        }

        private async Task<List<Expense>> callQueryExecuter(QueryBuilder query)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //var response = await client.GetStringAsync("expenses/getall"); //what does this do???

            //JsonContent jsonContent = JsonContent.Create(query);
            StringContent stringContent = new StringContent(query.toJSONString(), UnicodeEncoding.UTF8, "application/json");

            try
            {
                using (HttpResponseMessage response = await client.PostAsync("http://localhost:8080/expenses/runquery", stringContent))
                {
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string resultString = await content.ReadAsStringAsync();
                        string reasonPhrase = response.ReasonPhrase;
                        HttpResponseHeaders headers = response.Headers;
                        //HttpStatusCode code = response.StatusCode;



                        var data = JsonConvert.DeserializeObject<List<Expense>>(resultString);
                        return data;
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

        private void runQuery(object sender, QueryBuilder query)
        {
            Console.WriteLine(myBook.expenses.Count);
            //List<Expense> searchList = query.runQuery(myBook);
            var task = Task.Run(async () => await callQueryExecuter(query));
            //var task = callDataService();
            // run something else........
            logger.LogInformation("I am doing something else");
            //now I want to see if async task finished, if not wait for task finish
            List<Expense> searchList = task.GetAwaiter().GetResult();
            Console.WriteLine(searchList.Count);
            displayExpenses(searchList);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            /*QueryBuilder queryBuilder = new QueryBuilder();
            queryBuilder.queryExact("date", "20240922");
            Console.WriteLine(queryBuilder.toJSONString());
            callQueryExecuter(queryBuilder);*/

            var search = new FormSearch();
            search.bookSearched += new FormSearch.BookSearchedHandler(runQuery);
            search.Show();
            buttonClearSearch.Enabled = true;
        }

        private void buttonClearSearch_Click(object sender, EventArgs e)
        {
            displayExpenses(this.myBook.expenses.Values.ToList());
            buttonClearSearch.Enabled = false;

        }

        private void buttonEditCats_Click(object sender, EventArgs e)
        {
            var myForm = new FormExpenseCategory();
            myForm.Show();
        }

        private void monthlyStmntButton_Click(object sender, EventArgs e)
        {
            var myForm = new FormMonthlySatement();
            myForm.Show();

        }


        private void listenToBroadcast()
        {
            var handler = new SSEClient.BookUpdatedByOtherHandler(this.eventReceived);
            sseClient.bookUpdatedByOther += handler; //cant be sseclient class
            sseClient.Start();
        }


        private void eventReceived(object sender, SSEvent e)
        {
            Console.WriteLine("SSE handler thread is: " + Thread.CurrentThread.ManagedThreadId);

            if (true)
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(e.Data + " has been updated. \nWould you like to refresh the page? \n Careful! Refreshing the page may cause " +
                    "unsaved changes to be deleted", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    refreshPage();
                }
            }

        }

        private void refreshPageSafe()
        {

        }

        private void refreshPage()
        {
           
            Task bookVar = Task.Run(async () => await callDataService());
            displayExpenses(this.myBook.expenses.Values.ToList());
           
        }



    }
}
