using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Org.Apache.Http.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;

namespace Library_Project
{
    public class QuotesFragment : AndroidX.Fragment.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        private View view;
        private Spinner spinner_quote;
        private AutoCompleteTextView edit_quotes, num_Edit;
        private Button btn_quote;
        private ListView list_quote_view;
        private ArrayAdapter adapter;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            view = inflater.Inflate(Resource.Layout.quotes_layout, container, false);


            spinner_quote = view.FindViewById<Spinner>(Resource.Id.spinner_quote);
            edit_quotes = view.FindViewById<AutoCompleteTextView>(Resource.Id.edit_quotes);
            num_Edit = view.FindViewById<AutoCompleteTextView>(Resource.Id.num_Edit);
            btn_quote = view.FindViewById<Button>(Resource.Id.btn_quote);
            list_quote_view = view.FindViewById<ListView>(Resource.Id.list_quote_view);


          

            ArrayAdapter adapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleSpinnerDropDownItem, Variables.quotes_tupes);
            spinner_quote.Adapter = adapter;
            spinner_quote.ItemSelected += Spinner_quote_ItemSelected;
            btn_quote.Click += Btn_quote_Click;


  

            return view;
        }

        private void Spinner_quote_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            switch (Variables.quotes_tupes[e.Position])
            {

                case "Search by keyword":

                    edit_quotes.Hint = "Keyword";
                    adapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleSpinnerDropDownItem, Variables.nouns_quotes);
                    edit_quotes.Adapter = adapter;

                    break;
                case "Search by Author":

                    edit_quotes.Hint = "Author";
                    adapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleSpinnerDropDownItem, Variables.Authors_quotes);
                    edit_quotes.Adapter = adapter;
                    break;
                case "Search by tag":
                    adapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleSpinnerDropDownItem, Variables.nouns_quotes);
                    edit_quotes.Adapter = adapter;
                    edit_quotes.Hint = "Tag";

                    break;



            }



        }

        private void Btn_quote_Click(object sender, EventArgs e)
        {


            if(edit_quotes.Text == "")
            {
                Toast.MakeText(Context, "Input Text Empty", ToastLength.Long).Show();

            }
            else if (num_Edit.Text == "")
            {
                //int.Parse(num_Edit.Text) <= 0
                Toast.MakeText(Context, "Number Box is Empty", ToastLength.Long).Show();

           
            
                

            }else if (int.Parse(num_Edit.Text) == 0)
            {

                Toast.MakeText(Context, "it cannot equal 0", ToastLength.Long).Show();

       

            }else if (spinner_quote.SelectedItem.ToString() == "Select Searcher type")
            {


                Toast.MakeText(Context, "Select Search Type", ToastLength.Long).Show();

            }
            else
            {

                _ = Library.Quotes(Context, spinner_quote, edit_quotes, btn_quote, list_quote_view, num_Edit);

             
            }





        }
    }
}