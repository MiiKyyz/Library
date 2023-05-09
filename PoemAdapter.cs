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
    public class PoemAdapter : BaseAdapter
    {



        private List<string> poems_list = new List<string>();
        private List<string> author_list = new List<string>();
        private List<string> title_list = new List<string>();
        private LayoutInflater LayoutInflater;
        public PoemAdapter(Context context , List<string> poems_list, List<string> author_list, List<string> title_list)
        {
            this.author_list = author_list;
            this.title_list = title_list;
            this.poems_list = poems_list;
            LayoutInflater = LayoutInflater.FromContext(context);

        }



        public override int Count => poems_list.Count;

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


            convertView = LayoutInflater.Inflate(Resource.Layout.poem_adapter, parent, false);



            TextView poem_content = convertView.FindViewById<TextView>(Resource.Id.poem_content);
            TextView title_author = convertView.FindViewById<TextView>(Resource.Id.title_author);
            TextView author_txt = convertView.FindViewById<TextView>(Resource.Id.author_txt);

            poem_content.Text = $"{poems_list[position]}";
            title_author.Text = $"{title_list[position]}";
            author_txt.Text = $"{author_list[position]}";



            return convertView;
        }
    }
}