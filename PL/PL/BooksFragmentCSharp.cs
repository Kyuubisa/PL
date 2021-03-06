﻿using System;
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
    class BooksFragmentCSharp : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.frag_books_csharp, container, false);
            Fragment fragment = null;
            Button part1 = (Button)view.FindViewById(Resource.Id.cshp1);
            part1.Click += (s, e) =>
            {
                fragment = new CSharpPart1();
                FragmentManager fm = this.FragmentManager;
                fm.BeginTransaction().Replace(Resource.Id.fragment_container, fragment).Commit();
            };
            return view;
        }
    }
}