using System;
using com.vzaar.api;

namespace VzaarApi {
	class TestSuite {
    private Vzaar api;
    private int success = 0;
    private int failure = 0;
    private int videoId = 1465464;
    private string username = "vz-account1";
    private string token = "cyCFbqQ4YTkrQhjFu7OZ2yoO3ol2avg79jRqWhKCpo";

    public TestSuite() {
      this.api = new Vzaar(this.username, this.token);
      this.api.apiUrl = "http://app.vzaar.localhost";
    }

    public void whoAmITest() {
      this.assertEqual(this.api.whoAmI(), "qloop1002", "whoAmI");
    }

    public void videoDetailsTest() {
      System.Console.WriteLine(this.api.getVideoDetails(this.videoId));
//      this.assertEqual(this.api.getVideoDetails(this.videoId, true));
    }

    public void videoListTest() {
      var query = new VideoListQuery
      {
        labels = new string[]{"api", "api2"}
      };
      
      var col = this.api.getVideoList(query);
      System.Console.WriteLine(col.Count);
    }

    public void assertEqual(object a, object b, string mName) {
      if (a.Equals(b)) {
        this.success =+ 1;
        System.Console.WriteLine(".");
      }
      else
      {
        this.failure =+ 1;
        System.Console.WriteLine("F(" + mName + ")");
      }
    }
  }

  class Program {
		static void Main(string[] args)
		{

      var ts = new TestSuite();
      ts.whoAmITest();
      ts.videoListTest();
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