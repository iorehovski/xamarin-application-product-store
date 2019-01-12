
using Android.App;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;
using Android.Content;
using Android.Text;
using Android.Views;
using BLL;
using DAL;

namespace UI
{
    [Activity(Label = "ChangeActivity")]
    [IntentFilter(new[] { MainFragment.IntentHeader + ".insert" }, Categories = new[] { Intent.CategoryDefault })]
    public class InsertUpdateActivity : Activity
    {
        public const string IsEditKey = "ISEDIT";
        public const string ValueKey = "VALUE";
        private static readonly List<string> producers = new List<string> { "Coca-Cola", "Mercedes", "Tesla"};

        private int? chosedId;


        EditText name;
        AutoCompleteTextView producer;
        EditText price;
        EditText shelfLife;
        EditText count;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.InsertUpdate);
            // Create your application here
            Button button = FindViewById<Button>(Resource.Id.button);
            Button retriveValue = FindViewById<Button>(Resource.Id.retrieveValue);

            name = FindViewById<EditText>(Resource.Id.name);
            producer = FindViewById<AutoCompleteTextView>(Resource.Id.producer);
            price = FindViewById<EditText>(Resource.Id.price);
            shelfLife = FindViewById<EditText>(Resource.Id.shelfLife);
            count = FindViewById<EditText>(Resource.Id.count);

            var adapter = new ArrayAdapter<string>(this, Resource.Layout.listItem, producers);
            producer.Adapter = adapter;;
         
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
                value.Price = price.Text == "" ? 0 : int.Parse(price.Text);
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

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            this.ActionBar.SetDisplayHomeAsUpEnabled(true);
            MenuInflater.Inflate(Resource.Menu.menu, menu);

            return true;
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            int id = item.ItemId;
            Intent intent;
            switch (id)
            {
                case 16908332:
                    this.OnBackPressed();
                    break;
                case Resource.Id.add:
                    intent = new Intent($"{MainFragment.IntentHeader}.insert");
                    StartActivity(intent);
                    break;
                case Resource.Id.update:
                    if (chosedId != null)
                    {
                        intent = new Intent($"{MainFragment.IntentHeader}.insert");
                        intent.PutExtra(InsertUpdateActivity.IsEditKey, true);
                        intent.PutExtra(InsertUpdateActivity.ValueKey, chosedId.Value);

                        StartActivity(intent);
                    }

                    break;
                case Resource.Id.delete:
                    if (chosedId != null)
                    {
                        ProductService.Remove(chosedId.Value);
                        MainFragment.RenewValues();
                    }

                    break;
                case Resource.Id.menu_info:
                    Toast.MakeText(this, "Products application. v.1.6", ToastLength.Long).Show();
                    break;
            }

            return base.OnMenuItemSelected(featureId, item);
        }

        public void OnSelect(int? newId)
        {
            chosedId = newId;
        }


        private void FillValue(Product value)
        {
            value.Count = int.Parse(count.Text);
            value.Price = int.Parse(price.Text);
            value.ShelfLife = int.Parse(shelfLife.Text);
            value.Name = name.Text;
            value.UPC = "none";
            value.Producer = producer.Text;
        }
    }
}