using Android.Animation;
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
    public class AnimationManager
    {

        private static ObjectAnimator anim;
        public static void FadeIn_Animation(LinearLayout page, float alpha)
        {
            anim = ObjectAnimator.OfFloat(page, "alpha", alpha, 1f);
            anim.SetDuration(500);
            anim.Start();

        }
        public static void FadeOut_Animation(LinearLayout page, float alpha)
        {
            anim = ObjectAnimator.OfFloat(page, "alpha", alpha, 0f);
            anim.SetDuration(500);
            anim.Start();

        }




        public static void LoadingBook(ImageView page)
        {
            anim = ObjectAnimator.OfFloat(page, "rotationY", 0, 360);
            anim.SetDuration(900);
            anim.RepeatCount = (int)MathF.Pow(10, 5);
            anim.Start();

        }


    }
}