using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Library_Project
{
    public class Variables
    {
        public static string loading = "loading";
        public static string empty = "empty";
        public static string next_url = "";
        public static string previuos_url = "";
        public static string Languages_selected;
        public static AutoCompleteTextView edit_txt;

        public static Dictionary<string, string> Languages = new Dictionary<string, string>()
        {
            {"English", "en" },
            {"French", "fr" },
            {"Finnish", "fi" },
            {"Buriat (Russia)", "bxr" },
            {"Catalan","ca" },
            {"German","de" },
            {"Spanish","es" },
            {"Hindi","hi" },
            {"Javanese","jv" },
            {"Kannada","kn" },
            {"Korean","ko" },
            {"Nepali","ne" },
            {"Portuguese","pt" },
            {"Russian","ru" },
            {"Chinese","zh" },
            {"Arabic","ar" },
            {"Egyptian Arabic","arz" },
            {"Bulgarian","bg" }

        };



        public static List<string> Authors = new List<string> 
        {
            "Adam Lindsay Gordon",
            "Alan Seeger",
            "Alexander Pope",
            "Algernon Charles Swinburne",
            "Ambrose Bierce",
            "Amy Levy",
            "Andrew Marvell",
            "Ann Taylor",
            "Anne Bradstreet",
            "Anne Bronte",
            "Anne Killigrew",
            "Anne Kingsmill Finch",
            "Annie Louisa Walker",
            "Arthur Hugh Clough",
            "Ben Jonson",
            "Charles Kingsley",
            "Charles Sorley",
            "Charlotte Bronte",
            "Charlotte Smith",
            "Christina Rossetti",
            "Christopher Marlowe",
            "Christopher Smart",
            "Coventry Patmore",
            "Edgar Allan Poe",
            "Edmund Spenser",
            "Edward Fitzgerald",
            "Edward Lear",
            "Edward Taylor",
            "Edward Thomas",
            "Eliza Cook",
            "Elizabeth Barrett Browning",
            "Emily Bronte",
            "Emily Dickinson",
            "Emma Lazarus",
            "Ernest Dowson",
            "Eugene Field",
            "Francis Thompson",
            "Geoffrey Chaucer",
            "George Eliot",
            "George Gordon, Lord Byron",
            "George Herbert",
            "George Meredith",
            "Gerard Manley Hopkins",
            "Helen Hunt Jackson",
            "Henry David Thoreau",
            "Henry Vaughan",
            "Henry Wadsworth Longfellow",
            "Hugh Henry Brackenridge",
            "Isaac Watts",
            "James Henry Leigh Hunt",
            "James Thomson",
            "James Whitcomb Riley",
            "Jane Austen",
            "Jane Taylor",
            "John Clare",
            "John Donne",
            "John Dryden",
            "John Greenleaf Whittier",
            "John Keats",
            "John McCrae",
            "John Milton",
            "John Trumbull",
            "John Wilmot",
            "Jonathan Swift",
            "Joseph Warton",
            "Joyce Kilmer",
            "Julia Ward Howe",
            "Jupiter Hammon",
            "Katherine Philips",
            "Lady Mary Chudleigh",
            "Lewis Carroll",
            "Lord Alfred Tennyson",
            "Louisa May Alcott",
            "Major Henry Livingston, Jr.",
            "Mark Twain",
            "Mary Elizabeth Coleridge",
            "Matthew Arnold",
            "Matthew Prior",
            "Michael Drayton",
            "Oliver Goldsmith",
            "Oliver Wendell Holmes",
            "Oscar Wilde",
            "Paul Laurence Dunbar",
            "Percy Bysshe Shelley",
            "Philip Freneau",
            "Phillis Wheatley",
            "Ralph Waldo Emerson",
            "Richard Crashaw",
            "Richard Lovelace",
            "Robert Browning",
            "Robert Burns",
            "Robert Herrick",
            "Robert Louis Stevenson",
            "Robert Southey",
            "Robinson",
            "Rupert Brooke",
            "Samuel Coleridge",
            "Samuel Johnson",
            "Sarah Flower Adams",
            "Sidney Lanier",
            "Sir John Suckling",
            "Sir Philip Sidney",
            "Sir Thomas Wyatt",
            "Sir Walter Raleigh",
            "Sir Walter Scott",
            "Stephen Crane",
            "Thomas Campbell",
            "Thomas Chatterton",
            "Thomas Flatman",
            "Thomas Gray",
            "Thomas Hood",
            "Thomas Moore",
            "Thomas Warton",
            "Walt Whitman",
            "Walter Savage Landor",
            "Wilfred Owen",
            "William Allingham",
            "William Barnes",
            "William Blake",
            "William Browne",
            "William Cowper",
            "William Cullen Bryant",
            "William Ernest Henley",
            "William Lisle Bowles",
            "William Morris",
            "William Shakespeare",
            "William Topaz McGonagall",
            "William Vaughn Moody",
            "William Wordsworth"
        };


        public static List<string> quotes_tupes = new List<string>() 
        { 

            "Select Searcher type",
            "Search by Author",
            "Search by tag",
            "Search by keyword"
        
        };

        public static List<string> Authors_quotes = new List<string>();
        public static List<string> nouns_quotes = new List<string>();
        public static List<string> Dictionary_Words = new List<string>();


        public static Bitmap URL_IMG(string url)
        {
            while(true)
            {

                using (WebClient webClient = new WebClient())
                {
                    byte[] bytes = webClient.DownloadData(url);
                    if (bytes != null && bytes.Length > 0)
                    {
                        return BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
                    }
                }
                break;
            }
            return null;
        }


    }
}