using Android.Support.Design.Widget;
using Android.Views;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System.Threading;
using System.Collections.Generic;
using Android.Support.V7.App;
using System;

namespace PL
{
    public class BooksFragmentCPP : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.frag_books_cplusplus, root: null);
        }
    }
}