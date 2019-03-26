#include "functions.h"
#include <vector>
#include "smallgraph.h"
#include <algorithm>

int function::indexOf(std::vector < int > temp, int obj)
{
    int pos = std::distance(temp.begin(),std::find(temp.begin(), temp.end(), obj));
    if(pos < temp.size()){
        return pos;
    }

    return -1;
}

size_t function::find(std::vector<SubGraph> &subsets, const size_t i)
{
    if (subsets[i].parent() != i)
        subsets[i].setParent(find(subsets, subsets[i].parent()));

    return subsets[i].parent();
}

struct less_than_key
{
     bool operator() (const Edge& struct1, const Edge& struct2)
    {
        return (struct1.weight() < struct2.weight());
    }
};



void function::PrimMST(Graph *graph)
{
    std::vector <Edge> tree;
    std::vector <Edge> nonUsedEdges(graph->edgesArrey);
    std::vector <int> usedVerts;
    std::vector <int> nonUsedVerts;
    for (size_t i = 0; i < graph->verticles(); i++) {
        nonUsedVerts.push_back(i);
    }
    usedVerts.push_back(0);
    nonUsedVerts.erase(nonUsedVerts.begin());
    while(nonUsedVerts.size() != 0)
    {
        int minEdge = - 1;

        for (int i = 0; i < nonUsedEdges.size(); i++) {
            if((indexOf(usedVerts,nonUsedEdges[i].firstPoint()) != -1) && (indexOf(nonUsedVerts, nonUsedEdges[i].secondPoint()) != -1) ||
               (indexOf(usedVerts,nonUsedEdges[i].secondPoint()) != -1) && (indexOf(nonUsedVerts, nonUsedEdges[i].firstPoint()) != -1))
            {
                if(minEdge != -1)
                {
                    if(nonUsedEdges[i].weight() < nonUsedEdges[minEdge].weight())
                        minEdge = i;
                }
                else {
                    minEdge = i;
                }
            }
            if (indexOf(usedVerts, nonUsedEdges[minEdge].firstPoint()) != -1)
                {
                    usedVerts.push_back(nonUsedEdges[minEdge].secondPoint());
                    nonUsedVerts.erase(std::remove(nonUsedVerts.begin(),nonUsedVerts.end(),nonUsedEdges[minEdge].secondPoint()),nonUsedVerts.end());
                }
                else
                {
                    usedVerts.push_back(nonUsedEdges[minEdge].firstPoint());
                    nonUsedVerts.erase(std::remove(nonUsedVerts.begin(),nonUsedVerts.end(),nonUsedEdges[minEdge].firstPoint()),nonUsedVerts.end());
                }
                tree.push_back(nonUsedEdges[minEdge]);
                std::cout<<nonUsedEdges[minEdge].firstPoint()<<" "<<nonUsedEdges[minEdge].secondPoint()<<" weight "<<nonUsedEdges[minEdge].weight()<<std::endl;
                nonUsedEdges.erase(nonUsedEdges.begin() + minEdge);
        }


    }
}
