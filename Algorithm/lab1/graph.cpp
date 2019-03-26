#include "graph.h"



Graph::Graph(size_t verticles, size_t edges)
    : mVerticles(verticles), mEdges(edges)
{
        for (size_t i = 0 ; i < mEdges; ++i)
        {
            edgesArrey.push_back(Edge());
        }
    }

Graph &Graph::instance(size_t verticles, size_t edges)
{
    static Graph graph(verticles,edges);
    return graph;
}

std::vector<Edge> Graph::getEdgesArrey() const
{
    return edgesArrey;
}

void Graph::setEdgesArrey(const std::vector<Edge> &value)
{
    edgesArrey = value;
}

size_t Graph::verticles() const
{
    return mVerticles;
}

size_t Graph::edges() const
{
    return mEdges;
}
