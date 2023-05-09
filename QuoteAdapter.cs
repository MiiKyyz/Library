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
    public class QuoteAdapter : BaseAdapter
    {


        private List<string> Author = new List<string>();
        private List<string> Content = new List<string>();
        private List<string> lenght_list = new List<string>();
        private LayoutInflater LayoutInflater;
        public QuoteAdapter(Context context, List<string> Author, List<string> Content, List<string> lenght_list)
        {

            
            this.Author = Author;
            this.Content = Content;
            this.lenght_list = lenght_list;
            LayoutInflater = LayoutInflater.FromContext(context);
        }


        public override int Count => Author.Count;

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


            convertView = LayoutInflater.Inflate(Resource.Layout.quote_adapter_layout, parent, false);


            TextView Author_quote = convertView.FindViewById<TextView>(Resource.Id.Author_quote);
            TextView Content_Quote = convertView.FindViewById<TextView>(Resource.Id.Content_Quote);
            TextView lenth_num = convertView.FindViewById<TextView>(Resource.Id.lenth_num);


            Author_quote.Text = $"{Author[position]}";
            Content_Quote.Text = $"{Content[position]}";
            lenth_num.Text = $"{lenght_list[position]}";


            return convertView;
        }
    }
}