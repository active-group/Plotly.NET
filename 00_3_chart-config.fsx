(**
// can't yet format YamlFrontmatter (["title: Chart config"; "category: General"; "categoryindex: 1"; "index: 4"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Chart config

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=00_3_chart-config.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/00_3_chart-config.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/00_3_chart-config.ipynb)

`Config` is an object that configures high level properties of the chart like making all chart elements editable or the tool bar on top

## Image button options

Options for chart export can be set in the config at `ToImageButtonOptions`:

  - Three file formats for chart exports are supported (SVG, PNG, JPEG) and can be set as `Format`. 

  - A predefined name for the downloaded chart can be set at `Filename`. 

  - The dimensions of the downloaded chart are set at `Width` and `Height`.

  - The `Scale` defines the size of the exported svg.

The settings do not apply for the html document containing the chart but for charts that are exported by clicking the camera icon in the menu bar.


*)
open Plotly.NET
open Plotly.NET.ConfigObjects

let svgConfig =
    Config.init (
        ToImageButtonOptions = ToImageButtonOptions.init(
            Format = StyleParam.ImageFormat.JPEG,
            Filename = "mySvgChart",
            Width = 900.,
            Height = 600.,
            Scale = 10.
        )
    )

let svgButtonChart = 
    Chart.Point([(1.,2.)])
    |> Chart.withConfig svgConfig(* output: 
<div id="b8450a43-b5e7-4ed2-9457-062ed9984ed4" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_b8450a43b5e74ed29457062ed9984ed4 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0],"y":[2.0],"marker":{}}];
            var layout = {};
            var config = {"toImageButtonOptions":{"format":"jpeg","filename":"mySvgChart","width":900.0,"height":600.0,"scale":10.0}};
            Plotly.newPlot('b8450a43-b5e7-4ed2-9457-062ed9984ed4', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_b8450a43b5e74ed29457062ed9984ed4();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_b8450a43b5e74ed29457062ed9984ed4();
            }
</script>
*)
(**
## Static plots

To create a static plot that has no hoverable elements, use `StaticPlot=true` on the Config:


*)
let staticConfig = Config.init(StaticPlot=true)

let staticPlot =
    Chart.Point([(1.,2.)])
    |> Chart.withConfig staticConfig(* output: 
<div id="b0c66f65-b40e-44c3-bd2f-9388822eaba3" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_b0c66f65b40e44c3bd2f9388822eaba3 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0],"y":[2.0],"marker":{}}];
            var layout = {};
            var config = {"staticPlot":true};
            Plotly.newPlot('b0c66f65-b40e-44c3-bd2f-9388822eaba3', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_b0c66f65b40e44c3bd2f9388822eaba3();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_b0c66f65b40e44c3bd2f9388822eaba3();
            }
</script>
*)
(**
## Editable charts

You can define fields that can be edited on the chart by setting `Editable = true` on the config, optionally explicitly setting the editable parts via `EditableAnnotations`


*)
let editableConfig = 
    Config.init(
        Editable = true,
        EditableAnnotations = [
            StyleParam.AnnotationEditOptions.LegendPosition
            StyleParam.AnnotationEditOptions.AxisTitleText
            StyleParam.AnnotationEditOptions.LegendText
        ]
    )

let editablePlot =
    Chart.Point([(1.,2.)])
    |> Chart.withConfig editableConfig(* output: 
<div id="c0bb89f4-d866-490a-95eb-f8dfe6d03ba3" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_c0bb89f4d866490a95ebf8dfe6d03ba3 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0],"y":[2.0],"marker":{}}];
            var layout = {};
            var config = {"editable":true,"edits":{"legendPosition":true,"axisTitleText":true,"legendText":true}};
            Plotly.newPlot('c0bb89f4-d866-490a-95eb-f8dfe6d03ba3', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_c0bb89f4d866490a95ebf8dfe6d03ba3();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_c0bb89f4d866490a95ebf8dfe6d03ba3();
            }
</script>
*)
(**
## Responsive charts

To create a chart that is reponsive to its container size, use `Responsive=true` on the Config:

(try resizing the window)

*)
let responsiveConfig = Config.init(Responsive=true)

let responsivePlot =
    Chart.Point([(1.,2.)])
    |> Chart.withConfig responsiveConfig(* output: 
<div id="1137d2db-f29e-42f8-bd29-7fa561250cdc" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_1137d2dbf29e42f8bd297fa561250cdc = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0],"y":[2.0],"marker":{}}];
            var layout = {};
            var config = {"responsive":true};
            Plotly.newPlot('1137d2db-f29e-42f8-bd29-7fa561250cdc', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_1137d2dbf29e42f8bd297fa561250cdc();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_1137d2dbf29e42f8bd297fa561250cdc();
            }
</script>
*)

