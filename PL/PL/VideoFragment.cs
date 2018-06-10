using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Views;
using HtmlAgilityPack;
using static Android.App.ActionBar;

namespace PL
{
    class VideoFragment : Fragment
    {
        public List<VideoFragment> list = new List<VideoFragment>();
        public List<Url> list1 = new List<Url>();
        public List<Link> list2 = new List<Link>();
        public string image;
        public void YouTube()
        {
            try
            {
                HttpWebRequest NewsPars;
                HttpWebResponse response;
                HtmlDocument htmlDocument = new HtmlDocument();
                string url = "https://www.youtube.com/user/PlurrimiTube/videos?disable_polymer=1";
                NewsPars = (HttpWebRequest)WebRequest.Create(url);
                response = (HttpWebResponse)NewsPars.GetResponse();
                htmlDocument.Load(response.GetResponseStream(), Encoding.UTF8);

                var NewsHtml = htmlDocument.DocumentNode.Descendants("div").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "branded-page-v2-body branded-page-v2-primary-column-content");
                for (int i = 0; i < NewsHtml.ChildNodes.Count; i++)
                {
                    if (NewsHtml.ChildNodes[i].Name == "ul")
                    {
                        for (int j = 2; j < NewsHtml.ChildNodes[i].ChildNodes.Count; j++)
                        {
                            if (NewsHtml.ChildNodes[i].ChildNodes[j].Name == "li")
                            {
                                for (int l = 0; l < NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes.Count; l++)
                                {
                                    if (NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].Name == "ul")
                                    {
                                        for (int k = 0; k < NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes.Count; k++)
                                        {
                                            if (NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].Name == "li")
                                            {
                                                for (int e = 0; e < NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes.Count; e++)
                                                {
                                                    if (NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[e].Name == "div")
                                                    {
                                                        for (int h = 0; h < NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[e].ChildNodes.Count; h++)
                                                        {
                                                            if (NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[e].ChildNodes[h].Name == "div")
                                                            {
                                                                for (int x = 0; x < NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[e].ChildNodes[h].ChildNodes.Count; x++)
                                                                {
                                                                    for (int f = 0; f < NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[e].ChildNodes[h].ChildNodes[x].ChildNodes.Count; f++)
                                                                    {
                                                                        if (NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[e].ChildNodes[h].ChildNodes[x].ChildNodes[f].Name == "span")
                                                                        {
                                                                            for (int d = 0; d < NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[e].ChildNodes[h].ChildNodes[x].ChildNodes[f].ChildNodes.Count; d++)
                                                                            {
                                                                                if (NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[e].ChildNodes[h].ChildNodes[x].ChildNodes[f].ChildNodes[d].Name == "a")
                                                                                {
                                                                                    var image_url = NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[e].ChildNodes[h].ChildNodes[x].ChildNodes[f].ChildNodes[d].ChildNodes[1].ChildNodes[1].ChildNodes[1].ChildNodes[1].Attributes["src"].Value;
                                                                                    list.Add(new VideoFragment { image = image_url });
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }

                                                            }
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                for (int i = 0; i < NewsHtml.ChildNodes.Count; i++)
                {
                    if (NewsHtml.ChildNodes[i].Name == "ul")
                    {
                        for (int j = 2; j < NewsHtml.ChildNodes[i].ChildNodes.Count; j++)
                        {
                            if (NewsHtml.ChildNodes[i].ChildNodes[j].Name == "li")
                            {
                                for (int l = 0; l < NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes.Count; l++)
                                {
                                    if (NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].Name == "ul")
                                    {
                                        for (int k = 0; k < NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes.Count; k++)
                                        {
                                            if (NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].Name == "li")
                                            {
                                                for (int a = 0; a < NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes.Count; a++)
                                                {
                                                    if (NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[a].Name == "div")
                                                    {
                                                        for (int e = 0; e < NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[a].ChildNodes.Count; e++)
                                                        {
                                                            if (NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[a].ChildNodes[a].Name == "div")
                                                            {
                                                                for (int t = 2; t < NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[a].ChildNodes[e].ChildNodes.Count; t++)
                                                                {
                                                                    if (NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[a].ChildNodes[e].ChildNodes[t].Name == "div")
                                                                    {
                                                                        var text = NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[a].ChildNodes[e].ChildNodes[t].ChildNodes[1].ChildNodes[0].InnerText.Trim(); ;
                                                                        list1.Add(new Url { name_video_pars = text });
                                                                    }
                                                                }
                                                            }

                                                        }

                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                NewsPars = (HttpWebRequest)WebRequest.Create(url);
                response = (HttpWebResponse)NewsPars.GetResponse();
                htmlDocument.Load(response.GetResponseStream(), Encoding.UTF8);
                var NewsHtml1 = htmlDocument.DocumentNode.Descendants("div").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "branded-page-v2-body branded-page-v2-primary-column-content");
                for (int i = 0; i < NewsHtml1.ChildNodes.Count; i++)
                {
                    if (NewsHtml1.ChildNodes[i].Name == "ul")
                    {
                        for (int j = 2; j < NewsHtml1.ChildNodes[i].ChildNodes.Count; j++)
                        {
                            if (NewsHtml1.ChildNodes[i].ChildNodes[j].Name == "li")
                            {
                                for (int l = 0; l < NewsHtml1.ChildNodes[i].ChildNodes[j].ChildNodes.Count; l++)
                                {
                                    if (NewsHtml1.ChildNodes[i].ChildNodes[j].ChildNodes[l].Name == "ul")
                                    {
                                        for (int k = 0; k < NewsHtml1.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes.Count; k++)
                                        {
                                            if (NewsHtml1.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].Name == "li")
                                            {
                                                for (int a = 0; a < NewsHtml1.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes.Count; a++)
                                                {
                                                    if (NewsHtml1.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[a].Name == "div")
                                                    {
                                                        for (int e = 0; e < NewsHtml1.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[a].ChildNodes.Count; e++)
                                                        {
                                                            if (NewsHtml1.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[a].ChildNodes[a].Name == "div")
                                                            {
                                                                for (int t = 0; t < NewsHtml1.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[a].ChildNodes[e].ChildNodes.Count; t++)
                                                                {
                                                                    if (NewsHtml1.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[a].ChildNodes[e].ChildNodes[t].Name == "div")
                                                                    {
                                                                        var Link = NewsHtml1.ChildNodes[i].ChildNodes[j].ChildNodes[l].ChildNodes[k].ChildNodes[a].ChildNodes[e].ChildNodes[t].ChildNodes[1].ChildNodes[0].Attributes["href"].Value; ;
                                                                        list2.Add(new Link { Link_video = Link });
                                                                    }
                                                                }
                                                            }

                                                        }

                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
                catch (System.Net.WebException)
            {
                try
                {
                    Android.Support.V7.App.AlertDialog.Builder builder = new Android.Support.V7.App.AlertDialog.Builder(Context);
                    builder
                    .SetTitle("Ошибка")
                    .SetMessage("Отсутствует интернет соединение.");
                    builder.Show();
                }
                catch { }

            }

        }
        
        //ошибка интернета
        //try
        //{ }
        //catch (System.Net.WebException)
        //{
        //    try
        //    {
        //        Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(Context);
        //        builder.SetTitle("Ошибка!").SetMessage("Отсутствует интернет соединение!").SetCancelable(true);
        //        Android.App.AlertDialog alert = builder.Create();
        //        alert.Show();
        //        Thread.ResetAbort();
        //    }
        //    catch { }
        //}

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.frag_video, container, false);
            
            YouTube();

            ImageService.Instance.Initialize();

            var linearLayout = (LinearLayout)view.FindViewById(Resource.Id.lin);

            int j = 0;
            for (int i = 0; i < 30; i++)
            {
                CardView cardView = new CardView(inflater.Context);
                LayoutParams layoutParams = new LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
                linearLayout.AddView(cardView, layoutParams);
                TableLayout linear = new TableLayout(inflater.Context);
                cardView.AddView(linear, layoutParams);
                ImageViewAsync imageView = new ImageViewAsync(inflater.Context);
                imageView.LayoutParameters = new LinearLayout.LayoutParams(500, 500);
                LayoutParams imageParams = new LayoutParams(LayoutParams.MatchParent, 1000);
                ImageService.Instance.LoadUrl(list[i].image).Into(imageView);
                linear.AddView(imageView,imageParams);
                TextView textView = new TextView(inflater.Context);
                string text = list1[i].name_video_pars;
                textView.TextSize = 18;
                textView.Text = text;
                linear.AddView(textView, layoutParams);
                string url = list2[j].Link_video;
                    imageView.Click += (s, e) =>
                    {
                        var uri = Android.Net.Uri.Parse("https://www.youtube.com" + url);
                        var intent = new Intent(Intent.ActionView, uri);
                        StartActivity(intent);
                    };
                j += 2;
            }
            return view;
        }
    }
}