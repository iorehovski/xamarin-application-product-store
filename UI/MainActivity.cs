using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Views;
using DAL;
using System.IO;
using Android.Widget;
using BLL;

namespace UI
{
    [Activity(Label = "Products", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private const string Tag = "Main";

        private static string fileName =
            Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "fileName.xml");
        private int? chosedId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Log.Debug(Tag, "Reading");
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

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            
            return true;
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            int id = item.ItemId;
            Intent intent;
            switch (id)
            {
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

        public override void SetContentView(int layoutResourceId)
        {
            base.SetContentView(layoutResourceId);
            var leftMenu = FindViewById<LinearLayout>(Resource.Id.left_drawer);
            var leftMenuView = new NavigationLayout(ApplicationContext, leftMenu);

            leftMenu.AddView(leftMenuView);
        }
    }
}

