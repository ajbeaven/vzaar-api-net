using System;
using com.vzaar.api;

namespace VzaarApi {
	class TestSuite {
    private Vzaar api;
    private int total = 0;
    private int failures = 0;

    private int videoId = 1465464;
    private string username = "vz-account1";
    private string token = "cyCFbqQ4YTkrQhjFu7OZ2yoO3ol2avg79jRqWhKCpo";
    private string apiUrl = "http://app.vzaar.localhost";
    
//    private int videoId = 1945413;
//    private string username = "vz-qa-account1";
//    private string token = "9711lPengmZgtj6R6nBtNqSdMqOcrsb8nTQTOXyxWY";
//    private string apiUrl = "https://app.qavzr.com";

    public TestSuite() {
      this.api = new Vzaar(this.username, this.token);
      this.api.apiUrl = apiUrl;
    }

    public void whoAmITest() {
      this.assertEqual(this.api.whoAmI(), this.username, "whoAmI");
    }

    public void videoDetailsTest() {
      var vid = this.api.getVideoDetails(this.videoId);
      this.assertEqual(vid.type, "video", "videoDetails");
    }

    public void videoListTest() {
      var query = new VideoListQuery
      {
       count = 10,
       labels = new string[]{"api%2Capi2"}
      };
      
      var col = this.api.getVideoList(query);
      this.assertEqual(col.Count, 1, "videoList");
    }







    public void assertEqual(object a, object b, string mName) {
      this.total += 1;
      if (a.Equals(b)) {
        System.Console.Write(".");
      }
      else
      {
        this.failures =+ 1;
        System.Console.Write("F(" + mName + ")");
      }
    }

    public void summarize() {
      var str = String.Concat("\n", this.total, " examples ", this.failures, " failures");
      System.Console.WriteLine(str);
    }
  }

  class Program {
		static void Main(string[] args)
		{

      var ts = new TestSuite();
      ts.whoAmITest();
      ts.videoDetailsTest();
      ts.videoListTest();
      ts.summarize();
//      var query = new VideoListQuery
//      {
//        count = 10,
//        page = 1
//      };
//
//      var videoList = api.getVideoList(query);
//      foreach (var video in videoList) {
//        System.Console.WriteLine(video.title);
//      }
		}
	}
}