<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">

    <link href="StyleSheet.css" rel="stylesheet" />

    <div class="container bgclass lilBorder">
        <div class="row text-center jumbotron lilBorder">
            <div class="col-md-12">
                <h1>SC Follower Buddy </h1>
            </div>
        </div>
        <hr />

        <!-- ************************************************************* -->
        <!--                       ENTER URL LABEL DIV                           -->
        <!-- ************************************************************* -->
        <div class="row text-center">
            <div class="col-md-4">
            </div>
            <div class="col-md-4 text-center topMargin">
                <asp:Label ID="LabelInfo" runat="server" Text="Enter page URL"></asp:Label>
            </div>
            <div class="col-md-4"></div>
        </div>

        <!-- ************************************************************* -->
        <!--                       ENTER URL TEXTBOX DIV                           -->
        <!-- ************************************************************* -->
        <div class="row text-center">
            <div class="col-md-1">
            </div>
            <div class="col-md-10 text-center topMargin">
                <asp:TextBox ID="TextBoxProfileURL" runat="server" Width="100%" CssClass="enjoy-cssTextbox">https://api-v2.soundcloud.com/users/2751638/followers?offset=1501351687918&amp;limit=200&amp;client_id=JlZIsxg2hY5WnBgtn3jfS0UYCl0K8DOg&amp;app_version=1501667839</asp:TextBox>
            </div>
            <div class="col-md-1"></div>
        </div>
        <hr />
        <br />


        <asp:ScriptManager ID="ScriptManagerFollowers" runat="server" AsyncPostBackTimeout="120"></asp:ScriptManager>
        <asp:UpdateProgress runat="server"></asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanelGetFollowers" runat="server" RenderMode="Block">
            <ContentTemplate>

                <!-- ************************************************************* -->
                <!--                       "GO" BUTTON DIV                       -->
                <!-- ************************************************************* -->
                <div class="row text-center">
                    <div class="col-md-4"></div>
                    <div class="col-md-4 text-center topMargin">
                        <br />
                        <asp:Button ID="ButtonStart" runat="server" Text="Start!" OnClick="ButtonStart_Click" CssClass="feedback-button" Height="80%" Width="80%" /><br />
                        <br />
                        <br />
                    </div>
                    <div class="col-md-4">
                    </div>
                </div>
                <hr />

                <asp:UpdateProgress ID="UpdateProgressFollowers" runat="server">
                    <ProgressTemplate>
                        <div class="text-center">
                            <asp:Label runat="server" Text="Getting Followers... Please Wait..." ID="labelInfoID2"></asp:Label>
                            <br />
                            <br />
                            <br />
                            <asp:Image ID="ImageGifTest" runat="server" ImageUrl="~/Content/IMG/ajax-loader.gif" ImageAlign="Middle" Height="50px" Width="50px" CssClass="img" />
                            <br />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>

                <!-- ************************************************************* -->
                <!--                       INFO LABEL DIV                           -->
                <!-- ************************************************************* -->
                <div class="row text-center">
                    <div class="col-md-2"></div>
                    <div class="col-md-8 text-center topMargin">
                        <asp:Label runat="server" Text="" ID="labelInfoID" CssClass="well well-sm" Visible="False"></asp:Label>
                        <br />

                    </div>
                    <div class="col-md-2">
                    </div>
                </div>
                <hr />

                <!-- ************************************************************* -->
                <!--                       TABLE DIV                          -->
                <!-- ************************************************************* -->

                <asp:Panel ID="PanelOptions" runat="server" Visible="False">
                    <asp:Button ID="ButtonExportCSV" runat="server" CssClass="enjoy-css-B2" OnClick="ButtonExportCSV_Click" Text="Export Data" />
                    <asp:Button ID="ButtonSoryByFollowCount" runat="server" CssClass="enjoy-css-B2" OnClick="ButtonSoryByFollowCount_Click" Text="Sort by follow count" />
                    <asp:Button ID="ButtonSortByFollowDate" runat="server" CssClass="enjoy-css-B2" Text="Sort by follow date" />
                    <asp:Button ID="ButtonSortBytTracksPosted" runat="server" CssClass="enjoy-css-B2" Text="Sort by tracks posted" />
                </asp:Panel>
                <br />

                <asp:Table ID="TableFollowers" runat="server" CssClass="datagrid table table-bordered table-hover table-condensed" CellPadding="1" CellSpacing="1" GridLines="Both">
                </asp:Table>
                <hr />
            </ContentTemplate>

        </asp:UpdatePanel>


    </div>
</asp:Content>

