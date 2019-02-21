#include "graph.h"



Graph::Graph(size_t verticles, size_t edges)
    : mVerticles(verticles), mEdges(edges)
{}

Graph &Graph::instance(size_t verticles, size_t edges)
{
    static Graph graph(verticles,edges);
    return graph;
}

size_t Graph::verticles() const
{
    return mVerticles;
}

size_t Graph::edges() const
{
    return mEdges;
}
