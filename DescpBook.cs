using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.Snackbar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Java.Util.Jar.Attributes;

namespace Library_Project
{
    [Activity(Label = "Book Details")]
    public class DescpBook : AppCompatActivity
    {


        private TextView title_descrip, author_decrip;
        private ImageView descrip_img_book;
        private Button btn_read;
        private int position_int;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.descrip_book_layout);
            // Create your application here


            title_descrip = FindViewById<TextView>(Resource.Id.title_descrip);
            author_decrip = FindViewById<TextView>(Resource.Id.author_decrip);
            descrip_img_book = FindViewById<ImageView>(Resource.Id.descrip_img_book);
            btn_read = FindViewById<Button>(Resource.Id.btn_read);

            string position;
            position = Intent.GetStringExtra("position" ?? "not recv");

            position_int = int.Parse(position);


            title_descrip.Text = $"{Library.title[position_int]}";
            author_decrip.Text = $"author: {Library.author[position_int]}\n ({Library.birth_year[position_int]} - {Library.death_year[position_int]})";


            descrip_img_book.SetImageBitmap(Library.img_book[position_int]);


            btn_read.Click += Btn_read_Click;

        }

        private void Btn_read_Click(object sender, EventArgs e)
        {

            try
            {

                var uri = Android.Net.Uri.Parse($"{Library.read_book[position_int]}");

                Intent ConIntent = new Intent(Intent.ActionView, uri);
                StartActivity(ConIntent);

            }
            catch
            {
                View view = (View)sender;
                Snackbar.Make(view, "There is no Content", Snackbar.LengthLong)
                    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();


            }



        }
    }
}