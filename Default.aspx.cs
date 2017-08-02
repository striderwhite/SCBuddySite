/* *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *   *   *   *   *   *   *   *   *   * 
 * Class:       Default.aspx.cs
 * Author(s):   Strider White 
 * Desc:        This is the backing code page for the Default "main" page. This page makes
 *              calls to SoundCloud.com API using GET requests to download
 *              users follower information. From there, it collects the 
 *              information, and present it in a meaningful mannor.
 * *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  */


/* * * * * * * * * * *  NOTES OF INTEREST * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *  #1: use System.Diagnostics.Debug.WriteLine() for console output
 *  #2:
 *  #3:
 *  #4:
 *  
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

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
using System.Threading;

public partial class _Default : System.Web.UI.Page
{

    //hardcoded url to the api call on my soundcloud
    string followersURL = "https://api-v2.soundcloud.com/users/2751638/followers?offset=1501312799270&limit=200&client_id=JlZIsxg2hY5WnBgtn3jfS0UYCl0K8DOg&app_version=1501594219";

    //part of the url to keep track of
    string urlPartClientIDAppVersion = "";

    //this is what we are getting back as a collection of "users"
    List<Collection> scUserObjects = null;

    /// <summary>
    /// Page load callback
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (scUserObjects == null)
            scUserObjects = new List<Collection>();
    }

    /// <summary>
    /// This button begins the server calls, it keeps looping until we get back
    /// all the info we want. Right now this is blocking and needs
    /// to be updated to ASYNC
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButtonStart_Click(object sender, EventArgs e)
    {



        //Validate input
        if (!isValidURLInput(TextBoxProfileURL.Text))
            return;

        //First parse out some of the URL we need to append for later..
        if (!SetUrlPartClientIDAppVersion())
            return;


        //Reset info color
        labelInfoID.ForeColor = System.Drawing.Color.Black;

        //Clear obtained users 
        scUserObjects.Clear();

        //labelInfoID.Text = "Contacting Soundcloud... please wait...";

        //Make actual web call and get data (updates ui after)
        //Thread getFollowers = new Thread(MakeWebCallToSoundcloud);
        //getFollowers.Start();

        //labelInfoID.Text = "Getting followers... please wait...";
        MakeWebCallToSoundcloud();



        //Now sort the collection based on followers
        scUserObjects.Sort((a, b) => b.followers_count.CompareTo(a.followers_count));

        //Update UI
        DisplayTable();

    }

    private void MakeWebCallToSoundcloud()
    {

        //Now do actual api calls
        WebClient client = new WebClient();
        string jsonData;                          //what we get back 
        RootObject rootJsonObject;                //convert it into this
        string hrefNext = TextBoxProfileURL.Text; //url to next resource

        //Should be looping and jumping to next href until href is null (end of followers list)
        do
        {
            //DownloadString() does GET on api url
            //Soundcloud is nice enoungh to give us JSON
            try
            {
                jsonData = client.DownloadString(new Uri(hrefNext));
            }
            catch (Exception ex)
            {
                labelInfoID.ForeColor = System.Drawing.Color.Red;
                labelInfoID.Text = "Failed to download information (client.DownloadString()). Was the URL correct? <br><br>" + ex.Message + "<br><br>";
                return;
            }


            //Deserailzie JSON into a known mapped object ("RootObject")
            rootJsonObject = JsonConvert.DeserializeObject<RootObject>(jsonData);
            //get next url
            hrefNext = rootJsonObject.next_href + urlPartClientIDAppVersion;
            //add to our collection
            foreach (var b in rootJsonObject.collection)
            {
                scUserObjects.Add(b);
            }
        } while ((rootJsonObject.next_href != null));

        //Set up some controls
        //labelInfoID.Text = "Now sorting " + scUserObjects.Count + " followers";
        labelInfoID.Visible = true;
        labelInfoID.Text = "Found " + scUserObjects.Count + " followers!";





        #region SC Testing code
        ////************* testing code here **********
        //var url = "https://soundcloud.com/strider_white/followers";
        //var webClientFollowers = WebRequest.Create(url) as HttpWebRequest;
        //webClientFollowers.Method = WebRequestMethods.Http.Get;
        //webClientFollowers.ContentType = "application/json";
        //webClientFollowers.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705";
        //var response = webClientFollowers.GetResponse() as HttpWebResponse;

        //for (int i = 0; i < response.Headers.Count; i++)
        //    System.Diagnostics.Debug.WriteLine(response.Headers.GetKey(i) + "-- " + response.Headers.Get(i).ToString());

        //System.Diagnostics.Debug.WriteLine("WAIT");


        //foreach (var v in client.ResponseHeaders)
        //    System.Diagnostics.Debug.WriteLine(v.ToString());

        //System.Diagnostics.Debug.WriteLine("wait");


        //make a web request
        //using (WebClient webClientFollowers = new WebClient())
        //{
        //    //set headers 
        //    webClientFollowers.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        //    //now download the data from soundcloud
        //    byte[] scData = webClientFollowers.DownloadData("https://soundcloud.com/strider_white/followers");
        //    foreach (string s in webClientFollowers.ResponseHeaders)
        //        System.Diagnostics.Debug.WriteLine(s);

        //    //Dump out all the response headers
        //    //foreach (var resp in client.ResponseHeaders)
        //    //{
        //    //    System.Diagnostics.Debug.WriteLine(resp.ToString());
        //    //}

        //    System.Diagnostics.Debug.WriteLine("WAIT");

        //}

        #endregion SC Testing code

    }

    private bool SetUrlPartClientIDAppVersion()
    {
        try
        {
            urlPartClientIDAppVersion = "&" + TextBoxProfileURL.Text.Split('&')[2];
            return true;
        }
        catch (Exception ex)
        {
            labelInfoID.ForeColor = System.Drawing.Color.Red;
            labelInfoID.Text = "Failed to parse URL information (Text.Split). Was the URL correct? <br><br>" + ex.Message + "<br><br>";
            return false;
        }
    }

    private bool isValidURLInput(string inurl)
    {
        //validate input is URL (could use better input validation here)
        Uri uriResult;
        bool isValidUrl = Uri.TryCreate(inurl, UriKind.Absolute, out uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

        if (!isValidUrl)
        {
            labelInfoID.ForeColor = System.Drawing.Color.Red;
            labelInfoID.Text = "Invalid URL!";
            return false;
        }


        return true;
    }

    private void DisplayTable()
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


        //now populate the table

        //now run through what we got back from all the GET requets
        foreach (var v in scUserObjects)
        {

            //add wanted data to table
            TableRow tUserRow = new TableRow();

            TableCell tcUserName = new TableCell();
            tcUserName.Text = v.username;
            tcUserName.Controls.Add(new LiteralControl(v.username));

            TableCell tcFollowCount = new TableCell();
            tcFollowCount.Text = Convert.ToString(v.followers_count);
            tcFollowCount.Controls.Add(new LiteralControl(Convert.ToString(v.followers_count)));

            TableCell tcURL = new TableCell();
            tcURL.Text = v.permalink_url;
            HyperLink artistHyperlink = new HyperLink();
            artistHyperlink.Text = v.permalink_url.Substring(22);
            artistHyperlink.NavigateUrl = v.permalink_url;
            tcURL.Controls.Add(artistHyperlink);
            //thcUserName.Text = v.permalink.Substring(22);   //22 just to cut out https://www.soundcloud.com

            TableCell tcNumOfReposts = new TableCell();
            tcNumOfReposts.Text = Convert.ToString(v.reposts_count);
            tcNumOfReposts.Controls.Add(new LiteralControl(Convert.ToString(v.reposts_count)));

            TableCell tcNumOfTracks = new TableCell();
            tcNumOfTracks.Text = Convert.ToString(v.track_count);
            tcNumOfTracks.Controls.Add(new LiteralControl(Convert.ToString(v.track_count)));

            TableCell tcURLFullName = new TableCell();
            tcURLFullName.Text = v.full_name;
            tcURLFullName.Controls.Add(new LiteralControl(v.full_name));

            //add em up!
            tUserRow.Cells.Add(tcUserName);
            tUserRow.Cells.Add(tcFollowCount);
            tUserRow.Cells.Add(tcURL);
            //tUserRow.Cells.Add(thcNumOfReposts);
            tUserRow.Cells.Add(tcNumOfTracks);
            tUserRow.Cells.Add(tcURLFullName);
            TableFollowers.Rows.Add(tUserRow);

        }
    }





    //async Task<string> GetFollowersAsync(string inUrl)
    //{
    //    WebClient client = new WebClient();
    //    return await client.DownloadString(inUrl);
    //}


}