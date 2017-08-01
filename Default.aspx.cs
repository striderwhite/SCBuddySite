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

            TableHeaderCell thcFollowCount = new TableHeaderCell();
            thcUserName.Text = Convert.ToString(v.followers_count);

            TableHeaderCell thcURL = new TableHeaderCell();
            thcUserName.Text = v.permalink;
            //thcUserName.Text = v.permalink.Substring(22);   //22 just to cut out https://www.soundcloud.com

            TableHeaderCell thcNumOfReposts = new TableHeaderCell();
            thcUserName.Text = Convert.ToString(v.reposts_count);

            TableHeaderCell thcNumOfTracks = new TableHeaderCell();
            thcUserName.Text = Convert.ToString(v.track_count);

            TableHeaderCell thcURLFullName = new TableHeaderCell();
            thcUserName.Text = v.full_name;

            //add them up!
            TableCellCollection tchc = new TableCellCollection(;

            tchc.Add(thcUserName);
            tchc.Add(thcFollowCount);
            tchc.Add(thcURL);
            tchc.Add(thcNumOfReposts);
            tchc.Add(thcNumOfTracks);
            tchc.Add(thcURLFullName);
            TableFollowers.Rows.Add(tUserRow);

        }

    }

    private void SetUpTable()
    {
        TableFollowers.Rows.Clear();

        //set up table row header and cells
        TableRow HeaderRow = new TableRow();

        TableHeaderCell thcUserName = new TableHeaderCell();
        thcUserName.Text = "User Name";

        TableHeaderCell thcFollowCount = new TableHeaderCell();
        thcUserName.Text = "Followers";

        TableHeaderCell thcURL = new TableHeaderCell();
        thcUserName.Text = "URL";

        TableHeaderCell thcRepostedTracksCount = new TableHeaderCell();
        thcUserName.Text = "# Of Reposts";

        TableHeaderCell thcTracksCount = new TableHeaderCell();
        thcUserName.Text = "# Of Tracks";
    
        TableHeaderCell thcURLFullName = new TableHeaderCell();
        thcUserName.Text = "Full Name";

        //add em up
        HeaderRow.Cells.Add(thcUserName);
        HeaderRow.Cells.Add(thcFollowCount);
        HeaderRow.Cells.Add(thcURLFullName);
        HeaderRow.Cells.Add(thcURLFullName);
        HeaderRow.Cells.Add(thcRepostedTracksCount);
        HeaderRow.Cells.Add(thcTracksCount);
        TableFollowers.Rows.Add(HeaderRow);
    }


    //async Task<string> GetFollowersAsync(string inUrl)
    //{
    //    WebClient client = new WebClient();
    //    return await client.DownloadString(inUrl);
    //}

}