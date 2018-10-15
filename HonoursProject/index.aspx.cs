using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HonoursProject.Code.SentimentAnalysis;
using HonoursProject.Code.Twitter;

namespace HonoursProject
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void UpdatePage_Click(object sender, EventArgs e)
        {
            string category = txtCategory.Value;
            string twitterHandle = txtTwitterHandle.Value;
            string keyword = txtKeyword.Value;

            if (category.Equals(""))
            {
                category = "Crime";
            }

            if (twitterHandle.Equals(""))
            {
                twitterHandle = "S.A Crime Watch";
            }

            if (keyword.Equals(""))
            {
                keyword = "Crime";
            }

            List<DB_Service.CrimeTweets> tweetQuery = Query.Search_SearchTweet(keyword);
            DB_Service.ServiceClient service = new DB_Service.ServiceClient();
            queryFeed.InnerHtml = "";
            foreach (DB_Service.CrimeTweets tweet in tweetQuery)
            {
                queryFeed.InnerHtml += /*"<div class='col-lg-4 mb-4 bg-default'>" +*/
                                        "<div class='card'>" +
                                            "<div class='card-header'>Received At: " + DateTime.Now + "</div>" +
                                                "<div class='card-block'>" +
                                                    "<p>" + tweet.message + "</p>" +
                                                "</div>" +
                                        //"</div>" +
                                        "</div>";
            }
            queryFeed.InnerHtml += "<div class='alert bg-success' role='alert'> Success! Twitter has been queried and tweets have been added to the database.<a href= '#' class='float-right'></a></div>";

            List<DB_Service.CrimeTweets> newTweetList = service.getCrimeTweetsToAnalyse();
            List<SentimentResults> newResults = TextAnalyticsV2_1.fullAnalysis(newTweetList);
            
            queryFeed.InnerHtml += "<div class='alert bg-success' role='alert'> Success! New tweets language, phrases, entities and sentiment have been analysed and added to the database.<a href= '#' class='float-right'></a></div>";

            // Printing language results.
            //foreach (SentimentResults document in newResults)
            //{
            //    queryFeed.InnerHtml += "Document ID: " + document.getTweet_id() + ", Score: " + document.getSenti_score() + "\n";
            //}
        }
    }
}