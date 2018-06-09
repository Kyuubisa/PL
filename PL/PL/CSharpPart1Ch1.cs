using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Java.IO;
using Firebase.Database;
using Java.Util;

namespace PL
{
    class CSharpPart1Ch1 : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.CSharpPart1Ch1, container, false);
            var tableLayout = (TableLayout)view.FindViewById(Resource.Id.cshp1c1text);
            TextView textView = new TextView(inflater.Context);
            string txt = "";
            textView.Text = txt;
            tableLayout.AddView(textView);
            return view;
        }
    }
}