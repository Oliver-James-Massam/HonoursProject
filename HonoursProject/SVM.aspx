<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SVM.aspx.cs" Inherits="HonoursProject.SVM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" id="wrapper">
        <div class="row">
            <main class="col-xs-12 col-sm-8 col-lg-9 col-xl-10 pt-3 pl-4 ml-auto">
                <header class="page-header row justify-center">
                    <div class="col-md-6 col-lg-8">
                        <h1 class="float-left text-center text-md-left">SVM</h1>
                    </div>
                    <div class="dropdown user-dropdown col-md-6 col-lg-4 text-center text-md-right">
                        <button type="button" class="btn btn-lg btn-primary" runat="server" onServerclick="UpdatePage_Click">Update</button>
                    </div>
                    <div class="clear"></div>
                </header>
                <section class="row">
                    <div class="col-sm-12">
                        <section class="row">
                            <div class="col-12">
                                <div class="card mb-4">
                                    <div class="card-block">
                                        <h3 class="card-title">SVM Data Set Upload</h3>
                                        <form class="form" action="#">
                                            <div class="form-group row">
                                                <label class="col-md-3 col-form-label">Upload CSV</label>
                                                <div class="col-md-9">
                                                    <asp:FileUpload id="FileUploadControl" runat="server" class="btn btn-secondary margin" type="button" />
                                                    <button class="btn btn-primary margin" type="button" runat="server" id="UploadButton" onServerclick="UploadButton_Click">Upload</button>
                                                    <%--<input type="file" id="file" class="custom-file-input">--%>
                                                    <br /><br />
                                                    <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </div>
                </section>
                <section class="row">
                    <div class="col-sm-12">
                        <section class="row">
                            <div class="col-12">
                                <div class="card mb-4">
                                    <div class="card-block">
                                        <h3 class="card-title">Output</h3>
                                        <form class="form" action="#">
                                            <%-- The Output Feed --%>
                                            <div id="outputFeed" runat="server" contenteditable="true">

                                            </div>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </div>
                </section>
            </main>
        </div>
    </div>
</asp:Content>
