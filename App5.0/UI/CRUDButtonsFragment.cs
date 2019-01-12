using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using BLL;
using System;

namespace UI
{
    public class CRUDButtonsFragment : Fragment
    {
        public int? chosedId;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            var layout = inflater.Inflate(Resource.Layout.CRUDButtonsFragment, container, true);

            Button insert = layout.FindViewById<Button>(Resource.Id.insert);
            Button update = layout.FindViewById<Button>(Resource.Id.update);
            Button delete = layout.FindViewById<Button>(Resource.Id.delete);

            insert.Click += (object sender, EventArgs e) =>
            {
                Intent intent = new Intent($"{MainFragment.IntentHeader}.insert");

                StartActivity(intent);
            };

            update.Click += (object sender, EventArgs e) =>
            {
                if (chosedId != null)
                {
                    Intent intent = new Intent($"{MainFragment.IntentHeader}.insert");
                    intent.PutExtra(InsertUpdateActivity.IsEditKey, true);
                    intent.PutExtra(InsertUpdateActivity.ValueKey, chosedId.Value);

                    StartActivity(intent);
                }
            };

            delete.Click += (object sender, EventArgs e) =>
            {
                if (chosedId != null)
                {
                    ProductService.Remove(chosedId.Value);
                }
            };

            return layout;
        }

        public void OnSelect(int? newId)
        {
            chosedId = newId;
        }
    }
}