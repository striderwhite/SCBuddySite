<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">

    <link href="StyleSheet.css" rel="stylesheet" />

    <div class="container bgclass lilBorder">
        <div class="row text-center well well-sm lilBorder">
            <div class="col-md-12">
                <h1>SC Follower Buddy </h1>
            </div>
        </div>
        <hr />
        <!--                     PROFLILE URL ROW                     -->
        <div class="row text-center">
            <div class="col-md-4">
            </div>
            <div class="col-md-4 text-center topMargin">
                <asp:label id="LabelInfo" runat="server" text="Enter page URL"></asp:label>
            </div>
            <div class="col-md-4"></div>
        </div>

        <!--                     PROFLILE URL ROW                     -->
        <div class="row text-center">
            <div class="col-md-4">
            </div>
            <div class="col-md-4 text-center topMargin">
                <asp:textbox id="TextBoxProfileURL" runat="server" width="80%">https://api-v2.soundcloud.com/users/2751638/followers?offset=1501283655753&amp;limit=200&amp;client_id=JlZIsxg2hY5WnBgtn3jfS0UYCl0K8DOg&amp;app_version=1501506273</asp:textbox>
            </div>
            <div class="col-md-4"></div>
        </div>
              <hr />
        <br />
        <!--                    INFO                    -->
        <div class="row text-center">
            <div class="col-md-2"></div>
            <div class="col-md-8 text-center topMargin">
                <asp:label runat="server" text="Waiting..." id="labelInfoID"></asp:label>
                <br />
            </div>
            <div class="col-md-2">
            </div>
        </div>
        <hr />


        <!--                    START ROW                     -->
        <div class="row text-center">
            <div class="col-md-4"></div>
            <div class="col-md-4 text-center topMargin">
                <br />
                <asp:button id="ButtonStart" runat="server" text="Start!" onclick="ButtonStart_Click" height="21px" width="167px" cssclass="enjoy-css" />
            </div>
            <div class="col-md-4">
            </div>
        </div>
        <hr />

        <!--                    INFO ROW                     -->
        <div class="row text-center">
            <div class="col-md-2"></div>
            <div class="col-md-8 text-center topMargin">
                <asp:table id="TableFollowers" runat="server" cssclass="table table-bordered table-hover table-condensed" horizontalalign="Center" height="100%" width="100%" borderwidth="1px" cellpadding="1" cellspacing="1" gridlines="Both">
                </asp:table>
            </div>
            <div class="col-md-2"></div>
        </div>
        <hr />



    </div>

</asp:Content>

