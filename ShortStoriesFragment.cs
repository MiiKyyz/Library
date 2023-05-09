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
    public class ShortStoriesFragment : AndroidX.Fragment.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        private View view;
        private Button btn_Search;
        private TextView moral_txt, story_txt, author_txt, title_txt;
        private LinearLayout Page;



        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            view = inflater.Inflate(Resource.Layout.short_stories_layout, container, false);


            btn_Search = view.FindViewById<Button>(Resource.Id.btn_Search);
            moral_txt = view.FindViewById<TextView>(Resource.Id.moral_txt);
            story_txt = view.FindViewById<TextView>(Resource.Id.story_txt);
            author_txt = view.FindViewById<TextView>(Resource.Id.author_txt);
            title_txt = view.FindViewById<TextView>(Resource.Id.title_txt);
            Page = view.FindViewById<LinearLayout>(Resource.Id.Page);


            //Page.Alpha = 0f;

            btn_Search.Click += Btn_Search_Click;

            return view;
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            _=Library.Short_Stories(moral_txt, story_txt, author_txt, title_txt, btn_Search, Page);
        }
    }
}