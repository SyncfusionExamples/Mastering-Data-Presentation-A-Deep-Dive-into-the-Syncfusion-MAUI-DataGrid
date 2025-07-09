namespace MAUI_Sync_DataGrid
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            
        }
        private void SfDataGrid_Loaded(object sender, EventArgs e)
        {
            dataGrid.View.Filter = FilterRecords;
            //dataGrid.View.RefreshFilter();
        }
        public bool FilterRecords(object record)
        {
            TemplateModel? templateModel = record as TemplateModel;

            if (templateModel != null && templateModel.DealerName == "Jefferson")
            {
                return true;
            }
            return false;
        }

       
    }

}
