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

            var definedName = view.FindViewById<Button>(Resource.Id.button_name);
            var definedNameAndPrice = view.FindViewById<Button>(Resource.Id.button_name_price);
            var definedShelfLife = view.FindViewById<Button>(Resource.Id.button_shelf_life);
            var definedProducer = view.FindViewById<Button>(Resource.Id.button_producer);
            var definedOnStock = view.FindViewById<Button>(Resource.Id.button_onStock);

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

            definedProducer.Click += (sender, args) =>
            {
                var intent = new Intent($"{MainFragment.IntentHeader}.DefinedProducer");
                intent.AddFlags(ActivityFlags.NewTask);
                context.StartActivity(intent);
            };

            definedOnStock.Click += (sender, args) =>
            {
                var intent = new Intent($"{MainFragment.IntentHeader}.DefinedOnStock");
                intent.AddFlags(ActivityFlags.NewTask);
                context.StartActivity(intent);
            };
        }
    }
}