
using System.Runtime.CompilerServices;
using System.Linq;
using Home_Expense_Tracking_App.ManageBook;
using Home_Expense_Tracking_App;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;


namespace ExpenseTrackerWinForms
{
    public partial class FormSearch : Form
    {
        static ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        static ILogger logger = factory.CreateLogger("FormSearchClass");
        public delegate void BookSearchedHandler(object sender, QueryBuilder query);
        public event BookSearchedHandler bookSearched;
        static HttpClient client = new HttpClient();
        
        public string category;
        public string detailLower;
        public string detailUpper;
        public HashSet<ExpenseCategory> expenseCategories = new HashSet<ExpenseCategory>();
        public QueryBuilder queryBuilder = new QueryBuilder();
        public List<string> searchParams = new List<string>();

        /*public class BookSearchedHandler1
        {
            private Function handler;

            public BookSearchedHandler1(Function function)
            {
                this.handler = function;
            }

            public void call(object sender, QueryBuilder query)
            {
                this.handler(object sender, QueryBuilder query);
            }
        }*/

        public FormSearch()
        {
            InitializeComponent();
        }

        private void FormSearch_Load(object sender, EventArgs e)
        {
            comboBoxCategory.Items.Add("Date");
            comboBoxCategory.Items.Add("Item");
            comboBoxCategory.Items.Add("Type");
            comboBoxCategory.Items.Add("Spender");
            comboBoxCategory.Items.Add("Price");
            comboBoxCategory.Items.Add("Id");

            comboBoxSearchType.Enabled = false;
            label3.Enabled = false;
            textBoxLower.Enabled = false;
            textBoxUpper.Enabled = false;
            label1.Enabled = false;
            buttonAdd.Enabled = false;
            buttonGo.Enabled = false;
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxCategory.SelectedIndex)
            {
                case 0:
                    this.category = "date";
                    break;

                case 1:
                    this.category = "item";
                    break;

                case 2:
                    this.category = "type";
                    break;

                case 3:
                    this.category = "spender";
                    break;

                case 4:
                    this.category = "price";
                    break;

                case 5:
                    this.category = "id";
                    break;

                default:
                    throw new ArgumentException("Category type does not exist.");
            }
            comboBoxSearchType.Enabled = true;
            label3.Enabled = true;
            populateComboBoxSearchType();

        }


        private void populateComboBoxSearchType()
        {
            comboBoxSearchType.Items.Clear();

            var task = Task.Run(async () => await getSearchTypes());
            var result = task.GetAwaiter().GetResult();
            SearchType st = result;

            foreach (string searchType in result.sentTypes)
            {
                comboBoxSearchType.Items.Add(searchType);
            }
/*
            comboBoxSearchType.Items.Add("Equal");
            comboBoxSearchType.Items.Add("Range");
            comboBoxSearchType.Items.Add("Less Than");
            comboBoxSearchType.Items.Add("More Than");
            comboBoxSearchType.Items.Add("Not");

            if (this.category.Equals("type"))
            {
                comboBoxSearchType.Items.Remove("Range");
                comboBoxSearchType.Items.Remove("Less Than");
                comboBoxSearchType.Items.Remove("More Than");
            }*/
        }

        private async Task<SearchType> getSearchTypes()
        {
            string url = "http://localhost:8080/expenses/" + this.category + "/getsearchtypes";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            logger.LogInformation("I am going to call getSearchTypes web service");
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(new Uri(url)))
                {
                    logger.LogInformation("getSearchTypes service call finished");
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string resultString = await content.ReadAsStringAsync();
                        string reasonPhrase = response.ReasonPhrase;
                        HttpResponseHeaders headers = response.Headers;
                        //HttpStatusCode code = response.StatusCode;


                        var data = JsonConvert.DeserializeObject<SearchType>(resultString);
                        SearchType st = data;
                        return st;
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

            
        private void comboBoxSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxLower.Enabled = true;
            textBoxUpper.Enabled = false;

            if (comboBoxSearchType.Text.Equals("range")) 
            {
                label1.Enabled = true;
                textBoxUpper.Enabled = true; 
            }

            buttonAdd.Enabled = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.detailLower = textBoxLower.Text;
            this.detailUpper = textBoxUpper.Text;

            switch (comboBoxSearchType.Text)
            {
                case "Equal":
                    this.queryBuilder = this.queryBuilder.queryExact(this.category, this.detailLower);
                    this.searchParams.Add(this.category + ": " + this.detailLower);
                    break;

                case "Range":
                    this.queryBuilder = this.queryBuilder.queryRange(this.category, (this.detailLower, this.detailUpper));
                    this.searchParams.Add(this.category + ": " + this.detailLower + " to " + this.detailUpper);
                    break;

                case "Less than":
                    this.queryBuilder = this.queryBuilder.queryLessThan(this.category, this.detailLower);
                    this.searchParams.Add(this.category + ": <" + this.detailLower);
                    break;

                case "More than":
                    this.queryBuilder = this.queryBuilder.queryMoreThan(this.category, this.detailLower);
                    this.searchParams.Add(this.category + ": >" + this.detailLower);
                    break;

                case "Not":
                    this.queryBuilder = this.queryBuilder.queryNot(this.category, this.detailLower);
                    this.searchParams.Add(this.category + ": not " + this.detailLower);
                    break;

                default:
                    throw new ArgumentException("Search type does not exist.");
            }

            listboxSearchParams.Items.Add(searchParams[^1]);
            buttonGo.Enabled = true;
            resetSearchParams();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {

            this.bookSearched.Invoke(this, this.queryBuilder);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void resetSearchParams()
        {
            textBoxLower.Clear();
            textBoxUpper.Clear();
            textBoxLower.Enabled = false;
            textBoxUpper.Enabled = false;
            buttonAdd.Enabled = false;
            comboBoxSearchType.Items.Clear();
        }
        
    }
}
