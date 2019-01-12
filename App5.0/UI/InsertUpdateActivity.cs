using Android.App;
using Android.OS;
using Android.Widget;
using System;
using Android.Content;
using BLL;
using DAL;
using System.Collections.Generic;

namespace UI
{
    [Activity(Label = "ChangeActivity")]
    [IntentFilter(new[] { MainActivity.IntentHeader + ".insert" }, Categories = new[] { Intent.CategoryDefault })]
    public class InsertUpdateActivity : Activity
    {
        public const string IsEditKey = "ISEDIT";
        public const string ValueKey = "VALUE";
        private static readonly List<string> numbers = new List<string> { "0", "5", "15", "20", "25", "30" };

        EditText name;
        EditText producer;
        AutoCompleteTextView price;
        AutoCompleteTextView shelfLife;
        AutoCompleteTextView count;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.InsertUpdate);
            // Create your application here
            Button button = FindViewById<Button>(Resource.Id.button);
            Button retriveValue = FindViewById<Button>(Resource.Id.retrieveValue);

            name = FindViewById<EditText>(Resource.Id.name);
            producer = FindViewById<EditText>(Resource.Id.producer);
            price = FindViewById<AutoCompleteTextView>(Resource.Id.price);
            shelfLife = FindViewById<AutoCompleteTextView>(Resource.Id.shelfLife);
            count = FindViewById<AutoCompleteTextView>(Resource.Id.count);

            var adapter = new ArrayAdapter<string>(this, Resource.Layout.listItem, numbers);
            price.Adapter = adapter;
            shelfLife.Adapter = adapter;
            count.Adapter = adapter;

            adapter.NotifyDataSetChanged();

            var isEdit = Intent.GetBooleanExtra(IsEditKey, false);

            Product value;
            if (isEdit)
            {
                var valueId = Intent.GetIntExtra(ValueKey, 0);
                value = ProductService.GetById(valueId);
                
                producer.Text = value.Producer.ToString();
                price.Text = value.Price.ToString();
                name.Text = value.Name;
                shelfLife.Text = value.ShelfLife.ToString();
                count.Text = value.Count.ToString();
            }
            else
            {
                value = new Product();
            }

            button.Click += (object sender, EventArgs e) =>
            {
                value.Name = name.Text ?? "none";
                value.UPC = "none";
                value.Producer = producer.Text ?? "none";
                value.Price = price.Text == "" ? 0:int.Parse(price.Text);
                value.ShelfLife = shelfLife.Text == "" ? 0 : int.Parse(shelfLife.Text);
                value.Count = count.Text == "" ? 0 : int.Parse(count.Text);

                if (!isEdit)
                {
                    ProductService.Insert(value);
                }

                Finish();
            };

            retriveValue.Click += (object sender, EventArgs e) =>
            {
                FillValue(value);
                Toast.MakeText(this, value.ToString(), ToastLength.Long).Show();
            };
        }

        private void FillValue(Product value)
        {
            value.Count = int.Parse(count.Text);
            value.Price = int.Parse(price.Text);
            value.ShelfLife = int.Parse (shelfLife.Text);
            value.Name = name.Text;
            value.UPC = "none";
            value.Producer = producer.Text;
        }
    }
}