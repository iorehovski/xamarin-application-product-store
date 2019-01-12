using System;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
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
            var lineralLayout = layout.FindViewById<LinearLayout>(Resource.Id.lineralLayoutFragment);


            ListView list = layout.FindViewById<ListView>(Resource.Id.list);

            adapter = new ArrayAdapter<Product>(inflater.Context, Resource.Layout.listItem, ProductService.GetAll());
            list.Adapter = adapter;

            list.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
            {
                var item = (Product) list.GetItemAtPosition(list.CheckedItemPosition);
                ((MainActivity)Activity).OnSelect(item?.Id);
            };

            var imageButton = new Button(inflater.Context);
            imageButton.Text = "some button text inside dynamically button image";
            imageButton.SetBackgroundResource(Resource.Drawable.ic_launcher_round);

            imageButton.Click += (object sender, EventArgs e) =>
            {
                Toast.MakeText(inflater.Context, "some image button text", ToastLength.Long).Show();
            };

            lineralLayout.AddView(imageButton);

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