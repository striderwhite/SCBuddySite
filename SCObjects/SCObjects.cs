using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCObjects;

/// <summary>
/// Summary description for SCObjects
/// </summary>
public class SCObjects
{
    public SCObjects()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}



#region SC Object Clases
public class Product
{
    public string id { get; set; }
    public string name { get; set; }
}

public class CreatorSubscription
{
    public Product product { get; set; }
    public bool recurring { get; set; }
    public bool hug { get; set; }
}

public class Collection
{
    public string avatar_url { get; set; }
    public object city { get; set; }
    public int comments_count { get; set; }
    public object country_code { get; set; }
    public string created_at { get; set; }
    public List<CreatorSubscription> creator_subscriptions { get; set; }
    public object creator_subscription { get; set; }
    public object description { get; set; }
    public int followers_count { get; set; }
    public int followings_count { get; set; }
    public string first_name { get; set; }
    public string full_name { get; set; }
    public int groups_count { get; set; }
    public int id { get; set; }
    public string kind { get; set; }
    public string last_modified { get; set; }
    public string last_name { get; set; }
    public int likes_count { get; set; }
    public string permalink { get; set; }
    public string permalink_url { get; set; }
    public int playlist_count { get; set; }
    public object reposts_count { get; set; }
    public int track_count { get; set; }
    public string uri { get; set; }
    public string urn { get; set; }
    public string username { get; set; }
    public bool verified { get; set; }
    public object visuals { get; set; }
}

public class RootObject
{
    public List<Collection> collection { get; set; }
    public string next_href { get; set; }
    public object query_urn { get; set; }
}
#endregion