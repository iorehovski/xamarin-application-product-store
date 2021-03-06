﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using BLL;
using System;


namespace UI
{
    [Activity(Label = "DefinedName")]
    [IntentFilter(new[] { MainFragment.IntentHeader + ".DefinedName" }, Categories = new[] { Intent.CategoryDefault })]
    public class DefinedName : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DefinedNameLayout);
            // Create your application here
            TextView text = FindViewById<TextView>(Resource.Id.text);
            Button button = FindViewById<Button>(Resource.Id.button);
            EditText input = FindViewById<EditText>(Resource.Id.input);

            button.Click += (object sender, EventArgs e) =>
            {
                var name = input.Text;

                using(var _service = new ProductService(MainActivity.FileName))
                {
                    text.Text = string.Join("\n", _service.GetItemsByName(name));
                }
            };
        }
    }

    [Activity(Label = "DefinedNameAndPrice")]
    [IntentFilter(new[] { MainFragment.IntentHeader+ ".DefinedNameAndPrice" }, Categories = new[] { Intent.CategoryDefault })]
    public class DefinedNameAndPrice : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DefinedNameAndPriceLayour);
            // Create your application here
            TextView text = FindViewById<TextView>(Resource.Id.text);
            Button button = FindViewById<Button>(Resource.Id.button);
            EditText inputName = FindViewById<EditText>(Resource.Id.inputName);
            EditText inputPrice = FindViewById<EditText>(Resource.Id.inputPrice);

            button.Click += (object sender, EventArgs e) =>
            {
                var name = inputName.Text;
                var price = int.Parse(inputPrice.Text);
                using (var _service = new ProductService(MainActivity.FileName))
                {
                    text.Text = string.Join("\n", _service.GetItemsByName(name, price));
                }
            };
        }
    }

    [Activity(Label = "DefinedShelfLife")]
    [IntentFilter(new[] { MainFragment.IntentHeader+ ".DefinedShelfLife" }, Categories = new[] { Intent.CategoryDefault })]
    public class DefinedShelfLife : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DefinedShelfLifeLayout);
            // Create your application here
            TextView text = FindViewById<TextView>(Resource.Id.text);
            Button button = FindViewById<Button>(Resource.Id.button);
            EditText input = FindViewById<EditText>(Resource.Id.input);

            button.Click += (object sender, EventArgs e) =>
            {
                var days = int.Parse(input.Text);
                using (var _service = new ProductService(MainActivity.FileName))
                {
                    text.Text = string.Join("\n", _service.GetItemsByShelfLife(days));
                }
            };
        }
    }

    [Activity(Label = "DefinedProducer")]
    [IntentFilter(new[] { MainFragment.IntentHeader + ".DefinedProducer" }, Categories = new[] { Intent.CategoryDefault })]
    public class DefinedProducer : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DefinedNameLayout);
            // Create your application here
            TextView text = FindViewById<TextView>(Resource.Id.text);
            Button button = FindViewById<Button>(Resource.Id.button);
            EditText input = FindViewById<EditText>(Resource.Id.input);

            button.Click += (object sender, EventArgs e) =>
            {
                var name = input.Text;
                using (var _service = new ProductService(MainActivity.FileName))
                {
                    text.Text = string.Join("\n", _service.GetItemsByProducer(name));
                }
                
            };
        }
    }

    [Activity(Label = "DefinedOnStock")]
    [IntentFilter(new[] { MainFragment.IntentHeader + ".DefinedOnStock" }, Categories = new[] { Intent.CategoryDefault })]
    public class DefinedOnStock : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DefinedNameLayout);
            // Create your application here
            TextView text = FindViewById<TextView>(Resource.Id.text);
            Button button = FindViewById<Button>(Resource.Id.button);
            EditText input = FindViewById<EditText>(Resource.Id.input);

            button.Click += (object sender, EventArgs e) =>
            {
                var name = input.Text;
                using (var _service = new ProductService(MainActivity.FileName))
                {
                    text.Text = string.Join("\n", _service.GetItemsOnStock());
                }
            };
        }
    }

}