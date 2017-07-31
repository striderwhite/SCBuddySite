using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Serialization;

public partial class _Default : System.Web.UI.Page
{

    string followersURL = "https://api-v2.soundcloud.com/users/2751638/followers?offset=1501283655753&limit=200&client_id=JlZIsxg2hY5WnBgtn3jfS0UYCl0K8DOg&app_version=1501506273";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonStart_Click(object sender, EventArgs e)
    {

        WebClient client = new WebClient();
        string jsonData = client.DownloadString(TextBoxProfileURL.Text);
        RootObject rootJsonObject = JsonConvert.DeserializeObject<RootObject>(jsonData);


        //XmlSerializer xmlSerializer = new XmlSerializer(rootJsonObject.GetType());
        
     


        foreach (var v in rootJsonObject.collection)
        {

            ListItem li = new ListItem(v.username + "   " + Convert.ToString(v.followers_count), Convert.ToString(v.followers_count));
            ListBoxFollowers.Items.Add(li);
        }

    }


    //async Task<string> GetFollowersAsync(string inUrl)
    //{
    //    WebClient client = new WebClient();
    //    return await client.DownloadString(inUrl);
    //}

}