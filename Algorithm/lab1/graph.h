#ifndef GRAPH_H
#define GRAPH_H
#include <vector>
#include "edge.h"

class Graph
{

public:

    static Graph & instance(size_t verticles, size_t edges);
    std::vector <Edge> edgesArrey;


    size_t verticles() const;
    size_t edges() const;


private:
    Graph(size_t verticles, size_t edges);
    Graph(const Graph & another) = delete;
    Graph &operator = (Graph const & another) = delete ;
    size_t mVerticles;
    size_t mEdges;

};

#endif // GRAPH_H
