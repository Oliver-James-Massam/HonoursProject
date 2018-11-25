<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="HonoursProject.Results" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.3/Chart.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="col-xs-12 col-sm-8 col-lg-9 col-xl-10 pt-3 pl-4 ml-auto">
        <section class="row">
            <div class="col-sm-12">
                <section class="row">
                    <div class="col-12 mb-2">
                        <div class="card mb-8">
                            <div class="card mb-8">
                                <div class="card-block">
                                    <h3 class="card-title">k-Nearest Neighbors</h3>
                                    <h6 class="card-subtitle mb-2 text-muted">Categories Predicted</h6>

                                    <div class="canvas-wrapper">
                                        <%--<canvas class="chart" id="bar-chart" height="200" width="600"></canvas>--%>
                                        <canvas class="chart" id="bar-chart" height="200" width="600"></canvas>
                                        <script type="text/javascript">
                                            
                                            var colNames = <%= newCols %>
                                            var catTotal = <%= numPerCat_knn %>
                                            new Chart(document.getElementById("bar-chart"), {
                                                type: 'bar',
                                                    data: {
                                                        labels: colNames,
                                                    datasets: [
                                                        {
                                                            label: "Number of times predicted",
                                                            backgroundColor: ["#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                                                            data: catTotal
                                                        }
                                                    ]
                                                },
                                                options: {
                                                    legend: { display: false },
                                                    title: {
                                                        display: true,
                                                        text: 'Number of times category was predicted'
                                                    }
                                                }
                                            });
                                        </script>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                <section class="row">
                    <div class="col-12 mb-2">
                        <div class="card mb-8">
                            <div class="card mb-8">
                                <div class="card-block">
                                    <h3 class="card-title">Logistic Regression</h3>
                                    <h6 class="card-subtitle mb-2 text-muted">Categories Predicted</h6>

                                    <div class="canvas-wrapper">
                                        <%--<canvas class="chart" id="bar-chart" height="200" width="600"></canvas>--%>
                                        <canvas class="chart" id="bar-chart2" height="200" width="600"></canvas>
                                        <script type="text/javascript">
                                            
                                            var colNames = <%= newCols %>
                                            var catTotal = <%= numPerCat_logreg %>
                                            var catActual = <%= numPerCat_actual %>
                                            new Chart(document.getElementById("bar-chart2"), {
                                                type: 'bar',
                                                    data: {
                                                        labels: colNames,
                                                    datasets: [
                                                        {
                                                            label: "Number of times predicted",
                                                            backgroundColor: ["#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                                                            data: catTotal
                                                        },
                                                    ]
                                                },
                                                    options: {
                                                    barValueSpacing: 20,
                                                    legend: { display: false },
                                                    title: {
                                                        display: true,
                                                        text: 'Number of times category was predicted'
                                                    }
                                                }
                                            });
                                        </script>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                <section class="row">
                    <div class="col-12 mb-2">
                        <div class="card mb-8">
                            <div class="card mb-8">
                                <div class="card-block">
                                    <h3 class="card-title">Logistic Regression</h3>
                                    <h6 class="card-subtitle mb-2 text-muted">Categories Predicted</h6>

                                    <div class="canvas-wrapper">
                                        <%--<canvas class="chart" id="bar-chart" height="200" width="600"></canvas>--%>
                                        <canvas class="chart" id="bar-chart2" height="200" width="600"></canvas>
                                        <script type="text/javascript">
                                            
                                            var colNames = <%= newCols %>
                                            var catTotal = <%= numPerCat_logreg %>
                                            var catActual = <%= numPerCat_actual %>
                                            new Chart(document.getElementById("bar-chart2"), {
                                                type: 'bar',
                                                    data: {
                                                        labels: colNames,
                                                    datasets: [
                                                        {
                                                            label: "Number of times predicted",
                                                            backgroundColor: ["#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                                                            data: catTotal
                                                        },
                                                    ]
                                                },
                                                    options: {
                                                    barValueSpacing: 20,
                                                    legend: { display: false },
                                                    title: {
                                                        display: true,
                                                        text: 'Number of times category was predicted'
                                                    }
                                                }
                                            });
                                        </script>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </section>
    </main>

    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
    <script src="dist/js/bootstrap.min.js"></script>

    <script src="js/chart.min.js"></script>
    <script src="js/chart-data.js"></script>
    <script src="js/easypiechart.js"></script>
    <script src="js/easypiechart-data.js"></script>
    <script src="js/bootstrap-datepicker.js"></script>
    <script src="js/custom.js"></script>


    <script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js" integrity="sha384-DztdAPBWPRXSA/3eYEEUWrWCy7G5KFbe8fFjk5JAIxUYHKkDx6Qin1DkWx51bBrb" crossorigin="anonymous"></script>

</asp:Content>
