﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
        <!--                     PROFLILE URL ROW                     -->
        <div class="row text-center">
            <div class="col-md-4">
            </div>
            <div class="col-md-4 text-center topMargin well">
                <asp:Label ID="LabelInfo" runat="server" Text="Enter page URL"></asp:Label>
            </div>
            <div class="col-md-4"></div>
        </div>

        <!--                     PROFLILE URL ROW                     -->
        <div class="row text-center">
            <div class="col-md-4">
            </div>
            <div class="col-md-4 text-center topMargin">
                <asp:TextBox ID="TextBoxProfileURL" runat="server" Width="80%">https://api-v2.soundcloud.com/users/2751638/followers?offset=1501312799270&amp;limit=200&amp;client_id=JlZIsxg2hY5WnBgtn3jfS0UYCl0K8DOg&amp;app_version=1501594219</asp:TextBox>
            </div>
            <div class="col-md-4"></div>
        </div>
        <hr />
        <br />
        <!--                    INFO                    -->
        <div class="row text-center">
            <div class="col-md-2"></div>
            <div class="col-md-8 text-center topMargin">
                <asp:Label runat="server" Text="Waiting..." ID="labelInfoID" CssClass="well well-sm"></asp:Label>
                <br />
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
                <asp:Button ID="ButtonStart" runat="server" Text="Start!" OnClick="ButtonStart_Click" Height="21px" Width="167px" CssClass="enjoy-css" />
            </div>
            <div class="col-md-4">
            </div>
        </div>
        <hr />

        <!--                    INFO ROW                     -->
        <div class="row text-center">
            <div class="col-md-2"></div>
            <div class="col-md-8 text-center topMargin">
                <asp:Table ID="TableFollowers" runat="server" CssClass="datagrid table table-bordered table-hover table-condensed" CellPadding="1" CellSpacing="1" GridLines="Both">
                </asp:Table>
            </div>
            <div class="col-md-2"></div>
        </div>
        <hr />
    </div>
</asp:Content>

