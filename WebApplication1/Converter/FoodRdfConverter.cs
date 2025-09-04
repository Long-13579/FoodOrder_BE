using Domain;
using System.Text;
using VDS.RDF;
using VDS.RDF.Writing;

namespace WebApplication1.Converter;

public static class FoodRdfConverter
{
    public static string ConvertFoodToRdf(IEnumerable<Food> foods, string format = "turtle")
    {
        var graph = new Graph();

        // Define namespace
        var ns = "http://example.org/food#";
        graph.NamespaceMap.AddNamespace("food", new Uri(ns));

        // Add triples for each food
        foreach (var food in foods)
        {
            var foodUri = graph.CreateUriNode(UriFactory.Create($"{ns}food{food.Id}"));

            graph.Assert(foodUri, graph.CreateUriNode("rdf:type"), graph.CreateUriNode("food:Food"));
            graph.Assert(foodUri, graph.CreateUriNode("food:name"), graph.CreateLiteralNode(food.Name));
            graph.Assert(foodUri, graph.CreateUriNode("food:description"), graph.CreateLiteralNode(food.Description));
            graph.Assert(foodUri, graph.CreateUriNode("food:category"), graph.CreateLiteralNode(food.Category.ToString()));
            graph.Assert(foodUri, graph.CreateUriNode("food:price"), graph.CreateLiteralNode(food.Price.ToString()));
            graph.Assert(foodUri, graph.CreateUriNode("food:imageUrl"), graph.CreateLiteralNode(food.ImageUrl));
        }

        using var sw = new Utf8StringWriter();

        if (format.ToLower() == "rdfxml")
        {
            var writer = new RdfXmlWriter();
            writer.Save(graph, sw);
        }
        else if (format.ToLower() == "jsonld")
        {
            var writer = new JsonLdWriter();

            var store = new TripleStore();
            store.Add(graph);
            writer.Save(store, sw);
        }
        else
        {
            var writer = new CompressingTurtleWriter();
            writer.Save(graph, sw);
        }

        return sw.ToString();
    }
}

public class Utf8StringWriter : System.IO.StringWriter
{
    public override Encoding Encoding => Encoding.UTF8;
}

