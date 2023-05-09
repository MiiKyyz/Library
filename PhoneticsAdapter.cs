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
    public class PhoneticsAdapter : BaseAdapter
    {



        private List<string> txt_phonetics = new List<string>();
        private LayoutInflater layoutInflater;
        public PhoneticsAdapter(Context context, List<string> txt_phonetics)
        {
            layoutInflater = LayoutInflater.FromContext(context);
            this.txt_phonetics = txt_phonetics;
        }



        public override int Count => txt_phonetics.Count;

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

            convertView = layoutInflater.Inflate(Resource.Layout.phonetics_layout, parent, false);

            TextView txt = convertView.FindViewById<TextView>(Resource.Id.txt_pron);


            txt.Text = $"{txt_phonetics[position]}";



            return convertView;
        }
    }
}