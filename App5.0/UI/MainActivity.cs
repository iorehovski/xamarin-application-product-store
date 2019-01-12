using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Widget;
using BLL;
using DAL;
using System;
using System.IO;

namespace UI
{
    [Activity(Label = "Lab2.3", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public const string IntentHeader = "com.exercise3";

        private const string Tag = "Main";

        private static string fileName =
            Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "fileName.xml");

        private ArrayAdapter<Product> adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Log.Debug(Tag, "Reading");
            ProductService.Insert(new Product
            {
                Count = 1,
                Name = "1",
                Price = 1,
                Producer = "1",
                ShelfLife = 1,
                UPC = "12"
            });
            ProductSource.WriteToFile(fileName);

            ProductSource.ReadFromFile(fileName);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            ProductSource.WriteToFile(fileName);

            Log.Debug(Tag, "Saving");
        }

        protected override void OnResume()
        {
            base.OnResume();

            Log.Debug(Tag, "Resume");
        }
    }
}

