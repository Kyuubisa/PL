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
            var t = view.FindViewById<TextView>(Resource.Id.Name_video);
            t.Text = text;
            var parsing = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing);
            ImageService.Instance.LoadUrl(list[0].image).Into(parsing);

            string text2 = list1[1].name_video_pars;
            var t2 = view.FindViewById<TextView>(Resource.Id.Name_video2);
            t2.Text = text2;
            var parsing2 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing2);
            ImageService.Instance.LoadUrl(list[1].image).Into(parsing2);

            //string text3 = list1[2].name_video_pars;
            //var t3 = view.FindViewById<TextView>(Resource.Id.Name_video3);
            //t3.Text = text3;
            //var parsing3 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing3);
            //ImageService.Instance.LoadUrl(list[2].image).Into(parsing3);

            //string text4 = list1[3].name_video_pars;
            //var t4 = view.FindViewById<TextView>(Resource.Id.Name_video4);
            //t4.Text = text4;
            //var parsing4 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing4);
            //ImageService.Instance.LoadUrl(list[3].image).Into(parsing4);

            //string text5 = list1[4].name_video_pars;
            //var t5 = view.FindViewById<TextView>(Resource.Id.Name_video5);
            //t5.Text = text5;
            //var parsing5 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing5);
            //ImageService.Instance.LoadUrl(list[4].image).Into(parsing5);

            //string text6 = list1[5].name_video_pars;
            //var t6 = view.FindViewById<TextView>(Resource.Id.Name_video6);
            //t6.Text = text6;
            //var parsing6 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing6);
            //ImageService.Instance.LoadUrl(list[5].image).Into(parsing6);

            //string text7 = list1[6].name_video_pars;
            //var t7 = view.FindViewById<TextView>(Resource.Id.Name_video7);
            //t7.Text = text7;
            //var parsing7 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing7);
            //ImageService.Instance.LoadUrl(list[6].image).Into(parsing7);

            //string text8 = list1[7].name_video_pars;
            //var t8 = view.FindViewById<TextView>(Resource.Id.Name_video8);
            //t8.Text = text8;
            //var parsing8 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing8);
            //ImageService.Instance.LoadUrl(list[7].image).Into(parsing8);

            //string text9 = list1[8].name_video_pars;
            //var t9 = view.FindViewById<TextView>(Resource.Id.Name_video9);
            //t9.Text = text9;
            //var parsing9 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing9);
            //ImageService.Instance.LoadUrl(list[8].image).Into(parsing9);

            //string text10 = list1[9].name_video_pars;
            //var t10 = view.FindViewById<TextView>(Resource.Id.Name_video10);
            //t10.Text = text10;
            //var parsing10 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing10);
            //ImageService.Instance.LoadUrl(list[9].image).Into(parsing10);

            //string text11 = list1[10].name_video_pars;
            //var t11 = view.FindViewById<TextView>(Resource.Id.Name_video11);
            //t11.Text = text11;
            //var parsing11 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing11);
            //ImageService.Instance.LoadUrl(list[10].image).Into(parsing11);

            //string text12 = list1[11].name_video_pars;
            //var t12 = view.FindViewById<TextView>(Resource.Id.Name_video12);
            //t12.Text = text12;
            //var parsing12 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing12);
            //ImageService.Instance.LoadUrl(list[11].image).Into(parsing12);

            //string text13 = list1[12].name_video_pars;
            //var t13 = view.FindViewById<TextView>(Resource.Id.Name_video13);
            //t13.Text = text13;
            //var parsing13 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing13);
            //ImageService.Instance.LoadUrl(list[12].image).Into(parsing13);

            //string text14 = list1[13].name_video_pars;
            //var t14 = view.FindViewById<TextView>(Resource.Id.Name_video14);
            //t14.Text = text14;
            //var parsing14 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing14);
            //ImageService.Instance.LoadUrl(list[13].image).Into(parsing14);

            //string text15 = list1[14].name_video_pars;
            //var t15 = view.FindViewById<TextView>(Resource.Id.Name_video15);
            //t15.Text = text15;
            //var parsing15 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing15);
            //ImageService.Instance.LoadUrl(list[14].image).Into(parsing15);

            //string text16 = list1[15].name_video_pars;
            //var t16 = view.FindViewById<TextView>(Resource.Id.Name_video16);
            //t16.Text = text16;
            //var parsing16 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing16);
            //ImageService.Instance.LoadUrl(list[15].image).Into(parsing16);

            //string text17 = list1[16].name_video_pars;
            //var t17 = view.FindViewById<TextView>(Resource.Id.Name_video17);
            //t17.Text = text17;
            //var parsing17 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing17);
            //ImageService.Instance.LoadUrl(list[16].image).Into(parsing17);

            //string text18 = list1[17].name_video_pars;
            //var t18 = view.FindViewById<TextView>(Resource.Id.Name_video18);
            //t18.Text = text3;
            //var parsing18 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing18);
            //ImageService.Instance.LoadUrl(list[17].image).Into(parsing18);

            //string text19 = list1[18].name_video_pars;
            //var t19 = view.FindViewById<TextView>(Resource.Id.Name_video19);
            //t19.Text = text19;
            //var parsing19 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing19);
            //ImageService.Instance.LoadUrl(list[18].image).Into(parsing19);

            //string text20 = list1[19].name_video_pars;
            //var t20 = view.FindViewById<TextView>(Resource.Id.Name_video20);
            //t20.Text = text20;
            //var parsing20 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing20);
            //ImageService.Instance.LoadUrl(list[19].image).Into(parsing20);

            //string text21 = list1[20].name_video_pars;
            //var t21 = view.FindViewById<TextView>(Resource.Id.Name_video21);
            //t21.Text = text21;
            //var parsing21 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing21);
            //ImageService.Instance.LoadUrl(list[20].image).Into(parsing21);

            //string text22 = list1[21].name_video_pars;
            //var t22 = view.FindViewById<TextView>(Resource.Id.Name_video22);
            //t22.Text = text22;
            //var parsing22 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing22);
            //ImageService.Instance.LoadUrl(list[21].image).Into(parsing22);

            //string text23 = list1[22].name_video_pars;
            //var t23 = view.FindViewById<TextView>(Resource.Id.Name_video23);
            //t23.Text = text23;
            //var parsing23 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing23);
            //ImageService.Instance.LoadUrl(list[22].image).Into(parsing23);

            //string text24 = list1[23].name_video_pars;
            //var t24 = view.FindViewById<TextView>(Resource.Id.Name_video24);
            //t24.Text = text24;
            //var parsing24 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing24);
            //ImageService.Instance.LoadUrl(list[23].image).Into(parsing24);

            //string text25 = list1[24].name_video_pars;
            //var t25 = view.FindViewById<TextView>(Resource.Id.Name_video25);
            //t25.Text = text3;
            //var parsing25 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing25);
            //ImageService.Instance.LoadUrl(list[24].image).Into(parsing25);

            //string text26 = list1[25].name_video_pars;
            //var t26 = view.FindViewById<TextView>(Resource.Id.Name_video26);
            //t26.Text = text26;
            //var parsing26 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing26);
            //ImageService.Instance.LoadUrl(list[25].image).Into(parsing26);

            //string text27 = list1[26].name_video_pars;
            //var t27 = view.FindViewById<TextView>(Resource.Id.Name_video27);
            //t27.Text = text27;
            //var parsing27 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing27);
            //ImageService.Instance.LoadUrl(list[26].image).Into(parsing27);

            //string text28 = list1[27].name_video_pars;
            //var t28 = view.FindViewById<TextView>(Resource.Id.Name_video28);
            //t28.Text = text28;
            //var parsing28 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing28);
            //ImageService.Instance.LoadUrl(list[27].image).Into(parsing28);

            //string text29 = list1[28].name_video_pars;
            //var t29 = view.FindViewById<TextView>(Resource.Id.Name_video29);
            //t29.Text = text29;
            //var parsing29 = (FFImageLoading.Views.ImageViewAsync)view.FindViewById(Resource.Id.Parsing29);
            //ImageService.Instance.LoadUrl(list[28].image).Into(parsing29);

            //string text30 = list1[29].name_video_pars;
            //var t30 = view.FindViewById<TextView>(Resource.Id.Name_video30);
            //t30.Text = text30;
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