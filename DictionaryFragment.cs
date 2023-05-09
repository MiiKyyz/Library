using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stream = Android.Media.Stream;

namespace Library_Project
{
    public class DictionaryFragment : AndroidX.Fragment.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        private View view;
        private Button btn_search;
        private TextView error_txt_id, Word_txt;
        private ListView meanings_list, phonetics_list;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            view =  inflater.Inflate(Resource.Layout.dictionary_layout, container, false);
            btn_search = view.FindViewById<Button>(Resource.Id.btn_search);
            Variables.edit_txt = view.FindViewById<AutoCompleteTextView>(Resource.Id.edit_txt);
            error_txt_id = view.FindViewById<TextView>(Resource.Id.error_txt_id);
            Word_txt = view.FindViewById<TextView>(Resource.Id.Word_txt);
            meanings_list = view.FindViewById<ListView>(Resource.Id.meanings_list);
            phonetics_list = view.FindViewById<ListView>(Resource.Id.phonetics_list);



            ArrayAdapter adapter_word = new ArrayAdapter(Context, Android.Resource.Layout.SimpleSpinnerDropDownItem, Variables.nouns_quotes);
            Variables.edit_txt.Adapter = adapter_word;


            Word_txt.Alpha = 0f;
            error_txt_id.Alpha = 0f;

            btn_search.Click += Btn_search_Click;
            phonetics_list.ItemClick += Phonetics_list_ItemClick;


            return view;
        }

        private void Phonetics_list_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            try
            {
                MediaPlayer player = new MediaPlayer();

                player.SetAudioStreamType(Stream.Music);
                player.SetDataSource($"{Library.sound_phonetics[e.Position]}");
                player.Prepare();
                player.Start();

            }
            catch
            {
                Toast.MakeText(Context, "no audio", ToastLength.Short).Show();

            }

           

        }

        private void Btn_search_Click(object sender, EventArgs e)
        {


            if(Variables.edit_txt.Text != "")
            {

                _ = Library.Dictionary(Context, Variables.edit_txt, error_txt_id, phonetics_list, meanings_list, Word_txt);


            }
            else
            {

                Toast.MakeText(Context, "No Word was written!", ToastLength.Short).Show();

            }



        }
    }
}