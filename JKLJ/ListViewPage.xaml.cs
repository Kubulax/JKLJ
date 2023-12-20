using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JKLJ
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();

            Load();
        }


        public void Load()
        {
            string path = App.DdPath;

            if(File.Exists(path))
            {
                string text = File.ReadAllText(path);


                List<BMIResult> results = JsonConvert.DeserializeObject<List<BMIResult>>(text);

                listViewBMI.ItemsSource = results;
            }
        }
    }
}