<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultsBig.aspx.cs" Inherits="HonoursProject.ResultsBig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Icons -->
    <link href="css/fontawesome-all.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="css/style.css" rel="stylesheet">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.3/Chart.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <section class="row">
                <div class="col-12 mb-2">
                    <h1 class="card-title" style="text-align: center;background-color: #7376df;">kNN vs Logistic Regression Reports Page</h1>
                </div>
            </section>
            <%--<main class="col-xs-12 col-sm-8 col-lg-9 col-xl-10 pt-3 pl-4 ml-auto">--%>
            <section class="row">
                <div class="col-sm-12">
                    <section class="row">
                        <div class="col-12 mb-2">
                            <div class="card mb-8">
                                <div class="card mb-8">
                                    <div class="card-block">
                                        <h3 class="card-title">k-Nearest Neighbors</h3>
                                        <h6 class="card-subtitle mb-2 text-muted">Categories Predicted Between 2003-01-01 and 2015-05-10</h6>

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
                                                                    label: "Predicted on the test dataset",
                                                                    backgroundColor: ["#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252"],
                                                                    data: catTotal
                                                                }
                                                            ]
                                                        },
                                                        options: {
                                                            legend: { display: false },
                                                            title: {
                                                                display: true,
                                                                text: 'Number of times categories were predicted between 2003-01-01 and 2015-05-10'
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
                                        <h6 class="card-subtitle mb-2 text-muted">Categories Predicted Between 2003-01-01 and 2015-05-10</h6>

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
                                                                    label: "Predicted on the test dataset",
                                                                    backgroundColor: ["#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252"],
                                                                    data: catTotal
                                                                },
                                                            ]
                                                        },
                                                        options: {
                                                            barValueSpacing: 20,
                                                            legend: { display: false },
                                                            title: {
                                                                display: true,
                                                                text: 'Number of times categories were predicted between 2003-01-01 and 2015-05-10'
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
                                        <h3 class="card-title">Actual Results</h3>
                                        <h6 class="card-subtitle mb-2 text-muted">Categories That Actually Occurred in The Testing Dataset Between 2003-01-01 and 2015-05-10</h6>

                                        <div class="canvas-wrapper">
                                            <%--<canvas class="chart" id="bar-chart" height="200" width="600"></canvas>--%>
                                            <canvas class="chart" id="bar-chart3" height="200" width="600"></canvas>
                                            <script type="text/javascript">

                                                var colNames = <%= newCols %>
                                            var catActual = <%= numPerCat_actual %>
                                                    new Chart(document.getElementById("bar-chart3"), {
                                                        type: 'bar',
                                                        data: {
                                                            labels: colNames,
                                                            datasets: [
                                                                {
                                                                    label: "Actually occurred on the test dataset",
                                                                    backgroundColor: ["#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252"],
                                                                    data: catActual
                                                                },
                                                            ]
                                                        },
                                                        options: {
                                                            barValueSpacing: 20,
                                                            legend: { display: false },
                                                            title: {
                                                                display: true,
                                                                text: 'Number of times categories actually occurred between 2003-01-01 and 2015-05-10 on the test dataset'
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
                        <div class="col-md-6 mb-3">
                            <div class="card mb-3 text-center ">
                                <div class="card-block">
                                    <h5 class="mt-2 mb-1">kNN Accuracy Based On Testing Dataset: 2003-01-01 and 2015-05-10</h5>
                                    <div id="canvas-holder" <%--style="width: 40%"--%>>
                                        <canvas id="doughnut-chart" width="800" height="450"></canvas>

                                        <script type="text/javascript">
                                            var accuracy = <%= knnCorrect_JS %>
                                                        var inAccurate = 100 - accuracy
                                            new Chart(document.getElementById("doughnut-chart"), {
                                                type: 'doughnut',
                                                data: {
                                                    labels: ["Accuracy", "Inaccuracy"],
                                                    datasets: [
                                                        {
                                                            backgroundColor: ["#69f0ae", "#ff5252"],
                                                            data: [accuracy, inAccurate]
                                                        }
                                                    ]
                                                }
                                            });

                                        </script>
                                        <p id="knnAccuracy" class="mb-1" runat="server">21%</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 mb-3">
                            <div class="card mb-3 text-center ">
                                <div class="card-block">

                                    <h5 class="mt-2 mb-1">Logic Regression Accuracy Based On Testing Dataset: 2003-01-01 and 2015-05-10</h5>
                                    <div id="canvas-holder2" <%--style="width: 40%"--%>>
                                        <canvas id="doughnut-chart2" width="800" height="450"></canvas>

                                        <script type="text/javascript">
                                            var accuracy = <%= logregCorrect_JS %>
                                                        var inAccurate = 100 - accuracy
                                            new Chart(document.getElementById("doughnut-chart2"), {
                                                type: 'doughnut',
                                                data: {
                                                    labels: ["Accuracy", "Inaccuracy"],
                                                    datasets: [
                                                        {
                                                            backgroundColor: ["#69f0ae", "#ff5252"],
                                                            data: [accuracy, inAccurate]
                                                        }
                                                    ]
                                                }
                                            });

                                        </script>
                                        <p id="logregAccuracy" class="mb-1" runat="server">21%</p>
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
                                        <h3 class="card-title">Actual Results</h3>
                                        <h6 class="card-subtitle mb-2 text-muted">Categories That Actually Occurred in The Training Dataset</h6>

                                        <div class="canvas-wrapper">
                                            <%--<canvas class="chart" id="bar-chart" height="200" width="600"></canvas>--%>
                                            <canvas class="chart" id="bar-chart-with-training3" height="200" width="600"></canvas>
                                            <script type="text/javascript">

                                                var colNames = <%= newCols %>
                                            var catActual = <%= numPerCat_actual_With_Training %>
                                                    new Chart(document.getElementById("bar-chart-with-training3"), {
                                                        type: 'bar',
                                                        data: {
                                                            labels: colNames,
                                                            datasets: [
                                                                {
                                                                    label: "Actually occurred on the training dataset",
                                                                    backgroundColor: ["#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252", "#7c4dff", "#ff5252"],
                                                                    data: catActual
                                                                },
                                                            ]
                                                        },
                                                        options: {
                                                            barValueSpacing: 20,
                                                            legend: { display: false },
                                                            title: {
                                                                display: true,
                                                                text: 'Number of times categories actually occurred between 2003-01-01 and 2015-05-10 on the training dataset'
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
                        <div class="col-md-6 mb-3">
                            <div class="card mb-3 text-center ">
                                <div class="card-block">
                                    <h5 class="mt-2 mb-1">kNN Prediction Accuracy Based On Training Data</h5>
                                    <div id="canvas-holder-with-training" <%--style="width: 40%"--%>>
                                        <canvas id="doughnut-chart-with-training" width="800" height="450"></canvas>

                                        <script type="text/javascript">
                                            var accuracy = <%= knnCorrect_JS_With_Training %>
                                                        var inAccurate = 100 - accuracy
                                            new Chart(document.getElementById("doughnut-chart-with-training"), {
                                                type: 'doughnut',
                                                data: {
                                                    labels: ["Accuracy", "Inaccuracy"],
                                                    datasets: [
                                                        {
                                                            backgroundColor: ["#69f0ae", "#ff5252"],
                                                            data: [accuracy, inAccurate]
                                                        }
                                                    ]
                                                }
                                            });

                                        </script>
                                        <p id="knnAccuracy2" class="mb-1" runat="server">21%</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 mb-3">
                            <div class="card mb-3 text-center ">
                                <div class="card-block">

                                    <h5 class="mt-2 mb-1">Logic Regression Prediction Accuracy Based On Training Data</h5>
                                    <div id="canvas-holder-with-training2" <%--style="width: 40%"--%>>
                                        <canvas id="doughnut-chart-with-training2" width="800" height="450"></canvas>

                                        <script type="text/javascript">
                                            var accuracy = <%= logregCorrect_JS_With_Training %>
                                                        var inAccurate = 100 - accuracy
                                            new Chart(document.getElementById("doughnut-chart-with-training2"), {
                                                type: 'doughnut',
                                                data: {
                                                    labels: ["Accuracy", "Inaccuracy"],
                                                    datasets: [
                                                        {
                                                            backgroundColor: ["#69f0ae", "#ff5252"],
                                                            data: [accuracy, inAccurate]
                                                        }
                                                    ]
                                                }
                                            });

                                        </script>
                                        <p id="logregAccuracy2" class="mb-1" runat="server">21%</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                    <section class="row">
                        <div class="col-12 mb-2">
                            <h3 class="mt-4 mb-4">Metrics</h3>
                            <div id="metric1" class="alert bg-primary" role="alert" runat="server"><i class="fas fa-stroopwafel"></i>Training Data Records Processed: </div>
                            <div id="metric2" class="alert bg-primary" role="alert" runat="server"><i class="fas fa-stroopwafel"></i>Testing Data Records Processed: </div>
                        </div>
                    </section>
                </div>
            </section>
        </div>
        <%--</main>--%>
    </form>

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
</body>
</html>
