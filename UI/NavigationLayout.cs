using Android.Content;
using Android.Views;
using Android.Widget;

namespace UI
{
    public class NavigationLayout : LinearLayout
    {
        public NavigationLayout(Context context, LinearLayout parrent) : base(context)
        {
            Initialize(context, parrent);
        }

        private void Initialize(Context context, LinearLayout parrent)
        {
            var view = LayoutInflater.From(context).Inflate(Resource.Layout.LeftMenuLayout, parrent, true);

            var definedName = view.FindViewById<TextView>(Resource.Id.DefinedNameItem);
            var definedNameAndPrice = view.FindViewById<TextView>(Resource.Id.DefinedNameAndPriceItem);
            var definedShelfLife = view.FindViewById<TextView>(Resource.Id.DefinedShelfLifeItem);

            definedName.Click += (sender, args) =>
            {
                var intent = new Intent($"{MainFragment.IntentHeader}.DefinedName");
                intent.AddFlags(ActivityFlags.NewTask);
                context.StartActivity(intent);
            };

            definedNameAndPrice.Click += (sender, args) =>
            {
                var intent = new Intent($"{MainFragment.IntentHeader}.DefinedNameAndPrice");
                intent.AddFlags(ActivityFlags.NewTask);
                context.StartActivity(intent);
            };

            definedShelfLife.Click += (sender, args) =>
            {
                var intent = new Intent($"{MainFragment.IntentHeader}.DefinedShelfLife");
                intent.AddFlags(ActivityFlags.NewTask);
                context.StartActivity(intent);
            };
        }
    }
}