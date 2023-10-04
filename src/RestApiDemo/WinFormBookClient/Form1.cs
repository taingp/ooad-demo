using BookLib;

namespace WinFormBookClient
{
    public partial class Form1 : Form
    {
        private BindingSource bs = new();
        public Form1()
        {
            InitializeComponent();
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            bs.DataSource = new List<Book>();
            dgvBooks.DataSource = bs;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            btnRefresh.Click += DoClickRefresh;

            btnCreateSubmit.Click += DoClickCreateSubmit;

            bs.PositionChanged += DoBookPositionChanged;

            btnUpdateSubmit.Click += DoClickUpdateSubmit;

            btnDelete.Click += DoClickDelete;
        }

        private async void DoClickDelete(object? sender, EventArgs e)
        {
            if (bs.Current == null) return;
            if (bs.Current is not Book bk) return;
            string endpoint = $"api/books/{bk.Id}";
            var result = await Program.RestClient.DeleteAsync<Result<string?>>(endpoint);
            if (result!.Succeded && bk.Id == result!.Data)
            {
                bs.RemoveCurrent();
                bs.ResetBindings(false);
            }
            MessageBox.Show(result!.Message);
        }

        private async void DoClickUpdateSubmit(object? sender, EventArgs e)
        {
            string endpoint = "api/books";
            var req = new Book()
            {
                Id = txtUpdateId.Text,
                Title = txtUpdateTitle.Text,
                Pages = int.Parse(txtUpdatePages.Text)
            };
            var result = await Program.RestClient.PutAsync<Book, Result<string?>>(endpoint, req);
            Task task = Task.Run(async () =>
            {
                if (result!.Succeded)
                {
                    endpoint = $"api/books/{req.Id}";
                    var foundResult = await Program.RestClient.GetAsync<Result<Book?>>(endpoint);
                    if (foundResult!.Succeded && foundResult.Data != null)
                    {
                        var found = (bs.DataSource as List<Book>)?.FirstOrDefault(b => b.Id == foundResult.Data.Id);
                        if (found != null)
                        {
                            found.Copy(foundResult.Data);
                            bs.ResetBindings(false);
                        }
                    }
                }
            });
            MessageBox.Show(result!.Message);
            task.Wait();
        }

        private void DoBookPositionChanged(object? sender, EventArgs e)
        {
            if (bs.Current == null)
            {
                txtUpdateId.Clear();
                txtUpdateTitle.Clear();
                txtUpdatePages.Clear();
            }
            else
            {
                if (bs.Current is Book bk)
                {
                    txtUpdateId.Text = bk.Id.ToString();
                    txtUpdateTitle.Text = bk.Title;
                    txtUpdatePages.Text = bk.Pages.ToString();
                }
            }
        }

        private async void DoClickCreateSubmit(object? sender, EventArgs e)
        {
            string endpoint = "api/books";
            var req = new Book()
            {
                Id = txtCreateId.Text,
                Title = txtCreateTitile.Text,
                Pages = int.Parse(txtCreatePages.Text)
            };
            var result = await Program.RestClient.PostAsync<Book, Result<string?>>(endpoint, req);
            Task task = Task.Run(async () =>
            {
                if (result!.Succeded)
                {
                    endpoint = $"api/books/{req.Id}";
                    var foundResult = await Program.RestClient.GetAsync<Result<Book?>>(endpoint);
                    if (foundResult!.Succeded && foundResult.Data != null)
                    {
                        (bs.DataSource as List<Book>)?.Add(foundResult.Data);
                        bs.ResetBindings(false);
                    }
                }
            });
            MessageBox.Show(result!.Message);
        }

        private async void DoClickRefresh(object? sender, EventArgs e)
        {
            string endpoint = "api/books";
            var result = await Program.RestClient.GetAsync<Result<List<Book>>>(endpoint);
            if (result!.Succeded == true)
            {
                bs.DataSource = result.Data;
                bs.ResetBindings(false);
            }
        }

    }
}