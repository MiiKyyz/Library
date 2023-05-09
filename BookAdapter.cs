using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.CardView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_Project
{
    public class BookAdapter : BaseAdapter
    {


        private List<string> title = new List<string>();
        private List<Bitmap> img_book = new List<Bitmap>();
        private LayoutInflater layoutInflater;
        public static Dictionary<int, CardView> images = new Dictionary<int, CardView>();


        public BookAdapter(Context context, List<string> title, List<Bitmap> img_book)
        {

            this.title = title;
            this.img_book = img_book;
            layoutInflater = LayoutInflater.FromContext(context);
        }




        public override int Count => title.Count;

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

            convertView = layoutInflater.Inflate(Resource.Layout.book_adapter, parent, false);


            TextView txt_title = convertView.FindViewById<TextView>(Resource.Id.txt_title);
            ImageView img_book_panel = convertView.FindViewById<ImageView>(Resource.Id.img_book);

            CardView card_book = convertView.FindViewById<CardView>(Resource.Id.card_book);

            txt_title.Text = $"{title[position]}";

            img_book_panel.SetImageBitmap(img_book[position]);

            images[position] = card_book;


            return convertView;
        }
    }
}