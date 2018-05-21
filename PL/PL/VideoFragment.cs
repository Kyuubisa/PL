using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using HtmlAgilityPack;

namespace PL
{
    public class VideoFragment : Fragment
    {
        VideoFragment videoFragment;
        public List<VideoFragment> list = new List<VideoFragment>();
        public string image;
        public void YouTube()
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
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.frag_video, container, false);

            YouTube();
            ImageService.Instance.Initialize();
            var parsing = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing);
                ImageService.Instance.LoadUrl(list[0].image).Into(parsing);
            var parsing2 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing2);
            ImageService.Instance.LoadUrl(list[1].image).Into(parsing2);
            var parsing3 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing3);
            ImageService.Instance.LoadUrl(list[2].image).Into(parsing3);
            return view;
        }
        
        private Bitmap GetImageBitmapFromUrlAsync(string url)
        {

            Bitmap imageBitmap = null;
            try
            {
                Task.Run(async () =>
                {
                    using (var httpClient = new System.Net.Http.HttpClient())
                    {
                        byte[] imageBytes = await httpClient.GetByteArrayAsync(url);
                        if (imageBytes != null && imageBytes.Length > 0)
                        {
                            imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                        }
                    }
                });

            }
            catch
            { }
            return imageBitmap;
        }
    }
}