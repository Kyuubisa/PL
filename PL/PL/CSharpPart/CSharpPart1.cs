using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PL.CSharpPart
{
    class CSharpPart1 : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.CSharpPart1, container, false);
            Fragment fragment = null;
            var ch1 = (Button)view.FindViewById(Resource.Id.cshp1ch1);
            ch1.Click += (s, e) =>
            {
                fragment = new CSharpPart1Ch1();
            };
            //var ch2 = (Button)view.FindViewById(Resource.Id.cshp1ch2);
            //ch1.Click += (s, e) =>
            //{
            //    fragment = new CSharpPart1Ch2();
            //};
            //var ch3 = (Button)view.FindViewById(Resource.Id.cshp1ch3);
            //ch1.Click += (s, e) =>
            //{
            //    fragment = new CSharpPart1Ch3();
            //};
            return view;
        }
    }
}