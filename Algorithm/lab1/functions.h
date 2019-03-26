#ifndef FUNCTIONS_H
#define FUNCTIONS_H


#include "smallgraph.h"
#include "edge.h"
#include "graph.h"

#include <vector>
#include <algorithm>
#include <iostream>

int myComp(const void *a, const void *b);

class function
{
public:
    static int indexOf(std::vector < int > temp, int obj);

    static size_t find(std::vector<SubGraph> &subsets,const size_t i);

    static void PrimMST(Graph *graph);
private:
    static bool checkOurVector(const std::vector<bool> &vector);



    function()=delete;
};

#endif // FUNCTIONS_H
