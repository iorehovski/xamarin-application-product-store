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
        private ArrayAdapter<Product> adapter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            var layout = inflater.Inflate(Resource.Layout.MainFragment, container, false);

            Button button = layout.FindViewById<Button>(Resource.Id.button);
            ListView list = layout.FindViewById<ListView>(Resource.Id.list);

            adapter = new ArrayAdapter<Product>(inflater.Context, Resource.Layout.listItem, ProductService.GetAll());
            list.Adapter = adapter;

            button.Click += (object sender, EventArgs e) =>
            {
                Intent intent = new Intent(IntentHeader);
                Intent chooser = Intent.CreateChooser(intent, "Choose activity");

                // запуск activity
                StartActivity(chooser);
            };

            list.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
            {
                var fragment = FragmentManager.FindFragmentById<CRUDButtonsFragment>(Resource.Id.CRUDFragment);

                var item = (Product)list.GetItemAtPosition(list.CheckedItemPosition);
                fragment.OnSelect(item?.Id);
            };

            return layout;
        }

        public override void OnResume()
        {
            base.OnResume();

            adapter.Clear();
            adapter.AddAll(ProductService.GetAll());
            adapter.NotifyDataSetChanged();
        }
    }
}