using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_Project
{
    public class LoadingAdapter : BaseAdapter
    {

        private static List<string> txt_loading = new List<string>() { "Loading..." };
        private static List<int> img = new List<int>() { Resource.Drawable.loading};
        private string State;
        private LayoutInflater layoutInflater;


        private static List<string> txt_empty = new List<string>() { "No Book Was Found!" };
        private static List<int> img_empty = new List<int>() { Resource.Drawable.empty };

        public LoadingAdapter(Context context, string State)
        {

            this.State = State;
            layoutInflater = LayoutInflater.FromContext(context);
        }

        public override int Count => txt_loading.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            convertView = layoutInflater.Inflate(Resource.Layout.Loading_layout, parent, false);


            TextView txt_title = convertView.FindViewById<TextView>(Resource.Id.txt_title);

            ImageView img_book = convertView.FindViewById<ImageView>(Resource.Id.img_book);


            switch (State)
            {

                case "loading":

                    txt_title.Text = $"{txt_loading[position]}";


                    img_book.SetImageResource(img[position]);


                    AnimationManager.LoadingBook(img_book);


                    break;
                case "empty":


                    txt_title.Text = $"{txt_empty[position]}";


                    img_book.SetImageResource(img_empty[position]);


                    break;




            }


            return convertView;
        }
    }
}