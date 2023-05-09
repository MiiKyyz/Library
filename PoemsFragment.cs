using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_Project
{
    public class PoemsFragment : AndroidX.Fragment.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        private View view;

        private ListView listView;
        private Button btn_search;
        private AutoCompleteTextView edit_txt;
        private Spinner spinner_authors;
        private CheckBox check;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            view = inflater.Inflate(Resource.Layout.poems_quotes_layout, container, false);

            listView = view.FindViewById<ListView>(Resource.Id.listView);

            btn_search = view.FindViewById<Button>(Resource.Id.btn_search);
            edit_txt = view.FindViewById<AutoCompleteTextView>(Resource.Id.edit_txt);
            spinner_authors = view.FindViewById<Spinner>(Resource.Id.spinner_authors);


            ArrayAdapter adapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleSpinnerDropDownItem, Variables.Authors);
            spinner_authors.Adapter = adapter;

            check = view.FindViewById<CheckBox>(Resource.Id.check);

            check.CheckedChange += Check_CheckedChange;

            spinner_authors.Enabled = false;
            edit_txt.Enabled = true;
            spinner_authors.Alpha = 0.5f;



            btn_search.Click += Btn_search_Click;

            return view;
        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
            _=Library.Poems(Context, check, listView, edit_txt, spinner_authors, btn_search);
        }

        private void Check_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {


            if (e.IsChecked)
            {


                spinner_authors.Enabled = true;
                edit_txt.Enabled = false;
                edit_txt.Alpha = 0.5f;
                spinner_authors.Alpha = 1f;
            }
            else
            {
                edit_txt.Alpha = 1f;
                spinner_authors.Alpha = 0.5f;
                spinner_authors.Enabled = false;
                edit_txt.Enabled = true;
            }


        }
    }
}