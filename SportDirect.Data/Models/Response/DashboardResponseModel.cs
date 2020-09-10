using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SportDirect.Data.Models.Response
{
    public class DashboardResponseModel : BaseResponseModel
    {
        public Status status { get; set; }
    }
    public class Introduction
    {
        public int id { get; set; }
        public string tagline { get; set; }
        public string bgImage { get; set; }
    }

    public class Service
    {
        public int id { get; set; }
        public string title { get; set; }
        public string logo { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }
        public string image3 { get; set; }
        public string image4 { get; set; }
        public string carousal_slider_img1 { get; set; }
        public string carousal_slider_img2 { get; set; }
        public string carousal_slider_img3 { get; set; }
        public string carousal_slider_img4 { get; set; }
        public string carousal_single_img { get; set; }
        public int video1Choice { get; set; }
        public string video1Url { get; set; }
        public string video1File { get; set; }
        public int video2Choice { get; set; }
        public string video2Url { get; set; }
        public string video2File { get; set; }
        public int video3Choice { get; set; }
        public string video3Url { get; set; }
        public string video3File { get; set; }
        public string author { get; set; }
        public string content { get; set; }
        public int socialPoint { get; set; }
        public string color { get; set; }
        // public int public { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string carousal_content1 { get; set; }
        public string carousal_content2 { get; set; }
        public string carousal_content3 { get; set; }
        public string share_link { get; set; }
    }

    public class Aboutu
    {
        public int id { get; set; }
        public string front_title { get; set; }
        public string front_heading { get; set; }
        public string front_desc { get; set; }
        public string feature1_img { get; set; }
        public string feature1_txt { get; set; }
        public string feature2_img { get; set; }
        public string feature2_txt { get; set; }
        public string feature3_img { get; set; }
        public string feature3_txt { get; set; }
        public string feature4_img { get; set; }
        public string feature4_txt { get; set; }
        public string title { get; set; }
        public string logo { get; set; }
        public string logo_description { get; set; }
        public string carousal_img1 { get; set; }
        public string carousal_img2 { get; set; }
        public string carousal_img3 { get; set; }
        public string carousal_img4 { get; set; }
        public string carousal_description { get; set; }
        public object description { get; set; }
    }

    public class Testimonial
    {
        public int id { get; set; }
        public int client_id { get; set; }
        public string ratting { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public string designation { get; set; }
        public string star1 { get; set; }
        public string star2 { get; set; }
        public string star3 { get; set; }
        public string star4 { get; set; }
        public string star5 { get; set; }
    }

    public class Client
    {
        public int id { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public string main_logo { get; set; }
        public string designation { get; set; }
    }

    public class News
    {
        public int id { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public string date { get; set; }
        public string news_heading { get; set; }
        public int total_views { get; set; }
        public string fb_link { get; set; }
        public string linked_link { get; set; }
        public string google_link { get; set; }
        public string twitter_link { get; set; }
        public string share_link { get; set; }
        public List<NewsComment> comment { get; set; }
    }

    public class NewsComment
    {
        public string comment { get; set; }
        public string datetime { get; set; }
        public string name { get; set; }
        public string logo { get; set; } 
        public string news_heading { get; set; }
    }

    public class SampleWork
    {
        public int id { get; set; }
        public int service_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string caption { get; set; }
        public string photo1 { get; set; }
        public string photo2 { get; set; }
        public string photo3 { get; set; }
        public string photo4 { get; set; }
    }

    public class Portfolio
    {
        public int id { get; set; }
        public string image { get; set; }
    }

    public class Contact
    {
        public int id { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string facebook_link { get; set; }
        public string twitter_link { get; set; }
        public string instagram_link { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
    }

    public class Career
    {
        public int id { get; set; }
        public string logo { get; set; }
        public string description { get; set; }
        public string heading { get; set; }
        public string work_status { get; set; }
    }

    public class Data
    {
        public IList<Introduction> introduction { get; set; }
        public IList<Service> services { get; set; }
        public IList<Aboutu> aboutus { get; set; }
        public IList<Testimonial> testimonial { get; set; }
        public IList<Client> clients { get; set; }
        public IList<News> news { get; set; }
        public IList<NewsComment> news_comment { get; set; }
        public IList<SampleWork> sampleWorks { get; set; }
        public IList<Portfolio> portfolio { get; set; }
        public IList<Contact> contact { get; set; }
        public IList<Career> career { get; set; }
    }

    public class Status
    {
        public Data data { get; set; }
    }
}