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
    public class MeaningsAdapter : BaseAdapter
    {


        List<string> partOfSpeech = new List<string>();
        List<string> definition = new List<string>();
        List<string> example = new List<string>();
        LayoutInflater layoutInflater;
        public MeaningsAdapter(Context context, List<string> partOfSpeech, List<string> definition, List<string> example)
        {

            this.example = example;
            this.definition = definition;
            this.partOfSpeech = partOfSpeech;
            layoutInflater = LayoutInflater.FromContext(context);
        }


        public override int Count => example.Count;

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

            convertView = layoutInflater.Inflate(Resource.Layout.meanings_layout, parent, false);



            TextView partOfSpeech_txt = convertView.FindViewById<TextView>(Resource.Id.partOfSpeech);
            TextView definition_txt = convertView.FindViewById<TextView>(Resource.Id.definition);
            TextView example_txt = convertView.FindViewById<TextView>(Resource.Id.example);

            partOfSpeech_txt.Text = $"part Of Speech: {partOfSpeech[position]}";
            definition_txt.Text = $"definition: {definition[position]}";
            example_txt.Text = $"{example[position]}";

            return convertView; 
        }
    }
}