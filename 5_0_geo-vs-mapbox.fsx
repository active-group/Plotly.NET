(**
// can't yet format YamlFrontmatter (["title: Geo vs. Mapbox"; "category: Geo map charts"; "categoryindex: 6"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Mapbox Maps vs Geo Maps

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=5_0_geo-vs-mapbox.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/5_0_geo-vs-mapbox.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/5_0_geo-vs-mapbox.ipynb)

*Summary:* This introduction shows the differences between Geo and Mapbox based geographical charts.

Plotly and therefore Plotly.NET supports two different kinds of maps:

- **Mapbox maps** are tile-based maps. If your figure is created with a `Chart.*Mapbox` function or otherwise contains one or more traces of type `scattermapbox`, 
    `choroplethmapbox` or `densitymapbox`, the layout.mapbox object in your figure contains configuration information for the map itself.
    
- **Geo maps** are outline-based maps. If your figure is created with a `Chart.ScatterGeo, `Chart.PointGeo`, `Chart.LineGeo` or `Chart.Choropleth` function or 
    otherwise contains one or more traces of type `scattergeo` or `choropleth`, the layout.geo object in your figure contains configuration information for the map itself.
    
_This page documents Geo outline-based maps, and the [Mapbox Layers documentation](https://plotly.net//6_0_geo-vs-mapbox.html) describes how to configure Mapbox tile-based maps._

## Physical Base Maps

Plotly Geo maps have a built-in base map layer composed of "physical" and "cultural" (i.e. administrative border) data from the Natural Earth Dataset. 
Various lines and area fills can be shown or hidden, and their color and line-widths specified. 
In the default plotly template, a map frame and physical features such as a coastal outline and filled land areas are shown, at a small-scale 1:110m resolution:

*)
open Plotly.NET

let baseMapOnly = 
    Chart.PointGeo([]) // deliberately empty chart to show the base map only
    |> Chart.withMarginSize(0,0,0,0)(* output: 
<div id="58a13b0c-4c3e-4fc4-adc4-c2f48b39b0aa" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_58a13b0c4c3e4fc4adc4c2f48b39b0aa = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scattergeo","mode":"markers","lon":[],"lat":[],"marker":{}}];
            var layout = {"margin":{"l":0,"r":0,"t":0,"b":0}};
            var config = {};
            Plotly.newPlot('58a13b0c-4c3e-4fc4-adc4-c2f48b39b0aa', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_58a13b0c4c3e4fc4adc4c2f48b39b0aa();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_58a13b0c4c3e4fc4adc4c2f48b39b0aa();
            }
</script>
*)
(**
To control the features of the map, a `Geo` object is used that can be associtaed with a given chart using the `Chart.WithGeo` function.
Here is a map with all physical features enabled and styled, at a larger-scale 1:50m resolution:
*)
let myGeo =
    Geo.init(
        Resolution=StyleParam.GeoResolution.R50,
        ShowCoastLines=true, 
        CoastLineColor="RebeccaPurple",
        ShowLand=true, 
        LandColor="LightGreen",
        ShowOcean=true, 
        OceanColor="LightBlue",
        ShowLakes=true, 
        LakeColor="Blue",
        ShowRivers=true, 
        RiverColor="Blue"
    )

let moreFeaturesBaseMap =
    Chart.PointGeo([])
    |> Chart.withMap myGeo
    |> Chart.withMarginSize(0,0,0,0)(* output: 
<div id="e4e1b548-2d25-4072-ad4e-9f844f714d1e" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_e4e1b5482d254072ad4e9f844f714d1e = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scattergeo","mode":"markers","lon":[],"lat":[],"marker":{}}];
            var layout = {"geo":{"resolution":"50","showcoastline":true,"coastlinecolor":"RebeccaPurple","showland":true,"landcolor":"LightGreen","showocean":true,"oceancolor":"LightBlue","showlakes":true,"lakecolor":"Blue","showrivers":true,"rivercolor":"Blue"},"margin":{"l":0,"r":0,"t":0,"b":0}};
            var config = {};
            Plotly.newPlot('e4e1b548-2d25-4072-ad4e-9f844f714d1e', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_e4e1b5482d254072ad4e9f844f714d1e();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_e4e1b5482d254072ad4e9f844f714d1e();
            }
</script>
*)
(**
## Cultural Base Maps

In addition to physical base map features, a "cultural" base map is included which is composed of country borders and selected sub-country borders such as states.

_Note and disclaimer: cultural features are by definition subject to change, debate and dispute. Plotly includes data from Natural Earth "as-is" and defers to the Natural Earth policy regarding disputed borders which read:_

> Natural Earth Vector draws boundaries of countries according to defacto status. We show who actually controls the situation on the ground.

Here is a map with only cultural features enabled and styled, at a 1:50m resolution, which includes only country boundaries. See below for country sub-unit cultural base map features:
*)
let countryGeo =
    Geo.init(
        Visible=false, 
        Resolution=StyleParam.GeoResolution.R50,
        ShowCountries=true, 
        CountryColor="RebeccaPurple"
    )


let countryBaseMap =
    Chart.PointGeo([])
    |> Chart.withMap countryGeo
    |> Chart.withMarginSize(0,0,0,0)(* output: 
<div id="1e9b4a6a-a359-4a75-9e02-7fe52de44fb6" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_1e9b4a6aa3594a759e027fe52de44fb6 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scattergeo","mode":"markers","lon":[],"lat":[],"marker":{}}];
            var layout = {"geo":{"resolution":"50","visible":false,"showcountries":true,"countrycolor":"RebeccaPurple"},"margin":{"l":0,"r":0,"t":0,"b":0}};
            var config = {};
            Plotly.newPlot('1e9b4a6a-a359-4a75-9e02-7fe52de44fb6', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_1e9b4a6aa3594a759e027fe52de44fb6();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_1e9b4a6aa3594a759e027fe52de44fb6();
            }
</script>
*)

