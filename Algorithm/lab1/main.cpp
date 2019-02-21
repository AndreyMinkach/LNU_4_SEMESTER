#include "edge.h"
#include "graph.h"

void add()
{
    static int i(1);
    i++;
    std::cout<<i<<std::endl;
}

int main()
{
    Graph &graph = Graph::instance(10,20);
}
