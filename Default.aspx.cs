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
        //Build table header row
        SetUpTable();

        //Now do actual api calls
        WebClient client = new WebClient();
        //DownloadString() does GET on api url
        //Soundcloud is nice enoungh to give us JSON
        string jsonData = client.DownloadString(TextBoxProfileURL.Text);
        //Deserailzie JSON into a known mapped object ("RootObject")
        RootObject rootJsonObject = JsonConvert.DeserializeObject<RootObject>(jsonData);

        //should be looping and jumping to next href until href is null (end of followers list)
        //now run through what we got back from json
        foreach (var v in rootJsonObject.collection)
        {
            //add wanted data to table
            TableRow tUserRow = new TableRow();

            TableHeaderCell thcUserName = new TableHeaderCell();
            thcUserName.Text = v.username;
            thcUserName.Controls.Add(new LiteralControl(v.username));

            TableHeaderCell thcFollowCount = new TableHeaderCell();
            thcFollowCount.Text = Convert.ToString(v.followers_count);
            thcFollowCount.Controls.Add(new LiteralControl(Convert.ToString(v.followers_count)));

            TableHeaderCell thcURL = new TableHeaderCell();
            thcURL.Text = v.permalink_url;
            HyperLink artistHyperlink = new HyperLink();
            artistHyperlink.Text = v.permalink_url.Substring(22);
            artistHyperlink.NavigateUrl = v.permalink_url;
            thcURL.Controls.Add(artistHyperlink);
            //thcUserName.Text = v.permalink.Substring(22);   //22 just to cut out https://www.soundcloud.com

            TableHeaderCell thcNumOfReposts = new TableHeaderCell();
            thcNumOfReposts.Text = Convert.ToString(v.reposts_count);
            thcNumOfReposts.Controls.Add(new LiteralControl(Convert.ToString(v.reposts_count)));

            TableHeaderCell thcNumOfTracks = new TableHeaderCell();
            thcNumOfTracks.Text = Convert.ToString(v.track_count);
            thcNumOfTracks.Controls.Add(new LiteralControl(Convert.ToString(v.track_count)));

            TableHeaderCell thcURLFullName = new TableHeaderCell();
            thcURLFullName.Text = v.full_name;
            thcURLFullName.Controls.Add(new LiteralControl(v.full_name));

            //add em up!
            tUserRow.Cells.Add(thcUserName);
            tUserRow.Cells.Add(thcFollowCount);
            tUserRow.Cells.Add(thcURL);
            //tUserRow.Cells.Add(thcNumOfReposts);
            tUserRow.Cells.Add(thcNumOfTracks);
            tUserRow.Cells.Add(thcURLFullName);
            TableFollowers.Rows.Add(tUserRow);

        }

    }

    private void SetUpTable()
    {
        TableFollowers.Rows.Clear();

        //set up table row header and cells
        TableRow HeaderRow = new TableRow();

        TableHeaderCell thcUserName = new TableHeaderCell();
        thcUserName.Controls.Add(new LiteralControl("User Name"));
        thcUserName.Text = "User Name";

        TableHeaderCell thcFollowCount = new TableHeaderCell();
        thcFollowCount.Controls.Add(new LiteralControl("Followers"));
        thcFollowCount.Text = "Followers";

        TableHeaderCell thcURL = new TableHeaderCell();
        thcURL.Controls.Add(new LiteralControl("URL"));
        thcURL.Text = "URL";

        TableHeaderCell thcRepostedTracksCount = new TableHeaderCell();
        thcRepostedTracksCount.Controls.Add(new LiteralControl("# Of Reposts"));
        thcRepostedTracksCount.Text = "# Of Reposts";

        TableHeaderCell thcTracksCount = new TableHeaderCell();
        thcTracksCount.Controls.Add(new LiteralControl("# Of Tracks"));
        thcTracksCount.Text = "# Of Tracks";

        TableHeaderCell thcURLFullName = new TableHeaderCell();
        thcURLFullName.Controls.Add(new LiteralControl("Given Name"));
        thcURLFullName.Text = "Full Name";

        //add em up
        HeaderRow.Cells.Add(thcUserName);
        HeaderRow.Cells.Add(thcFollowCount);
        HeaderRow.Cells.Add(thcURL);
        //HeaderRow.Cells.Add(thcRepostedTracksCount);
        HeaderRow.Cells.Add(thcTracksCount);
        HeaderRow.Cells.Add(thcURLFullName);
        TableFollowers.Rows.Add(HeaderRow);
    }


    //async Task<string> GetFollowersAsync(string inUrl)
    //{
    //    WebClient client = new WebClient();
    //    return await client.DownloadString(inUrl);
    //}

}