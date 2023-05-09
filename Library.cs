using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Google.Android.Material.Snackbar;
using Java.Util;
using Newtonsoft.Json.Linq;
using Org.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using static Android.Content.ClipData;

namespace Library_Project
{
    public class Library
    {


        public static List<string> sound_phonetics = new List<string>();
        private static List<string> phonetics_txt = new List<string>();


        public static List<string> partOfSpeech = new List<string>();
        private static List<string> definitions = new List<string>();
        private static List<string> example = new List<string>();
        public static async Task Dictionary(Context context, AutoCompleteTextView edit_txt, TextView error_txt,ListView list_phonetics, ListView meanings_list, TextView Word_txt)
        {
            error_txt.Alpha = 0f;
            JObject word_data = null;

            

            sound_phonetics.Clear();
            phonetics_txt.Clear();
            partOfSpeech.Clear();
            definitions.Clear();
            example.Clear();


            try
            {


                await Task.Run(async () =>
                {

                    while (true)
                    {
                        string URL = $"https://api.dictionaryapi.dev/api/v2/entries/en/{edit_txt.Text}";

                        var handler = new HttpClientHandler();
                        HttpClient client = new HttpClient();
                        string all_data = await client.GetStringAsync(URL);
                        JArray jsonArray = JArray.Parse(all_data);
                        word_data = JObject.Parse(jsonArray[0].ToString());


                        //Log.Info("data", $"{word_data}");


                        foreach (var item in word_data["phonetics"].ToArray())
                        {




                            try
                            {
                                sound_phonetics.Add(item["audio"].ToString());
                                phonetics_txt.Add(item["text"].ToString());
                            }
                            catch
                            {

                                sound_phonetics.Add("");
                                phonetics_txt.Add($"{edit_txt.Text}");
                            }


                        }

                        foreach (var item in word_data["meanings"].ToArray())
                        {


                            //Log.Info("Lengthhhhhhhhhhhhhhhhhhh", $"{item}");







                            foreach (var def in item["definitions"])
                            {

                                

                                try
                                {
                                    


                                    if (def["example"].ToString() != "")
                                    {

                                        example.Add($"example: {def["example"]}");

                                    }
                                    else
                                    {
                                        example.Add("No example!");


                                    }


                                    partOfSpeech.Add(item["partOfSpeech"].ToString());
                                    definitions.Add(def["definition"].ToString());
                                }
                                catch
                                {
                                    partOfSpeech.Add("No part Of Speech");
                                    definitions.Add("No definitions");
                                    example.Add("No example!");
                                }


                            }




                        }

                        break;

                    }


                    //Log.Info("Lengthhhhhhhhhhhhhhhhhhh", $"{word_data["phonetics"].ToArray().Length}");





                });



                if (word_data["meanings"].ToArray().Length != 0)
                {
                    MeaningsAdapter meaningsAdapter = new MeaningsAdapter(context, partOfSpeech, definitions, example);
                    meanings_list.Adapter = meaningsAdapter;

                }
                else
                {
                    MeaningsAdapter meaningsAdapter = new MeaningsAdapter(context, new List<string> { "No Found" }, new List<string> { "No Found" }, new List<string> { "No Found" });
                    meanings_list.Adapter = meaningsAdapter;


                }





                if (word_data["phonetics"].ToArray().Length != 0)
                {

                    PhoneticsAdapter adapter = new PhoneticsAdapter(context, phonetics_txt);

                    list_phonetics.Adapter = adapter;

                }
                else
                {

                    List<string> not = new List<string>() {


                        "No Audio!"



                    };

                    PhoneticsAdapter adapter = new PhoneticsAdapter(context, not);

                    list_phonetics.Adapter = adapter;

                }



            }
            catch(Exception ex)
            {

                //Log.Info("Lengthhhhhhhhhhhhhhhhhhh", $"{ex.Message}");

                error_txt.Alpha = 1f;

                List<string> not = new List<string>() {


                        "Error!"



                    };

                PhoneticsAdapter adapter = new PhoneticsAdapter(context, not);

                list_phonetics.Adapter = adapter;


                MeaningsAdapter meaningsAdapter = new MeaningsAdapter(context, new List<string> { "No Found" }, new List<string> { "No Found" }, new List<string> { "No Found" });
                meanings_list.Adapter = meaningsAdapter;
            }



            Word_txt.Alpha = 1f;
            Word_txt.Text = $"Word: {edit_txt.Text}";
            edit_txt.Text = "";
        }





        public static async Task Short_Stories(TextView moral_txt, TextView story_txt, TextView author_txt, TextView title_txt, Button btn, LinearLayout page)
        {

            btn.Enabled = false;
            AnimationManager.FadeOut_Animation(page, page.Alpha);
            JObject data = null;

            while (true)
            {

                try
                {
                    string URL = $"https://shortstories-api.onrender.com/";
                    var handler = new HttpClientHandler();

                    HttpClient client = new HttpClient();
                    string All_Data = await client.GetStringAsync(URL);



                    data = JObject.Parse(All_Data);
                    moral_txt.Text = $"\n {data["moral"]}";
                    story_txt.Text = $"{data["story"]}";
                    author_txt.Text = $"Author: {data["author"]}";
                    title_txt.Text = $"{data["title"]}";
                    btn.Enabled = true;
                    break;
                }
                catch(Exception ex)
                {

                    moral_txt.Text = $"";
                    story_txt.Text = $"";
                    author_txt.Text = $"";
                    title_txt.Text = $"Error!";
                    //Log.Info("miky", $"{ex.Message}");

                    break;
                }


                
            

            }


            AnimationManager.FadeIn_Animation(page, page.Alpha);


        }



        public static List<string> title = new List<string>();
        public static List<string> read_book = new List<string>();
        public static List<Bitmap> img_book = new List<Bitmap>();


        public static List<string> author = new List<string>();
        public static List<string> birth_year = new List<string>();
        public static List<string> death_year = new List<string>();

        public static async Task Book(string URL,Context context, ListView list, AutoCompleteTextView edit_txt, TextView error_txt_book, Button btn_search, Button next, Button Previuos, Bitmap empty_img)
        {


            title.Clear();
            author.Clear();
            read_book.Clear();
            img_book.Clear();
            birth_year.Clear();
            death_year.Clear();

            btn_search.Enabled = false;
            next.Enabled = false;
            Previuos.Enabled = false;

            edit_txt.Enabled = false;

            error_txt_book.Alpha = 0f;


            //Log.Info("title", books.ToString());
            LoadingAdapter adapter_anim = new LoadingAdapter(context, Variables.loading);
            list.Adapter = adapter_anim;

  


            HttpClient client = new HttpClient();
            string All_Data = await client.GetStringAsync(URL);



            JObject books = JObject.Parse(All_Data);


            Bitmap images_bit = null;


            await Task.Run(() =>
            {

                while (true)
                {

                    foreach (var book in books["results"].ToArray())
                    {



                        //Log.Info("books", book.ToString());


                    

                        try
                        {

                            title.Add(book["title"].ToString());




                        }
                        catch (Exception ex)
                        {
                            //Log.Info("errorrrrrrrrrr", $"{ex.Message}");

                            title.Add("No Title found!");
                        }

                        try
                        {
                            read_book.Add(book["formats"]["text/html"].ToString());
                        }
                        catch (Exception ex)
                        {
                            //Log.Info("errorrrrrrrrrr", $"{ex.Message}");

                            read_book.Add("");
                        }





                        try
                        {
                            images_bit = Variables.URL_IMG(book["formats"]["image/jpeg"].ToString());
                            
                        }
                        catch (Exception ex)
                        {
                            //Log.Info("errorrrrrrrrrr", $"{ex.Message}");

                            images_bit = empty_img;
                        }

                        img_book.Add(images_bit);


                        try
                        {


                            author.Add($"{book["authors"][0]["name"]}");



                        }
                        catch (Exception ex)
                        {
                            //Log.Info("errorrrrrrrrrr", $"{ex.Message}");

                            author.Add($"Author was not found!");
                        }
                        try
                        {
                            birth_year.Add($"{book["authors"][0]["birth_year"]}");

                        }
                        catch (Exception ex)
                        {
                            //Log.Info("errorrrrrrrrrr", $"{ex.Message}");

                            birth_year.Add($"");
                        }
                        try
                        {

                            death_year.Add($"{book["authors"][0]["death_year"]}");




                        }
                        catch (Exception ex)
                        {
                            //Log.Info("errorrrrrrrrrr", $"{ex.Message}");

                            death_year.Add($"");
                        }


                    }
                    break;

                }


            });


            if (title.Count != 0)
            {

                BookAdapter adapter = new BookAdapter(context, title, img_book);
                list.Adapter = adapter;

            }
            else
            {

                LoadingAdapter adapter_empty = new LoadingAdapter(context, Variables.empty);
                list.Adapter = adapter_empty;

            }


            

            if (books["next"].ToString() != "")
            {

                next.Enabled = true;

                Variables.next_url = $"{books["next"]}";
            }
            else
            {
                next.Enabled = false;
                Variables.next_url = "";
            }

           if (books["previous"].ToString() != "")
            {
                Variables.previuos_url = $"{books["previous"]}";
                Previuos.Enabled = true;


            }
            else
            {
                Previuos.Enabled = false;
                Variables.previuos_url = "";
            }

            //Log.Info("nexttttttttttttttttttt", $"{Variables.next_url}");
            btn_search.Enabled = true;
            edit_txt.Text = "";
            edit_txt.Enabled = true;





        }



        private static List<string> content_poem = new List<string>();
        private static List<string> title_poem = new List<string>();
        private static List<string> author_poem = new List<string>();
        public static async Task Poems(Context context, CheckBox check, ListView listView, AutoCompleteTextView edit_txt, Spinner spinner_authors, Button btn_search)
        {

            content_poem.Clear();
            title_poem.Clear();
            author_poem.Clear();
            



            string URL = "";
            btn_search.Enabled = false;
            switch (check.Checked)
            {

                case true:

                    URL = $"https://poetrydb.org/author/{spinner_authors.SelectedItem}";
                   

                    break;
                case false:


                    URL = $"https://poetrydb.org/title/{edit_txt.Text}";


                    break;



            }





            //Log.Info("url", $"{URL}");


            LoadingAdapter adapter_anim = new LoadingAdapter(context, Variables.loading);
            listView.Adapter = adapter_anim;


            await Task.Run(async () =>
            {
                var handler = new HttpClientHandler();
                HttpClient client = new HttpClient(handler);
                string all_data = await client.GetStringAsync(URL);
                JArray jsonArray = JArray.Parse(all_data);
                //JObject data = JObject.Parse(jsonArray.ToString());

                

                while (true)
                 {


                    foreach (var item in jsonArray.ToArray())
                    {

                        
                        string statement = "";
                        foreach (var item2 in item["lines"])
                        {


                            statement += item2;
                        }
                        //Log.Info("statement", $"{statement}");
                        content_poem.Add(statement.ToLower());
                        author_poem.Add(item["author"].ToString());
                        title_poem.Add(item["title"].ToString());
                    }
                    break;
                 }
                 


            });


            PoemAdapter adapter = new PoemAdapter(context, content_poem, author_poem, title_poem);
            listView.Adapter = adapter;
            btn_search.Enabled = true;
            edit_txt.Text = "";



            if (!check.Checked)
            {


                btn_search.Enabled = true;

            }

        }


        static List<string> Author_quote = new List<string>();
        static List<string> Content_quote = new List<string>();
        static  List<string> lenght_list_quote = new List<string>();

        public static async Task Quotes(Context context, Spinner spinner_quote, AutoCompleteTextView edit_quotes, Button btn_quote, ListView list_quote, AutoCompleteTextView num_Edit)
        {

            Author_quote.Clear();
            Content_quote.Clear();
            lenght_list_quote.Clear();

            string URL = "";
            edit_quotes.Enabled = false;
            num_Edit.Enabled = false;
            btn_quote.Enabled = false;
            spinner_quote.Enabled = false;


            LoadingAdapter adapter_anim = new LoadingAdapter(context, Variables.loading);
            list_quote.Adapter = adapter_anim;




            switch (spinner_quote.SelectedItem.ToString())
            {

                case "Search by keyword":

                    URL = $"https://api.quotable.io/quotes/random?limit={num_Edit.Text}?query={edit_quotes.Text}";


                    break;
                case "Search by Author":
                    URL = $"https://api.quotable.io/quotes/random?limit={num_Edit.Text}?author={edit_quotes.Text}";




                    break;
                case "Search by tag":
                    URL = $"https://api.quotable.io/quotes/random?limit={num_Edit.Text}?tags={edit_quotes.Text}";

                    break;


            };

            
            await Task.Run(async () =>
            {

                var handler = new HttpClientHandler();
                HttpClient client = new HttpClient();
                string all_data = await client.GetStringAsync(URL);
                JArray jsonArray = JArray.Parse(all_data);
                var data = JObject.Parse(jsonArray[0].ToString());


                while (true)
                {


                    foreach (var item in jsonArray.ToArray())
                    {


                        try
                        {

                            Author_quote.Add(item["author"].ToString());
                        }
                        catch
                        {
                            Author_quote.Add("None");


                        }
                        try
                        {

                            Content_quote.Add(item["content"].ToString());
                        }
                        catch
                        {

                            Content_quote.Add("None");

                        }
                        try
                        {

                            lenght_list_quote.Add(item["length"].ToString());
                        }
                        catch
                        {

                            lenght_list_quote.Add("None");

                        }

                    }
                    break;
                }
            });

            /*Log.Info("ERRORRRRR!", $"{Content.Count}");
            Log.Info("ERRORRRRR!", $"{Author.Count}");
            Log.Info("ERRORRRRR!", $"{lenght_list.Count}");*/


            
            //QuoteAdapter adapter_quote = new QuoteAdapter(context, tell, tell, tell);
            QuoteAdapter quote_adap = new QuoteAdapter(context, Author_quote, Content_quote, lenght_list_quote);
            //PoemAdapter adapter = new PoemAdapter(context, Author_quote, Content_quote, lenght_list_quote);
            //ArrayAdapter adapter_quote = new ArrayAdapter(context, Android.Resource.Layout.SimpleSpinnerDropDownItem, Author);

            list_quote.Adapter = quote_adap;


            edit_quotes.Text = "";
            num_Edit.Text = "";



            edit_quotes.Enabled = true;
            num_Edit.Enabled = true;
            btn_quote.Enabled = true;
            spinner_quote.Enabled = true;

        }
    }
}