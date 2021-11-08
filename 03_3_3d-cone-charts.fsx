(**
// can't yet format YamlFrontmatter (["title: 3D Cone plots"; "category: 3D Charts"; "categoryindex: 4"; "index: 4"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# 3D Cone plots

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=03_3_3d-cone-charts.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/03_3_3d-cone-charts.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/03_3_3d-cone-charts.ipynb)

*Summary:* This example shows how to create 3D-Cone charts in F#.


*)
open System
open Plotly.NET 


let cone =
    Chart.Cone(
        x = [1; 1; 1],
        y = [1; 2; 3],
        z = [1; 1; 1],
        u = [1; 2; 3],
        v = [1; 1; 2],
        w = [4; 4; 1]
    )(* output: 
<div id="94cecc65-8ebc-44e2-a5e0-56c88073cec8" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_94cecc658ebc44e2a5e056c88073cec8 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"cone","x":[1,1,1],"y":[1,2,3],"z":[1,1,1],"u":[1,2,3],"v":[1,1,2],"w":[4,4,1]}];
            var layout = {};
            var config = {};
            Plotly.newPlot('94cecc65-8ebc-44e2-a5e0-56c88073cec8', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_94cecc658ebc44e2a5e056c88073cec8();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_94cecc658ebc44e2a5e056c88073cec8();
            }
</script>
*)

