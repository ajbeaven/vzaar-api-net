using System;
using com.vzaar.api;

namespace VzaarApi {
	class TestSuite {
    private Vzaar api;
    private int success = 0;
    private int failure = 0;
    private int videoId = 1945413;
    private string username = "vz-qa-account1";
    private string token = "9711lPengmZgtj6R6nBtNqSdMqOcrsb8nTQTOXyxWY";

    public TestSuite() {
      this.api = new Vzaar(this.username, this.token);
      this.api.apiUrl = "https://app.qavzr.com";
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
        labels = new string[]{"api", "api2"}
      };
      
      var col = this.api.getVideoList(query);
      System.Console.Write(col.Count);
    }







    public void assertEqual(object a, object b, string mName) {
      if (a.Equals(b)) {
        this.success =+ 1;
        System.Console.Write(".");
      }
      else
      {
        this.failure =+ 1;
        System.Console.Write("F(" + mName + ")");
      }
    }

    public void summarize() {
      System.Console.WriteLine("\ndone");
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