using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Home_Expense_Tracking_App;
using Home_Expense_Tracking_App.ManageBook;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ExpenseTrackerWinForms
{
    public partial class FormExpenseCategory : Form
    {
        static ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        static ILogger logger = factory.CreateLogger("FormExpenseCategoryClass");
        public delegate void CategoriesEditedHandler(object sender);
        public event CategoriesEditedHandler categoriesEdited;
        static HttpClient client = new HttpClient();

        public HashSet<ExpenseCategory> toAdd = new HashSet<ExpenseCategory>();
        public HashSet<ExpenseCategory> expenseCategories = new HashSet<ExpenseCategory>();
        public ExpenseCategory categorySelected = new ExpenseCategory();
        private string editType = "";


        public FormExpenseCategory()
        {
            InitializeComponent();

            displayExpenseCats();
        }


        private void displayExpenseCats()
        {
            var task = Task.Run(async () => await loadExpenseCategories());
            var result = task.GetAwaiter().GetResult();

            loadAllSubCats();

            this.dataGridViewCats.Columns.Add("Category", "Category");
            this.dataGridViewCats.Columns.Add("Parent", "Parent");
            this.dataGridViewToAdd.Columns.Add("Category", "Category");
            this.dataGridViewToAdd.Columns.Add("Parent", "Parent");

            displayInDataGridView(dataGridViewCats, expenseCategories);

        }


        private void displayInDataGridView(DataGridView grid, HashSet<ExpenseCategory> cats)
        {
            grid.Rows.Clear();
            foreach (ExpenseCategory entry in cats)
            {
                grid.Rows.Add(entry.category, entry.parent);
            }
        }


        private async Task<HashSet<ExpenseCategory>> loadExpenseCategories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YWRtaW46YWRtaW4=");
            logger.LogInformation("I am going to call loadExpenseCategories web service");
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(new Uri("http://localhost:8080/category/getall")))
                {
                    logger.LogInformation("loadExpenseCategories service call finished");
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


        private async Task<HashSet<ExpenseCategory>> loadSubCats(ExpenseCategory category)
        {
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

        private void loadAllSubCats()
        {
            foreach (ExpenseCategory cat in this.expenseCategories)
            {
                var subcats = Task.Run(async () => await loadSubCats(cat));
                var subcatsResult = subcats.GetAwaiter().GetResult();
            }
        }

        private void refreshDisplay()
        {
            displayInDataGridView(dataGridViewCats, expenseCategories);
            loadAllSubCats();
            editType = "";
            categorySelected = null;
        }


        private void dataGridViewCats_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numRow = e.RowIndex;
            if (numRow < 1)
            {
                return;
            }
            string cat = dataGridViewCats.Rows[numRow].Cells[0].Value.ToString();
            logger.LogInformation(cat);
            categorySelected = findCatFromSet(cat);
            logger.LogInformation(categorySelected.ToString());
            if(categorySelected != null)
            {
                System.Windows.Forms.MessageBox.Show(this.categorySelected.ToString());
            }            
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ExpenseCategory cat = new ExpenseCategory(textBoxCategory.Text, textBoxParent.Text);
            toAdd.Add(cat);
            displayInDataGridView(dataGridViewToAdd, toAdd);
            textBoxCategory.Clear();
            textBoxParent.Clear();
            editType = "add";
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (editType.Equals("add"))
            {
                var task = Task.Run(async () => await addExpenseCategory(toAdd));
                string result = task.GetAwaiter().GetResult();
                dataGridViewToAdd.Rows.Clear();
                if(result != null)
                {
                    expenseCategories = JsonConvert.DeserializeObject<HashSet<ExpenseCategory>>(result);
                    refreshDisplay();
                }
                toAdd = new HashSet<ExpenseCategory>();
            }

            else if (editType.Equals("edit"))
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to edit this category?\n Editing thing category many affect other subsequent " +
                    "categories", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var task = Task.Run(async () => await editCategory(categorySelected, textBoxCategory.Text, textBoxParent.Text));
                    string result = task.GetAwaiter().GetResult();
                    if (result != null)
                    {
                        expenseCategories = JsonConvert.DeserializeObject<HashSet<ExpenseCategory>>(result);
                        refreshDisplay();
                    }
                    textBoxCategory.Clear();
                    textBoxParent.Clear();
                }
            }

        }


        private void buttonRemoveCat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this category?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var task = Task.Run(async () => await removeExpenseCategory(categorySelected));
                string result = task.GetAwaiter().GetResult();
                if (result != null)
                {
                    expenseCategories = JsonConvert.DeserializeObject<HashSet<ExpenseCategory>>(result);
                    refreshDisplay();
                }
            }
        }


        private void buttonEditCat_Click(object sender, EventArgs e)
        {
            //TODO: FINISH EDIT FUNCTION
            textBoxCategory.Text = categorySelected.category;
            textBoxParent.Text = categorySelected.parent;
            editType = "edit";

        }


        private async Task<string> addExpenseCategory(HashSet<ExpenseCategory> cats)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YWRtaW46YWRtaW4=");
            logger.LogInformation("I am going to call addExpenseCategory web service");

            try
            {
                string jcontent = System.Text.Json.JsonSerializer.Serialize(cats);
                JsonContent jsonContent = JsonContent.Create(cats);
                string stringContent = "{\"cats\": " + jcontent + "}";
                logger.LogInformation(stringContent);
                StringContent stringContent1 = new StringContent(stringContent, Encoding.UTF8, "application/json");
                Console.WriteLine(stringContent1);

                using (HttpResponseMessage response = await client.PostAsync("http://localhost:8080/category/addcategory2", stringContent1))
                {
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string resultString = await content.ReadAsStringAsync();
                        string reasonPhrase = response.ReasonPhrase;
                        HttpResponseHeaders headers = response.Headers;
                        //HttpStatusCode code = response.StatusCode;
                        logger.LogInformation("addExpenseCategory service call finished");
                        if ((int)response.StatusCode == 200)
                        {
                            return resultString;
                        }
                        System.Windows.Forms.MessageBox.Show(resultString);
                        return null;
                        
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


        private async Task<string> removeExpenseCategory(ExpenseCategory cats)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YWRtaW46YWRtaW4=");
            logger.LogInformation("I am going to call removeExpenseCategory web service");

            try
            {
                JsonContent jsonContent = JsonContent.Create(cats);

                using (HttpResponseMessage response = await client.PostAsync("http://localhost:8080/category/removecategory", jsonContent))
                {
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string resultString = await content.ReadAsStringAsync();
                        string reasonPhrase = response.ReasonPhrase;
                        HttpResponseHeaders headers = response.Headers;
                        logger.LogInformation("removeExpenseCategory service call finished");
                        if ((int)response.StatusCode == 200)
                        {
                            return resultString;
                        }
                        System.Windows.Forms.MessageBox.Show(resultString);
                        return null;
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


        private async Task<string> editCategory(ExpenseCategory cat, string newCategory, string newParent)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YWRtaW46YWRtaW4=");
            logger.LogInformation("I am going to call editExpenseCategory web service");

            try
            {
                ExpenseCategory newCat = new ExpenseCategory(newCategory, newParent);
                List<ExpenseCategory> toSend = new List<ExpenseCategory>();
                toSend.Add(cat);
                toSend.Add(newCat);
                string jcontent = System.Text.Json.JsonSerializer.Serialize(toSend);
                string stringContent = "{\"cats\": " + jcontent + "}";
                logger.LogInformation(stringContent);
                StringContent stringContent1 = new StringContent(stringContent, Encoding.UTF8, "application/json");
                Console.WriteLine(stringContent1);

                using (HttpResponseMessage response = await client.PostAsync("http://localhost:8080/category/editcategory", stringContent1))
                {
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string resultString = await content.ReadAsStringAsync();
                        string reasonPhrase = response.ReasonPhrase;
                        HttpResponseHeaders headers = response.Headers;
                        logger.LogInformation("editExpenseCategory service call finished");
                        if ((int)response.StatusCode == 200)
                        {
                            return resultString;
                        }
                        System.Windows.Forms.MessageBox.Show(resultString);
                        return null;
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


        private ExpenseCategory findCatFromSet(string cat)
        {
            if(cat == null)
            {
                return null;
            }

            foreach(ExpenseCategory category in expenseCategories)
            {
                if (category.category.Equals(cat))
                {
                    return category;
                }
            }

            return null;
        }


        private async Task<HashSet<ExpenseCategory>> saveCats(HashSet<ExpenseCategory> cats)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YWRtaW46YWRtaW4=");
            logger.LogInformation("I am going to call saveCats web service");

            try
            {
                string jcontent = System.Text.Json.JsonSerializer.Serialize(cats);
                JsonContent jsonContent = JsonContent.Create(cats);
                string stringContent = "{\"cats\": " + jcontent + "}";
                logger.LogInformation(stringContent);
                StringContent stringContent1 = new StringContent(stringContent, Encoding.UTF8, "application/json");
                Console.WriteLine(stringContent1);

                using (HttpResponseMessage response = await client.PostAsync("http://localhost:8080/category/save", stringContent1))
                {
                    logger.LogInformation("SaveCats service call finished");
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string resultString = await content.ReadAsStringAsync();
                        string reasonPhrase = response.ReasonPhrase;
                        HttpResponseHeaders headers = response.Headers;
                        //HttpStatusCode code = response.StatusCode;


                        var data = JsonConvert.DeserializeObject<HashSet<ExpenseCategory>>(resultString);
                        this.expenseCategories = data;
                        logger.LogInformation("saveCats service call finished");
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


        private void buttonSave_Click(object sender, EventArgs e)
        {
            var task = Task.Run(async () => await saveCats(this.expenseCategories));
            var result = task.GetAwaiter().GetResult();

        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
