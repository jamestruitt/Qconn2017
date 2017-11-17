using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using System.IO;

namespace LicensePlatePOCClient
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetProcessedPlates_Click(object sender, EventArgs e)
        {

            LoadData();

        }

        private void lvProcessedTags_ItemCheck(object sender, ItemCheckEventArgs e)
        {
           
        }

        private void lvProcessedTags_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String((string)lvProcessedTags.Items[e.ItemIndex].Tag);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                pictureBox1.Image = image;
            }
        }

        private void LoadData() {

            var connectionString = "mongodb://licenseplatepocprocessingdb:e5mdG2PMFuPqHQ32b8IMMqNnG6Kbeb111U7SUdnOAqZZ2LT4cdBHOePkSujJEicfbC0nvtMbFcU0Q9pobqKbDA==@licenseplatepocprocessingdb.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("admin");

            var collection = db.GetCollection<LicensePlateData>("ProcessedLicensePlates");

            ImageList imageListLarge = new ImageList();

            lvProcessedTags.Items.Clear();

            using (var cursor = collection.FindSync(new BsonDocument()))
            {

                while (cursor.MoveNext())
                {
                    IEnumerable<LicensePlateData> batch = cursor.Current;
                    foreach (LicensePlateData document in batch)
                    {
                        Console.WriteLine(document.plate);

                        var listItem = new ListViewItem(document.plate);

                        listItem.SubItems.Add(document.state);
                        listItem.SubItems.Add(document.body_type);
                        listItem.SubItems.Add(document.color);
                        listItem.SubItems.Add(document.make);
                        listItem.SubItems.Add(document.make_model);
                        listItem.Tag = document.image_bytes;

                        lvProcessedTags.Items.Add(listItem);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
