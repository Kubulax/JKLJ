using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;

namespace JKLJ
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        private ObservableCollection<string> itemList = new ObservableCollection<string>();

        public ListViewPage()
        {
            InitializeComponent();

            Load();
        }


        public void Load()
        {
            string path = App.DbPath;

            if(File.Exists(path))
            {
                string text = File.ReadAllText(path);


                List<BMIResult> results = JsonConvert.DeserializeObject<List<BMIResult>>(text);

                listViewBMI.ItemsSource = results;

                foreach (var item in results)
                {
                    itemList.Add(item.ToString());
                }

            }


            

            
        }

        private void Delete_btn(object sender, EventArgs e)
        {
            string path = App.DbPath;

            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
            }

            string selectedItem = (string)listViewBMI.SelectedItem;

            if (selectedItem == null)
            {
                DisplayAlert("Error", "Please select an item to delete.", "OK");
                return;
            }

            
            itemList.Remove(selectedItem);

            
            JArray jsonArray = new JArray();
            foreach (var item in itemList)
            {
                jsonArray.Add(item);
            }

            
            string updatedJson = jsonArray.ToString();

           
            
            File.WriteAllText(path, updatedJson);

            DisplayAlert("Success", "Item has been deleted from the JSON file.", "OK");

        }
    }
}