using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using BLL;
using DAL;

namespace UI
{
    public class MainFragment : Fragment
    {
        public const string IntentHeader = "com.exercise3";
        private static ArrayAdapter<Product> adapter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            var layout = inflater.Inflate(Resource.Layout.MainFragment, container, false);

            ListView list = layout.FindViewById<ListView>(Resource.Id.list);

            adapter = new ArrayAdapter<Product>(inflater.Context, Resource.Layout.listItem, ProductService.GetAll());
            list.Adapter = adapter;

            list.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
            {
                var item = (Product) list.GetItemAtPosition(list.CheckedItemPosition);
                ((MainActivity)Activity).OnSelect(item?.Id);
            };

            return layout;
        }

        public static void RenewValues()
        {
            adapter.Clear();
            adapter.AddAll(ProductService.GetAll());
            adapter.NotifyDataSetChanged();
        }

        public override void OnResume()
        {
            base.OnResume();

            RenewValues();
        }
    }
}