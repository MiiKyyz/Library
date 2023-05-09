using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Core.App;
using AndroidX.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Library_Project
{
    public class BookFragment : AndroidX.Fragment.App.Fragment, IDialogInterfaceOnClickListener, IDialogInterfaceOnMultiChoiceClickListener
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        private View view;
        private Button Filter_btn, btn_search, Previuos, next;
        private bool[] check_out;
        private Context context;
        private ListView listView_book;
        private AutoCompleteTextView edit_txt;
        private TextView error_txt_book;
        private int page_count = 1;
        private Bitmap empty_img;
        private string languages;
        private TextView Page_Counter;
        List<string> Languages_selected_temp = new List<string>();
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            view =  inflater.Inflate(Resource.Layout.book_layout, container, false);
            Filter_btn = view.FindViewById<Button>(Resource.Id.Filter_btn);
            btn_search = view.FindViewById<Button>(Resource.Id.btn_search);
            next = view.FindViewById<Button>(Resource.Id.next);
            Previuos = view.FindViewById<Button>(Resource.Id.Previuos);
            Page_Counter = view.FindViewById<TextView>(Resource.Id.Page_Counter);
            error_txt_book = view.FindViewById<TextView>(Resource.Id.error_txt_book);
            empty_img = BitmapFactory.DecodeResource(Resources, Resource.Drawable.empty);
            listView_book = view.FindViewById<ListView>(Resource.Id.listView_book);
            edit_txt = view.FindViewById<AutoCompleteTextView>(Resource.Id.edit_txt);

            ArrayAdapter adapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleSpinnerDropDownItem, Variables.Dictionary_Words);
            edit_txt.Adapter = adapter;



            listView_book.ItemClick += ListView_book_ItemClick;
            btn_search.Click += Btn_search_Click;
            Filter_btn.Click += Filter_btn_Click;
            next.Click += Next_Click;
            Previuos.Click += Previuos_Click;

            next.Enabled = false;
            Previuos.Enabled = false;

            error_txt_book.Alpha = 0f;


            check_out  = new bool[Variables.Languages.Keys.ToArray().Length];

            return view;
        }

        private void Previuos_Click(object sender, EventArgs e)
        {

            _ = Library.Book(Variables.previuos_url, Context, listView_book, edit_txt, error_txt_book, btn_search, next, Previuos, empty_img);


            page_count--;
            Page_Counter.Text = $"Page: {page_count}";
        }

        private void Next_Click(object sender, EventArgs e)
        {
            _ = Library.Book(Variables.next_url, Context, listView_book, edit_txt, error_txt_book, btn_search, next, Previuos, empty_img);

            
            page_count++;
            Page_Counter.Text = $"Page: {page_count}";
        }

        private void ListView_book_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent next_page = new Intent(Context, typeof(DescpBook));
            next_page.PutExtra("position", $"{e.Position}");
            ActivityOptionsCompat anim = ActivityOptionsCompat.MakeSceneTransitionAnimation(Activity, BookAdapter.images.Values.ToArray()[e.Position], ViewCompat.GetTransitionName(BookAdapter.images.Values.ToArray()[e.Position]));
            StartActivity(next_page, anim.ToBundle());

        }

    

        private void Btn_search_Click(object sender, EventArgs e)
        {
            string URL = $"https://gutendex.com/books/?&search={edit_txt.Text}";
            string lang = "";
            if (Languages_selected_temp.Count != 0)
            {

                lang = $"?languages={Variables.Languages_selected}";
                //lang.Remove(lang.Length - 1);
                Log.Info("Length", $"{lang}");
            }
            else
            {

                lang = $"";
                Log.Info("Length", $"{lang}");
            }

     
            error_txt_book.Alpha = 0f;
            if (edit_txt.Text != "")
            {

                page_count = 1;
                Page_Counter.Text = $"Page: {page_count}";
                _ = Library.Book(URL, Context, listView_book, edit_txt, error_txt_book, btn_search, next, Previuos, empty_img);
            }
            else
            {

                error_txt_book.Alpha = 1f;

            }
        }

        private void Filter_btn_Click(object sender, EventArgs e)
        {



            
            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(Context);



            dialog.SetPositiveButton("Select Languages", delegate
            {


                Log.Info("language", $"{Variables.Languages_selected}");
                //Toast.MakeText(Context, languages, ToastLength.Long).Show();
                dialog.Dispose();

            });


            dialog.SetMultiChoiceItems(Variables.Languages.Keys.ToArray(), check_out, this);
            dialog.Create();
            dialog.Show();
        }

        public void OnClick(IDialogInterface dialog, int which)
        {


            
        }
        
        public void OnClick(IDialogInterface dialog, int which, bool isChecked)
        {


            if (isChecked)
            {


                Languages_selected_temp.Add(Variables.Languages.Values.ToArray()[which]);
                
            }
            else
            {

                if (Languages_selected_temp.Contains(Variables.Languages.Values.ToArray()[which]))
                {

                    Languages_selected_temp.RemoveAt(which);

                }


            }

            Variables.Languages_selected = "";

            foreach (var item in Languages_selected_temp)
            {
                Variables.Languages_selected += $"{item},";


            }

            check_out[which] = isChecked;
        }
    }
}