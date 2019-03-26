#include "edge.h"
#include "graph.h"
#include "smallgraph.h"
#include "functions.h"
#include <iostream>

using namespace std;

int main()
{
    std::cout<<"input v and e"<<std::endl;
    size_t V ;
    size_t E ;
    std::cin>>V>>E;
    Graph *graph = new Graph(V,E);
    for(size_t i = 0; i != E ; ++i)
    {
        std::cout<<"input first, second, weight"<<std::endl;
        size_t f,s,w;
        std::cin>>f>>s>>w;
        Edge e(f--,s--,w);
        graph->edgesArrey.push_back(e);
    }
   function::PrimMST(graph);
    return 0;

}
