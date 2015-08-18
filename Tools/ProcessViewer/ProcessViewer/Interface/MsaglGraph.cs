using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using ProcessViewer.Library;
using ProcessViewer.Library.Common;
using ProcessViewer.Library.Data;
using Microsoft.Msagl;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.Splines;
using MSAGL = Microsoft.Msagl;

namespace ProcessViewer.Interface
{
    public static class MsaglGraph
    {

        public static void SomeClass()
        {
            var graph = new MSAGL.Drawing.Graph("");
            graph.AddEdge("A", "B");
            graph.AddEdge("A", "B");
            graph.FindNode("A").Attr.FillColor = MSAGL.Drawing.Color.BlanchedAlmond;
            graph.FindNode("B").Attr.FillColor = MSAGL.Drawing.Color.BurlyWood;
            var renderer = new MSAGL.GraphViewerGdi.GraphRenderer(graph);
            renderer.CalculateLayout();
            const int width = 50;
            int height = (int)(graph.Height * (width / graph.Width));
            const PixelFormat pixfmt = System.Drawing.Imaging.PixelFormat.Format32bppPArgb;
            using (var bitmap = new System.Drawing.Bitmap(width, height, pixfmt))
            {
                using (var gfx = System.Drawing.Graphics.FromImage(bitmap))
                {
                    gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    gfx.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    var rect = new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height);
                    renderer.Render(gfx, rect);
                    bitmap.Save("test.png");

                }

            }
           
        }

        public static Graph GenerateGraph(DrawItem drawItem, ref Palette palette, string savePath = null)
        {
            var msg = String.Empty;
            return GenerateGraph(drawItem, ref palette, ref msg, savePath);
        }

     
        public static Graph GenerateGraph(DrawItem drawItem, ref Palette palette, ref string message, string savePath = null)
        {
            try
            {
                var graph = new Graph(GetTitle(drawItem));

                switch (drawItem.ViewLevel)
                {
                    case ViewLevel.Activity:
                        DrawActivity(ref graph, drawItem, ref palette);
                        break;
                    case ViewLevel.SubProcess:
                        DrawTask(ref graph, drawItem, ref palette);
                        break;
                }


                //Saves the graph to file if a file name is specified
                if (!string.IsNullOrEmpty(savePath))
                {
                    try
                    {
                        var renderer = new Microsoft.Msagl.GraphViewerGdi.GraphRenderer(graph);

                        renderer.CalculateLayout();
                        
                        var img = new System.Drawing.Bitmap((int) graph.Width, (int) graph.Height, PixelFormat.Format32bppPArgb);
                        renderer.Render(img);

                        var encoderParameters = new EncoderParameters(1);
                        encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
                        img.Save(savePath, ImageCodecInfo.GetImageDecoders().Where(e => e.FormatID == ImageFormat.Png.Guid).First(), encoderParameters);
                    }
                    catch (Exception ex)
                    {
                        message = ex.Message;
                        return null;
                    }
                }

                return graph;

            } catch (Exception ex)
            {
                message = ex.Message;
                return null;
            }
         
        }

        private static void DrawTask(ref Graph graph, DrawItem drawItem, ref Palette palette)
        {
            foreach (var node in Nodes.GetStructureNodes(drawItem.Version, drawItem.ConnectionString, drawItem.ViewLevel, drawItem.Process, (drawItem.Options & Options.Instance) == Options.Instance))
            {

                

                ShapeType shape;
                if (node.ID == 0)
                {
                    shape = ShapeType.Finish;
                    node.Title = "Finish";
                }
                else if (node.Startable)
                {
                    shape = ShapeType.StartableTask;
                }
                else if (node.Decision)
                {
                    shape = ShapeType.DecisionTask;
                }
                else
                {
                    shape = ShapeType.NormalTask;
                }

                AddNodeToGraph(ref graph, drawItem, ref palette, node, shape);
            }

            foreach (var connector in Connectors.GetStructureConnectors(drawItem.Version, drawItem.ConnectionString, drawItem.ViewLevel, drawItem.Process))
            {
                graph.AddEdge(connector.FromID.ToString(), connector.Title, connector.ToID.ToString());
            }
        }

        private static void DrawActivity(ref Graph graph, DrawItem drawItem, ref Palette palette)
        {
            foreach (var node in Nodes.GetStructureNodes(drawItem.Version, drawItem.ConnectionString, drawItem.ViewLevel, drawItem.Process, (drawItem.Options & Options.Instance) == Options.Instance))
            {
                ShapeType shape;
                if (node.Startable)
                    shape = ShapeType.StartPage;
                else if (node.ID == 0)
                    shape = ShapeType.Finish;
                else switch (node.ActivityType)
                    {
                        case "Business Rule":
                            shape = ShapeType.Rule;
                            break;
                        case "Trigger":
                            shape = ShapeType.Trigger;
                            break;
                        case "Page":
                            shape = ShapeType.Page;
                            break;
                        case "Event":
                            shape = ShapeType.Event;
                            break;
                        case "Parked":
                            shape = ShapeType.Page;
                            break;
                        default:
                            shape = ShapeType.Page;
                            break;
                    }

                AddNodeToGraph(ref graph, drawItem, ref palette, node, shape);
            }

            foreach (var connector in Connectors.GetStructureConnectors(drawItem.Version, drawItem.ConnectionString, drawItem.ViewLevel, drawItem.Process))
            {
                var edge = graph.AddEdge(connector.FromID.ToString(), connector.Title, connector.ToID.ToString());

                if (connector.FlowInd != 0)
                {
                    switch (connector.FlowInd)
                    {
                        case 1: //Optimal Flow
                            edge.Attr.Color = Color.Green;
                            break;
                        case 2: //Negative Flow
                            edge.Attr.Color = Color.Red;
                            break;
                    }
                }
            }
        }

        private static void AddNodeToGraph(ref Graph graph, DrawItem drawItem, ref Palette palette, Library.Node snope, ShapeType shapeType)
        {

            if (snope.ID == 0)
                snope.Title = "Finish";

            if (Options.Id == (drawItem.Options & Options.Id) && snope.ID != 0)
            {
                snope.Title = snope.ID + ": " + snope.Title;
            }

            if ((drawItem.Options & Options.Instance) == Options.Instance && snope.ID != 0)
                snope.Title = String.Format(@"{0} {2}(Instances: {1})", snope.Title, snope.Instances, '\n');

            var node = graph.AddNode(snope.ID.ToString());
            node.Attr.AddStyle(Style.Bold);

            node.Label.Text = "\n" + snope.Title + "\n\n";

            
            FormatShapes(node, shapeType);

            if ((Options.Colour != (drawItem.Options & Options.Colour)) || snope.GroupID == 0) return;
            var colour = palette.AddColor(snope.GroupID ?? 0, snope.GroupTitle);
            var groupColour = new Color(colour.Color.R, colour.Color.G, colour.Color.B);
            node.Attr.FillColor = groupColour;
        }

        private static void FormatShapes(Microsoft.Msagl.Drawing.Node node, ShapeType shapeType)
        {
            switch (shapeType)
            {
                case ShapeType.StartPage:
                    node.Attr.Shape = Shape.Ellipse;
                    node.Attr.LabelMargin = -13;
                    break;
                case ShapeType.StartableTask:
                    node.Attr.Shape = Shape.Ellipse;
                    node.Attr.LabelMargin = -13;
                    break;
                case ShapeType.DecisionTask:
                    node.Attr.Shape = Shape.Diamond;
                    node.Attr.LabelMargin = -5;
                    break;
                case ShapeType.Rule:
                    node.Attr.Shape = Shape.Diamond;
                    node.Attr.LabelMargin = -5;
                    node.Attr.XRad = 5;
                    node.Attr.YRad = 20;
                    break;
                case ShapeType.Page:
                    node.Attr.Shape = Shape.Box;
                    node.Attr.LabelMargin = 10;
                    break;
                case ShapeType.NormalTask:
                    node.Attr.Shape = Shape.Box;
                    node.Attr.LabelMargin = 10;
                    break;
                case ShapeType.Event:
                    node.Attr.Shape = Shape.Octagon;
                    break;
                case ShapeType.Trigger:
                    node.Attr.Shape = Shape.Octagon;
                    break;
                case ShapeType.Finish:
                    node.Attr.Shape = Shape.Circle;
                    break;
                default:
                    node.Attr.Shape = Shape.Box;
                    node.Attr.LabelMargin = 10;
                    break;
            }

            node.Attr.Padding = 500;
        }

        private static string GetTitle(DrawItem drawItem)
        {
            return String.Format(@"ProcessViewer {0} - {1} flow", drawItem.Version, drawItem.ViewLevel);
        }
    }
}
