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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExpenseTrackerWinForms
{
    public partial class FormExpense : Form
    {
        static ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        static ILogger logger = factory.CreateLogger("FormExpenseClass");
        public Form1 parent;
        public delegate void BookUpdatedHandler(object sender, Expense e);
        public event BookUpdatedHandler bookUpdated;
        static HttpClient client = new HttpClient();

        public HashSet<ExpenseCategory> expenseCategories = new HashSet<ExpenseCategory>();
        public HashSet<ExpenseCategory> highLvlCategories = new HashSet<ExpenseCategory>();
        public ExpenseCategory typeCategory;
        List<BookUpdatedHandler> callbackFunctionList;
        public Expense expenseToEdit;


        public FormExpense()
        {
            InitializeComponent();
            expenseToEdit = new Expense(0);
            displayExpense();
        }

        public FormExpense(Expense expense)
        {
            InitializeComponent();
            expenseToEdit = expense;
            displayExpense();
        }

        private async Task<HashSet<ExpenseCategory>> loadExpenseCategories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            logger.LogInformation("I am going to call loadExpenseCategories web service");
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(new Uri("http://localhost:8080/category/getall")))
                {
                    logger.LogInformation("loadExpenseCategories  service call finished");
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string resultString = await content.ReadAsStringAsync();
                        string reasonPhrase = response.ReasonPhrase;
                        HttpResponseHeaders headers = response.Headers;
                        //HttpStatusCode code = response.StatusCode;


                        var data = JsonConvert.DeserializeObject<HashSet<ExpenseCategory>>(resultString);
                        this.expenseCategories = data;
                        return expenseCategories;
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


        private void displayExpense()
        {
            var task = Task.Run(async () => await loadExpenseCategories());
            var result = task.GetAwaiter().GetResult();

            foreach (ExpenseCategory cat in this.expenseCategories)
            {
                var subcats = Task.Run(async () => await loadSubCats(cat));
                var subcatsResult = task.GetAwaiter().GetResult();
            }

            var hlcats = Task.Run(async () => await loadSubCats(null));
            var hlcatsResult = task.GetAwaiter().GetResult();

            if (expenseToEdit == null) { return; }

            txtDate.Text = expenseToEdit.date.ToString();
            txtItem.Text = expenseToEdit.item;
            txtType.Text = expenseToEdit.type;
            txtType.ReadOnly = true;
            txtName.Text = expenseToEdit.spender;
            txtPrice.Text = expenseToEdit.price.ToString();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            bool dateSuccess = int.TryParse(txtDate.Text, out int date);
            string item = txtItem.Text;
            string type = txtType.Text;
            string name = txtName.Text;
            bool priceSuccess = double.TryParse(txtPrice.Text, out double price);

            if (!dateSuccess && !priceSuccess)
            {
                System.Windows.Forms.MessageBox.Show("Error: please enter a valid date and price.");
            }

            else if (!dateSuccess)
            {
                System.Windows.Forms.MessageBox.Show("Error: please enter a valid date");
            }

            else if (!priceSuccess)
            {
                System.Windows.Forms.MessageBox.Show("Error: please enter a valid price");
            }

            else if (findCatFromSet(type) == null)
            {
                System.Windows.Forms.MessageBox.Show("Error: please select a valid type");
            }

            else
            {
                expenseToEdit.date = date;
                expenseToEdit.type = type;
                expenseToEdit.item = item;
                expenseToEdit.spender = name;
                expenseToEdit.price = price;
                this.Close();
                this.bookUpdated.Invoke(this, expenseToEdit);
                //parent.bookUpdated();
            }
        }


        private async Task<HashSet<ExpenseCategory>> loadHighestCategories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            logger.LogInformation("I am going to call loadHighestCategories web service");
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(new Uri("http://localhost:8080/category/main")))
                {
                    logger.LogInformation("loadHighestCategories service call finished");
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string resultString = await content.ReadAsStringAsync();
                        string reasonPhrase = response.ReasonPhrase;
                        HttpResponseHeaders headers = response.Headers;
                        //HttpStatusCode code = response.StatusCode;


                        var data = JsonConvert.DeserializeObject<HashSet<ExpenseCategory>>(resultString);
                        highLvlCategories = data;
                        return highLvlCategories;
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


        private async Task<HashSet<ExpenseCategory>> loadSubCats(ExpenseCategory category)
        {
            if (category == null)
            {
                highLvlCategories = await loadHighestCategories();
                return highLvlCategories;
            }

            string url = "http://localhost:8080/category/" + category.category + "/subcategories";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            logger.LogInformation("I am going to call subcats web service");
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(new Uri(url)))
                {
                    logger.LogInformation("Subcats service call finished");
                    using (HttpContent content = response.Content)
                    {
                        string resultString = await content.ReadAsStringAsync();
                        string reasonPhrase = response.ReasonPhrase;
                        HttpResponseHeaders headers = response.Headers;

                        var data = JsonConvert.DeserializeObject<HashSet<ExpenseCategory>>(resultString);
                        category.children = data;
                        return category.children;
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

        private ExpenseCategory findCatFromSet(string category)
        {
            foreach (ExpenseCategory cat in expenseCategories)
            {
                if (cat.category.Equals(category))
                {
                    return cat;
                }
            }
            return null;
        }


        private void toolStripMenuItemType_Click(object sender, EventArgs e)
        {
            /*            ToolStripMenuItem[] col = new ToolStripMenuItem[expenseCategories.Count];
                        int i = 0;
                        foreach (ExpenseCategory cat in expenseCategories)
                        {
                            col[i++] = new ToolStripMenuItem(cat.getCategory());
                        }*/

            toolStripMenuItemType.DropDownItems.Clear();
            foreach (ExpenseCategory cat in highLvlCategories)
            {
                ToolStripMenuItem collectionMenu = new ToolStripMenuItem(cat.category);
                toolStripMenuItemType.DropDownItems.Add(collectionMenu);
                collectionMenu.Click += new EventHandler(MenuItemClickHandler);
            }
            toolStripMenuItemType.DropDown.Top = 100;
            toolStripMenuItemType.DropDown.Show();
            //toolStripMenuItemType.DropDown.AutoClose = false;

        }


        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            // Take some action based on the data in clickedItem
            clickedItem.DropDownItems.Clear();

            ExpenseCategory clicked = findCatFromSet(clickedItem.Text);
            Console.WriteLine(clicked.children);

            if (clicked.children.Count == 0)
            {
                expenseToEdit.type = clicked.category;
                txtType.Text = expenseToEdit.type;
                return;
            }

            foreach (ExpenseCategory cat in clicked.children)
            {
                ToolStripMenuItem collectionMenu = new ToolStripMenuItem(cat.category);
                clickedItem.DropDownItems.Add(collectionMenu);
                collectionMenu.Click += new EventHandler(MenuItemClickHandler);
            }

            /*ToolStripMenuItem collectionMenu1 = new ToolStripMenuItem("aaa");
            clickedItem.DropDownItems.Add(collectionMenu1);
            collectionMenu1.Click += new EventHandler(MenuItemClickHandler);

            collectionMenu1 = new ToolStripMenuItem("bbb");
            clickedItem.DropDownItems.Add(collectionMenu1);
            collectionMenu1.Click += new EventHandler(MenuItemClickHandler);*/

            clickedItem.DropDown.Show();
            //clickedItem.DropDown.AutoClose = false;

        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
