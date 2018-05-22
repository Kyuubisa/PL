using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using HtmlAgilityPack;

namespace PL
{
    class VideoFragment : Fragment
    {

        VideoFragment videoFragment;
        public List<VideoFragment> list = new List<VideoFragment>();
        public List<Url> list1 = new List<Url>();
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
            for (int i = 0; i < NewsHtml.ChildNodes.Count; i++)
            {
                if (NewsHtml.ChildNodes[i].Name == "ul")
                {
                    for (int j = 2; j < NewsHtml.ChildNodes[i].ChildNodes.Count; j++)
                    {
                        if (NewsHtml.ChildNodes[i].ChildNodes[j].Name == "li")
                        {
                            for (int l = 0; l < NewsHtml.ChildNodes[i].ChildNodes[j].ChildNodes.Count; l++)
                            {//Стоп
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
        }
        //ошибка интернета
        //try
        //{
        //catch (System.Net.WebException)
        //{
        //    try
        //    {
        //        Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(Context);
        //builder.SetTitle("Ошибка!").SetMessage("Отсутствует интернет соединение!").SetCancelable(true);
        //Android.App.AlertDialog alert = builder.Create();
        //alert.Show();
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
            string text = list1[0].name_video_pars;
            var t = view.FindViewById<TextView>(Resource.Id.Name_video1);
            t.Text = text;
            var parsing = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing);
            ImageService.Instance.LoadUrl(list[0].image).Into(parsing);

            //string text1 = list1[1].name_video_pars;
            //var t1 = view.FindViewById<TextView>(Resource.Id.Name_video2);
            //var parsing2 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing2);
            //ImageService.Instance.LoadUrl(list[1].image).Into(parsing2);
            //
            //t1.Text = text;
            //string text3 = list1[1].name_video_pars;
            //var t3 = view.FindViewById<TextView>(Resource.Id.Name_video3);
            //t3.Text = text;

            //string text4 = list1[1].name_video_pars;
            //var t4 = view.FindViewById<TextView>(Resource.Id.Name_video4);
            //t1.Text = text;
            //var parsing = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing);
            //ImageService.Instance.LoadUrl(list[0].image).Into(parsing);
            //var parsing2 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing2);
            //ImageService.Instance.LoadUrl(list[1].image).Into(parsing2);
            //var parsing3 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing3);
            //ImageService.Instance.LoadUrl(list[2].image).Into(parsing3);
            ////
            //var parsing4 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing4);
            //ImageService.Instance.LoadUrl(list[3].image).Into(parsing4);
            //var parsing5 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing5);
            //ImageService.Instance.LoadUrl(list[4].image).Into(parsing5);
            //var parsing6 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing6);
            //ImageService.Instance.LoadUrl(list[5].image).Into(parsing6);
            ////
            //var parsing7 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing7);
            //ImageService.Instance.LoadUrl(list[6].image).Into(parsing7);
            //var parsing8 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing8);
            //ImageService.Instance.LoadUrl(list[7].image).Into(parsing8);
            //var parsing9 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing9);
            //ImageService.Instance.LoadUrl(list[8].image).Into(parsing9);
            ////
            //var parsing10 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing10);
            //ImageService.Instance.LoadUrl(list[9].image).Into(parsing10);
            //var parsing11 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing11);
            //ImageService.Instance.LoadUrl(list[10].image).Into(parsing11);
            //var parsing12 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing12);
            //ImageService.Instance.LoadUrl(list[11].image).Into(parsing12);
            ////
            //var parsing13 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing13);
            //ImageService.Instance.LoadUrl(list[12].image).Into(parsing13);
            //var parsing14 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing14);
            //ImageService.Instance.LoadUrl(list[13].image).Into(parsing14);
            //var parsing15 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing15);
            //ImageService.Instance.LoadUrl(list[14].image).Into(parsing15);
            ////
            //var parsing16 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing16);
            //ImageService.Instance.LoadUrl(list[15].image).Into(parsing16);
            //var parsing17 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing17);
            //ImageService.Instance.LoadUrl(list[16].image).Into(parsing17);
            //var parsing18 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing18);
            //ImageService.Instance.LoadUrl(list[17].image).Into(parsing18);
            ////
            //var parsing19 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing19);
            //ImageService.Instance.LoadUrl(list[18].image).Into(parsing19);
            //var parsing20 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing20);
            //ImageService.Instance.LoadUrl(list[19].image).Into(parsing20);
            //var parsing21 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing21);
            //ImageService.Instance.LoadUrl(list[20].image).Into(parsing21);
            ////
            //var parsing22 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing22);
            //ImageService.Instance.LoadUrl(list[21].image).Into(parsing22);
            //var parsing23 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing23);
            //ImageService.Instance.LoadUrl(list[22].image).Into(parsing23);
            //var parsing24 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing24);
            //ImageService.Instance.LoadUrl(list[23].image).Into(parsing24);
            ////
            //var parsing25 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing25);
            //ImageService.Instance.LoadUrl(list[24].image).Into(parsing25);
            //var parsing26 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing26);
            //ImageService.Instance.LoadUrl(list[25].image).Into(parsing26);
            //var parsing27 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing27);
            //ImageService.Instance.LoadUrl(list[26].image).Into(parsing27);
            ////
            //var parsing28 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing28);
            //ImageService.Instance.LoadUrl(list[27].image).Into(parsing28);
            //var parsing29 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing29);
            //ImageService.Instance.LoadUrl(list[28].image).Into(parsing29);
            //var parsing30 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing30);
            //ImageService.Instance.LoadUrl(list[29].image).Into(parsing30);
            return view;
        }

        private Bitmap GetImageBitmapFromUrlAsync(string url)
        {

            Bitmap name_video_Youtube = null;
            try
            {
                Task.Run(async () =>
                {
                    using (var httpClient = new System.Net.Http.HttpClient())
                    {
                        byte[] imageBytes = await httpClient.GetByteArrayAsync(url);
                        if (imageBytes != null && imageBytes.Length > 0)
                        {
                            name_video_Youtube = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                        }
                    }
                });

            }
            catch
            { }
            return name_video_Youtube;
        }

    }
    }