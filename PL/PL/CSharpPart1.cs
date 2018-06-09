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

namespace PL
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
            var ch1 = (Button)view.FindViewById(Resource.Id.cshp1c1);
            var ch2 = (Button)view.FindViewById(Resource.Id.cshp1c2);
            var ch3 = (Button)view.FindViewById(Resource.Id.cshp1c3);
            ch1.Click += (s, e) =>
            {
                fragment = new CSharpPart1Ch1();
                FragmentManager fm = this.FragmentManager;
                fm.BeginTransaction().Replace(Resource.Id.fragment_container, fragment).Commit();
            };
            ch2.Click += (s, e) =>
            {
               // fragment = new CSharpPart1();
            };
            ch3.Click += (s, e) =>
            {
               // fragment = new CSharpPart1();
            };
            return view;
        }
    }
}